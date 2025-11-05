namespace MscrmTools.RelationshipMappingEditor.Forms
{
    partial class TableSelectionControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSearchEntity = new System.Windows.Forms.Label();
            this.txtSearchEntity = new System.Windows.Forms.TextBox();
            this.lvTables = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearchEntity);
            this.pnlTop.Controls.Add(this.lblSearchEntity);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlTop.Size = new System.Drawing.Size(1260, 31);
            this.pnlTop.TabIndex = 85;
            // 
            // lblSearchEntity
            // 
            this.lblSearchEntity.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchEntity.Location = new System.Drawing.Point(0, 4);
            this.lblSearchEntity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchEntity.Name = "lblSearchEntity";
            this.lblSearchEntity.Size = new System.Drawing.Size(83, 27);
            this.lblSearchEntity.TabIndex = 85;
            this.lblSearchEntity.Text = "Search:";
            this.lblSearchEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchEntity
            // 
            this.txtSearchEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchEntity.Location = new System.Drawing.Point(83, 4);
            this.txtSearchEntity.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchEntity.Name = "txtSearchEntity";
            this.txtSearchEntity.Size = new System.Drawing.Size(1177, 22);
            this.txtSearchEntity.TabIndex = 86;
            this.txtSearchEntity.TextChanged += new System.EventHandler(this.txtSearchEntity_TextChanged);
            // 
            // lvTables
            // 
            this.lvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTables.FullRowSelect = true;
            this.lvTables.HideSelection = false;
            this.lvTables.Location = new System.Drawing.Point(0, 31);
            this.lvTables.Margin = new System.Windows.Forms.Padding(4);
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(1260, 1334);
            this.lvTables.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTables.TabIndex = 86;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTables_ColumnClick);
            this.lvTables.SelectedIndexChanged += new System.EventHandler(this.lvTables_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display name";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Schema name";
            this.columnHeader2.Width = 100;
            // 
            // TableSelectionControl
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 1365);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lvTables);
            this.Controls.Add(this.pnlTop);
            this.Name = "TableSelectionControl";
            this.Text = "Tables";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtSearchEntity;
        private System.Windows.Forms.Label lblSearchEntity;
        private System.Windows.Forms.ListView lvTables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}