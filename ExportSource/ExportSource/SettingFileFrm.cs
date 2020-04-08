using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace ExportSource
{
    public partial class chkFileXaml : Form
    {
        // Danh sach duoi file 
        public static HashSet<String> lstFileExt = new HashSet<string>();
        public chkFileXaml()
        {
            InitializeComponent();
        }

        private void chkFileXaml_Load(object sender, EventArgs e)
        {
            foreach (String keyAppConfig in lstFileExt )
            {
                foreach (Control ctrl in this.Controls)
                {
                    CheckBox chk = ctrl as CheckBox;

                    if (chk != null)
                    {
                        if (keyAppConfig == chk.Text)
                        {
                            chk.Checked = true;
                        }
                    }
                }
            }            
        }

        private void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkboxSelectAll.Checked == true)
            {
                foreach (Control ctrl in this.Controls)
                {
                    CheckBox chk = ctrl as CheckBox;
                    if (chk != null)
                    {
                        chk.Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control ctrl in this.Controls)
                {
                    CheckBox chk = ctrl as CheckBox;
                    if (chk != null)
                    {
                        chk.Checked = false;
                    }
                }
            }
        }

        private void chkFileXaml_FormClosed(object sender, FormClosedEventArgs e)
        {
            string filePath = System.IO.Path.GetFullPath("App.config").Replace("\\bin\\Debug","");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            bool isAddFlg = true;

            foreach (Control ctrl in this.Controls)
            {
                isAddFlg = true;

                CheckBox chk = ctrl as CheckBox;
                if (chk != null && chk.Checked == true)
                {
                    // Add a file extention to App.config
                    try
                    {
                        // Existed file
                        foreach (String key in lstFileExt)
                        {
                            if (key == chk.Text)
                            {
                                isAddFlg = false;
                                break ;
                            }
                        }

                        if (isAddFlg == true)
                        {
                            // Add an Application Setting if not exist
                            config.AppSettings.Settings.Add(chk.Text.Replace(".", ""), chk.Text);
                            lstFileExt.Add(chk.Text);
                        }
                    }
                    catch (ConfigurationErrorsException ex)
                    {
                        if (ex.BareMessage == "Root element is missing.")
                        {
                            File.Delete(filePath);
                            return;
                        }
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
        
    }
}
