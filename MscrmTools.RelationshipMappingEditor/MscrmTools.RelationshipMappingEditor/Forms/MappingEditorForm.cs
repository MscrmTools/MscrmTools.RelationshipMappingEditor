using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.RelationshipMappingEditor.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;

namespace MscrmTools.RelationshipMappingEditor.Forms
{
    public partial class MappingEditorForm : DockContent
    {
        private Entity currentEntityMap;
        private PluginControlBase parent;
        private Thread searchThread;
        private List<ListViewItem> sourceItems = new List<ListViewItem>();
        private List<ListViewItem> targetItems = new List<ListViewItem>();

        public MappingEditorForm()
        {
            InitializeComponent();
        }

        public List<Entity> Mappings { get; set; } = new List<Entity>();
        public IOrganizationService Service { get; set; }
        public EntityMetadata SourceTable { get; set; }
        public EntityMetadata TargetTable { get; set; }

        public void LoadMapping(PluginControlBase parent)
        {
            this.parent = parent;
            gbSourceColumns.Text = gbSourceColumns.Text.Split('(')[0] + $" ({SourceTable.DisplayName?.UserLocalizedLabel?.Label})";
            gbTargetColumns.Text = gbTargetColumns.Text.Split('(')[0] + $" ({TargetTable.DisplayName?.UserLocalizedLabel?.Label})";

            parent.WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading mapping...",
                Work = (bw, e) =>
                {
                    currentEntityMap = Service.RetrieveMultiple(new QueryExpression("entitymap")
                    {
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("sourceentityname", ConditionOperator.Equal, SourceTable.SchemaName.ToLower()),
                                new ConditionExpression("targetentityname", ConditionOperator.Equal, TargetTable.SchemaName.ToLower()),
                            }
                        }
                    }).Entities.FirstOrDefault();

