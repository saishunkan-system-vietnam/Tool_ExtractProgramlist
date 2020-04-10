using ExportSource.Entity;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibGit2Sharp;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace ExportSource
{
    public partial class Form1 : Form
    {

        private string connectionString = string.Empty;
        private char key = Convert.ToChar(@"/");

        public Form1()
        {
            InitializeComponent();
        }

        #region Search Area

        #region Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClearErr();
            this.InitControl();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                chkFileXaml.lstFileExt.Add(value);
            } 

            this.checkBox1.Enabled = false;
        }

        #endregion

        #region  Even Button Open Program list click
        /// <summary>
        /// Even Button Open Program list click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenProgramLstPath_Click(object sender, EventArgs e)
        {
            string fullPathToExcel = string.Empty;

            using (OpenFileDialog dialog = new OpenFileDialog())            {
                
                dialog.Filter = "Exel File | *.xlsx";
                dialog.DefaultExt = "xlsx";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fullPathToExcel = dialog.FileName;
                    this.connectionString = this.GetConneectionString(fullPathToExcel);

                    this.txtProgramLstPath.Text = fullPathToExcel;
                }
            }
        }
        #endregion

        #region  Even Drag program list
        /// <summary>
        /// Even Drag program list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProgramLstPath_DragOver(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                this.connectionString = this.GetConneectionString(files[0]);
                this.txtProgramLstPath.Text = files[0];
            }
        }
        #endregion

        private string GetConneectionString(string filePath)
        {
            string connectionString = string.Empty;
            if (!string.IsNullOrEmpty(filePath))
            {
                connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;\"", filePath);
            }

            return connectionString;
        }

        #region Even Button Open Source Path click
        /// <summary>
        /// Even Button Open Source Path click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenSourcePath_Click(object sender, EventArgs e)
        {
            try
            {
                string path = string.Empty;
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();                    
                    path = fbd.SelectedPath;
                }

                this.txtSourcePath.Text = path;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Even Button Find click
        /// <summary>
        ///  Even Button Find click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            this.ClearErr();
            try
            {
                // Get file code in source
                List<string> lstFile = new List<string>();

                string path = this.txtSourcePath.Text;
                int lengtpath = path.Length;

                FileInfoDs fileInfoDs = new FileInfoDs();

                // Get file name in program list
                int rowCnt = 0;

                if (this.radChkByPrgList.Checked == true)
                {
                    this.dtGrvProgramList.Rows.Clear();
                    String test = txtProgramLstPath.Text;

                    fileInfoDs = this.ReadDataFileExcel(test);
                }
                else if (this.radChkBySource.Checked == true)
                {
                    fileInfoDs = this.FindBySource();
                }

                if (fileInfoDs.FileInfo.Rows.Count <= 0)
                {
                    return;
                }
                this.dtGrvProgramList.Rows.Clear();
                this.dtGrvProgramList.Rows.Add(fileInfoDs.FileInfo.Rows.Count);

                foreach (FileInfoDs.FileInfoRow rows in fileInfoDs.FileInfo.Rows)
                {
                    this.dtGrvProgramList[0, rowCnt].Value = rowCnt + 1;
                    this.dtGrvProgramList[1, rowCnt].Value = string.Empty;
                    this.dtGrvProgramList[2, rowCnt].Value = string.Empty;
                    this.dtGrvProgramList[3, rowCnt].Value = rows.FileUrl;
                    this.dtGrvProgramList[4, rowCnt].Value = rows.FileName;
                    this.dtGrvProgramList[5, rowCnt].Value = rows.status;
                    this.dtGrvProgramList[6, rowCnt].Value = rows.checkexist;
                    if (rows.checkexist == "not exist" || rows.checkexist == "no commit")
                    {

                        this.dtGrvProgramList.Rows[rowCnt].DefaultCellStyle.BackColor = Color.Red;
                    }
                    rowCnt++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region Event check all file in GridView
        /// <summary>
        /// Event check all file in GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxSelectOutPut_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dtGrvProgramList.Rows)
            {
                if (this.chkboxSelectOutPut.Checked == true)
                {
                    this.dtGrvProgramList[7, row.Index].Value = true;
                    this.checkBox1.Enabled = true;

                }
                else
                {
                    this.dtGrvProgramList[7, row.Index].Value = false;
                    this.checkBox1.Enabled = false;
                }
            }
        }
        #endregion

        #region Radio Find By programlist selection
        /// <summary>
        /// Radio Find By programlist selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radChkByPrgList_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radChkByPrgList.Checked == true)
            {
                this.btnOpenProgramLstPath.Enabled = true;
                this.txtProgramLstPath.Enabled = true;
                this.dtpkSinceCommitSource.Enabled = false;
            }
        }
        #endregion

        #region Radio find by source selection
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radChkBySource_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radChkBySource.Checked == true)
            {
                this.btnOpenProgramLstPath.Enabled = false;
                this.txtProgramLstPath.Enabled = false;
                this.txtProgramLstPath.Clear();
                this.dtpkSinceCommitSource.Enabled = true;
            }
        }
        #endregion

        #region Find By Proram List

        private FileInfoDs ReadDataFileExcel(string path)
        {
            ExcelApp.Application excelApp = new ExcelApp.Application();
            FileInfoDs fileInfoDs = new FileInfoDs();
            try
            {
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(path);
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;

                for (int i = 4; i < rows; i++)
                {
                    FileInfoDs.FileInfoRow row = fileInfoDs.FileInfo.NewFileInfoRow();
                    row.FileUrl = excelRange.Cells[i, 5].Value2.ToString();
                    row.FileName = excelRange.Cells[i, 6].Value2.ToString();
                    row.status = excelRange.Cells[i, 8].Value2.ToString();

                    string fullPath = Path.Combine(txtSourcePath.Text, row.FileUrl, row.FileName);

                    if (File.Exists(fullPath))
                    {
                        row.checkexist = "exist";
                    }
                    else
                    {
                        row.checkexist = "not exist";
                    }

                    fileInfoDs.FileInfo.AddFileInfoRow(row);
                }

                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            }
            catch (Exception)
            {
                excelApp.Quit();
                MessageBox.Show("Kiểm tra lại file data");
                return null;
            }
            return fileInfoDs;
        }

        #endregion

        #region Find By PathSource
        /// <summary>
        /// Find By PathSource
        /// </summary>
        /// <returns></returns>
        private FileInfoDs FindBySource()
        {

            FileInfoDs fileInfoDs = new FileInfoDs();
            string repoDir = this.txtSourcePath.Text;
            using (var repo = new Repository(repoDir))
            {
                #region Get Files Un Commit

                foreach (var item in repo.RetrieveStatus())
                {
                    if (chkFileXaml.lstFileExt.Contains(Path.GetExtension(item.FilePath).Trim()))
                    {
                        if (item.State == FileStatus.NewInWorkdir ||
                            item.State == FileStatus.ModifiedInWorkdir ||
                            item.State == FileStatus.NewInIndex ||
                            item.State == FileStatus.ModifiedInIndex)
                        {
                            string strpath = item.FilePath.ToString();
                            string strUrl = strpath.Contains(key) ? @"\" + strpath.Substring(0, strpath.LastIndexOf(key)).Replace(@"/", @"\") : @"\";
                            string strFileName = strpath.Contains(key) ? strpath.Substring(strpath.LastIndexOf(key) + 1) : strpath;

                            string status = string.Empty;
                            if (item.State == FileStatus.NewInWorkdir || item.State == FileStatus.NewInIndex)
                                status = "Add";
                            else if (item.State == FileStatus.ModifiedInWorkdir || item.State == FileStatus.ModifiedInIndex)
                                status = "Update";

                            //var patch = repo.Diff.Compare<Patch>(new List<string>() { item.FilePath });
                            //fileStatusInfos.Add(new FileStatusInfo { FileName = Path.GetFileName(item.FilePath), Status = status });
                            FileInfoDs.FileInfoRow unCommitRow = fileInfoDs.FileInfo.NewFileInfoRow();

                            unCommitRow.FileUrl = strUrl;
                            unCommitRow.FileName = strFileName;
                            unCommitRow.status = status;
                            unCommitRow.checkexist = "no commit";
                            fileInfoDs.FileInfo.AddFileInfoRow(unCommitRow);
                            unCommitRow.AcceptChanges();
                        }
                    }
                }

                #endregion

                #region Get Files Commit

                foreach (Commit commit in repo.Commits.Where(x => x.Committer.When >= dtpkSinceCommitSource.Value.Date).OrderBy(x => x.Committer.When))
                {
                    foreach (var parent in commit.Parents)
                    {
                        foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
                        {
                            FileInfoDs.FileInfoRow fileInfoRow = fileInfoDs.FileInfo.NewFileInfoRow();

                            string strpath = change.Path.ToString();
                            string strUrl = strpath.Contains(key) ? @"\" + strpath.Substring(0, strpath.LastIndexOf(key)).Replace(@"/", @"\") : @"\";
                            string strFileName = strpath.Contains(key) ? strpath.Substring(strpath.LastIndexOf(key) + 1) : strpath;
                            string status = string.Empty;
                            status = change.Status.ToString() == "Modified" ? "Update" : "Add";

                            if (chkFileXaml.lstFileExt.Contains(Path.GetExtension(strpath).Trim()))
                            {
                                FileInfoDs.FileInfoRow rowFilter = fileInfoDs.FileInfo.Where(x => x.FileUrl == strUrl
                                                                                             && x.FileName == strFileName).FirstOrDefault();

                                if (rowFilter == null)
                                {
                                    fileInfoRow.FileUrl = strUrl;
                                    fileInfoRow.FileName = strFileName;
                                    fileInfoRow.status = status;
                                    fileInfoRow.CreateDate = commit.Committer.When.ToString("dd-MM-yyyy");
                                    fileInfoDs.FileInfo.AddFileInfoRow(fileInfoRow);
                                    fileInfoRow.AcceptChanges();
                                }
                            }
                        }
                    }
                }

                #endregion

                return fileInfoDs;
            }
        }
        #endregion

        private Boolean ValidationCheck()
        {
            Boolean isCheck = true;
            if (this.radChkByPrgList.Checked == true)
            {
                if (String.IsNullOrEmpty(this.txtProgramLstPath.Text))
                {
                    this.txtProgramLstPath.BackColor = Color.Red;
                    isCheck = false;
                }
                else if (String.IsNullOrEmpty(this.txtSourcePath.Text))
                {
                    this.txtSourcePath.BackColor = Color.Red;
                    isCheck = false;
                }
            }
            else if (this.radChkBySource.Checked == true)
            {
                if (String.IsNullOrEmpty(this.txtSourcePath.Text))
                {
                    this.txtSourcePath.BackColor = Color.Red;
                    isCheck = false;
                }
            }
            return isCheck;
        }
        private void ClearErr()
        {
            this.txtProgramLstPath.BackColor = Color.White;
            this.txtSourcePath.BackColor = Color.White;
        }
        private void InitControl()
        {
            this.chkboxSelectOutPut.Checked = false;
            this.dtGrvProgramList.Rows.Clear();
        }

        #region PhuongDT

        #region Export Source and ProgramList
        /// <summary>
        /// Button Export ProgramList click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {  
            if (dtGrvProgramList.Rows.Count > 0)
            {
                #region Export Source

                string saveFolderPath = string.Empty;

                using (FolderBrowserDialog directchoosedlg = new FolderBrowserDialog())
                {
                    if (directchoosedlg.ShowDialog() == DialogResult.OK)
                    {
                        saveFolderPath = directchoosedlg.SelectedPath;

                        foreach (DataGridViewRow dgviewRow in dtGrvProgramList.Rows)
                        {
                            if (Convert.ToBoolean(dgviewRow.Cells[7].Value) == true)
                            {

                                string openFile = string.Empty;

                                if (radChkBySource.Checked == true)
                                {
                                    openFile = this.txtSourcePath.Text;
                                }
                                else if (radChkByPrgList.Checked == true)
                                {
                                    openFile = this.txtProgramLstPath.Text;
                                }

                                string sourcePathOrigin = openFile + Convert.ToString(dgviewRow.Cells[3].Value);
                                string sourceFileNameOrigin = Convert.ToString(dgviewRow.Cells[4].Value);
                                string sourceOriginCombine = System.IO.Path.Combine(sourcePathOrigin, sourceFileNameOrigin);

                                if (!System.IO.File.Exists(sourceOriginCombine))
                                {
                                    continue;
                                }

                                string sourcePathSave = Convert.ToString(dgviewRow.Cells[3].Value);
                                string sourcePathSaveCombine = string.Empty;
                                string sourceFileNameSave = sourceFileNameOrigin;

                                string temPath = saveFolderPath + sourcePathSave;

                                if (!System.IO.Directory.Exists(temPath))
                                {
                                    System.IO.Directory.CreateDirectory(temPath);
                                }

                                sourcePathSaveCombine = System.IO.Path.Combine(temPath, sourceFileNameOrigin);

                                System.IO.File.Copy(sourceOriginCombine, sourcePathSaveCombine, true);

                            }
                        }
                    }
                }

                #endregion

                #region Export ProgramList

                if (checkBox1.Checked == true)
                {
                    this.ExportProgramList(saveFolderPath);
                }

                #endregion
            }
        }

        #endregion

        #region ExportProgramList
        private void ExportProgramList(string savePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            try
            {
                // Khởi tạo các object
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet currentWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)currentWorkbook.ActiveSheet;
                currentWorksheet.Columns.ColumnWidth = 18;
                currentWorksheet.Name = "プログラム一覧";

                currentWorksheet.Rows.Font.Name = "ＭＳ Ｐゴシック";
                currentWorksheet.Rows.Font.Size = 11;

                //***************************HEADER*****HEADER*****HEADER*****************************************************
                //************************************************************************************************************
                // Định nghĩa Tên Header
                currentWorksheet.Cells[5, 1] = "No.";
                currentWorksheet.Cells[5, 2] = "Date";
                currentWorksheet.Cells[5, 3] = "REP.";
                currentWorksheet.Cells[5, 4] = "Project Name";
                currentWorksheet.Cells[5, 5] = "Path";
                currentWorksheet.Cells[5, 6] = "File";
                currentWorksheet.Cells[5, 7] = "Function";
                currentWorksheet.Cells[5, 8] = "Add\nUpdate\nDelete";
                currentWorksheet.Cells[5, 9] = "1st Check\nPlan Date";
                currentWorksheet.Cells[5, 10] = "1st Check\nREP";
                currentWorksheet.Cells[5, 11] = "1st Check\nStats";
                currentWorksheet.Cells[5, 12] = "受入検収\n完了予定日";
                currentWorksheet.Cells[5, 13] = "受入検収\n担当者";
                currentWorksheet.Cells[5, 14] = "受入検収\nｽﾃｰﾀｽ";
                currentWorksheet.Cells[5, 15] = "Others";

                // Định nghĩa phạm vi Header
                Microsoft.Office.Interop.Excel.Range headerColumnRange = currentWorksheet.get_Range("A5", "O5");
                currentWorksheet.Range["A3"].Value = currentWorksheet.Name;
                currentWorksheet.Cells[3, 15] = DateTime.Now.ToString("yyyy/MM/dd") + " 現在";

                // Căn chỉnh Header
                //headerColumnRange.Font.Name = "ＭＳ Ｐゴシック";
                //headerColumnRange.Font.Size = 11;
                headerColumnRange.Font.Color = 0xFF0000;

                // Trang điểm cho Header
                Microsoft.Office.Interop.Excel.Borders borderheader = headerColumnRange.Borders;
                borderheader.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borderheader.Weight = 2d;
                FormattingExcelCells(headerColumnRange, "#CCFFCC", System.Drawing.Color.Black, true);
                FormattingExcelCells(currentWorksheet.get_Range("I5", "K5"), "#FFFF00", System.Drawing.Color.Black, true);
                FormattingExcelCells(currentWorksheet.get_Range("L5", "N5"), "#FF99FF", System.Drawing.Color.Black, true);

                headerColumnRange.WrapText = true;
                headerColumnRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                headerColumnRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                //************************************************************************************************************
                //***************************DETAIL*****DETAIL*****DETAIL*****************************************************
                //************************************************************************************************************
                // Trường hợp có data trong Grid

                if (this.dtGrvProgramList.Rows.Count > 0)
                {
                    // Fill nội dung các row
                    int rowIndex = 0;
                    int rowCount = dtGrvProgramList.Rows.Count + 4;
                    int rowNoExcel = 0;
                    Microsoft.Office.Interop.Excel.Range excelCellrange;
                    Microsoft.Office.Interop.Excel.Borders borderdetail;
                    rowNoExcel = 4;
                    for (rowIndex = 4; rowIndex < rowCount; rowIndex++)
                    {

                        DataGridViewRow dgRow = dtGrvProgramList.Rows[rowIndex - 4];

                        if (Convert.ToBoolean(dgRow.Cells[7].Value) == false)
                        {
                            continue;
                        }

                        // No.
                        currentWorksheet.Cells[rowNoExcel + 2, 1] = rowNoExcel - 3;

                        // Date
                        currentWorksheet.Cells[rowNoExcel + 2, 2] = DateTime.Now.ToString("yyyy/MM/dd");

                        // REP.
                        currentWorksheet.Cells[rowNoExcel + 2, 3] = dgRow.Cells[1].Value;

                        // Project Name
                        currentWorksheet.Cells[rowNoExcel + 2, 4] = dgRow.Cells[2].Value;

                        // Path
                        currentWorksheet.Cells[rowNoExcel + 2, 5] = dgRow.Cells[3].Value;

                        // File
                        currentWorksheet.Cells[rowNoExcel + 2, 6] = dgRow.Cells[4].Value;

                        // Function
                        currentWorksheet.Cells[rowNoExcel + 2, 7] = string.Empty;

                        // Add Update Delete
                        currentWorksheet.Cells[rowNoExcel + 2, 8] = dgRow.Cells[5].Value;

                        // 1st Check Plan Date
                        currentWorksheet.Cells[rowNoExcel + 2, 9] = string.Empty;

                        // 1st Check REP
                        currentWorksheet.Cells[rowNoExcel + 2, 10] = string.Empty;

                        // 1st Check Stats
                        currentWorksheet.Cells[rowNoExcel + 2, 11] = string.Empty;

                        // 受入検収 完了予定日
                        currentWorksheet.Cells[rowNoExcel + 2, 12] = string.Empty;

                        // 受入検収 担当者
                        currentWorksheet.Cells[rowNoExcel + 2, 13] = string.Empty;

                        // 受入検収 ｽﾃｰﾀｽ
                        currentWorksheet.Cells[rowNoExcel + 2, 14] = string.Empty;

                        // Others
                        currentWorksheet.Cells[rowNoExcel + 2, 15] = string.Empty;

                        excelCellrange = currentWorksheet.Range[currentWorksheet.Cells[6, 1], currentWorksheet.Cells[rowNoExcel + 2, 15]];
                        borderdetail = excelCellrange.Borders;
                        borderdetail.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        borderdetail.Weight = 2d;
                        excelCellrange.EntireColumn.AutoFit();
                        excelCellrange.EntireRow.AutoFit();

                        rowNoExcel++;
                    }

                    excelCellrange = currentWorksheet.Range[currentWorksheet.Cells[6, 1], currentWorksheet.Cells[rowNoExcel + 2, 15]];
                    currentWorksheet.Range["A3"].EntireColumn.ColumnWidth = 5;

                    excelCellrange.WrapText = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    using (SaveFileDialog exportSaveFileDialog = new SaveFileDialog())
                    {
                        exportSaveFileDialog.Title = "Select Excel File";
                        exportSaveFileDialog.Filter = "Microsoft Office Excel Workbook(*.xlsx)|*.xlsx";

                        string fullFileName = savePath + @"\" + "ProgramList.xlsx";

                        currentWorkbook.SaveAs(fullFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                        currentWorkbook.Saved = true;
                        MessageBox.Show("Export to Excel successful", "Exported to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Data not exist", "Not Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (excelApp != null)
                {
                    excelApp.Quit();
                }
            }
        }

        #endregion

        #region FormattingExcelCells

        private void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }

        #endregion

        #region When click into checkbox in Grid

        private void dtGrvProgramList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtGrvProgramList.Rows)
            {
                if (Convert.ToBoolean(row.Cells[7].Value) == true)
                {
                    this.checkBox1.Enabled = true;
                    break;
                }
                else
                {
                    this.checkBox1.Enabled = false;
                }
            }
        }

        #endregion

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Setting Extention file

        private void button1_Click(object sender, EventArgs e)
        {
            chkFileXaml chkFileXaml = new chkFileXaml();
            chkFileXaml.ShowDialog();
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearErr();
            this.InitControl();
            this.txtProgramLstPath.Text = string.Empty;
            this.txtSourcePath.Text = string.Empty;
        }
    }
}
