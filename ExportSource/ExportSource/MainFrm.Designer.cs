﻿namespace ExportSource
{
	partial class MainFrm
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
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PathFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CheckExist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.REP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSetting = new System.Windows.Forms.Button();
			this.chkExportProgramList = new System.Windows.Forms.CheckBox();
			this.chkExportSource = new System.Windows.Forms.CheckBox();
			this.txtInputProjectName = new System.Windows.Forms.TextBox();
			this.lblProjectName = new System.Windows.Forms.Label();
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
			this.grbSearchInf.Location = new System.Drawing.Point(16, 38);
			this.grbSearchInf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grbSearchInf.Name = "grbSearchInf";
			this.grbSearchInf.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grbSearchInf.Size = new System.Drawing.Size(1429, 130);
			this.grbSearchInf.TabIndex = 0;
			this.grbSearchInf.TabStop = false;
			this.grbSearchInf.Text = "Search Infor";
			// 
			// DateTimeGetChangeControl
			// 
			this.DateTimeGetChangeControl.Location = new System.Drawing.Point(1041, 80);
			this.DateTimeGetChangeControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.DateTimeGetChangeControl.Name = "DateTimeGetChangeControl";
			this.DateTimeGetChangeControl.Size = new System.Drawing.Size(183, 22);
			this.DateTimeGetChangeControl.TabIndex = 10;
			// 
			// radChkBySource
			// 
			this.radChkBySource.AutoSize = true;
			this.radChkBySource.Checked = true;
			this.radChkBySource.Location = new System.Drawing.Point(852, 84);
			this.radChkBySource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radChkBySource.Name = "radChkBySource";
			this.radChkBySource.Size = new System.Drawing.Size(137, 21);
			this.radChkBySource.TabIndex = 9;
			this.radChkBySource.TabStop = true;
			this.radChkBySource.Text = "Check By Source";
			this.radChkBySource.UseVisualStyleBackColor = true;
			this.radChkBySource.CheckedChanged += new System.EventHandler(this.radChkBySource_CheckedChanged);
			// 
			// radChkByPrgList
			// 
			this.radChkByPrgList.AutoSize = true;
			this.radChkByPrgList.Location = new System.Drawing.Point(852, 33);
			this.radChkByPrgList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radChkByPrgList.Name = "radChkByPrgList";
			this.radChkByPrgList.Size = new System.Drawing.Size(168, 21);
			this.radChkByPrgList.TabIndex = 9;
			this.radChkByPrgList.Text = "Check By ProgramList";
			this.radChkByPrgList.UseVisualStyleBackColor = true;
			this.radChkByPrgList.CheckedChanged += new System.EventHandler(this.radChkByPrgList_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(517, 94);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Open Path Source";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(516, 37);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(233, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Open path or Drag ProgramList File";
			// 
			// btnFind
			// 
			this.btnFind.BackColor = System.Drawing.Color.Transparent;
			this.btnFind.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnFind.Location = new System.Drawing.Point(1267, 33);
			this.btnFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(129, 71);
			this.btnFind.TabIndex = 6;
			this.btnFind.Text = "Find";
			this.btnFind.UseVisualStyleBackColor = false;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// txtSourcePath
			// 
			this.txtSourcePath.Location = new System.Drawing.Point(132, 90);
			this.txtSourcePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtSourcePath.Name = "txtSourcePath";
			this.txtSourcePath.Size = new System.Drawing.Size(369, 22);
			this.txtSourcePath.TabIndex = 4;
			// 
			// btnOpenSourcePath
			// 
			this.btnOpenSourcePath.Location = new System.Drawing.Point(35, 84);
			this.btnOpenSourcePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnOpenSourcePath.Name = "btnOpenSourcePath";
			this.btnOpenSourcePath.Size = new System.Drawing.Size(77, 34);
			this.btnOpenSourcePath.TabIndex = 5;
			this.btnOpenSourcePath.Text = "Open";
			this.btnOpenSourcePath.UseVisualStyleBackColor = true;
			this.btnOpenSourcePath.Click += new System.EventHandler(this.btnOpenSourcePath_Click);
			// 
			// txtProgramLstPath
			// 
			this.txtProgramLstPath.AllowDrop = true;
			this.txtProgramLstPath.Location = new System.Drawing.Point(132, 33);
			this.txtProgramLstPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtProgramLstPath.Name = "txtProgramLstPath";
			this.txtProgramLstPath.Size = new System.Drawing.Size(369, 22);
			this.txtProgramLstPath.TabIndex = 2;
			this.txtProgramLstPath.DragOver += new System.Windows.Forms.DragEventHandler(this.txtProgramLstPath_DragOver);
			// 
			// btnOpenProgramLstPath
			// 
			this.btnOpenProgramLstPath.Location = new System.Drawing.Point(35, 33);
			this.btnOpenProgramLstPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnOpenProgramLstPath.Name = "btnOpenProgramLstPath";
			this.btnOpenProgramLstPath.Size = new System.Drawing.Size(77, 30);
			this.btnOpenProgramLstPath.TabIndex = 3;
			this.btnOpenProgramLstPath.Text = "Open";
			this.btnOpenProgramLstPath.UseVisualStyleBackColor = true;
			this.btnOpenProgramLstPath.Click += new System.EventHandler(this.btnOpenProgramLstPath_Click);
			// 
			// grbProgramList
			// 
			this.grbProgramList.Controls.Add(this.chkboxSelectOutPut);
			this.grbProgramList.Controls.Add(this.dtGrvProgramList);
			this.grbProgramList.Location = new System.Drawing.Point(17, 190);
			this.grbProgramList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grbProgramList.Name = "grbProgramList";
			this.grbProgramList.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grbProgramList.Size = new System.Drawing.Size(1428, 539);
			this.grbProgramList.TabIndex = 1;
			this.grbProgramList.TabStop = false;
			this.grbProgramList.Text = "Program List";
			// 
			// chkboxSelectOutPut
			// 
			this.chkboxSelectOutPut.AutoSize = true;
			this.chkboxSelectOutPut.Location = new System.Drawing.Point(1331, 22);
			this.chkboxSelectOutPut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkboxSelectOutPut.Name = "chkboxSelectOutPut";
			this.chkboxSelectOutPut.Size = new System.Drawing.Size(84, 21);
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
            this.PathFile,
            this.FileName,
            this.Status,
            this.CheckExist,
            this.REP,
            this.Check});
			this.dtGrvProgramList.Location = new System.Drawing.Point(8, 53);
			this.dtGrvProgramList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dtGrvProgramList.Name = "dtGrvProgramList";
			this.dtGrvProgramList.RowHeadersWidth = 51;
			this.dtGrvProgramList.RowTemplate.Height = 21;
			this.dtGrvProgramList.Size = new System.Drawing.Size(1387, 479);
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
			// REP
			// 
			this.REP.HeaderText = "REP";
			this.REP.MinimumWidth = 6;
			this.REP.Name = "REP";
			this.REP.Visible = false;
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
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(1091, 770);
			this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(135, 46);
			this.btnExport.TabIndex = 2;
			this.btnExport.Text = "Export ";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(1277, 770);
			this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(135, 46);
			this.btnClear.TabIndex = 2;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSetting
			// 
			this.btnSetting.Location = new System.Drawing.Point(27, 770);
			this.btnSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.Size = new System.Drawing.Size(135, 46);
			this.btnSetting.TabIndex = 5;
			this.btnSetting.Text = "Setting";
			this.btnSetting.UseVisualStyleBackColor = true;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting__Click);
			// 
			// chkExportProgramList
			// 
			this.chkExportProgramList.AutoSize = true;
			this.chkExportProgramList.Location = new System.Drawing.Point(1220, 735);
			this.chkExportProgramList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkExportProgramList.Name = "chkExportProgramList";
			this.chkExportProgramList.Size = new System.Drawing.Size(154, 21);
			this.chkExportProgramList.TabIndex = 6;
			this.chkExportProgramList.Tag = "Export Program List only";
			this.chkExportProgramList.Text = "Export Program List";
			this.chkExportProgramList.UseVisualStyleBackColor = true;
			this.chkExportProgramList.CheckedChanged += new System.EventHandler(this.chkExportProgramList_CheckedChanged);
			// 
			// chkExportSource
			// 
			this.chkExportSource.AutoSize = true;
			this.chkExportSource.Location = new System.Drawing.Point(1091, 735);
			this.chkExportSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkExportSource.Name = "chkExportSource";
			this.chkExportSource.Size = new System.Drawing.Size(119, 21);
			this.chkExportSource.TabIndex = 6;
			this.chkExportSource.Tag = "Export source only";
			this.chkExportSource.Text = "Export Source";
			this.chkExportSource.UseVisualStyleBackColor = true;
			// 
			// txtInputProjectName
			// 
			this.txtInputProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInputProjectName.Location = new System.Drawing.Point(575, 775);
			this.txtInputProjectName.Name = "txtInputProjectName";
			this.txtInputProjectName.Size = new System.Drawing.Size(430, 30);
			this.txtInputProjectName.TabIndex = 8;
			// 
			// lblProjectName
			// 
			this.lblProjectName.AutoSize = true;
			this.lblProjectName.Location = new System.Drawing.Point(572, 742);
			this.lblProjectName.Name = "lblProjectName";
			this.lblProjectName.Size = new System.Drawing.Size(128, 17);
			this.lblProjectName.TabIndex = 9;
			this.lblProjectName.Text = "Input Project Name";
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1461, 846);
			this.Controls.Add(this.lblProjectName);
			this.Controls.Add(this.txtInputProjectName);
			this.Controls.Add(this.chkExportSource);
			this.Controls.Add(this.chkExportProgramList);
			this.Controls.Add(this.btnSetting);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.grbProgramList);
			this.Controls.Add(this.grbSearchInf);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "MainFrm";
			this.Text = "Tool extract source and program list";
			this.Load += new System.EventHandler(this.Form_Load);
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
        private System.Windows.Forms.Button btnSetting;
		private System.Windows.Forms.DataGridViewTextBoxColumn No;
		private System.Windows.Forms.DataGridViewTextBoxColumn PathFile;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.DataGridViewTextBoxColumn CheckExist;
		private System.Windows.Forms.DataGridViewTextBoxColumn REP;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
		private System.Windows.Forms.CheckBox chkExportProgramList;
        private System.Windows.Forms.CheckBox chkExportSource;
        private System.Windows.Forms.TextBox txtInputProjectName;
        private System.Windows.Forms.Label lblProjectName;
    }
}