                    Mappings = Service.RetrieveMultiple(new QueryExpression("attributemap")
                    {
                        ColumnSet = new ColumnSet(true),
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("entitymapid", ConditionOperator.Equal, currentEntityMap.Id),
                                new ConditionExpression("parentattributemapid", ConditionOperator.Null),
                            }
                        }
                    }).Entities.ToList();
                },
                PostWorkCallBack = e =>
                {
                    lvMapping.Items.Clear();
                    lvSourceColumns.Items.Clear();
                    lvTargetColumns.Items.Clear();

                    lvMapping.Items.AddRange(Mappings.Select(m => new ListViewItem
                    {
                        Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == m.GetAttributeValue<string>("sourceattributename"))?.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                        SubItems =
                        {
                            new ListViewItem.ListViewSubItem{Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == m.GetAttributeValue<string>("sourceattributename"))?.SchemaName },
                            new ListViewItem.ListViewSubItem{Text = TargetTable.Attributes.FirstOrDefault(a => a.LogicalName == m.GetAttributeValue<string>("targetattributename"))?.DisplayName?.UserLocalizedLabel?.Label ?? "N/A" },
                            new ListViewItem.ListViewSubItem{Text = TargetTable.Attributes.FirstOrDefault(a => a.LogicalName == m.GetAttributeValue<string>("targetattributename"))?.SchemaName },
                            new ListViewItem.ListViewSubItem{Text = TargetTable.Attributes.FirstOrDefault(a => a.LogicalName == m.GetAttributeValue<string>("targetattributename"))?.AttributeType.Value.ToString() },
                             new ListViewItem.ListViewSubItem{Text = m.GetAttributeValue<bool>("issystem").ToString() },
                            new ListViewItem.ListViewSubItem{Text = m.GetAttributeValue<bool>("ismanaged").ToString() }
                        },
                        Tag = m
                    }).ToArray());

                    lvMapping.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvMapping.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                    sourceItems = SourceTable.Attributes
                   .Where(a => a.AttributeOf == null)
                   .Select(a => new ListViewItem
                   {
                       Text = a.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                       SubItems =
                      {
                          new ListViewItem.ListViewSubItem{Text = a.SchemaName},
                          new ListViewItem.ListViewSubItem{Text = a.AttributeType.Value.ToString() + (a is StringAttributeMetadata samd ? (" (" + samd.MaxLength.ToString() + ")"):"")},
                      },
                       Tag = a
                   }).ToList();

                    DisplaySourceItems();

                    targetItems = TargetTable.Attributes
                     .Where(a => a.AttributeOf == null)
                     .Where(a => a.IsValidForUpdate.Value)
                     .Where(a => a.IsValidForCreate.Value)

                     .Select(a => new ListViewItem
                     {
                         Text = a.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                         SubItems =
                       {
                          new ListViewItem.ListViewSubItem{Text = a.SchemaName},
                          new ListViewItem.ListViewSubItem{Text = a.AttributeType.Value.ToString() + (a is StringAttributeMetadata samd ? (" (" + samd.MaxLength.ToString() + ")"):"")},
                       },
                         Tag = a
                     }).ToList();
                    lvTargetColumns.Items.AddRange(targetItems
                        .Where(i => Mappings.All(m => m.GetAttributeValue<string>("targetattributename") != ((AttributeMetadata)i.Tag).LogicalName))
                        .ToArray());
                    lvTargetColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvTargetColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            });
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (lvSourceColumns.SelectedItems.Count == 0
                || lvTargetColumns.SelectedItems.Count == 0) return;

            var sourceAttr = ((AttributeMetadata)lvSourceColumns.SelectedItems[0].Tag).LogicalName;
            var targetAttr = ((AttributeMetadata)lvTargetColumns.SelectedItems[0].Tag).LogicalName;

            parent.WorkAsync(new WorkAsyncInfo
            {
                Message = "Creating mapping...",
                Work = (bw, evt) =>
                {
                    var am = new Entity("attributemap");
                    am["entitymapid"] = currentEntityMap.ToEntityReference();
                    am["sourceattributename"] = sourceAttr;
                    am["targetattributename"] = targetAttr;

                    am.Id = Service.Create(am);
                    Mappings.Add(am);
                    evt.Result = am;
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, "Error while creating mapping: " + evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Entity am = (Entity)evt.Result;

                    lvMapping.Items.Add(new ListViewItem
                    {
                        Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == am.GetAttributeValue<string>("sourceattributename"))?.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                        SubItems =
                        {
                            new ListViewItem.ListViewSubItem{Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == am.GetAttributeValue<string>("sourceattributename"))?.SchemaName },
                            new ListViewItem.ListViewSubItem{Text = TargetTable.Attributes.FirstOrDefault(a => a.LogicalName == am.GetAttributeValue<string>("targetattributename"))?.DisplayName?.UserLocalizedLabel?.Label ?? "N/A" },
                            new ListViewItem.ListViewSubItem{Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == am.GetAttributeValue<string>("targetattributename"))?.SchemaName },
                            new ListViewItem.ListViewSubItem{Text = am.GetAttributeValue<bool>("issystem").ToString() },
                            new ListViewItem.ListViewSubItem{Text = am.GetAttributeValue<bool>("ismanaged").ToString() }
                        },
                        Tag = am
                    });
                    lvMapping.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvMapping.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    lvMapping.Sorting = SortOrder.Descending;
                    lvMapping.Sort();

                    lvTargetColumns.Items.Remove(lvTargetColumns.SelectedItems[0]);
                }
            });
        }

        private void btnAutoMap_Click(object sender, EventArgs e)
        {
            var attributes = lvSourceColumns.Items.Cast<ListViewItem>().Where(si => lvTargetColumns.Items.Cast<ListViewItem>().FirstOrDefault(ti =>
                ti.SubItems[1].Text.Equals(si.SubItems[1].Text, StringComparison.InvariantCultureIgnoreCase)
            ) != null).Select(i => i.SubItems[1].Text).OrderBy(i => i).ToList();

            if (!attributes.Any())
            {
                MessageBox.Show(this, "No columns have been found for auto mapping", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DialogResult.No == MessageBox.Show(this, "The following columns will be mapped:\n- " + string.Join("\n- ", attributes) + "\n\nDo you want continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            var errors = new Dictionary<string, string>();

            parent.WorkAsync(new WorkAsyncInfo
            {
                Message = "Applying auto mapping...",
                Work = (bw, evt) =>
                {
                    List<Entity> newAttributeMaps = new List<Entity>();
                    foreach (var attribute in attributes)
                    {
                        try
                        {
                            var am = new Entity("attributemap");
                            am["entitymapid"] = currentEntityMap.ToEntityReference();
                            am["sourceattributename"] = attribute.ToLower();
                            am["targetattributename"] = attribute.ToLower();

                            am.Id = Service.Create(am);
                            Mappings.Add(am);
                            newAttributeMaps.Add(am);
                        }
                        catch (Exception error)
                        {
                            errors.Add(attribute, error.Message);
                        }
                    }

                    evt.Result = newAttributeMaps;
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, "An error occured when creating mappings: " + evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newAms = (List<Entity>)evt.Result;

                    lvMapping.Items.AddRange(newAms.Select(na => new ListViewItem
                    {
                        Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == na.GetAttributeValue<string>("sourceattributename"))?.DisplayName?.UserLocalizedLabel?.Label ?? "N/A",
                        SubItems =
                        {
                            new ListViewItem.ListViewSubItem{Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == na.GetAttributeValue<string>("sourceattributename"))?.SchemaName },
                            new ListViewItem.ListViewSubItem{Text = TargetTable.Attributes.FirstOrDefault(a => a.LogicalName == na.GetAttributeValue<string>("targetattributename"))?.DisplayName?.UserLocalizedLabel?.Label ?? "N/A" },
                            new ListViewItem.ListViewSubItem{Text = SourceTable.Attributes.FirstOrDefault(a => a.LogicalName == na.GetAttributeValue<string>("targetattributename"))?.SchemaName },
                            new ListViewItem.ListViewSubItem{Text = na.GetAttributeValue<bool>("issystem").ToString() },
                            new ListViewItem.ListViewSubItem{Text = na.GetAttributeValue<bool>("ismanaged").ToString() }
                        },
                        Tag = na
                    }).ToArray());
                    lvMapping.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvMapping.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    lvMapping.Sorting = SortOrder.Descending;
                    lvMapping.Sort();

                    for (int i = lvTargetColumns.Items.Count - 1; i >= 0; i--)
                    {
                        if (newAms.Any(am => am.GetAttributeValue<string>("targetattributename").Equals(lvTargetColumns.Items[i].SubItems[1].Text, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            lvTargetColumns.Items.RemoveAt(i);
                        }
                    }

                    if (errors.Any())
                    {
                        MessageBox.Show(this, "Some errors occured:\n-  " + string.Join("\n- ", errors.Select(err => $"{err.Key}: {err.Value}")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
            });
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            var toDelete = new List<Entity>();
            foreach (ListViewItem item in lvMapping.SelectedItems)
            {
                if (((Entity)item.Tag).GetAttributeValue<bool>("issystem"))
                {
                    continue;
                }

                toDelete.Add((Entity)item.Tag);
            }

            parent.WorkAsync(new WorkAsyncInfo
            {
                Message = "Deleting mapping(s)...",
                Work = (bw, evt) =>
                {
                    foreach (var record in toDelete)
                    {
                        Service.Delete(record.LogicalName, record.Id);
                    }
                },
                PostWorkCallBack = evt =>
                {
                    foreach (var record in toDelete)
                    {
                        Mappings.Remove(record);
                        lvMapping.Items.Remove(lvMapping.Items.Cast<ListViewItem>().First(i => i.Tag == record));
                    }

                    lvSourceColumns_SelectedIndexChanged(lvSourceColumns, new System.EventArgs());
                }
            });
        }

        private void DisplaySourceItems()
        {
            Thread.Sleep(200);

            Invoke(new Action(() =>
            {
                lvSourceColumns.SelectedIndexChanged -= lvSourceColumns_SelectedIndexChanged;

                lvSourceColumns.Items.Clear();
                lvSourceColumns.Items.AddRange(sourceItems
                    .Where(i => txtSearchSource.Text.Length == 0
                    || i.SubItems[0].Text.IndexOf(txtSearchSource.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                    || i.SubItems[1].Text.IndexOf(txtSearchSource.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    .ToArray());

                lvSourceColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvSourceColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvSourceColumns.SelectedIndexChanged += lvSourceColumns_SelectedIndexChanged;
            }));
        }

        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var lv = (ListView)sender;
            lv.Sorting = lv.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lv.ListViewItemSorter = new ListViewItemComparer(e.Column, lv.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
            lv.Sort();
        }

        private void lvMapping_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = lvMapping.SelectedItems.Cast<ListViewItem>().All(i => ((Entity)i.Tag).GetAttributeValue<bool>("issystem") == false &&
            ((Entity)i.Tag).GetAttributeValue<bool>("ismanaged") == false
            );
        }

        private void lvSourceColumns_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lvTargetColumns.Items.Clear();
            if (lvSourceColumns.SelectedItems.Count == 0)
            {
                lvTargetColumns.Items.AddRange(targetItems
                       .Where(i => Mappings.All(m => m.GetAttributeValue<string>("targetattributename") != ((AttributeMetadata)i.Tag).LogicalName))
                       .ToArray());
                lvTargetColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvTargetColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                return;
            }

            var sourceMetadata = (AttributeMetadata)lvSourceColumns.SelectedItems[0].Tag;

            lvTargetColumns.Items.AddRange(targetItems
                       .Where(i => Mappings.All(m => m.GetAttributeValue<string>("targetattributename") != ((AttributeMetadata)i.Tag).LogicalName))
                       .Where(i => ((AttributeMetadata)i.Tag).AttributeType.Value == sourceMetadata.AttributeType.Value)
                       .Where(i => !(i.Tag is LookupAttributeMetadata) || i.Tag is LookupAttributeMetadata amd && amd.Targets.Contains((sourceMetadata as LookupAttributeMetadata)?.Targets[0] ?? ""))
                       .Where(i => !(i.Tag is PicklistAttributeMetadata) || i.Tag is PicklistAttributeMetadata omd && omd.OptionSet.Name == ((sourceMetadata as PicklistAttributeMetadata)?.OptionSet.Name ?? ""))
                       .Where(i => !(i.Tag is StringAttributeMetadata) || i.Tag is StringAttributeMetadata smd && smd.MaxLength >= ((sourceMetadata as StringAttributeMetadata)?.MaxLength ?? 0) && smd.Format == ((sourceMetadata as StringAttributeMetadata)?.Format))
                       .Where(i => !(i.Tag is IntegerAttributeMetadata) || i.Tag is IntegerAttributeMetadata smd && smd.Format == ((sourceMetadata as IntegerAttributeMetadata)?.Format))
                       .Where(i => !(i.Tag is MemoAttributeMetadata) || i.Tag is MemoAttributeMetadata smd && smd.Format == ((sourceMetadata as MemoAttributeMetadata)?.Format))
                       .ToArray());
            lvTargetColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvTargetColumns.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvTargetColumns_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSourceColumns.SelectedItems.Count > 0
                && lvTargetColumns.SelectedItems.Count > 0)
            {
                btnAdd_Click(this, new System.EventArgs());
            }
        }

        private void txtSearchSource_TextChanged(object sender, System.EventArgs e)
        {
            searchThread?.Abort();
            searchThread = new Thread(new ThreadStart(DisplaySourceItems));
            searchThread.Start();
        }
    }
}