using ExportSource.Entity;
using System;
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
    public partial class MainFrm : Form
    {
        private char forwardSlashChar = '/';

        struct ApConst
        {
            #region Status File
            public static string NotExistStatus = "Not Exist";
            public static string ExistStatus = "Exist";
            public static string NotcommitStatus = "Not commit";
            public static string NotExistInExcel = "Not Exist inExcel";
            #endregion

            #region Species File
            public static string AddStatus = "Add";
            public static string UpdateStatus = "Update";
            public static string DeleteStatus = "Delete";
            public static string RenameStatus = "Rename";
            #endregion

            #region FileSetting
            public static string FolderFileSetting = @"C:\ProgramData\SSV\";
            public static string RelativeFolderSetting = @"FileSetting";
            public static string FileNameSetting = @"ExtensionSetting.ini";
            public static string FullFolderSetting = Path.Combine(FolderFileSetting, RelativeFolderSetting);
            public static string FullFilePathSetting = Path.Combine(FullFolderSetting, FileNameSetting);
            #endregion
        }

        struct GrvColumnName
        {
            public static int DRV_NO = 0;
            public static int DRV_PATH = 1;
            public static int DRV_FILE_NAME = 2;
            public static int DRV_STATUS = 3;
            public static int DRV_CHECK_EXIST = 4;
            public static int DRV_COMMITER = 5;
            public static int DRV_CHKBOX_SELECT = 6;
        }

        private string extSettingPath = string.Empty;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void CopyFileSetting(string destFileSetting)
        {
            //Run in debug
            string appFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
            string sourceFileSetting = Path.Combine(appFolder.Replace(@"\bin", ""), ApConst.RelativeFolderSetting, ApConst.FileNameSetting);
            // End Run in debug

            //string appFolder = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
            //string sourceFileSetting = Path.Combine(appFolder, ApConst.RelativeFolderSetting, ApConst.FileNameSetting);

            if (!Directory.Exists(ApConst.FullFolderSetting))
            {
                Directory.CreateDirectory(ApConst.FullFolderSetting);
            }

            if (!File.Exists(destFileSetting))
            {
                File.Copy(sourceFileSetting, destFileSetting, true);
            }
        }

        public void LoadSetting(out string outFilePathSetting)
        {
            if (!File.Exists(ApConst.FullFilePathSetting))
            {
                this.CopyFileSetting(ApConst.FullFilePathSetting);
            }
            outFilePathSetting = ApConst.FullFilePathSetting;
        }

        #region Search Area

        #region Load Form
        private void Form_Load(object sender, EventArgs e)
        {
            this.ClearErr();
            this.InitControl();
            LoadSetting(out extSettingPath);
        }

        private void InitControl()
        {
            this.chkboxSelectOutPut.Checked = false;
            this.dtGrvProgramList.Rows.Clear();
            this.MaximizeBox = false;
            this.chkExportProgramList.Checked = false;
            this.chkExportSource.Checked = false;
            this.dtGrvProgramList.RowHeadersVisible = false;
            this.FindBySourceCheck();
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

            using (OpenFileDialog dialog = new OpenFileDialog())
            {

                dialog.Filter = "Exel File | *.xlsx";
                dialog.DefaultExt = "xlsx";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtProgramLstPath.Text = dialog.FileName;
                }
            }
        }
        #endregion

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

                this.dtGrvProgramList.Rows.Clear();
                if (this.radChkByPrgList.Checked == true)
                {
                    fileInfoDs = this.FindByProgramList(txtProgramLstPath.Text);

                    FileInfoDs fileInfoDsSource = new FileInfoDs();

                    fileInfoDsSource = this.FindBySource();

                    foreach (FileInfoDs.FileInfoRow dataSourceRow in fileInfoDsSource.FileInfo.Rows)
                    {
                        var isFileExcelExistInSource = fileInfoDs.FileInfo.Where(x => x.FileName == dataSourceRow.FileName).FirstOrDefault();
                        if (isFileExcelExistInSource == null)
                        {
                            dataSourceRow.checkexist = ApConst.NotExistInExcel;
                            fileInfoDs.FileInfo.ImportRow(dataSourceRow);
                        }
                    }
                }
                else if (this.radChkBySource.Checked == true)
                {
                    fileInfoDs = this.FindBySource();
                }

                if (fileInfoDs.FileInfo.Rows.Count <= 0)
                {
                    return;
                }

                foreach (FileInfoDs.FileInfoRow rows in fileInfoDs.FileInfo.Rows)
                {
                    string commiter = (rows["Commiter"] == DBNull.Value ? string.Empty : rows.Commiter);
                    // Add data in new Row
                    dtGrvProgramList.Rows.Add(rowCnt + 1, rows.FileUrl, rows.FileName, rows.status, rows.checkexist, commiter);
                    if (rows.checkexist == ApConst.NotExistStatus ||
                         rows.checkexist == ApConst.NotExistInExcel)
                    {
                        this.dtGrvProgramList.Rows[rowCnt].DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (rows.checkexist == ApConst.NotcommitStatus)
                    {
                        this.dtGrvProgramList.Rows[rowCnt].DefaultCellStyle.ForeColor = Color.Red;
                        this.dtGrvProgramList.Rows[rowCnt].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (rows.checkexist == ApConst.NotExistStatus)
                    {
                        (this.dtGrvProgramList.Rows[rowCnt].Cells[GrvColumnName.DRV_CHKBOX_SELECT]).ReadOnly = true;
                    }
                    rowCnt++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                this.txtProgramLstPath.Text = files[0];
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
                    if (this.dtGrvProgramList[GrvColumnName.DRV_CHECK_EXIST, row.Index].Value.ToString() != ApConst.NotExistStatus)
                    {
                        this.dtGrvProgramList[GrvColumnName.DRV_CHKBOX_SELECT, row.Index].Value = true;
                        this.chkExportProgramList.Checked = true;
                        this.chkExportSource.Checked = true;
                    }
                }
                else
                {
                    this.dtGrvProgramList[GrvColumnName.DRV_CHKBOX_SELECT, row.Index].Value = false;
                    //this.chkExportProgramList.Checked = false;
                }
            }
        }
        #endregion

        #region Radio Find By programlist selection
        /// <summary>
        /// Tìm kiếm dựa theo programlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radChkByPrgList_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radChkByPrgList.Checked == true)
            {
                this.btnOpenProgramLstPath.Enabled = true;
                this.txtProgramLstPath.Enabled = true;
            }
        }
        #endregion

        #region Radio find by source selection
        /// <summary>
        /// Tìm kiếm từ source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radChkBySource_CheckedChanged(object sender, EventArgs e)
        {
            this.FindBySourceCheck();
        }

        private void FindBySourceCheck()
        {
            if (this.radChkBySource.Checked == true)
            {
                this.btnOpenProgramLstPath.Enabled = false;
                this.txtProgramLstPath.Enabled = false;
                this.txtProgramLstPath.Clear();
            }
        }
        #endregion

        #region Find By Proram List

        /// <summary>
        /// Tìm kiếm file theo đường dẫn programlist
        /// </summary>
        /// <param name="programListPath"></param>
        /// <returns></returns>
        private FileInfoDs FindByProgramList(string programListPath)
        {
            ExcelApp.Application excelApp = new ExcelApp.Application();
            FileInfoDs fileInfoDs = new FileInfoDs();
            try
            {
                ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(programListPath);
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;

                for (int i = 4; i < rows; i++)
                {
                    FileInfoDs.FileInfoRow row = fileInfoDs.FileInfo.NewFileInfoRow();
                    row.FileUrl = excelRange.Cells[i, 5].Value2.ToString();
                    row.FileName = excelRange.Cells[i, 6].Value2.ToString();
                    row.status = excelRange.Cells[i, 8].Value2.ToString();

                    // ghép đường dẫn tương đối
                    string relativePath = Path.Combine(row.FileUrl, row.FileName);

                    // ghép full đương dẫn file(đường dẫn tương đối có \\ đằng trước nên ko combine được)
                    string absolutePath = string.Format("{0}{1}", txtSourcePath.Text, relativePath);

                    row.checkexist = File.Exists(absolutePath) ? ApConst.ExistStatus : ApConst.NotExistStatus;

                    fileInfoDs.FileInfo.AddFileInfoRow(row);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Check File Data Again!");
                return null;
            }
            finally
            {
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
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

            List<string> lstFileKey = new List<string>(File.ReadAllLines(extSettingPath));

            using (var repo = new Repository(repoDir))
            {
                #region Get Files Un Commit

                foreach (var item in repo.RetrieveStatus())
                {
                    if (lstFileKey.Contains(Path.GetExtension(item.FilePath).Trim()))
                    {
                        if (item.State == FileStatus.NewInWorkdir ||
                            item.State == FileStatus.ModifiedInWorkdir ||
                            item.State == FileStatus.NewInIndex ||
                            item.State == FileStatus.ModifiedInIndex)
                        {
                            string gitFolderPath = item.FilePath.ToString();
                            string displayFolderPath = gitFolderPath.Contains(forwardSlashChar) ? @"\" +
                                                    gitFolderPath.Substring(0, gitFolderPath.LastIndexOf(forwardSlashChar)).Replace(@"/", @"\") : @"\";
                            if (CheckInvalidFiles(displayFolderPath))
                            {
                                continue;
                            }

                            string strFileName = gitFolderPath.Contains(forwardSlashChar) ? gitFolderPath.Substring(gitFolderPath.LastIndexOf(forwardSlashChar) + 1) : gitFolderPath;
                            if (CheckInvalidFiles(strFileName))
                            {
                                continue;
                            }

                            string status = string.Empty;
                            if (item.State == FileStatus.NewInWorkdir || item.State == FileStatus.NewInIndex)
                                status = ApConst.AddStatus;
                            else if (item.State == FileStatus.ModifiedInWorkdir || item.State == FileStatus.ModifiedInIndex)
                                status = ApConst.UpdateStatus;

                            FileInfoDs.FileInfoRow unCommitRow = fileInfoDs.FileInfo.NewFileInfoRow();

                            unCommitRow.FileUrl = displayFolderPath;
                            unCommitRow.FileName = strFileName;
                            unCommitRow.status = status;
                            unCommitRow.checkexist = ApConst.NotcommitStatus;
                            fileInfoDs.FileInfo.AddFileInfoRow(unCommitRow);
                            unCommitRow.AcceptChanges();
                        }
                    }
                }

                #endregion

                #region Get Files Commit

                var test = repo.Commits.Where(x => x.Committer.When >= DateTimeGetChangeControl.Value.Date).OrderBy(x => x.Committer.When);

                foreach (Commit commit in repo.Commits.Where(x => x.Committer.When >= DateTimeGetChangeControl.Value.Date).OrderBy(x => x.Committer.When))
                {
                    string commiter = commit.Committer.Name;

                    foreach (var parent in commit.Parents)
                    {
                        foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
                        {
                            FileInfoDs.FileInfoRow fileInfoRow = fileInfoDs.FileInfo.NewFileInfoRow();

                            string gitFolderPath = change.OldPath.ToString();
                            if (CheckInvalidFiles(gitFolderPath))
                            {
                                continue;
                            }

                            string displayFolderPath = gitFolderPath.Contains(forwardSlashChar) ? @"\" +
                                                 gitFolderPath.Substring(0, gitFolderPath.LastIndexOf(forwardSlashChar)).Replace(@"/", @"\") : @"\";
                            if (CheckInvalidFiles(displayFolderPath))
                            {
                                continue;
                            }

                            string strFileName = gitFolderPath.Contains(forwardSlashChar) ?
                                                    gitFolderPath.Substring(gitFolderPath.LastIndexOf(forwardSlashChar) + 1) : gitFolderPath;
                            if (CheckInvalidFiles(strFileName))
                            {
                                continue;
                            }

                            string gitFolderNewPath = string.Empty;
                            string displayFolderNewPath = string.Empty;
                            string strNewFileName = string.Empty;

                            if (change.OldPath.ToString() != change.Path.ToString())
                            {
                                gitFolderNewPath = change.Path.ToString();
                                displayFolderNewPath = gitFolderNewPath.Contains(forwardSlashChar) ? @"\" +
                                                 gitFolderNewPath.Substring(0, gitFolderNewPath.LastIndexOf(forwardSlashChar)).Replace(@"/", @"\") : @"\";

                                strNewFileName = gitFolderNewPath.Contains(forwardSlashChar) ?
                                                    gitFolderNewPath.Substring(gitFolderNewPath.LastIndexOf(forwardSlashChar) + 1) : gitFolderNewPath;
                            }

                            string status = this.GetStatusToGit(change.Status);

                            if (lstFileKey.Contains(Path.GetExtension(gitFolderPath).Trim()))
                            {
                                // kiểm tra file đã tồn tại trên grid hay chưa
                                FileInfoDs.FileInfoRow rowFileExist = fileInfoDs.FileInfo.Where(x => x.FileUrl == displayFolderPath
                                                                                             && x.FileName == strFileName).FirstOrDefault();

                                if (rowFileExist == null)
                                {
                                    fileInfoRow.FileUrl = displayFolderPath;
                                    fileInfoRow.FileName = strFileName;
                                    fileInfoRow.status = status;
                                    fileInfoRow.Commiter = commiter;
                                    fileInfoDs.FileInfo.AddFileInfoRow(fileInfoRow);
                                    fileInfoRow.AcceptChanges();
                                }
                                else
                                {
                                    if (status == ApConst.DeleteStatus)
                                    {
                                        fileInfoDs.FileInfo.Rows.Remove(rowFileExist);
                                    }
                                    else if (status == ApConst.RenameStatus)
                                    {
                                        rowFileExist.BeginEdit();
                                        rowFileExist.FileUrl = displayFolderNewPath;
                                        rowFileExist.FileName = strNewFileName;
                                        rowFileExist.Commiter = commiter;
                                        rowFileExist.EndEdit();
                                        fileInfoDs.FileInfo.AcceptChanges();
                                    }
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

        #region Funcions Child

        private bool CheckInvalidFiles(string strCheck)
        {
            if (strCheck.Contains(@"\bin\")
               || strCheck.Contains(@"\obj\")
               || strCheck.Contains(@"\.vs\")
               || strCheck.Contains(@"~$")
               || strCheck.Contains(".suo"))
            {
                return true;
            }
            return false;
        }

        private string GetStatusToGit(ChangeKind kind)
        {
            string status = string.Empty;

            if (kind == LibGit2Sharp.ChangeKind.Modified)
            {
                status = ApConst.UpdateStatus;
            }
            else if (kind == LibGit2Sharp.ChangeKind.Added)
            {
                status = ApConst.AddStatus;
            }
            else if (kind == LibGit2Sharp.ChangeKind.Deleted)
            {
                status = ApConst.DeleteStatus;
            }
            else if (kind == LibGit2Sharp.ChangeKind.Renamed)
            {
                status = ApConst.RenameStatus;
            }

            return status;
        }

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

        #endregion

        #region PhuongDT

        #region Event Click Button Export Source and ProgramList
        /// <summary>
        /// Button Export ProgramList click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtGrvProgramList.Rows.Count > 0)
            {
                using (FolderBrowserDialog directchoosedlg = new FolderBrowserDialog())
                {
                    if (directchoosedlg.ShowDialog() == DialogResult.OK)
                    {
                        string exportFoderPath = directchoosedlg.SelectedPath;

                        int fileCount = Directory.GetFiles(exportFoderPath).Length;
                        if (fileCount > 0)
                        {
                            if ((MessageBox.Show("The selected folder seem already contain files, Do you want to remove all", "Folder not empty",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes))
                            {
                                DirectoryInfo directoryInfo = new DirectoryInfo(exportFoderPath);
                                directoryInfo.EnumerateDirectories().ToList().ForEach(folder => folder.Delete(true));
                                directoryInfo.EnumerateFiles().ToList().ForEach(file => file.Delete());
                            }
                            else
                            {
                                return;
                            }
                        }


                        if (chkExportSource.Checked == false && chkExportProgramList.Checked == false)
                        {
                            MessageBox.Show("Please specify target export. Source or programlist");
                        }

                        if (chkExportSource.Checked == true)
                        {
                            this.ExportSource(exportFoderPath);
                        }

                        if (chkExportProgramList.Checked == true)
                        {
                            this.ExportProgramList(exportFoderPath);
                        }
                    }
                }
            }
        }
        #endregion

        #region Export Source
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exportPath"></param>
        private void ExportSource(string exportPath)
        {
            foreach (DataGridViewRow dgviewRow in dtGrvProgramList.Rows)
            {
                if (Convert.ToBoolean(dgviewRow.Cells[6].Value) == true)
                {
                    string programListPath = dgviewRow.Cells[1].Value.ToString();
                    string programListFileName = dgviewRow.Cells[2].Value.ToString();

                    // Tạo đường dẫn file từ source
                    string sourceRelativePath = Path.Combine(programListPath, programListFileName);
                    string sourceAbsolutePath = string.Format("{0}{1}", txtSourcePath.Text, sourceRelativePath);

                    if (!File.Exists(sourceAbsolutePath))
                    {
                        // add vào list để thông báo lỗi
                        continue;
                    }

                    // tạo đường dẫn file copy đến
                    string targetAbsoluteFolder = string.Format("{0}{1}", exportPath, programListPath);
                    string targetAbsolutePath = Path.Combine(targetAbsoluteFolder, programListFileName);
                    try
                    {
                        if (!Directory.Exists(targetAbsoluteFolder))
                        {
                            Directory.CreateDirectory(targetAbsoluteFolder);
                        }
                        File.Copy(sourceAbsolutePath, targetAbsolutePath, true);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }
        #endregion

        #region Event Click Button Setting Extention file

        private void btnSetting__Click(object sender, EventArgs e)
        {
            SettingFileFrm settingFileFrm = new SettingFileFrm();
            settingFileFrm.Show();
        }

        #endregion

        #region ExportProgramList
        /// <summary>
        /// Output file programlist
        /// </summary>
        /// <param name="savePath"></param>
        private void ExportProgramList(string saveFilePath)
        {
            ExcelApp.Application excelApp = null;
            // Create New File Excel
            excelApp = new ExcelApp.Application();
            ExcelApp.Workbook currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
            try
            {
                // Khởi tạo các object
                // ExcelApp.Workbook currentWorkbook = excelApp.Workbooks.Add(Type.Missing);
                ExcelApp.Worksheet currentWorksheet = (ExcelApp.Worksheet)currentWorkbook.ActiveSheet;
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
                ExcelApp.Range headerColumnRange = currentWorksheet.get_Range("A5", "O5");
                currentWorksheet.Range["A3"].Value = currentWorksheet.Name;
                currentWorksheet.Cells[3, 15] = DateTime.Now.ToString("yyyy/MM/dd") + " 現在";

                // Căn chỉnh Header
                //headerColumnRange.Font.Name = "ＭＳ Ｐゴシック";
                //headerColumnRange.Font.Size = 11;
                headerColumnRange.Font.Color = 0xFF0000;

                // Trang điểm cho Header
                ExcelApp.Borders borderheader = headerColumnRange.Borders;
                borderheader.LineStyle = ExcelApp.XlLineStyle.xlContinuous;
                borderheader.Weight = 2d;
                FormattingExcelCells(headerColumnRange, "#CCFFCC", System.Drawing.Color.Black, true);
                FormattingExcelCells(currentWorksheet.get_Range("I5", "K5"), "#FFFF00", System.Drawing.Color.Black, true);
                FormattingExcelCells(currentWorksheet.get_Range("L5", "N5"), "#FF99FF", System.Drawing.Color.Black, true);

                headerColumnRange.WrapText = true;
                headerColumnRange.HorizontalAlignment = ExcelApp.XlHAlign.xlHAlignCenter;
                headerColumnRange.VerticalAlignment = ExcelApp.XlHAlign.xlHAlignCenter;


                //************************************************************************************************************
                //***************************DETAIL*****DETAIL*****DETAIL*****************************************************
                //************************************************************************************************************
                // Trường hợp có data trong Grid

                #region export
                if (this.dtGrvProgramList.Rows.Count > 0)
                {
                    // Fill nội dung các row
                    int rowIndex = 0;
                    int rowCount = dtGrvProgramList.Rows.Count + 4;
                    int rowNoExcel = 0;
                    ExcelApp.Range excelCellrange;
                    ExcelApp.Borders borderdetail;
                    rowNoExcel = 4;
                    for (rowIndex = 4; rowIndex < rowCount; rowIndex++)
                    {

                        DataGridViewRow dgRow = dtGrvProgramList.Rows[rowIndex - 4];

                        if (Convert.ToBoolean(dgRow.Cells[GrvColumnName.DRV_CHKBOX_SELECT].Value) == false)
                        {
                            continue;
                        }
                        if ( dgRow.Cells[GrvColumnName.DRV_CHECK_EXIST].Value.ToString() == ApConst.NotExistStatus)
                        {
                            continue;
                        }

                        // Set Color for Row Not Commit
                        if (chkExportProgramList.Checked == true
                            && dgRow.Cells[4].Value.ToString() == ApConst.NotcommitStatus)
                        {
                            FormattingExcelCells(currentWorksheet.get_Range("A" + (rowNoExcel + 2).ToString(), "H" + (rowNoExcel + 2)), "#FFFF00", System.Drawing.Color.Red, true);
                        }

                        // No.
                        currentWorksheet.Cells[rowNoExcel + 2, 1] = dgRow.Cells[GrvColumnName.DRV_NO].Value;

                        // Date
                        currentWorksheet.Cells[rowNoExcel + 2, 2] = DateTime.Now.ToString("yyyy/MM/dd");

                        // REP.
                        currentWorksheet.Cells[rowNoExcel + 2, 3] = dgRow.Cells[GrvColumnName.DRV_COMMITER].Value;

                        // Project Name
                        currentWorksheet.Cells[rowNoExcel + 2, 4] = string.Empty;

                        // Path
                        currentWorksheet.Cells[rowNoExcel + 2, 5] = dgRow.Cells[GrvColumnName.DRV_PATH].Value;

                        // File
                        currentWorksheet.Cells[rowNoExcel + 2, 6] = dgRow.Cells[GrvColumnName.DRV_FILE_NAME].Value;

                        // Function
                        currentWorksheet.Cells[rowNoExcel + 2, 7] = string.Empty;

                        // Add Update Delete
                        currentWorksheet.Cells[rowNoExcel + 2, 8] = dgRow.Cells[GrvColumnName.DRV_STATUS].Value;

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
                        borderdetail.LineStyle = ExcelApp.XlLineStyle.xlContinuous;
                        borderdetail.Weight = 2d;
                        excelCellrange.EntireColumn.AutoFit();
                        excelCellrange.EntireRow.AutoFit();

                        rowNoExcel++;
                    }

                    excelCellrange = currentWorksheet.Range[currentWorksheet.Cells[6, 1], currentWorksheet.Cells[rowNoExcel + 2, 15]];
                    currentWorksheet.Range["A3"].EntireColumn.ColumnWidth = 5;

                    excelCellrange.WrapText = true;
                    excelCellrange.HorizontalAlignment = ExcelApp.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = ExcelApp.XlHAlign.xlHAlignCenter;

                    string fullFileName = Path.Combine(saveFilePath, "ProgramList.xlsx");

                    currentWorkbook.SaveAs(fullFileName, ExcelApp.XlFileFormat.xlOpenXMLWorkbook,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false,
                        ExcelApp.XlSaveAsAccessMode.xlNoChange,
                        ExcelApp.XlSaveConflictResolution.xlUserResolution, true,
                        System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                    currentWorkbook.Saved = true;
                    MessageBox.Show("Export Succes");
                }
                #endregion

            }
            catch (Exception ex)
            {
                currentWorkbook.Saved = true;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        #endregion

        #region FormattingExcelCells
        /// <summary>
        /// Add style cho file excel
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        private void FormattingExcelCells(ExcelApp.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
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

        /// <summary>
        /// Sự kiện chọn checkbox trên data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtGrvProgramList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtGrvProgramList.Rows)
            {
                if (Convert.ToBoolean(row.Cells[GrvColumnName.DRV_CHKBOX_SELECT].Value) == true)
                {
                    this.chkExportProgramList.Checked = true;
                    this.chkExportSource.Checked = true;
                    break;
                }
                else
                {
                    this.chkExportProgramList.Checked = false;
                    this.chkExportSource.Checked = false;
                }
            }
        }

        #endregion

        #region Event Click Button Clear

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearErr();
            this.InitControl();
            this.txtProgramLstPath.Text = string.Empty;
            this.txtSourcePath.Text = string.Empty;
        }

        #endregion

        #endregion

    }
}
