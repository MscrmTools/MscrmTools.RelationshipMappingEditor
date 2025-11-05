using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.RelationshipMappingEditor.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MscrmTools.RelationshipMappingEditor.Forms
{
    public partial class TableSelectionControl : DockContent
    {
        private List<ListViewItem> items = new List<ListViewItem>();
        private List<EntityMetadata> tables = new List<EntityMetadata>();

        public TableSelectionControl()
        {
            InitializeComponent();
        }

        public event EventHandler<TableSelectionEventArgs> TableSelected;

        public EntityMetadata SelectedTable => lvTables.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag as EntityMetadata;
        public List<EntityMetadata> Tables => tables;

        public void Clear()
        {
            tables = new List<EntityMetadata>();
            items = new List<ListViewItem>();
            lvTables.Items.Clear();
        }

        public void LoadTables(IOrganizationService service, Guid? solutionId = null)
        {
            tables = MetadataHelper.RetrieveTables(service, solutionId ?? Guid.Empty);
        }

        public void ShowTables()
        {
            lvTables.Items.Clear();
            items = new List<ListViewItem>();
            foreach (var table in tables)
            {
                var item = new ListViewItem(table.DisplayName?.UserLocalizedLabel?.Label ?? table.SchemaName)
                {
                    Tag = table,
                };
                item.SubItems.Add(table.SchemaName);
                items.Add(item);
            }

            lvTables.SelectedIndexChanged -= lvTables_SelectedIndexChanged;
            lvTables.Items.AddRange(items.ToArray());
            lvTables.SelectedIndexChanged += lvTables_SelectedIndexChanged;
        }

        internal void LoadTargetTables(IOrganizationService service, string schemaName)
        {
            var query = new QueryExpression("entitymap")
            {
                ColumnSet = new ColumnSet("targetentityname"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("sourceentityname", ConditionOperator.Equal, schemaName.ToLower())
                    }
                }
            };

            var records = service.RetrieveMultiple(query).Entities;
            var targetTables = records.Select(e => e.GetAttributeValue<string>("targetentityname")).ToList();

            tables = MetadataHelper.RetrieveTables(service, targetTables);

            if (tables.Count == 0) throw new RelationshipNotFoundException();
        }

        private void lvTables_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvTables.Sorting = lvTables.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lvTables.ListViewItemSorter = new ListViewItemComparer(e.Column, lvTables.Sorting);
        }

        private void lvTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count > 0)
            {
                var item = lvTables.SelectedItems[0];
                var table = item.Tag as Microsoft.Xrm.Sdk.Metadata.EntityMetadata;
                TableSelected?.Invoke(this, new TableSelectionEventArgs { SelectedTable = table });
            }
        }

        private void txtSearchEntity_TextChanged(object sender, EventArgs e)
        {
            var entityName = txtSearchEntity.Text;
            if (string.IsNullOrWhiteSpace(entityName))
            {
                lvTables.BeginUpdate();
                lvTables.Items.Clear();
                lvTables.Items.AddRange(items.ToArray());
                lvTables.EndUpdate();
            }
            else
            {
                lvTables.BeginUpdate();
                lvTables.Items.Clear();
                var filteredItems = items
                    .Where(i => i.SubItems.Cast<ListViewItem.ListViewSubItem>().Any(si => si.Text.IndexOf(entityName, StringComparison.InvariantCultureIgnoreCase) >= 0))
                    .ToArray();
                lvTables.Items.AddRange(filteredItems);
                lvTables.EndUpdate();
            }
        }
    }
}