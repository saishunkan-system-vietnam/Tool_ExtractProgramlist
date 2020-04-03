using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

   lstFileExt.Clear();
   foreach (Control ctrl in this.Controls)
   {
    CheckBox chk = ctrl as CheckBox;
    if (chk != null && chk.Checked == true)
    {
    lstFileExt.Add(chk.Text);
    }
   }
  }

 }
}
