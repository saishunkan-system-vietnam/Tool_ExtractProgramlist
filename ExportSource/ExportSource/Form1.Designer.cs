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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grbSearchInf = new System.Windows.Forms.GroupBox();
			this.dtpkSinceCommitSource = new System.Windows.Forms.DateTimePicker();
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
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
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
			this.grbSearchInf.Controls.Add(this.dtpkSinceCommitSource);
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
			this.grbSearchInf.Margin = new System.Windows.Forms.Padding(4);
			this.grbSearchInf.Name = "grbSearchInf";
			this.grbSearchInf.Padding = new System.Windows.Forms.Padding(4);
			this.grbSearchInf.Size = new System.Drawing.Size(1681, 137);
			this.grbSearchInf.TabIndex = 0;
			this.grbSearchInf.TabStop = false;
			this.grbSearchInf.Text = "Search Infor";
			// 
			// dtpkSinceCommitSource
			// 
			this.dtpkSinceCommitSource.Enabled = false;
			this.dtpkSinceCommitSource.Location = new System.Drawing.Point(1216, 80);
			this.dtpkSinceCommitSource.Margin = new System.Windows.Forms.Padding(4);
			this.dtpkSinceCommitSource.Name = "dtpkSinceCommitSource";
			this.dtpkSinceCommitSource.Size = new System.Drawing.Size(183, 22);
			this.dtpkSinceCommitSource.TabIndex = 10;
			// 
			// radChkBySource
			// 
			this.radChkBySource.AutoSize = true;
			this.radChkBySource.Location = new System.Drawing.Point(1027, 84);
			this.radChkBySource.Margin = new System.Windows.Forms.Padding(4);
			this.radChkBySource.Name = "radChkBySource";
			this.radChkBySource.Size = new System.Drawing.Size(137, 21);
			this.radChkBySource.TabIndex = 9;
			this.radChkBySource.Text = "Check By Source";
			this.radChkBySource.UseVisualStyleBackColor = true;
			this.radChkBySource.CheckedChanged += new System.EventHandler(this.radChkBySource_CheckedChanged);
			// 
			// radChkByPrgList
			// 
			this.radChkByPrgList.AutoSize = true;
			this.radChkByPrgList.Checked = true;
			this.radChkByPrgList.Location = new System.Drawing.Point(1027, 33);
			this.radChkByPrgList.Margin = new System.Windows.Forms.Padding(4);
			this.radChkByPrgList.Name = "radChkByPrgList";
			this.radChkByPrgList.Size = new System.Drawing.Size(168, 21);
			this.radChkByPrgList.TabIndex = 9;
			this.radChkByPrgList.TabStop = true;
			this.radChkByPrgList.Text = "Check By ProgramList";
			this.radChkByPrgList.UseVisualStyleBackColor = true;
			this.radChkByPrgList.CheckedChanged += new System.EventHandler(this.radChkByPrgList_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(607, 94);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Open Path Source";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(605, 37);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(233, 17);
			this.label1.TabIndex = 7;
			this.label1.Text = "Open path or Drag ProgramList File";
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(1512, 32);
			this.btnFind.Margin = new System.Windows.Forms.Padding(4);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(129, 57);
			this.btnFind.TabIndex = 6;
			this.btnFind.Text = "Find";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// txtSourcePath
			// 
			this.txtSourcePath.Location = new System.Drawing.Point(177, 90);
			this.txtSourcePath.Margin = new System.Windows.Forms.Padding(4);
			this.txtSourcePath.Name = "txtSourcePath";
			this.txtSourcePath.Size = new System.Drawing.Size(407, 22);
			this.txtSourcePath.TabIndex = 4;
			// 
			// btnOpenSourcePath
			// 
			this.btnOpenSourcePath.Location = new System.Drawing.Point(79, 84);
			this.btnOpenSourcePath.Margin = new System.Windows.Forms.Padding(4);
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
			this.txtProgramLstPath.Location = new System.Drawing.Point(177, 33);
			this.txtProgramLstPath.Margin = new System.Windows.Forms.Padding(4);
			this.txtProgramLstPath.Name = "txtProgramLstPath";
			this.txtProgramLstPath.Size = new System.Drawing.Size(407, 22);
			this.txtProgramLstPath.TabIndex = 2;
			this.txtProgramLstPath.DragOver += new System.Windows.Forms.DragEventHandler(this.txtProgramLstPath_DragOver);
			// 
			// btnOpenProgramLstPath
			// 
			this.btnOpenProgramLstPath.Location = new System.Drawing.Point(79, 33);
			this.btnOpenProgramLstPath.Margin = new System.Windows.Forms.Padding(4);
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
			this.grbProgramList.Margin = new System.Windows.Forms.Padding(4);
			this.grbProgramList.Name = "grbProgramList";
			this.grbProgramList.Padding = new System.Windows.Forms.Padding(4);
			this.grbProgramList.Size = new System.Drawing.Size(1680, 703);
			this.grbProgramList.TabIndex = 1;
			this.grbProgramList.TabStop = false;
			this.grbProgramList.Text = "Program List";
			// 
			// chkboxSelectOutPut
			// 
			this.chkboxSelectOutPut.AutoSize = true;
			this.chkboxSelectOutPut.Location = new System.Drawing.Point(1580, 25);
			this.chkboxSelectOutPut.Margin = new System.Windows.Forms.Padding(4);
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
            this.Rep,
            this.ProjectName,
            this.PathFile,
            this.FileName,
            this.Status,
            this.CheckExist,
            this.Check,
            this.CreateDate,
            this.UpdateDate});
			this.dtGrvProgramList.Location = new System.Drawing.Point(25, 50);
			this.dtGrvProgramList.Margin = new System.Windows.Forms.Padding(4);
			this.dtGrvProgramList.Name = "dtGrvProgramList";
			this.dtGrvProgramList.RowHeadersWidth = 51;
			this.dtGrvProgramList.RowTemplate.Height = 21;
			this.dtGrvProgramList.Size = new System.Drawing.Size(1629, 628);
			this.dtGrvProgramList.TabIndex = 0;
			this.dtGrvProgramList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrvProgramList_CellValueChanged);
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(1420, 960);
			this.btnExport.Margin = new System.Windows.Forms.Padding(4);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(135, 46);
			this.btnExport.TabIndex = 2;
			this.btnExport.Text = "Export ";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1563, 960);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(135, 46);
			this.button2.TabIndex = 2;
			this.button2.Text = "Exit";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1276, 960);
			this.button3.Margin = new System.Windows.Forms.Padding(4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(135, 46);
			this.button3.TabIndex = 2;
			this.button3.Text = "Clear";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(1420, 916);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(154, 21);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.Text = "Export Program List";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(17, 949);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(135, 46);
			this.button1.TabIndex = 5;
			this.button1.Text = "Setting";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// No
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			this.No.DefaultCellStyle = dataGridViewCellStyle2;
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1713, 1029);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.grbProgramList);
			this.Controls.Add(this.grbSearchInf);
			this.Margin = new System.Windows.Forms.Padding(4);
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
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
  private System.Windows.Forms.DateTimePicker dtpkSinceCommitSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
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

