namespace linkemen
{
    partial class LookAllLinkmenInfo
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gunterMPLMSDataSet = new linkemen.gunterMPLMSDataSet();
            this.procViewLinkmenInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.procViewLinkmenInfoTableAdapter = new linkemen.gunterMPLMSDataSetTableAdapters.procViewLinkmenInfoTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkmenIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupKindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkmanNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunterMPLMSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procViewLinkmenInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.linkmenIDDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.groupKindDataGridViewTextBoxColumn,
            this.linkmanNameDataGridViewTextBoxColumn,
            this.workUnitDataGridViewTextBoxColumn,
            this.linkNumDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.personImageDataGridViewImageColumn});
            this.dataGridView1.DataSource = this.procViewLinkmenInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(736, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // gunterMPLMSDataSet
            // 
            this.gunterMPLMSDataSet.DataSetName = "gunterMPLMSDataSet";
            this.gunterMPLMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // procViewLinkmenInfoBindingSource
            // 
            this.procViewLinkmenInfoBindingSource.DataMember = "procViewLinkmenInfo";
            this.procViewLinkmenInfoBindingSource.DataSource = this.gunterMPLMSDataSet;
            // 
            // procViewLinkmenInfoTableAdapter
            // 
            this.procViewLinkmenInfoTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // linkmenIDDataGridViewTextBoxColumn
            // 
            this.linkmenIDDataGridViewTextBoxColumn.DataPropertyName = "LinkmenID";
            this.linkmenIDDataGridViewTextBoxColumn.HeaderText = "LinkmenID";
            this.linkmenIDDataGridViewTextBoxColumn.Name = "linkmenIDDataGridViewTextBoxColumn";
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            // 
            // groupKindDataGridViewTextBoxColumn
            // 
            this.groupKindDataGridViewTextBoxColumn.DataPropertyName = "GroupKind";
            this.groupKindDataGridViewTextBoxColumn.HeaderText = "GroupKind";
            this.groupKindDataGridViewTextBoxColumn.Name = "groupKindDataGridViewTextBoxColumn";
            // 
            // linkmanNameDataGridViewTextBoxColumn
            // 
            this.linkmanNameDataGridViewTextBoxColumn.DataPropertyName = "LinkmanName";
            this.linkmanNameDataGridViewTextBoxColumn.HeaderText = "LinkmanName";
            this.linkmanNameDataGridViewTextBoxColumn.Name = "linkmanNameDataGridViewTextBoxColumn";
            // 
            // workUnitDataGridViewTextBoxColumn
            // 
            this.workUnitDataGridViewTextBoxColumn.DataPropertyName = "WorkUnit";
            this.workUnitDataGridViewTextBoxColumn.HeaderText = "WorkUnit";
            this.workUnitDataGridViewTextBoxColumn.Name = "workUnitDataGridViewTextBoxColumn";
            // 
            // linkNumDataGridViewTextBoxColumn
            // 
            this.linkNumDataGridViewTextBoxColumn.DataPropertyName = "LinkNum";
            this.linkNumDataGridViewTextBoxColumn.HeaderText = "LinkNum";
            this.linkNumDataGridViewTextBoxColumn.Name = "linkNumDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // personImageDataGridViewImageColumn
            // 
            this.personImageDataGridViewImageColumn.DataPropertyName = "PersonImage";
            this.personImageDataGridViewImageColumn.HeaderText = "PersonImage";
            this.personImageDataGridViewImageColumn.Name = "personImageDataGridViewImageColumn";
            // 
            // LookAllLinkmenInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 342);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LookAllLinkmenInfo";
            this.Text = "LookAllLinkmenInfo";
            this.Load += new System.EventHandler(this.LookAllLinkmenInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunterMPLMSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procViewLinkmenInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private gunterMPLMSDataSet gunterMPLMSDataSet;
        private System.Windows.Forms.BindingSource procViewLinkmenInfoBindingSource;
        private linkemen.gunterMPLMSDataSetTableAdapters.procViewLinkmenInfoTableAdapter procViewLinkmenInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkmenIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupKindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkmanNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn personImageDataGridViewImageColumn;

    }
}