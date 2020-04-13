namespace ExportSource
{
 partial class SettingFileFrm
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtListKey = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Input file you want to use";
			// 
			// txtListKey
			// 
			this.txtListKey.Location = new System.Drawing.Point(24, 45);
			this.txtListKey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtListKey.Multiline = true;
			this.txtListKey.Name = "txtListKey";
			this.txtListKey.Size = new System.Drawing.Size(151, 208);
			this.txtListKey.TabIndex = 12;
			// 
			// SettingFileFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(197, 266);
			this.Controls.Add(this.txtListKey);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "SettingFileFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SettingFileFrm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chkFileXaml_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

  }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtListKey;
    }
}