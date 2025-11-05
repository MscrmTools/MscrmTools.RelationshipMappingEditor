namespace MscrmTools.RelationshipMappingEditor
{
    partial class RelationshipMappingEditorPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssbLoadTables = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiLoadAllTables = new System.Windows.Forms.ToolStripMenuItem();
            this.dpMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbLoadTables});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1453, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssbLoadTables
            // 
            this.tssbLoadTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadAllTables});
            this.tssbLoadTables.Image = global::MscrmTools.RelationshipMappingEditor.Properties.Resources.Dataverse_32x32;
            this.tssbLoadTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbLoadTables.Name = "tssbLoadTables";
            this.tssbLoadTables.Size = new System.Drawing.Size(138, 36);
            this.tssbLoadTables.Text = "Load Tables";
            this.tssbLoadTables.ButtonClick += new System.EventHandler(this.tssbLoadTables_ButtonClick);
            // 
            // tsmiLoadAllTables
            // 
            this.tsmiLoadAllTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiLoadAllTables.Name = "tsmiLoadAllTables";
            this.tsmiLoadAllTables.Size = new System.Drawing.Size(224, 26);
            this.tsmiLoadAllTables.Text = "Load all tables";
            this.tsmiLoadAllTables.Click += new System.EventHandler(this.tsmiLoadAllTables_Click);
            // 
            // dpMain
            // 
            this.dpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpMain.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dpMain.Location = new System.Drawing.Point(0, 39);
            this.dpMain.Name = "dpMain";
            this.dpMain.Size = new System.Drawing.Size(1453, 903);
            this.dpMain.TabIndex = 5;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dpMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1453, 942);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dpMain;
        private System.Windows.Forms.ToolStripSplitButton tssbLoadTables;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadAllTables;
    }
}
