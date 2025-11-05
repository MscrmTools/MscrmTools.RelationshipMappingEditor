namespace MscrmTools.RelationshipMappingEditor.Forms
{
    partial class MappingEditorForm
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
            this.txtSearchSource = new System.Windows.Forms.TextBox();
            this.lblSearchSource = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbTargetColumns = new System.Windows.Forms.GroupBox();
            this.lvTargetColumns = new System.Windows.Forms.ListView();
            this.chTargetName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTargetSchemaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTargetType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSourceColumns = new System.Windows.Forms.GroupBox();
            this.lvSourceColumns = new System.Windows.Forms.ListView();
            this.chSourceDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSourceSchemaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSourceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTopBottom = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvMapping = new System.Windows.Forms.ListView();
            this.chMappingSourceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMappingSourceSchema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMappingTargetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMappingTargetSchema = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMappingType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMappingIsSytem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMappingManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblseparator1 = new System.Windows.Forms.Label();
            this.btnAutoMap = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.gbTargetColumns.SuspendLayout();
            this.gbSourceColumns.SuspendLayout();
            this.pnlTopBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnAutoMap);
            this.pnlTop.Controls.Add(this.lblseparator1);
            this.pnlTop.Controls.Add(this.txtSearchSource);
            this.pnlTop.Controls.Add(this.lblSearchSource);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlTop.Size = new System.Drawing.Size(1165, 28);
            this.pnlTop.TabIndex = 0;
            // 
            // txtSearchSource
            // 
            this.txtSearchSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSearchSource.Location = new System.Drawing.Point(74, 4);
            this.txtSearchSource.Name = "txtSearchSource";
            this.txtSearchSource.Size = new System.Drawing.Size(252, 22);
            this.txtSearchSource.TabIndex = 1;
            this.txtSearchSource.TextChanged += new System.EventHandler(this.txtSearchSource_TextChanged);
            // 
            // lblSearchSource
            // 
            this.lblSearchSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchSource.Location = new System.Drawing.Point(0, 4);
            this.lblSearchSource.Name = "lblSearchSource";
            this.lblSearchSource.Size = new System.Drawing.Size(74, 24);
            this.lblSearchSource.TabIndex = 0;
            this.lblSearchSource.Text = "Search";
            this.lblSearchSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 846);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Size = new System.Drawing.Size(1165, 60);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(10, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(1145, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete mapping";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.scMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1165, 818);
            this.pnlMain.TabIndex = 2;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tlpMain);
            this.scMain.Panel1.Controls.Add(this.pnlTopBottom);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.lvMapping);
            this.scMain.Size = new System.Drawing.Size(1165, 818);
            this.scMain.SplitterDistance = 447;
            this.scMain.TabIndex = 0;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.gbTargetColumns, 1, 0);
            this.tlpMain.Controls.Add(this.gbSourceColumns, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(1165, 386);
            this.tlpMain.TabIndex = 2;
            // 
            // gbTargetColumns
            // 
            this.gbTargetColumns.Controls.Add(this.lvTargetColumns);
            this.gbTargetColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTargetColumns.Location = new System.Drawing.Point(585, 3);
            this.gbTargetColumns.Name = "gbTargetColumns";
            this.gbTargetColumns.Size = new System.Drawing.Size(577, 380);
            this.gbTargetColumns.TabIndex = 1;
            this.gbTargetColumns.TabStop = false;
            this.gbTargetColumns.Text = "Target columns";
            // 
            // lvTargetColumns
            // 
            this.lvTargetColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTargetName,
            this.chTargetSchemaName,
            this.chTargetType});
            this.lvTargetColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTargetColumns.HideSelection = false;
            this.lvTargetColumns.Location = new System.Drawing.Point(3, 18);
            this.lvTargetColumns.Name = "lvTargetColumns";
            this.lvTargetColumns.Size = new System.Drawing.Size(571, 359);
            this.lvTargetColumns.TabIndex = 1;
            this.lvTargetColumns.UseCompatibleStateImageBehavior = false;
            this.lvTargetColumns.View = System.Windows.Forms.View.Details;
            this.lvTargetColumns.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvTargetColumns.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTargetColumns_MouseDoubleClick);
            // 
            // chTargetName
            // 
            this.chTargetName.Text = "Name";
            // 
            // chTargetSchemaName
            // 
            this.chTargetSchemaName.Text = "SchemaName";
            // 
            // chTargetType
            // 
            this.chTargetType.Text = "Type";
            // 
            // gbSourceColumns
            // 
            this.gbSourceColumns.Controls.Add(this.lvSourceColumns);
            this.gbSourceColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSourceColumns.Location = new System.Drawing.Point(3, 3);
            this.gbSourceColumns.Name = "gbSourceColumns";
            this.gbSourceColumns.Size = new System.Drawing.Size(576, 380);
            this.gbSourceColumns.TabIndex = 0;
            this.gbSourceColumns.TabStop = false;
            this.gbSourceColumns.Text = "Source columns";
            // 
            // lvSourceColumns
            // 
            this.lvSourceColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSourceDisplayName,
            this.chSourceSchemaName,
            this.chSourceType});
            this.lvSourceColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSourceColumns.HideSelection = false;
            this.lvSourceColumns.Location = new System.Drawing.Point(3, 18);
            this.lvSourceColumns.Name = "lvSourceColumns";
            this.lvSourceColumns.Size = new System.Drawing.Size(570, 359);
            this.lvSourceColumns.TabIndex = 0;
            this.lvSourceColumns.UseCompatibleStateImageBehavior = false;
            this.lvSourceColumns.View = System.Windows.Forms.View.Details;
            this.lvSourceColumns.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvSourceColumns.SelectedIndexChanged += new System.EventHandler(this.lvSourceColumns_SelectedIndexChanged);
            // 
            // chSourceDisplayName
            // 
            this.chSourceDisplayName.Text = "Name";
            // 
            // chSourceSchemaName
            // 
            this.chSourceSchemaName.Text = "SchemaName";
            // 
            // chSourceType
            // 
            this.chSourceType.Text = "Type";
            // 
            // pnlTopBottom
            // 
            this.pnlTopBottom.Controls.Add(this.btnAdd);
            this.pnlTopBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopBottom.Location = new System.Drawing.Point(0, 386);
            this.pnlTopBottom.Name = "pnlTopBottom";
            this.pnlTopBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTopBottom.Size = new System.Drawing.Size(1165, 61);
            this.pnlTopBottom.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(1145, 41);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add mapping";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvMapping
            // 
            this.lvMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMappingSourceColumn,
            this.chMappingSourceSchema,
            this.chMappingTargetColumn,
            this.chMappingTargetSchema,
            this.chMappingType,
            this.chMappingIsSytem,
            this.chMappingManaged});
            this.lvMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMapping.FullRowSelect = true;
            this.lvMapping.HideSelection = false;
            this.lvMapping.Location = new System.Drawing.Point(0, 0);
            this.lvMapping.Name = "lvMapping";
            this.lvMapping.Size = new System.Drawing.Size(1165, 367);
            this.lvMapping.TabIndex = 1;
            this.lvMapping.UseCompatibleStateImageBehavior = false;
            this.lvMapping.View = System.Windows.Forms.View.Details;
            this.lvMapping.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
            this.lvMapping.SelectedIndexChanged += new System.EventHandler(this.lvMapping_SelectedIndexChanged);
            // 
            // chMappingSourceColumn
            // 
            this.chMappingSourceColumn.Text = "Source";
            // 
            // chMappingSourceSchema
            // 
            this.chMappingSourceSchema.Text = "SchemaName";
            // 
            // chMappingTargetColumn
            // 
            this.chMappingTargetColumn.Text = "Target";
            // 
            // chMappingTargetSchema
            // 
            this.chMappingTargetSchema.Text = "Schema";
            // 
            // chMappingType
            // 
            this.chMappingType.Text = "Type";
            // 
            // chMappingIsSytem
            // 
            this.chMappingIsSytem.Text = "Is system";
            // 
            // chMappingManaged
            // 
            this.chMappingManaged.Text = "Is managed";
            // 
            // lblseparator1
            // 
            this.lblseparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblseparator1.Location = new System.Drawing.Point(326, 4);
            this.lblseparator1.Name = "lblseparator1";
            this.lblseparator1.Size = new System.Drawing.Size(10, 24);
            this.lblseparator1.TabIndex = 2;
            this.lblseparator1.Text = "|";
            this.lblseparator1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAutoMap
            // 
            this.btnAutoMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAutoMap.Location = new System.Drawing.Point(336, 4);
            this.btnAutoMap.Name = "btnAutoMap";
            this.btnAutoMap.Size = new System.Drawing.Size(98, 24);
            this.btnAutoMap.TabIndex = 3;
            this.btnAutoMap.Text = "Auto Map";
            this.btnAutoMap.UseVisualStyleBackColor = true;
            this.btnAutoMap.Click += new System.EventHandler(this.btnAutoMap_Click);
            // 
            // MappingEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 906);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "MappingEditorForm";
            this.Text = "Mapping Editor";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.gbTargetColumns.ResumeLayout(false);
            this.gbSourceColumns.ResumeLayout(false);
            this.pnlTopBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlTopBottom;
        private System.Windows.Forms.GroupBox gbTargetColumns;
        private System.Windows.Forms.GroupBox gbSourceColumns;
        private System.Windows.Forms.ListView lvSourceColumns;
        private System.Windows.Forms.ColumnHeader chSourceDisplayName;
        private System.Windows.Forms.ColumnHeader chSourceSchemaName;
        private System.Windows.Forms.ListView lvTargetColumns;
        private System.Windows.Forms.ColumnHeader chTargetName;
        private System.Windows.Forms.ColumnHeader chTargetSchemaName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvMapping;
        private System.Windows.Forms.ColumnHeader chMappingSourceColumn;
        private System.Windows.Forms.ColumnHeader chMappingSourceSchema;
        private System.Windows.Forms.ColumnHeader chMappingTargetColumn;
        private System.Windows.Forms.ColumnHeader chMappingTargetSchema;
        private System.Windows.Forms.ColumnHeader chSourceType;
        private System.Windows.Forms.ColumnHeader chTargetType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader chMappingType;
        private System.Windows.Forms.Label lblSearchSource;
        private System.Windows.Forms.TextBox txtSearchSource;
        private System.Windows.Forms.ColumnHeader chMappingIsSytem;
        private System.Windows.Forms.ColumnHeader chMappingManaged;
        private System.Windows.Forms.Label lblseparator1;
        private System.Windows.Forms.Button btnAutoMap;
    }
}