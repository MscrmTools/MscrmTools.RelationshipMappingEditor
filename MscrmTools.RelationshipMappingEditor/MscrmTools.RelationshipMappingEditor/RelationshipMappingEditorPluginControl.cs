using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using MscrmTools.RelationshipMappingEditor.AppCode;
using MscrmTools.RelationshipMappingEditor.Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.RelationshipMappingEditor
{
    public partial class RelationshipMappingEditorPluginControl : PluginControlBase, IGitHubPlugin, IHelpPlugin, IPayPalPlugin
    {
        private MappingEditorForm meForm;
        private Settings mySettings;
        private TableSelectionControl tsSourceForm;
        private TableSelectionControl tsTargetForm;

        public RelationshipMappingEditorPluginControl()
        {
            InitializeComponent();
            SetTheme();

            meForm = new MappingEditorForm();

            tsSourceForm = new TableSelectionControl();
            tsSourceForm.Text = "Parent table";
            tsSourceForm.TableSelected += TsForm_TableSelected;

            tsTargetForm = new TableSelectionControl();
            tsTargetForm.Text = "Child table";
            tsTargetForm.TableSelected += TsForm_TableSelected;

            tsSourceForm.Show(dpMain, DockState.DockLeft);
            tsTargetForm.Show(dpMain, DockState.DockLeft);
            tsSourceForm.Show(dpMain, DockState.DockLeft);
            meForm.Show(dpMain, DockState.Document);
        }

        public string DonationDescription => "Donation for Relationship Mapping Editor";
        public string EmailAccount => "tanguy92@hotmail.com";
        public string HelpUrl => "https://www.github.com/MscrmTools/MscrmTools.RelationshipMappingEditor";
        public string RepositoryName => "MscrmTools.RelationshipMappingEditor";

        public string UserName => "MscrmTools";

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            tsSourceForm.Clear();
            tsTargetForm.Clear();
            tsSourceForm.Show(dpMain, DockState.DockLeft);
        }

        private void LoadTables(bool fromSolution = true)
        {
            Guid solutionId = Guid.Empty;
            if (fromSolution)
            {
                using (var dialog = new SolutionPicker(Service))
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        solutionId = dialog.SelectedSolution.FirstOrDefault()?.Id ?? Guid.Empty;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (bw, e) =>
                {
                    tsSourceForm.LoadTables(Service, solutionId);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, true);
                        MessageBox.Show(ParentForm, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tsSourceForm.ShowTables();
                }
            });
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void SetTheme()
        {
            if (XrmToolBox.Options.Instance.Theme != null)
            {
                switch (XrmToolBox.Options.Instance.Theme)
                {
                    case "Blue theme":
                        {
                            var theme = new VS2015BlueTheme();
                            dpMain.Theme = theme;
                        }
                        break;

                    case "Light theme":
                        {
                            var theme = new VS2015LightTheme();
                            dpMain.Theme = theme;
                        }
                        break;

                    case "Dark theme":
                        {
                            var theme = new VS2015DarkTheme();
                            dpMain.Theme = theme;
                        }
                        break;
                }
            }
        }

        private void TsForm_TableSelected(object sender, TableSelectionEventArgs e)
        {
            if (sender == tsSourceForm)
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading target tables...",
                    Work = (bw, ev) =>
                    {
                        tsTargetForm.LoadTargetTables(Service, e.SelectedTable.SchemaName);
                    },
                    PostWorkCallBack = ev =>
                    {
                        if (ev.Error != null)
                        {
                            if (ev.Error is RelationshipNotFoundException)
                            {
                                MessageBox.Show(ParentForm, "There is no child table for the selected parent table. \n\nPlease try to select the other table from the relationship you would like to update the mapping.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            string errorMessage = CrmExceptionHelper.GetErrorMessage(ev.Error, true);
                            MessageBox.Show(ParentForm, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        tsTargetForm.ShowTables();
                        tsTargetForm.Show(dpMain, DockState.DockLeft);
                    }
                });
            }
            else
            {
                meForm.SourceTable = tsSourceForm.SelectedTable;
                meForm.TargetTable = tsTargetForm.SelectedTable;
                meForm.Service = Service;
                meForm.LoadMapping(this);
            }
        }

        private void tsmiLoadAllTables_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadTables, false);
        }

        private void tssbLoadTables_ButtonClick(object sender, EventArgs e)
        {
            ExecuteMethod(LoadTables, true);
        }
    }
}