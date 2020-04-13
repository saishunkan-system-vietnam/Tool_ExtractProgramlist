namespace ExportSource
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grbSearchInf = new System.Windows.Forms.GroupBox();
			this.DateTimeGetChangeControl = new System.Windows.Forms.DateTimePicker();
			this.radChkBySource = new System.Windows.Forms.RadioButton();
			this.radChkByPrgList = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFind = new System.Windows.Forms.Button();
			this.txtSourcePath = new System.Windows.Forms.TextBox();
			this.btnOpenSourcePath = new System.Windows.Forms.Button();
			this.txtProgramLstPath = new System.Windows.Forms.TextBox();
			this.btnOpenProgramLstPath = new System.Windows.Forms.Button();
			this.grbProgramList = new System.Windows.Forms.GroupBox();
			this.chkboxSelectOutPut = new System.Windows.Forms.CheckBox();
			this.dtGrvProgramList = new System.Windows.Forms.DataGridView();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.chkIsExportProgramList = new System.Windows.Forms.CheckBox();
			this.btnSetting = new System.Windows.Forms.Button();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Rep = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PathFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CheckExist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

			this.grbSearchInf.SuspendLayout();
			this.grbProgramList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtGrvProgramList)).BeginInit();
			this.SuspendLayout();
			// 
			// grbSearchInf
			// 
			this.grbSearchInf.Controls.Add(this.DateTimeGetChangeControl);
			this.grbSearchInf.Controls.Add(this.radChkBySource);
			this.grbSearchInf.Controls.Add(this.radChkByPrgList);
			this.grbSearchInf.Controls.Add(this.label2);
			this.grbSearchInf.Controls.Add(this.label1);
			this.grbSearchInf.Controls.Add(this.btnFind);
			this.grbSearchInf.Controls.Add(this.txtSourcePath);
			this.grbSearchInf.Controls.Add(this.btnOpenSourcePath);
			this.grbSearchInf.Controls.Add(this.txtProgramLstPath);
			this.grbSearchInf.Controls.Add(this.btnOpenProgramLstPath);
			this.grbSearchInf.Location = new System.Drawing.Point(12, 31);
			this.grbSearchInf.Name = "grbSearchInf";
			this.grbSearchInf.Size = new System.Drawing.Size(1261, 111);
			this.grbSearchInf.TabIndex = 0;
			this.grbSearchInf.TabStop = false;
			this.grbSearchInf.Text = "Search Infor";
			// 
			// DateTimeGetChangeControl
			// 
			this.DateTimeGetChangeControl.Enabled = false;
			this.DateTimeGetChangeControl.Location = new System.Drawing.Point(912, 65);
			this.DateTimeGetChangeControl.Name = "DateTimeGetChangeControl";
			this.DateTimeGetChangeControl.Size = new System.Drawing.Size(138, 20);
			this.DateTimeGetChangeControl.TabIndex = 10;
			// 
			// radChkBySource
			// 
			this.radChkBySource.AutoSize = true;
			this.radChkBySource.Location = new System.Drawing.Point(770, 68);
			this.radChkBySource.Name = "radChkBySource";
			this.radChkBySource.Size = new System.Drawing.Size(108, 17);
			this.radChkBySource.TabIndex = 9;
			this.radChkBySource.Text = "Check By Source";
			this.radChkBySource.UseVisualStyleBackColor = true;
			this.radChkBySource.CheckedChanged += new System.EventHandler(this.radChkBySource_CheckedChanged);
			// 
			// radChkByPrgList
			// 
			this.radChkByPrgList.AutoSize = true;
			this.radChkByPrgList.Checked = true;
			this.radChkByPrgList.Location = new System.Drawing.Point(770, 27);
			this.radChkByPrgList.Name = "radChkByPrgList";
			this.radChkByPrgList.Size = new System.Drawing.Size(129, 17);
			this.radChkByPrgList.TabIndex = 9;
			this.radChkByPrgList.TabStop = true;
			this.radChkByPrgList.Text = "Check By ProgramList";
			this.radChkByPrgList.UseVisualStyleBackColor = true;
			this.radChkByPrgList.CheckedChanged += new System.EventHandler(this.radChkByPrgList_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(455, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Open Path Source";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(454, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Open path or Drag ProgramList File";
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(1134, 26);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(97, 46);
			this.btnFind.TabIndex = 6;
			this.btnFind.Text = "Find";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// txtSourcePath
			// 
			this.txtSourcePath.Location = new System.Drawing.Point(133, 73);
			this.txtSourcePath.Name = "txtSourcePath";
			this.txtSourcePath.Size = new System.Drawing.Size(306, 20);
			this.txtSourcePath.TabIndex = 4;
			// 
			// btnOpenSourcePath
			// 
			this.btnOpenSourcePath.Location = new System.Drawing.Point(59, 68);
			this.btnOpenSourcePath.Name = "btnOpenSourcePath";
			this.btnOpenSourcePath.Size = new System.Drawing.Size(58, 28);
			this.btnOpenSourcePath.TabIndex = 5;
			this.btnOpenSourcePath.Text = "Open";
			this.btnOpenSourcePath.UseVisualStyleBackColor = true;
			this.btnOpenSourcePath.Click += new System.EventHandler(this.btnOpenSourcePath_Click);
			// 
			// txtProgramLstPath
			// 
			this.txtProgramLstPath.AllowDrop = true;
			this.txtProgramLstPath.Location = new System.Drawing.Point(133, 27);
			this.txtProgramLstPath.Name = "txtProgramLstPath";
			this.txtProgramLstPath.Size = new System.Drawing.Size(306, 20);
			this.txtProgramLstPath.TabIndex = 2;
			this.txtProgramLstPath.DragOver += new System.Windows.Forms.DragEventHandler(this.txtProgramLstPath_DragOver);
			// 
			// btnOpenProgramLstPath
			// 
			this.btnOpenProgramLstPath.Location = new System.Drawing.Point(59, 27);
			this.btnOpenProgramLstPath.Name = "btnOpenProgramLstPath";
			this.btnOpenProgramLstPath.Size = new System.Drawing.Size(58, 24);
			this.btnOpenProgramLstPath.TabIndex = 3;
			this.btnOpenProgramLstPath.Text = "Open";
			this.btnOpenProgramLstPath.UseVisualStyleBackColor = true;
			this.btnOpenProgramLstPath.Click += new System.EventHandler(this.btnOpenProgramLstPath_Click);
			// 
			// grbProgramList
			// 
			this.grbProgramList.Controls.Add(this.chkboxSelectOutPut);
			this.grbProgramList.Controls.Add(this.dtGrvProgramList);
			this.grbProgramList.Location = new System.Drawing.Point(13, 154);
			this.grbProgramList.Name = "grbProgramList";
			this.grbProgramList.Size = new System.Drawing.Size(1260, 571);
			this.grbProgramList.TabIndex = 1;
			this.grbProgramList.TabStop = false;
			this.grbProgramList.Text = "Program List";
			// 
			// chkboxSelectOutPut
			// 
			this.chkboxSelectOutPut.AutoSize = true;
			this.chkboxSelectOutPut.Location = new System.Drawing.Point(1185, 20);
			this.chkboxSelectOutPut.Name = "chkboxSelectOutPut";
			this.chkboxSelectOutPut.Size = new System.Drawing.Size(67, 17);
			this.chkboxSelectOutPut.TabIndex = 9;
			this.chkboxSelectOutPut.Text = "SelectAll";
			this.chkboxSelectOutPut.UseVisualStyleBackColor = true;
			this.chkboxSelectOutPut.CheckedChanged += new System.EventHandler(this.chkboxSelectOutPut_CheckedChanged);
			// 
			// dtGrvProgramList
			// 
			this.dtGrvProgramList.AllowUserToAddRows = false;
			this.dtGrvProgramList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dtGrvProgramList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtGrvProgramList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Rep,
            this.ProjectName,
            this.PathFile,
            this.FileName,
            this.Status,
            this.CheckExist,
            this.Check,
            this.CreateDate,
            this.UpdateDate});
			this.dtGrvProgramList.Location = new System.Drawing.Point(19, 41);
			this.dtGrvProgramList.Name = "dtGrvProgramList";
			this.dtGrvProgramList.RowHeadersWidth = 51;
			this.dtGrvProgramList.RowTemplate.Height = 21;
			this.dtGrvProgramList.Size = new System.Drawing.Size(1222, 510);
			this.dtGrvProgramList.TabIndex = 0;
			this.dtGrvProgramList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrvProgramList_CellValueChanged);
			// 
			// No
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			this.No.DefaultCellStyle = dataGridViewCellStyle3;
			this.No.FillWeight = 44.08547F;
			this.No.HeaderText = "No";
			this.No.MinimumWidth = 6;
			this.No.Name = "No";
			this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Rep
			// 
			this.Rep.HeaderText = "Rep.";
			this.Rep.MinimumWidth = 6;
			this.Rep.Name = "Rep";
			this.Rep.ReadOnly = true;
			this.Rep.Visible = false;
			// 
			// ProjectName
			// 
			this.ProjectName.HeaderText = "Project Name";
			this.ProjectName.MinimumWidth = 6;
			this.ProjectName.Name = "ProjectName";
			this.ProjectName.ReadOnly = true;
			this.ProjectName.Visible = false;
			// 
			// PathFile
			// 
			this.PathFile.FillWeight = 197.2825F;
			this.PathFile.HeaderText = "Path";
			this.PathFile.MinimumWidth = 6;
			this.PathFile.Name = "PathFile";
			this.PathFile.ReadOnly = true;
			this.PathFile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// FileName
			// 
			this.FileName.FillWeight = 197.2825F;
			this.FileName.HeaderText = "File Name";
			this.FileName.MinimumWidth = 6;
			this.FileName.Name = "FileName";
			this.FileName.ReadOnly = true;
			this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Status
			// 
			this.Status.FillWeight = 57.13477F;
			this.Status.HeaderText = "Status";
			this.Status.MinimumWidth = 6;
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// CheckExist
			// 
			this.CheckExist.FillWeight = 56.08641F;
			this.CheckExist.HeaderText = "Check exist";
			this.CheckExist.MinimumWidth = 6;
			this.CheckExist.Name = "CheckExist";
			this.CheckExist.ReadOnly = true;
			// 
			// Check
			// 
			this.Check.FillWeight = 48.12834F;
			this.Check.HeaderText = "";
			this.Check.MinimumWidth = 6;
			this.Check.Name = "Check";
			this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// CreateDate
			// 
			this.CreateDate.HeaderText = "Create Date";
			this.CreateDate.MinimumWidth = 6;
			this.CreateDate.Name = "CreateDate";
			this.CreateDate.ReadOnly = true;
			this.CreateDate.Visible = false;
			// 
			// UpdateDate
			// 
			this.UpdateDate.HeaderText = "UpdateDate";
			this.UpdateDate.MinimumWidth = 6;
			this.UpdateDate.Name = "UpdateDate";
			this.UpdateDate.ReadOnly = true;
			this.UpdateDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.UpdateDate.Visible = false;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(1065, 780);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(101, 37);
			this.btnExport.TabIndex = 2;
			this.btnExport.Text = "Export ";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(1172, 780);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(101, 37);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(957, 780);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(101, 37);
			this.btnClear.TabIndex = 2;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// chkIsExportProgramList
			// 
			this.chkIsExportProgramList.AutoSize = true;
			this.chkIsExportProgramList.Location = new System.Drawing.Point(1065, 744);
			this.chkIsExportProgramList.Name = "chkIsExportProgramList";
			this.chkIsExportProgramList.Size = new System.Drawing.Size(117, 17);
			this.chkIsExportProgramList.TabIndex = 4;
			this.chkIsExportProgramList.Text = "Export Program List";
			this.chkIsExportProgramList.UseVisualStyleBackColor = true;
			// 
			// btnSetting
			// 
			this.btnSetting.Location = new System.Drawing.Point(13, 771);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.Size = new System.Drawing.Size(101, 37);
			this.btnSetting.TabIndex = 5;
			this.btnSetting.Text = "Setting";
			this.btnSetting.UseVisualStyleBackColor = true;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting__Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1285, 836);
			this.Controls.Add(this.btnSetting);
			this.Controls.Add(this.chkIsExportProgramList);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.grbProgramList);
			this.Controls.Add(this.grbSearchInf);
			this.Name = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.grbSearchInf.ResumeLayout(false);
			this.grbSearchInf.PerformLayout();
			this.grbProgramList.ResumeLayout(false);
			this.grbProgramList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtGrvProgramList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grbSearchInf;
		private System.Windows.Forms.GroupBox grbProgramList;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.TextBox txtSourcePath;
		private System.Windows.Forms.Button btnOpenSourcePath;
		private System.Windows.Forms.TextBox txtProgramLstPath;
		private System.Windows.Forms.Button btnOpenProgramLstPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dtGrvProgramList;
		private System.Windows.Forms.CheckBox chkboxSelectOutPut;
		private System.Windows.Forms.RadioButton radChkBySource;
		private System.Windows.Forms.RadioButton radChkByPrgList;
  private System.Windows.Forms.DateTimePicker DateTimeGetChangeControl;
        private System.Windows.Forms.CheckBox chkIsExportProgramList;
        private System.Windows.Forms.Button btnSetting;
		private System.Windows.Forms.DataGridViewTextBoxColumn No;
		private System.Windows.Forms.DataGridViewTextBoxColumn Rep;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
		private System.Windows.Forms.DataGridViewTextBoxColumn PathFile;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.DataGridViewTextBoxColumn CheckExist;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
		private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
	}
}

