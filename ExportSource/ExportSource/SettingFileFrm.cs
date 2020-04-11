using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace ExportSource
{
	public partial class SettingFileFrm : Form
	{
		private List<string> listKey = null;

		string fullPath = string.Empty;

		public SettingFileFrm()
		{
			InitializeComponent();
			txtListKey.ScrollBars = ScrollBars.Both;
			LoadKeyConfig();
		}

		private void LoadKeyConfig()
		{
			fullPath = Path.GetFullPath("InputFileExtension.txt").Replace("\\bin\\Debug", "\\FileText");
			listKey = new List<string>(File.ReadAllLines(fullPath));

			foreach (string i in listKey)
			{
				txtListKey.Text += i + "\r\n";
			}
		}

		private string[] ListAllKey(string content)
		{
			string[] stringSeparators = new string[] { "\r\n" };

			return content.Split(stringSeparators, StringSplitOptions.None);
		}

		private void chkFileXaml_FormClosed(object sender, FormClosedEventArgs e)
		{
			List<string> items = new List<string>(ListAllKey(txtListKey.Text));

			using (StreamWriter writer = new StreamWriter(fullPath))
			{
				foreach (string key in items)
				{
					// Add new line
					if (!String.IsNullOrEmpty(key))
					{
						writer.WriteLine(key);
					}
				}

				writer.Dispose();
			}
		}
	}
}