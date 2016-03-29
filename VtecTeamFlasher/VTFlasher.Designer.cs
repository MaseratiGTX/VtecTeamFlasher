using System.Drawing;
namespace VtecTeamFlasher
{
    partial class VTFlasher
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.cbAdapter = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbModules = new System.Windows.Forms.ComboBox();
            this.lbAdapter = new System.Windows.Forms.Label();
            this.btnResetAdaptation = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnEraseErrors = new System.Windows.Forms.Button();
            this.btnReadErrors = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbControlSum = new System.Windows.Forms.CheckBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnReadFromECU = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabNews = new System.Windows.Forms.TabPage();
            this.pbNews = new System.Windows.Forms.PictureBox();
            this.btnRefreshNews = new System.Windows.Forms.Button();
            this.tlNews = new DevExpress.XtraTreeList.TreeList();
            this.colInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.lblNews = new System.Windows.Forms.Label();
            this.tabReflash = new System.Windows.Forms.TabPage();
            this.tabControlReflash = new System.Windows.Forms.TabControl();
            this.tabReflashCar = new System.Windows.Forms.TabPage();
            this.panelReflash = new System.Windows.Forms.Panel();
            this.btnCreateNewRequest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnUploadToECU = new System.Windows.Forms.Button();
            this.lblBinaryLoadingStatus = new System.Windows.Forms.Label();
            this.btnUploadBinary = new System.Windows.Forms.Button();
            this.lbModule = new System.Windows.Forms.Label();
            this.tbReflashText = new System.Windows.Forms.TextBox();
            this.tbECUVin = new System.Windows.Forms.TextBox();
            this.lbVIN = new System.Windows.Forms.Label();
            this.tbBinaryNumber = new System.Windows.Forms.TextBox();
            this.lbECUBinaryNumber = new System.Windows.Forms.Label();
            this.panelKeyUnavailible = new System.Windows.Forms.Panel();
            this.labelKeyUnavailible = new System.Windows.Forms.Label();
            this.btnReloadFlasher = new System.Windows.Forms.Button();
            this.tabReflashUpload = new System.Windows.Forms.TabPage();
            this.panelLoadBinary = new System.Windows.Forms.Panel();
            this.btnSearchReflashFile = new System.Windows.Forms.Button();
            this.txtEcuNumbertoSearch = new System.Windows.Forms.TextBox();
            this.lblEcuNumbertoSearch = new System.Windows.Forms.Label();
            this.lblChooseBinarytoUpload = new System.Windows.Forms.Label();
            this.btnBinaryDescriptionOK = new System.Windows.Forms.Button();
            this.btnBinaryDescriptionCancel = new System.Windows.Forms.Button();
            this.gbBinaryDescription = new System.Windows.Forms.GroupBox();
            this.pbReflash = new System.Windows.Forms.PictureBox();
            this.cbBinaryDescriptionImmoOff = new System.Windows.Forms.CheckBox();
            this.cbBinaryDescriptionEGROff = new System.Windows.Forms.CheckBox();
            this.cbBinaryDescriptionEuro2 = new System.Windows.Forms.CheckBox();
            this.txtBinaryDescription = new System.Windows.Forms.TextBox();
            this.cbBinaryDescriptionCS = new System.Windows.Forms.CheckBox();
            this.lblChooseBinary = new System.Windows.Forms.Label();
            this.cbBinaryToLoad = new System.Windows.Forms.ComboBox();
            this.tabRequest = new System.Windows.Forms.TabPage();
            this.pnlSendRequest = new System.Windows.Forms.Panel();
            this.lblCreateRequest = new System.Windows.Forms.Label();
            this.btnRequestUploadEcuPhoto = new System.Windows.Forms.Button();
            this.lblCarDescription = new System.Windows.Forms.Label();
            this.txtRequestCarDescription = new System.Windows.Forms.TextBox();
            this.txtEcuPhotoStatus = new System.Windows.Forms.TextBox();
            this.txtEcuBinaryNumber = new System.Windows.Forms.TextBox();
            this.lblEcuPhoto = new System.Windows.Forms.Label();
            this.lblBinaryNumber = new System.Windows.Forms.Label();
            this.lblEcuNumber = new System.Windows.Forms.Label();
            this.txtEcuNumber = new System.Windows.Forms.TextBox();
            this.pbRequest = new System.Windows.Forms.PictureBox();
            this.lblAdditionalInfo = new System.Windows.Forms.Label();
            this.txtAdditionalInfo = new System.Windows.Forms.TextBox();
            this.txtStockFilePath = new System.Windows.Forms.TextBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.lblStockFile = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.tabControlHistory = new System.Windows.Forms.TabControl();
            this.tabReflashHistory = new System.Windows.Forms.TabPage();
            this.panelRequestHistory = new System.Windows.Forms.Panel();
            this.pbReflashHistory = new System.Windows.Forms.PictureBox();
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.dgReflashHistory = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reflashDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.binaryFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSendReview = new System.Windows.Forms.DataGridViewButtonColumn();
            this.reflashHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabRequestHistory = new System.Windows.Forms.TabPage();
            this.pnlRequestsHistory = new System.Windows.Forms.Panel();
            this.dgRequests = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.reflashRequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            this.pbRequestHistory = new System.Windows.Forms.PictureBox();
            this.tabPerson = new System.Windows.Forms.TabPage();
            this.pbPersonalInfo = new System.Windows.Forms.PictureBox();
            this.tbUserKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateUserDetails = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserCity = new System.Windows.Forms.TextBox();
            this.cbUserWhatsapp = new System.Windows.Forms.CheckBox();
            this.cbUserViber = new System.Windows.Forms.CheckBox();
            this.tbUserVK = new System.Windows.Forms.TextBox();
            this.tbUserSkype = new System.Windows.Forms.TextBox();
            this.tbUserPhone = new System.Windows.Forms.TextBox();
            this.tbUserSecondName = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.pbLogin = new System.Windows.Forms.PictureBox();
            this.lblErrLogin = new System.Windows.Forms.Label();
            this.checkBoxSavePassword = new System.Windows.Forms.CheckBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabNews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlNews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.tabReflash.SuspendLayout();
            this.tabControlReflash.SuspendLayout();
            this.tabReflashCar.SuspendLayout();
            this.panelReflash.SuspendLayout();
            this.panelKeyUnavailible.SuspendLayout();
            this.tabReflashUpload.SuspendLayout();
            this.panelLoadBinary.SuspendLayout();
            this.gbBinaryDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReflash)).BeginInit();
            this.tabRequest.SuspendLayout();
            this.pnlSendRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequest)).BeginInit();
            this.tabHistory.SuspendLayout();
            this.tabControlHistory.SuspendLayout();
            this.tabReflashHistory.SuspendLayout();
            this.panelRequestHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReflashHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReflashHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashHistoryBindingSource)).BeginInit();
            this.tabRequestHistory.SuspendLayout();
            this.pnlRequestsHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashRequestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequestHistory)).BeginInit();
            this.tabPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalInfo)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(835, 15);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cbAdapter
            // 
            this.cbAdapter.FormattingEnabled = true;
            this.cbAdapter.Location = new System.Drawing.Point(79, 19);
            this.cbAdapter.Name = "cbAdapter";
            this.cbAdapter.Size = new System.Drawing.Size(491, 21);
            this.cbAdapter.TabIndex = 1;
            this.cbAdapter.SelectedIndexChanged += new System.EventHandler(this.cbAdapter_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1062, 581);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbModules
            // 
            this.cbModules.FormattingEnabled = true;
            this.cbModules.Location = new System.Drawing.Point(79, 51);
            this.cbModules.Name = "cbModules";
            this.cbModules.Size = new System.Drawing.Size(491, 21);
            this.cbModules.TabIndex = 1;
            this.cbModules.SelectedIndexChanged += new System.EventHandler(this.cbModules_SelectedIndexChanged);
            // 
            // lbAdapter
            // 
            this.lbAdapter.AutoSize = true;
            this.lbAdapter.Location = new System.Drawing.Point(13, 22);
            this.lbAdapter.Name = "lbAdapter";
            this.lbAdapter.Size = new System.Drawing.Size(49, 13);
            this.lbAdapter.TabIndex = 3;
            this.lbAdapter.Text = "Адаптер";
            // 
            // btnResetAdaptation
            // 
            this.btnResetAdaptation.Location = new System.Drawing.Point(435, 117);
            this.btnResetAdaptation.Name = "btnResetAdaptation";
            this.btnResetAdaptation.Size = new System.Drawing.Size(135, 29);
            this.btnResetAdaptation.TabIndex = 2;
            this.btnResetAdaptation.Text = "Сброс адаптации";
            this.btnResetAdaptation.UseVisualStyleBackColor = true;
            this.btnResetAdaptation.Click += new System.EventHandler(this.btnResetAdaptation_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(79, 117);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(135, 29);
            this.btnInitialize.TabIndex = 2;
            this.btnInitialize.Text = "Инициализация";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(435, 82);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(135, 29);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Перезагрузка";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnEraseErrors
            // 
            this.btnEraseErrors.Location = new System.Drawing.Point(260, 117);
            this.btnEraseErrors.Name = "btnEraseErrors";
            this.btnEraseErrors.Size = new System.Drawing.Size(135, 29);
            this.btnEraseErrors.TabIndex = 2;
            this.btnEraseErrors.Text = "Стереть ошибки";
            this.btnEraseErrors.UseVisualStyleBackColor = true;
            this.btnEraseErrors.Click += new System.EventHandler(this.btnEraseErrors_Click);
            // 
            // btnReadErrors
            // 
            this.btnReadErrors.Location = new System.Drawing.Point(260, 82);
            this.btnReadErrors.Name = "btnReadErrors";
            this.btnReadErrors.Size = new System.Drawing.Size(135, 29);
            this.btnReadErrors.TabIndex = 2;
            this.btnReadErrors.Text = "Прочитать ошибки";
            this.btnReadErrors.UseVisualStyleBackColor = true;
            this.btnReadErrors.Click += new System.EventHandler(this.btnReadErrors_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdentify.Location = new System.Drawing.Point(79, 82);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(135, 29);
            this.btnIdentify.TabIndex = 2;
            this.btnIdentify.Text = "Идентификация";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbControlSum);
            this.groupBox1.Controls.Add(this.btnWrite);
            this.groupBox1.Controls.Add(this.btnOpenFileDialog);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Location = new System.Drawing.Point(916, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // cbControlSum
            // 
            this.cbControlSum.AutoSize = true;
            this.cbControlSum.Checked = true;
            this.cbControlSum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbControlSum.Location = new System.Drawing.Point(7, 51);
            this.cbControlSum.Name = "cbControlSum";
            this.cbControlSum.Size = new System.Drawing.Size(176, 17);
            this.cbControlSum.TabIndex = 3;
            this.cbControlSum.Text = "Проверка/Корректировка КС";
            this.cbControlSum.UseVisualStyleBackColor = true;
            this.cbControlSum.CheckedChanged += new System.EventHandler(this.cbControlSum_CheckedChanged);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(337, 45);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 27);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "Запись";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Location = new System.Drawing.Point(374, 16);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(38, 23);
            this.btnOpenFileDialog.TabIndex = 1;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(6, 17);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(362, 20);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnReadFromECU
            // 
            this.btnReadFromECU.Enabled = false;
            this.btnReadFromECU.Location = new System.Drawing.Point(371, 449);
            this.btnReadFromECU.Name = "btnReadFromECU";
            this.btnReadFromECU.Size = new System.Drawing.Size(135, 27);
            this.btnReadFromECU.TabIndex = 2;
            this.btnReadFromECU.Text = "Чтение из ЭБУ";
            this.btnReadFromECU.UseVisualStyleBackColor = true;
            this.btnReadFromECU.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(916, 101);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(418, 246);
            this.txtStatus.TabIndex = 6;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabNews);
            this.tabControlMain.Controls.Add(this.tabReflash);
            this.tabControlMain.Controls.Add(this.tabRequest);
            this.tabControlMain.Controls.Add(this.tabHistory);
            this.tabControlMain.Controls.Add(this.tabPerson);
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(90, 25);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(615, 537);
            this.tabControlMain.TabIndex = 7;
            this.tabControlMain.Click += new System.EventHandler(this.tabControlMain_Click);
            // 
            // tabNews
            // 
            this.tabNews.Controls.Add(this.pbNews);
            this.tabNews.Controls.Add(this.btnRefreshNews);
            this.tabNews.Controls.Add(this.tlNews);
            this.tabNews.Controls.Add(this.lblNews);
            this.tabNews.Location = new System.Drawing.Point(4, 29);
            this.tabNews.Name = "tabNews";
            this.tabNews.Size = new System.Drawing.Size(607, 504);
            this.tabNews.TabIndex = 4;
            this.tabNews.Text = "Новости";
            this.tabNews.UseVisualStyleBackColor = true;
            // 
            // pbNews
            // 
            this.pbNews.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbNews.Location = new System.Drawing.Point(373, 471);
            this.pbNews.Name = "pbNews";
            this.pbNews.Size = new System.Drawing.Size(28, 29);
            this.pbNews.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNews.TabIndex = 36;
            this.pbNews.TabStop = false;
            this.pbNews.Visible = false;
            // 
            // btnRefreshNews
            // 
            this.btnRefreshNews.Location = new System.Drawing.Point(407, 470);
            this.btnRefreshNews.Name = "btnRefreshNews";
            this.btnRefreshNews.Size = new System.Drawing.Size(184, 31);
            this.btnRefreshNews.TabIndex = 35;
            this.btnRefreshNews.Text = "Обновить новости";
            this.btnRefreshNews.UseVisualStyleBackColor = true;
            this.btnRefreshNews.Click += new System.EventHandler(this.btnRefreshNews_Click);
            // 
            // tlNews
            // 
            this.tlNews.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.tlNews.Appearance.Empty.Options.UseBackColor = true;
            this.tlNews.Appearance.EvenRow.BackColor = System.Drawing.Color.Transparent;
            this.tlNews.Appearance.EvenRow.Options.UseBackColor = true;
            this.tlNews.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.tlNews.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlNews.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.tlNews.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlNews.Appearance.Preview.Options.UseBackColor = true;
            this.tlNews.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.tlNews.Appearance.Row.Options.UseBackColor = true;
            this.tlNews.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tlNews.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlNews.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colInfo});
            this.tlNews.Location = new System.Drawing.Point(14, 42);
            this.tlNews.Name = "tlNews";
            this.tlNews.OptionsBehavior.Editable = false;
            this.tlNews.OptionsView.ShowButtons = false;
            this.tlNews.OptionsView.ShowColumns = false;
            this.tlNews.OptionsView.ShowFocusedFrame = false;
            this.tlNews.OptionsView.ShowHorzLines = false;
            this.tlNews.OptionsView.ShowIndicator = false;
            this.tlNews.OptionsView.ShowVertLines = false;
            this.tlNews.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.tlNews.Size = new System.Drawing.Size(577, 425);
            this.tlNews.TabIndex = 34;
            this.tlNews.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList1_NodeCellStyle);
            // 
            // colInfo
            // 
            this.colInfo.AppearanceCell.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colInfo.AppearanceCell.Options.UseFont = true;
            this.colInfo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colInfo.FieldName = "info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 0;
            this.colInfo.Width = 275;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // lblNews
            // 
            this.lblNews.AutoSize = true;
            this.lblNews.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNews.Location = new System.Drawing.Point(235, 19);
            this.lblNews.Name = "lblNews";
            this.lblNews.Size = new System.Drawing.Size(81, 20);
            this.lblNews.TabIndex = 16;
            this.lblNews.Text = "Новости";
            // 
            // tabReflash
            // 
            this.tabReflash.Controls.Add(this.tabControlReflash);
            this.tabReflash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReflash.Location = new System.Drawing.Point(4, 29);
            this.tabReflash.Name = "tabReflash";
            this.tabReflash.Padding = new System.Windows.Forms.Padding(3);
            this.tabReflash.Size = new System.Drawing.Size(607, 504);
            this.tabReflash.TabIndex = 0;
            this.tabReflash.Text = "Прошивка";
            this.tabReflash.UseVisualStyleBackColor = true;
            // 
            // tabControlReflash
            // 
            this.tabControlReflash.Controls.Add(this.tabReflashCar);
            this.tabControlReflash.Controls.Add(this.tabReflashUpload);
            this.tabControlReflash.Location = new System.Drawing.Point(0, 0);
            this.tabControlReflash.Name = "tabControlReflash";
            this.tabControlReflash.SelectedIndex = 0;
            this.tabControlReflash.Size = new System.Drawing.Size(611, 508);
            this.tabControlReflash.TabIndex = 0;
            // 
            // tabReflashCar
            // 
            this.tabReflashCar.Controls.Add(this.panelReflash);
            this.tabReflashCar.Location = new System.Drawing.Point(4, 22);
            this.tabReflashCar.Name = "tabReflashCar";
            this.tabReflashCar.Padding = new System.Windows.Forms.Padding(3);
            this.tabReflashCar.Size = new System.Drawing.Size(603, 482);
            this.tabReflashCar.TabIndex = 0;
            this.tabReflashCar.Text = "Загрузка прошивки в машину";
            this.tabReflashCar.UseVisualStyleBackColor = true;
            // 
            // panelReflash
            // 
            this.panelReflash.Controls.Add(this.lbAdapter);
            this.panelReflash.Controls.Add(this.btnCreateNewRequest);
            this.panelReflash.Controls.Add(this.textBox1);
            this.panelReflash.Controls.Add(this.cbModules);
            this.panelReflash.Controls.Add(this.btnUploadToECU);
            this.panelReflash.Controls.Add(this.btnReadFromECU);
            this.panelReflash.Controls.Add(this.lblBinaryLoadingStatus);
            this.panelReflash.Controls.Add(this.btnInitialize);
            this.panelReflash.Controls.Add(this.btnIdentify);
            this.panelReflash.Controls.Add(this.btnUploadBinary);
            this.panelReflash.Controls.Add(this.lbModule);
            this.panelReflash.Controls.Add(this.tbReflashText);
            this.panelReflash.Controls.Add(this.btnReadErrors);
            this.panelReflash.Controls.Add(this.btnRestart);
            this.panelReflash.Controls.Add(this.tbECUVin);
            this.panelReflash.Controls.Add(this.cbAdapter);
            this.panelReflash.Controls.Add(this.lbVIN);
            this.panelReflash.Controls.Add(this.btnEraseErrors);
            this.panelReflash.Controls.Add(this.tbBinaryNumber);
            this.panelReflash.Controls.Add(this.btnResetAdaptation);
            this.panelReflash.Controls.Add(this.lbECUBinaryNumber);
            this.panelReflash.Controls.Add(this.panelKeyUnavailible);
            this.panelReflash.Location = new System.Drawing.Point(0, 0);
            this.panelReflash.Name = "panelReflash";
            this.panelReflash.Size = new System.Drawing.Size(611, 508);
            this.panelReflash.TabIndex = 9;
            // 
            // btnCreateNewRequest
            // 
            this.btnCreateNewRequest.Enabled = false;
            this.btnCreateNewRequest.Location = new System.Drawing.Point(57, 449);
            this.btnCreateNewRequest.Name = "btnCreateNewRequest";
            this.btnCreateNewRequest.Size = new System.Drawing.Size(135, 27);
            this.btnCreateNewRequest.TabIndex = 19;
            this.btnCreateNewRequest.Text = "Создать запрос";
            this.btnCreateNewRequest.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 420);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(278, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "Не загружено";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUploadToECU
            // 
            this.btnUploadToECU.Enabled = false;
            this.btnUploadToECU.Location = new System.Drawing.Point(214, 449);
            this.btnUploadToECU.Name = "btnUploadToECU";
            this.btnUploadToECU.Size = new System.Drawing.Size(135, 27);
            this.btnUploadToECU.TabIndex = 16;
            this.btnUploadToECU.Text = "Запись в ЭБУ";
            this.btnUploadToECU.UseVisualStyleBackColor = true;
            // 
            // lblBinaryLoadingStatus
            // 
            this.lblBinaryLoadingStatus.AutoSize = true;
            this.lblBinaryLoadingStatus.Location = new System.Drawing.Point(17, 423);
            this.lblBinaryLoadingStatus.Name = "lblBinaryLoadingStatus";
            this.lblBinaryLoadingStatus.Size = new System.Drawing.Size(127, 13);
            this.lblBinaryLoadingStatus.TabIndex = 17;
            this.lblBinaryLoadingStatus.Text = "Загруженная прошивка";
            // 
            // btnUploadBinary
            // 
            this.btnUploadBinary.Location = new System.Drawing.Point(435, 416);
            this.btnUploadBinary.Name = "btnUploadBinary";
            this.btnUploadBinary.Size = new System.Drawing.Size(135, 27);
            this.btnUploadBinary.TabIndex = 15;
            this.btnUploadBinary.Text = "Загрузка с сервера";
            this.btnUploadBinary.UseVisualStyleBackColor = true;
            this.btnUploadBinary.Click += new System.EventHandler(this.btnUploadBinary_Click);
            // 
            // lbModule
            // 
            this.lbModule.AutoSize = true;
            this.lbModule.Location = new System.Drawing.Point(13, 54);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(45, 13);
            this.lbModule.TabIndex = 9;
            this.lbModule.Text = "Модуль";
            this.lbModule.Click += new System.EventHandler(this.lbModule_Click);
            // 
            // tbReflashText
            // 
            this.tbReflashText.Location = new System.Drawing.Point(17, 228);
            this.tbReflashText.Multiline = true;
            this.tbReflashText.Name = "tbReflashText";
            this.tbReflashText.ReadOnly = true;
            this.tbReflashText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReflashText.Size = new System.Drawing.Size(553, 172);
            this.tbReflashText.TabIndex = 14;
            // 
            // tbECUVin
            // 
            this.tbECUVin.Location = new System.Drawing.Point(135, 189);
            this.tbECUVin.Name = "tbECUVin";
            this.tbECUVin.Size = new System.Drawing.Size(435, 20);
            this.tbECUVin.TabIndex = 13;
            // 
            // lbVIN
            // 
            this.lbVIN.AutoSize = true;
            this.lbVIN.Location = new System.Drawing.Point(17, 196);
            this.lbVIN.Name = "lbVIN";
            this.lbVIN.Size = new System.Drawing.Size(60, 13);
            this.lbVIN.TabIndex = 12;
            this.lbVIN.Text = "VIN номер";
            // 
            // tbBinaryNumber
            // 
            this.tbBinaryNumber.Location = new System.Drawing.Point(135, 156);
            this.tbBinaryNumber.Name = "tbBinaryNumber";
            this.tbBinaryNumber.Size = new System.Drawing.Size(435, 20);
            this.tbBinaryNumber.TabIndex = 11;
            // 
            // lbECUBinaryNumber
            // 
            this.lbECUBinaryNumber.AutoSize = true;
            this.lbECUBinaryNumber.Location = new System.Drawing.Point(17, 163);
            this.lbECUBinaryNumber.Name = "lbECUBinaryNumber";
            this.lbECUBinaryNumber.Size = new System.Drawing.Size(94, 13);
            this.lbECUBinaryNumber.TabIndex = 10;
            this.lbECUBinaryNumber.Text = "Номер прошивки";
            // 
            // panelKeyUnavailible
            // 
            this.panelKeyUnavailible.Controls.Add(this.labelKeyUnavailible);
            this.panelKeyUnavailible.Controls.Add(this.btnReloadFlasher);
            this.panelKeyUnavailible.Location = new System.Drawing.Point(0, 0);
            this.panelKeyUnavailible.Name = "panelKeyUnavailible";
            this.panelKeyUnavailible.Size = new System.Drawing.Size(595, 492);
            this.panelKeyUnavailible.TabIndex = 8;
            this.panelKeyUnavailible.Visible = false;
            // 
            // labelKeyUnavailible
            // 
            this.labelKeyUnavailible.AutoSize = true;
            this.labelKeyUnavailible.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeyUnavailible.Location = new System.Drawing.Point(35, 217);
            this.labelKeyUnavailible.Name = "labelKeyUnavailible";
            this.labelKeyUnavailible.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelKeyUnavailible.Size = new System.Drawing.Size(519, 48);
            this.labelKeyUnavailible.TabIndex = 1;
            this.labelKeyUnavailible.Text = "Система не может найти ключ безопасности.\r\nВставьте ключ безопасности в USB порт " +
    "и нажмите ОК.";
            // 
            // btnReloadFlasher
            // 
            this.btnReloadFlasher.Location = new System.Drawing.Point(158, 291);
            this.btnReloadFlasher.Name = "btnReloadFlasher";
            this.btnReloadFlasher.Size = new System.Drawing.Size(229, 23);
            this.btnReloadFlasher.TabIndex = 0;
            this.btnReloadFlasher.Text = "OK";
            this.btnReloadFlasher.UseVisualStyleBackColor = true;
            this.btnReloadFlasher.Click += new System.EventHandler(this.btnReloadFlasher_Click);
            // 
            // tabReflashUpload
            // 
            this.tabReflashUpload.Controls.Add(this.panelLoadBinary);
            this.tabReflashUpload.Location = new System.Drawing.Point(4, 22);
            this.tabReflashUpload.Name = "tabReflashUpload";
            this.tabReflashUpload.Padding = new System.Windows.Forms.Padding(3);
            this.tabReflashUpload.Size = new System.Drawing.Size(603, 482);
            this.tabReflashUpload.TabIndex = 1;
            this.tabReflashUpload.Text = "Проверка наличия и загрузка прошивки";
            this.tabReflashUpload.UseVisualStyleBackColor = true;
            // 
            // panelLoadBinary
            // 
            this.panelLoadBinary.Controls.Add(this.btnSearchReflashFile);
            this.panelLoadBinary.Controls.Add(this.txtEcuNumbertoSearch);
            this.panelLoadBinary.Controls.Add(this.lblEcuNumbertoSearch);
            this.panelLoadBinary.Controls.Add(this.lblChooseBinarytoUpload);
            this.panelLoadBinary.Controls.Add(this.btnBinaryDescriptionOK);
            this.panelLoadBinary.Controls.Add(this.btnBinaryDescriptionCancel);
            this.panelLoadBinary.Controls.Add(this.gbBinaryDescription);
            this.panelLoadBinary.Controls.Add(this.lblChooseBinary);
            this.panelLoadBinary.Controls.Add(this.cbBinaryToLoad);
            this.panelLoadBinary.Location = new System.Drawing.Point(0, 0);
            this.panelLoadBinary.Name = "panelLoadBinary";
            this.panelLoadBinary.Size = new System.Drawing.Size(603, 486);
            this.panelLoadBinary.TabIndex = 9;
            // 
            // btnSearchReflashFile
            // 
            this.btnSearchReflashFile.Location = new System.Drawing.Point(468, 52);
            this.btnSearchReflashFile.Name = "btnSearchReflashFile";
            this.btnSearchReflashFile.Size = new System.Drawing.Size(112, 23);
            this.btnSearchReflashFile.TabIndex = 26;
            this.btnSearchReflashFile.Text = "Поиск прошивок";
            this.btnSearchReflashFile.UseVisualStyleBackColor = true;
            this.btnSearchReflashFile.Click += new System.EventHandler(this.btnSearchReflashFile_Click);
            // 
            // txtEcuNumbertoSearch
            // 
            this.txtEcuNumbertoSearch.Location = new System.Drawing.Point(124, 54);
            this.txtEcuNumbertoSearch.Name = "txtEcuNumbertoSearch";
            this.txtEcuNumbertoSearch.Size = new System.Drawing.Size(321, 20);
            this.txtEcuNumbertoSearch.TabIndex = 25;
            this.txtEcuNumbertoSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEcuNumbertoSearch
            // 
            this.lblEcuNumbertoSearch.AutoSize = true;
            this.lblEcuNumbertoSearch.Location = new System.Drawing.Point(6, 57);
            this.lblEcuNumbertoSearch.Name = "lblEcuNumbertoSearch";
            this.lblEcuNumbertoSearch.Size = new System.Drawing.Size(97, 13);
            this.lblEcuNumbertoSearch.TabIndex = 24;
            this.lblEcuNumbertoSearch.Text = "Номер прошивки:";
            // 
            // lblChooseBinarytoUpload
            // 
            this.lblChooseBinarytoUpload.AutoSize = true;
            this.lblChooseBinarytoUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChooseBinarytoUpload.Location = new System.Drawing.Point(189, 18);
            this.lblChooseBinarytoUpload.Name = "lblChooseBinarytoUpload";
            this.lblChooseBinarytoUpload.Size = new System.Drawing.Size(207, 20);
            this.lblChooseBinarytoUpload.TabIndex = 23;
            this.lblChooseBinarytoUpload.Text = "Выбор/Поиск прошивки";
            this.lblChooseBinarytoUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBinaryDescriptionOK
            // 
            this.btnBinaryDescriptionOK.Enabled = false;
            this.btnBinaryDescriptionOK.Location = new System.Drawing.Point(99, 446);
            this.btnBinaryDescriptionOK.Name = "btnBinaryDescriptionOK";
            this.btnBinaryDescriptionOK.Size = new System.Drawing.Size(135, 27);
            this.btnBinaryDescriptionOK.TabIndex = 22;
            this.btnBinaryDescriptionOK.Text = "Загрузить";
            this.btnBinaryDescriptionOK.UseVisualStyleBackColor = true;
            this.btnBinaryDescriptionOK.Click += new System.EventHandler(this.btnBinaryDescriptionOK_Click);
            // 
            // btnBinaryDescriptionCancel
            // 
            this.btnBinaryDescriptionCancel.Enabled = false;
            this.btnBinaryDescriptionCancel.Location = new System.Drawing.Point(328, 446);
            this.btnBinaryDescriptionCancel.Name = "btnBinaryDescriptionCancel";
            this.btnBinaryDescriptionCancel.Size = new System.Drawing.Size(135, 27);
            this.btnBinaryDescriptionCancel.TabIndex = 19;
            this.btnBinaryDescriptionCancel.Text = "Отмена";
            this.btnBinaryDescriptionCancel.UseVisualStyleBackColor = true;
            this.btnBinaryDescriptionCancel.Click += new System.EventHandler(this.btnBinaryDescriptionCancel_Click);
            // 
            // gbBinaryDescription
            // 
            this.gbBinaryDescription.Controls.Add(this.pbReflash);
            this.gbBinaryDescription.Controls.Add(this.cbBinaryDescriptionImmoOff);
            this.gbBinaryDescription.Controls.Add(this.cbBinaryDescriptionEGROff);
            this.gbBinaryDescription.Controls.Add(this.cbBinaryDescriptionEuro2);
            this.gbBinaryDescription.Controls.Add(this.txtBinaryDescription);
            this.gbBinaryDescription.Controls.Add(this.cbBinaryDescriptionCS);
            this.gbBinaryDescription.Enabled = false;
            this.gbBinaryDescription.Location = new System.Drawing.Point(50, 110);
            this.gbBinaryDescription.Name = "gbBinaryDescription";
            this.gbBinaryDescription.Size = new System.Drawing.Size(476, 330);
            this.gbBinaryDescription.TabIndex = 21;
            this.gbBinaryDescription.TabStop = false;
            this.gbBinaryDescription.Text = "Описание";
            // 
            // pbReflash
            // 
            this.pbReflash.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbReflash.Location = new System.Drawing.Point(200, 99);
            this.pbReflash.Name = "pbReflash";
            this.pbReflash.Size = new System.Drawing.Size(96, 90);
            this.pbReflash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReflash.TabIndex = 18;
            this.pbReflash.TabStop = false;
            this.pbReflash.Visible = false;
            // 
            // cbBinaryDescriptionImmoOff
            // 
            this.cbBinaryDescriptionImmoOff.AutoSize = true;
            this.cbBinaryDescriptionImmoOff.Enabled = false;
            this.cbBinaryDescriptionImmoOff.Location = new System.Drawing.Point(22, 307);
            this.cbBinaryDescriptionImmoOff.Name = "cbBinaryDescriptionImmoOff";
            this.cbBinaryDescriptionImmoOff.Size = new System.Drawing.Size(125, 17);
            this.cbBinaryDescriptionImmoOff.TabIndex = 4;
            this.cbBinaryDescriptionImmoOff.Text = "Отключение ИММО";
            this.cbBinaryDescriptionImmoOff.UseVisualStyleBackColor = true;
            // 
            // cbBinaryDescriptionEGROff
            // 
            this.cbBinaryDescriptionEGROff.AutoSize = true;
            this.cbBinaryDescriptionEGROff.Enabled = false;
            this.cbBinaryDescriptionEGROff.Location = new System.Drawing.Point(153, 307);
            this.cbBinaryDescriptionEGROff.Name = "cbBinaryDescriptionEGROff";
            this.cbBinaryDescriptionEGROff.Size = new System.Drawing.Size(111, 17);
            this.cbBinaryDescriptionEGROff.TabIndex = 3;
            this.cbBinaryDescriptionEGROff.Text = "Отключение ЕГР";
            this.cbBinaryDescriptionEGROff.UseVisualStyleBackColor = true;
            // 
            // cbBinaryDescriptionEuro2
            // 
            this.cbBinaryDescriptionEuro2.AutoSize = true;
            this.cbBinaryDescriptionEuro2.Enabled = false;
            this.cbBinaryDescriptionEuro2.Location = new System.Drawing.Point(268, 307);
            this.cbBinaryDescriptionEuro2.Name = "cbBinaryDescriptionEuro2";
            this.cbBinaryDescriptionEuro2.Size = new System.Drawing.Size(57, 17);
            this.cbBinaryDescriptionEuro2.TabIndex = 2;
            this.cbBinaryDescriptionEuro2.Text = "Евро2";
            this.cbBinaryDescriptionEuro2.UseVisualStyleBackColor = true;
            // 
            // txtBinaryDescription
            // 
            this.txtBinaryDescription.Location = new System.Drawing.Point(19, 22);
            this.txtBinaryDescription.Multiline = true;
            this.txtBinaryDescription.Name = "txtBinaryDescription";
            this.txtBinaryDescription.ReadOnly = true;
            this.txtBinaryDescription.Size = new System.Drawing.Size(439, 267);
            this.txtBinaryDescription.TabIndex = 1;
            // 
            // cbBinaryDescriptionCS
            // 
            this.cbBinaryDescriptionCS.AutoSize = true;
            this.cbBinaryDescriptionCS.Enabled = false;
            this.cbBinaryDescriptionCS.Location = new System.Drawing.Point(331, 307);
            this.cbBinaryDescriptionCS.Name = "cbBinaryDescriptionCS";
            this.cbBinaryDescriptionCS.Size = new System.Drawing.Size(128, 17);
            this.cbBinaryDescriptionCS.TabIndex = 0;
            this.cbBinaryDescriptionCS.Text = "Контрольная сумма";
            this.cbBinaryDescriptionCS.UseVisualStyleBackColor = true;
            // 
            // lblChooseBinary
            // 
            this.lblChooseBinary.AutoSize = true;
            this.lblChooseBinary.Enabled = false;
            this.lblChooseBinary.Location = new System.Drawing.Point(47, 86);
            this.lblChooseBinary.Name = "lblChooseBinary";
            this.lblChooseBinary.Size = new System.Drawing.Size(120, 13);
            this.lblChooseBinary.TabIndex = 20;
            this.lblChooseBinary.Text = "Доступные прошивки:";
            // 
            // cbBinaryToLoad
            // 
            this.cbBinaryToLoad.Enabled = false;
            this.cbBinaryToLoad.FormattingEnabled = true;
            this.cbBinaryToLoad.Location = new System.Drawing.Point(205, 83);
            this.cbBinaryToLoad.Name = "cbBinaryToLoad";
            this.cbBinaryToLoad.Size = new System.Drawing.Size(321, 21);
            this.cbBinaryToLoad.TabIndex = 19;
            this.cbBinaryToLoad.SelectedIndexChanged += new System.EventHandler(this.cbBinaryToLoad_SelectedIndexChanged);
            // 
            // tabRequest
            // 
            this.tabRequest.Controls.Add(this.pnlSendRequest);
            this.tabRequest.Location = new System.Drawing.Point(4, 29);
            this.tabRequest.Name = "tabRequest";
            this.tabRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequest.Size = new System.Drawing.Size(607, 504);
            this.tabRequest.TabIndex = 1;
            this.tabRequest.Text = "Запросы";
            this.tabRequest.UseVisualStyleBackColor = true;
            // 
            // pnlSendRequest
            // 
            this.pnlSendRequest.Controls.Add(this.lblCreateRequest);
            this.pnlSendRequest.Controls.Add(this.btnRequestUploadEcuPhoto);
            this.pnlSendRequest.Controls.Add(this.lblCarDescription);
            this.pnlSendRequest.Controls.Add(this.txtRequestCarDescription);
            this.pnlSendRequest.Controls.Add(this.txtEcuPhotoStatus);
            this.pnlSendRequest.Controls.Add(this.txtEcuBinaryNumber);
            this.pnlSendRequest.Controls.Add(this.lblEcuPhoto);
            this.pnlSendRequest.Controls.Add(this.lblBinaryNumber);
            this.pnlSendRequest.Controls.Add(this.lblEcuNumber);
            this.pnlSendRequest.Controls.Add(this.txtEcuNumber);
            this.pnlSendRequest.Controls.Add(this.pbRequest);
            this.pnlSendRequest.Controls.Add(this.lblAdditionalInfo);
            this.pnlSendRequest.Controls.Add(this.txtAdditionalInfo);
            this.pnlSendRequest.Controls.Add(this.txtStockFilePath);
            this.pnlSendRequest.Controls.Add(this.btnSendRequest);
            this.pnlSendRequest.Controls.Add(this.lblStockFile);
            this.pnlSendRequest.Controls.Add(this.btnOpenFile);
            this.pnlSendRequest.Location = new System.Drawing.Point(0, 0);
            this.pnlSendRequest.Name = "pnlSendRequest";
            this.pnlSendRequest.Size = new System.Drawing.Size(608, 501);
            this.pnlSendRequest.TabIndex = 7;
            // 
            // lblCreateRequest
            // 
            this.lblCreateRequest.AutoSize = true;
            this.lblCreateRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCreateRequest.Location = new System.Drawing.Point(217, 20);
            this.lblCreateRequest.Name = "lblCreateRequest";
            this.lblCreateRequest.Size = new System.Drawing.Size(168, 20);
            this.lblCreateRequest.TabIndex = 15;
            this.lblCreateRequest.Text = "Создание Запроса";
            // 
            // btnRequestUploadEcuPhoto
            // 
            this.btnRequestUploadEcuPhoto.Location = new System.Drawing.Point(488, 126);
            this.btnRequestUploadEcuPhoto.Name = "btnRequestUploadEcuPhoto";
            this.btnRequestUploadEcuPhoto.Size = new System.Drawing.Size(98, 25);
            this.btnRequestUploadEcuPhoto.TabIndex = 14;
            this.btnRequestUploadEcuPhoto.Text = "Загрузить";
            this.btnRequestUploadEcuPhoto.UseVisualStyleBackColor = true;
            this.btnRequestUploadEcuPhoto.Click += new System.EventHandler(this.btnRequestUploadEcuPhoto_Click);
            // 
            // lblCarDescription
            // 
            this.lblCarDescription.AutoSize = true;
            this.lblCarDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCarDescription.Location = new System.Drawing.Point(15, 180);
            this.lblCarDescription.Name = "lblCarDescription";
            this.lblCarDescription.Size = new System.Drawing.Size(48, 13);
            this.lblCarDescription.TabIndex = 13;
            this.lblCarDescription.Text = "Машина";
            // 
            // txtRequestCarDescription
            // 
            this.txtRequestCarDescription.Location = new System.Drawing.Point(123, 168);
            this.txtRequestCarDescription.Multiline = true;
            this.txtRequestCarDescription.Name = "txtRequestCarDescription";
            this.txtRequestCarDescription.Size = new System.Drawing.Size(463, 105);
            this.txtRequestCarDescription.TabIndex = 12;
            // 
            // txtEcuPhotoStatus
            // 
            this.txtEcuPhotoStatus.Enabled = false;
            this.txtEcuPhotoStatus.Location = new System.Drawing.Point(123, 130);
            this.txtEcuPhotoStatus.Name = "txtEcuPhotoStatus";
            this.txtEcuPhotoStatus.ReadOnly = true;
            this.txtEcuPhotoStatus.Size = new System.Drawing.Size(352, 22);
            this.txtEcuPhotoStatus.TabIndex = 11;
            this.txtEcuPhotoStatus.Text = "не загружен";
            this.txtEcuPhotoStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEcuBinaryNumber
            // 
            this.txtEcuBinaryNumber.Location = new System.Drawing.Point(123, 89);
            this.txtEcuBinaryNumber.Name = "txtEcuBinaryNumber";
            this.txtEcuBinaryNumber.Size = new System.Drawing.Size(463, 22);
            this.txtEcuBinaryNumber.TabIndex = 10;
            // 
            // lblEcuPhoto
            // 
            this.lblEcuPhoto.AutoSize = true;
            this.lblEcuPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEcuPhoto.Location = new System.Drawing.Point(15, 130);
            this.lblEcuPhoto.Name = "lblEcuPhoto";
            this.lblEcuPhoto.Size = new System.Drawing.Size(69, 13);
            this.lblEcuPhoto.TabIndex = 9;
            this.lblEcuPhoto.Text = "Фото мозга";
            // 
            // lblBinaryNumber
            // 
            this.lblBinaryNumber.AutoSize = true;
            this.lblBinaryNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBinaryNumber.Location = new System.Drawing.Point(15, 92);
            this.lblBinaryNumber.Name = "lblBinaryNumber";
            this.lblBinaryNumber.Size = new System.Drawing.Size(94, 13);
            this.lblBinaryNumber.TabIndex = 8;
            this.lblBinaryNumber.Text = "Номер прошивки";
            // 
            // lblEcuNumber
            // 
            this.lblEcuNumber.AutoSize = true;
            this.lblEcuNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEcuNumber.Location = new System.Drawing.Point(15, 55);
            this.lblEcuNumber.Name = "lblEcuNumber";
            this.lblEcuNumber.Size = new System.Drawing.Size(75, 13);
            this.lblEcuNumber.TabIndex = 7;
            this.lblEcuNumber.Text = "Номер мозга";
            // 
            // txtEcuNumber
            // 
            this.txtEcuNumber.Location = new System.Drawing.Point(123, 52);
            this.txtEcuNumber.Name = "txtEcuNumber";
            this.txtEcuNumber.Size = new System.Drawing.Size(463, 22);
            this.txtEcuNumber.TabIndex = 1;
            // 
            // pbRequest
            // 
            this.pbRequest.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbRequest.Location = new System.Drawing.Point(348, 459);
            this.pbRequest.Name = "pbRequest";
            this.pbRequest.Size = new System.Drawing.Size(28, 29);
            this.pbRequest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRequest.TabIndex = 6;
            this.pbRequest.TabStop = false;
            this.pbRequest.Visible = false;
            // 
            // lblAdditionalInfo
            // 
            this.lblAdditionalInfo.AutoSize = true;
            this.lblAdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblAdditionalInfo.Location = new System.Drawing.Point(15, 291);
            this.lblAdditionalInfo.Name = "lblAdditionalInfo";
            this.lblAdditionalInfo.Size = new System.Drawing.Size(65, 13);
            this.lblAdditionalInfo.TabIndex = 0;
            this.lblAdditionalInfo.Text = "Пожелания";
            // 
            // txtAdditionalInfo
            // 
            this.txtAdditionalInfo.Location = new System.Drawing.Point(123, 288);
            this.txtAdditionalInfo.Multiline = true;
            this.txtAdditionalInfo.Name = "txtAdditionalInfo";
            this.txtAdditionalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdditionalInfo.Size = new System.Drawing.Size(463, 131);
            this.txtAdditionalInfo.TabIndex = 1;
            // 
            // txtStockFilePath
            // 
            this.txtStockFilePath.Location = new System.Drawing.Point(123, 429);
            this.txtStockFilePath.Name = "txtStockFilePath";
            this.txtStockFilePath.ReadOnly = true;
            this.txtStockFilePath.Size = new System.Drawing.Size(352, 22);
            this.txtStockFilePath.TabIndex = 1;
            this.txtStockFilePath.Text = "не загружен";
            this.txtStockFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(382, 459);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(204, 29);
            this.btnSendRequest.TabIndex = 3;
            this.btnSendRequest.Text = "Отправить запрос";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // lblStockFile
            // 
            this.lblStockFile.AutoSize = true;
            this.lblStockFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblStockFile.Location = new System.Drawing.Point(15, 432);
            this.lblStockFile.Name = "lblStockFile";
            this.lblStockFile.Size = new System.Drawing.Size(86, 13);
            this.lblStockFile.TabIndex = 0;
            this.lblStockFile.Text = "Стоковый файл";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(488, 428);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(98, 25);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Загрузить";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.tabControlHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 29);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(607, 504);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "История";
            this.tabHistory.UseVisualStyleBackColor = true;
            this.tabHistory.Click += new System.EventHandler(this.tabHistory_Click);
            // 
            // tabControlHistory
            // 
            this.tabControlHistory.Controls.Add(this.tabReflashHistory);
            this.tabControlHistory.Controls.Add(this.tabRequestHistory);
            this.tabControlHistory.Location = new System.Drawing.Point(0, 0);
            this.tabControlHistory.Name = "tabControlHistory";
            this.tabControlHistory.SelectedIndex = 0;
            this.tabControlHistory.Size = new System.Drawing.Size(611, 508);
            this.tabControlHistory.TabIndex = 0;
            // 
            // tabReflashHistory
            // 
            this.tabReflashHistory.Controls.Add(this.panelRequestHistory);
            this.tabReflashHistory.Location = new System.Drawing.Point(4, 25);
            this.tabReflashHistory.Name = "tabReflashHistory";
            this.tabReflashHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabReflashHistory.Size = new System.Drawing.Size(603, 479);
            this.tabReflashHistory.TabIndex = 0;
            this.tabReflashHistory.Text = "Прошивки";
            this.tabReflashHistory.UseVisualStyleBackColor = true;
            // 
            // panelRequestHistory
            // 
            this.panelRequestHistory.Controls.Add(this.pbReflashHistory);
            this.panelRequestHistory.Controls.Add(this.btnRefreshHistory);
            this.panelRequestHistory.Controls.Add(this.dgReflashHistory);
            this.panelRequestHistory.Location = new System.Drawing.Point(0, 0);
            this.panelRequestHistory.Name = "panelRequestHistory";
            this.panelRequestHistory.Size = new System.Drawing.Size(604, 483);
            this.panelRequestHistory.TabIndex = 0;
            // 
            // pbReflashHistory
            // 
            this.pbReflashHistory.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbReflashHistory.Location = new System.Drawing.Point(367, 448);
            this.pbReflashHistory.Name = "pbReflashHistory";
            this.pbReflashHistory.Size = new System.Drawing.Size(29, 28);
            this.pbReflashHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReflashHistory.TabIndex = 2;
            this.pbReflashHistory.TabStop = false;
            this.pbReflashHistory.Visible = false;
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Location = new System.Drawing.Point(402, 448);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(198, 28);
            this.btnRefreshHistory.TabIndex = 1;
            this.btnRefreshHistory.Text = "Обновить";
            this.btnRefreshHistory.UseVisualStyleBackColor = true;
            this.btnRefreshHistory.Click += new System.EventHandler(this.btnRefreshHistory_Click);
            // 
            // dgReflashHistory
            // 
            this.dgReflashHistory.AllowUserToAddRows = false;
            this.dgReflashHistory.AllowUserToDeleteRows = false;
            this.dgReflashHistory.AutoGenerateColumns = false;
            this.dgReflashHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReflashHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.reflashDateDataGridViewTextBoxColumn,
            this.binaryFileNameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.btnSendReview});
            this.dgReflashHistory.DataSource = this.reflashHistoryBindingSource;
            this.dgReflashHistory.Location = new System.Drawing.Point(0, 0);
            this.dgReflashHistory.Name = "dgReflashHistory";
            this.dgReflashHistory.RowHeadersVisible = false;
            this.dgReflashHistory.Size = new System.Drawing.Size(600, 442);
            this.dgReflashHistory.TabIndex = 0;
            this.dgReflashHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReflashHistory_CellContentClick);
            this.dgReflashHistory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgReflashHistory_CellFormatting);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Номер";
            this.Id.Name = "Id";
            // 
            // reflashDateDataGridViewTextBoxColumn
            // 
            this.reflashDateDataGridViewTextBoxColumn.DataPropertyName = "ReflashDate";
            this.reflashDateDataGridViewTextBoxColumn.HeaderText = "Дата прошивки";
            this.reflashDateDataGridViewTextBoxColumn.Name = "reflashDateDataGridViewTextBoxColumn";
            // 
            // binaryFileNameDataGridViewTextBoxColumn
            // 
            this.binaryFileNameDataGridViewTextBoxColumn.DataPropertyName = "BinaryFileName";
            this.binaryFileNameDataGridViewTextBoxColumn.HeaderText = "Имя рефлеш файла";
            this.binaryFileNameDataGridViewTextBoxColumn.Name = "binaryFileNameDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус платежа";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // btnSendReview
            // 
            this.btnSendReview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.btnSendReview.HeaderText = "Полная информация";
            this.btnSendReview.Name = "btnSendReview";
            this.btnSendReview.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnSendReview.Text = "Полная информация";
            this.btnSendReview.UseColumnTextForButtonValue = true;
            // 
            // reflashHistoryBindingSource
            // 
            this.reflashHistoryBindingSource.DataSource = typeof(ClientAndServerCommons.DataClasses.ReflashHistory);
            // 
            // tabRequestHistory
            // 
            this.tabRequestHistory.Controls.Add(this.pnlRequestsHistory);
            this.tabRequestHistory.Location = new System.Drawing.Point(4, 25);
            this.tabRequestHistory.Name = "tabRequestHistory";
            this.tabRequestHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequestHistory.Size = new System.Drawing.Size(603, 479);
            this.tabRequestHistory.TabIndex = 1;
            this.tabRequestHistory.Text = "Запросы";
            this.tabRequestHistory.UseVisualStyleBackColor = true;
            // 
            // pnlRequestsHistory
            // 
            this.pnlRequestsHistory.Controls.Add(this.dgRequests);
            this.pnlRequestsHistory.Controls.Add(this.btnRefreshRequests);
            this.pnlRequestsHistory.Controls.Add(this.pbRequestHistory);
            this.pnlRequestsHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlRequestsHistory.Name = "pnlRequestsHistory";
            this.pnlRequestsHistory.Size = new System.Drawing.Size(605, 627);
            this.pnlRequestsHistory.TabIndex = 8;
            // 
            // dgRequests
            // 
            this.dgRequests.AllowUserToAddRows = false;
            this.dgRequests.AllowUserToDeleteRows = false;
            this.dgRequests.AutoGenerateColumns = false;
            this.dgRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.requestDateDataGridViewTextBoxColumn,
            this.carDescriptionDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn1,
            this.FullInfo});
            this.dgRequests.DataSource = this.reflashRequestBindingSource;
            this.dgRequests.Location = new System.Drawing.Point(0, 0);
            this.dgRequests.Name = "dgRequests";
            this.dgRequests.RowHeadersVisible = false;
            this.dgRequests.Size = new System.Drawing.Size(601, 441);
            this.dgRequests.TabIndex = 4;
            this.dgRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRequests_CellContentClick);
            this.dgRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgRequests_CellFormatting);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Номер запроса";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // requestDateDataGridViewTextBoxColumn
            // 
            this.requestDateDataGridViewTextBoxColumn.DataPropertyName = "RequestDate";
            this.requestDateDataGridViewTextBoxColumn.HeaderText = "Дата запроса";
            this.requestDateDataGridViewTextBoxColumn.Name = "requestDateDataGridViewTextBoxColumn";
            // 
            // carDescriptionDataGridViewTextBoxColumn
            // 
            this.carDescriptionDataGridViewTextBoxColumn.DataPropertyName = "CarDescription";
            this.carDescriptionDataGridViewTextBoxColumn.HeaderText = "Машина";
            this.carDescriptionDataGridViewTextBoxColumn.Name = "carDescriptionDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            // 
            // FullInfo
            // 
            this.FullInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullInfo.HeaderText = "Полная информация";
            this.FullInfo.Name = "FullInfo";
            this.FullInfo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FullInfo.Text = "Полная информация";
            this.FullInfo.UseColumnTextForButtonValue = true;
            // 
            // reflashRequestBindingSource
            // 
            this.reflashRequestBindingSource.DataSource = typeof(ClientAndServerCommons.DataClasses.ReflashRequest);
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.Location = new System.Drawing.Point(362, 450);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(235, 23);
            this.btnRefreshRequests.TabIndex = 5;
            this.btnRefreshRequests.Text = "Получить\\Обновить данные";
            this.btnRefreshRequests.UseVisualStyleBackColor = true;
            this.btnRefreshRequests.Click += new System.EventHandler(this.btnRefreshRequests_Click);
            // 
            // pbRequestHistory
            // 
            this.pbRequestHistory.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbRequestHistory.Location = new System.Drawing.Point(327, 447);
            this.pbRequestHistory.Name = "pbRequestHistory";
            this.pbRequestHistory.Size = new System.Drawing.Size(28, 29);
            this.pbRequestHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRequestHistory.TabIndex = 6;
            this.pbRequestHistory.TabStop = false;
            this.pbRequestHistory.Visible = false;
            // 
            // tabPerson
            // 
            this.tabPerson.Controls.Add(this.pbPersonalInfo);
            this.tabPerson.Controls.Add(this.tbUserKey);
            this.tabPerson.Controls.Add(this.label7);
            this.tabPerson.Controls.Add(this.btnUpdateUserDetails);
            this.tabPerson.Controls.Add(this.label6);
            this.tabPerson.Controls.Add(this.label5);
            this.tabPerson.Controls.Add(this.label4);
            this.tabPerson.Controls.Add(this.label3);
            this.tabPerson.Controls.Add(this.label2);
            this.tabPerson.Controls.Add(this.label1);
            this.tabPerson.Controls.Add(this.tbUserCity);
            this.tabPerson.Controls.Add(this.cbUserWhatsapp);
            this.tabPerson.Controls.Add(this.cbUserViber);
            this.tabPerson.Controls.Add(this.tbUserVK);
            this.tabPerson.Controls.Add(this.tbUserSkype);
            this.tabPerson.Controls.Add(this.tbUserPhone);
            this.tabPerson.Controls.Add(this.tbUserSecondName);
            this.tabPerson.Controls.Add(this.tbUserName);
            this.tabPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.Size = new System.Drawing.Size(607, 504);
            this.tabPerson.TabIndex = 3;
            this.tabPerson.Text = "Персонализация";
            this.tabPerson.UseVisualStyleBackColor = true;
            // 
            // pbPersonalInfo
            // 
            this.pbPersonalInfo.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbPersonalInfo.Location = new System.Drawing.Point(340, 235);
            this.pbPersonalInfo.Name = "pbPersonalInfo";
            this.pbPersonalInfo.Size = new System.Drawing.Size(39, 35);
            this.pbPersonalInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonalInfo.TabIndex = 17;
            this.pbPersonalInfo.TabStop = false;
            this.pbPersonalInfo.Visible = false;
            // 
            // tbUserKey
            // 
            this.tbUserKey.Enabled = false;
            this.tbUserKey.Location = new System.Drawing.Point(116, 197);
            this.tbUserKey.Name = "tbUserKey";
            this.tbUserKey.Size = new System.Drawing.Size(464, 22);
            this.tbUserKey.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ключ";
            // 
            // btnUpdateUserDetails
            // 
            this.btnUpdateUserDetails.Location = new System.Drawing.Point(394, 226);
            this.btnUpdateUserDetails.Name = "btnUpdateUserDetails";
            this.btnUpdateUserDetails.Size = new System.Drawing.Size(186, 44);
            this.btnUpdateUserDetails.TabIndex = 14;
            this.btnUpdateUserDetails.Text = "Обновить данные";
            this.btnUpdateUserDetails.UseVisualStyleBackColor = true;
            this.btnUpdateUserDetails.Click += new System.EventHandler(this.btnUpdateUserDetails_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "ВКонтакте";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Скайп";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Телефон";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Город";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Имя";
            // 
            // tbUserCity
            // 
            this.tbUserCity.Location = new System.Drawing.Point(116, 86);
            this.tbUserCity.Name = "tbUserCity";
            this.tbUserCity.Size = new System.Drawing.Size(464, 22);
            this.tbUserCity.TabIndex = 7;
            // 
            // cbUserWhatsapp
            // 
            this.cbUserWhatsapp.AutoSize = true;
            this.cbUserWhatsapp.Location = new System.Drawing.Point(490, 115);
            this.cbUserWhatsapp.Name = "cbUserWhatsapp";
            this.cbUserWhatsapp.Size = new System.Drawing.Size(90, 20);
            this.cbUserWhatsapp.TabIndex = 6;
            this.cbUserWhatsapp.Text = "WhatsApp";
            this.cbUserWhatsapp.UseVisualStyleBackColor = true;
            // 
            // cbUserViber
            // 
            this.cbUserViber.AutoSize = true;
            this.cbUserViber.Location = new System.Drawing.Point(427, 115);
            this.cbUserViber.Name = "cbUserViber";
            this.cbUserViber.Size = new System.Drawing.Size(59, 20);
            this.cbUserViber.TabIndex = 5;
            this.cbUserViber.Text = "Viber";
            this.cbUserViber.UseVisualStyleBackColor = true;
            // 
            // tbUserVK
            // 
            this.tbUserVK.Location = new System.Drawing.Point(116, 169);
            this.tbUserVK.Name = "tbUserVK";
            this.tbUserVK.Size = new System.Drawing.Size(464, 22);
            this.tbUserVK.TabIndex = 4;
            // 
            // tbUserSkype
            // 
            this.tbUserSkype.Location = new System.Drawing.Point(116, 141);
            this.tbUserSkype.Name = "tbUserSkype";
            this.tbUserSkype.Size = new System.Drawing.Size(464, 22);
            this.tbUserSkype.TabIndex = 3;
            // 
            // tbUserPhone
            // 
            this.tbUserPhone.Location = new System.Drawing.Point(116, 113);
            this.tbUserPhone.Name = "tbUserPhone";
            this.tbUserPhone.Size = new System.Drawing.Size(305, 22);
            this.tbUserPhone.TabIndex = 2;
            // 
            // tbUserSecondName
            // 
            this.tbUserSecondName.Location = new System.Drawing.Point(116, 58);
            this.tbUserSecondName.Name = "tbUserSecondName";
            this.tbUserSecondName.Size = new System.Drawing.Size(464, 22);
            this.tbUserSecondName.TabIndex = 1;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(116, 28);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(464, 22);
            this.tbUserName.TabIndex = 0;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.pbLogin);
            this.panelLogin.Controls.Add(this.lblErrLogin);
            this.panelLogin.Controls.Add(this.checkBoxSavePassword);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Location = new System.Drawing.Point(12, 12);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(615, 802);
            this.panelLogin.TabIndex = 8;
            // 
            // pbLogin
            // 
            this.pbLogin.ErrorImage = global::VtecTeamFlasher.Properties.Resources.Error;
            this.pbLogin.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbLogin.Location = new System.Drawing.Point(135, 112);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(30, 29);
            this.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogin.TabIndex = 7;
            this.pbLogin.TabStop = false;
            this.pbLogin.Visible = false;
            // 
            // lblErrLogin
            // 
            this.lblErrLogin.AutoSize = true;
            this.lblErrLogin.BackColor = System.Drawing.SystemColors.Control;
            this.lblErrLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrLogin.ForeColor = System.Drawing.Color.Red;
            this.lblErrLogin.Location = new System.Drawing.Point(169, 119);
            this.lblErrLogin.Name = "lblErrLogin";
            this.lblErrLogin.Size = new System.Drawing.Size(0, 17);
            this.lblErrLogin.TabIndex = 6;
            // 
            // checkBoxSavePassword
            // 
            this.checkBoxSavePassword.AutoSize = true;
            this.checkBoxSavePassword.Location = new System.Drawing.Point(335, 92);
            this.checkBoxSavePassword.Name = "checkBoxSavePassword";
            this.checkBoxSavePassword.Size = new System.Drawing.Size(118, 17);
            this.checkBoxSavePassword.TabIndex = 5;
            this.checkBoxSavePassword.Text = "Сохранять пароль";
            this.checkBoxSavePassword.UseVisualStyleBackColor = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(55, 92);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(55, 66);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(106, 13);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Имя пользователя:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(335, 61);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(168, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(168, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(152, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(978, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // VTFlasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Name = "VTFlasher";
            this.Text = "VTFlasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VTFlasher_FormClosing);
            this.Load += new System.EventHandler(this.VTFlasher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabNews.ResumeLayout(false);
            this.tabNews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlNews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.tabReflash.ResumeLayout(false);
            this.tabControlReflash.ResumeLayout(false);
            this.tabReflashCar.ResumeLayout(false);
            this.panelReflash.ResumeLayout(false);
            this.panelReflash.PerformLayout();
            this.panelKeyUnavailible.ResumeLayout(false);
            this.panelKeyUnavailible.PerformLayout();
            this.tabReflashUpload.ResumeLayout(false);
            this.panelLoadBinary.ResumeLayout(false);
            this.panelLoadBinary.PerformLayout();
            this.gbBinaryDescription.ResumeLayout(false);
            this.gbBinaryDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReflash)).EndInit();
            this.tabRequest.ResumeLayout(false);
            this.pnlSendRequest.ResumeLayout(false);
            this.pnlSendRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequest)).EndInit();
            this.tabHistory.ResumeLayout(false);
            this.tabControlHistory.ResumeLayout(false);
            this.tabReflashHistory.ResumeLayout(false);
            this.panelRequestHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReflashHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReflashHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashHistoryBindingSource)).EndInit();
            this.tabRequestHistory.ResumeLayout(false);
            this.pnlRequestsHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashRequestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequestHistory)).EndInit();
            this.tabPerson.ResumeLayout(false);
            this.tabPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalInfo)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox cbAdapter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbModules;
        private System.Windows.Forms.Label lbAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnResetAdaptation;
        private System.Windows.Forms.Button btnEraseErrors;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnReadErrors;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnReadFromECU;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.CheckBox cbControlSum;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabReflash;
        private System.Windows.Forms.TabPage tabRequest;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.TabPage tabPerson;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox checkBoxSavePassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Panel panelKeyUnavailible;
        private System.Windows.Forms.Label labelKeyUnavailible;
        private System.Windows.Forms.Button btnReloadFlasher;
        private System.Windows.Forms.Label lblErrLogin;
        private System.Windows.Forms.Label lblStockFile;
        private System.Windows.Forms.Label lblAdditionalInfo;
        private System.Windows.Forms.TextBox txtStockFilePath;
        private System.Windows.Forms.TextBox txtAdditionalInfo;
        private System.Windows.Forms.TextBox txtEcuNumber;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnRefreshRequests;
        private System.Windows.Forms.BindingSource reflashRequestBindingSource;
        private System.Windows.Forms.Button btnRefreshHistory;
        private System.Windows.Forms.DataGridView dgReflashHistory;
        private System.Windows.Forms.BindingSource reflashHistoryBindingSource;
        private System.Windows.Forms.CheckBox cbUserViber;
        private System.Windows.Forms.TextBox tbUserVK;
        private System.Windows.Forms.TextBox tbUserSkype;
        private System.Windows.Forms.TextBox tbUserPhone;
        private System.Windows.Forms.TextBox tbUserSecondName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbUserKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateUserDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserCity;
        private System.Windows.Forms.CheckBox cbUserWhatsapp;
        private System.Windows.Forms.PictureBox pbLogin;
        private System.Windows.Forms.PictureBox pbRequestHistory;
        private System.Windows.Forms.PictureBox pbReflashHistory;
        private System.Windows.Forms.PictureBox pbPersonalInfo;
        private System.Windows.Forms.Panel pnlSendRequest;
        private System.Windows.Forms.PictureBox pbRequest;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.DataGridView dgRequests;
        private System.Windows.Forms.Panel pnlRequestsHistory;
        private System.Windows.Forms.Label lbModule;
        private System.Windows.Forms.Button btnUploadToECU;
        private System.Windows.Forms.Button btnUploadBinary;
        private System.Windows.Forms.TextBox tbReflashText;
        private System.Windows.Forms.TextBox tbECUVin;
        private System.Windows.Forms.Label lbVIN;
        private System.Windows.Forms.TextBox tbBinaryNumber;
        private System.Windows.Forms.Label lbECUBinaryNumber;
        private System.Windows.Forms.TabControl tabControlHistory;
        private System.Windows.Forms.TabPage tabReflashHistory;
        private System.Windows.Forms.TabPage tabRequestHistory;
        private System.Windows.Forms.Panel panelRequestHistory;
        private System.Windows.Forms.TextBox txtEcuPhotoStatus;
        private System.Windows.Forms.TextBox txtEcuBinaryNumber;
        private System.Windows.Forms.Label lblEcuPhoto;
        private System.Windows.Forms.Label lblBinaryNumber;
        private System.Windows.Forms.Label lblEcuNumber;
        private System.Windows.Forms.Button btnRequestUploadEcuPhoto;
        private System.Windows.Forms.Label lblCarDescription;
        private System.Windows.Forms.TextBox txtRequestCarDescription;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblBinaryLoadingStatus;
        private System.Windows.Forms.Panel panelLoadBinary;
        private System.Windows.Forms.Button btnBinaryDescriptionOK;
        private System.Windows.Forms.Button btnBinaryDescriptionCancel;
        private System.Windows.Forms.GroupBox gbBinaryDescription;
        private System.Windows.Forms.CheckBox cbBinaryDescriptionImmoOff;
        private System.Windows.Forms.CheckBox cbBinaryDescriptionEGROff;
        private System.Windows.Forms.CheckBox cbBinaryDescriptionEuro2;
        private System.Windows.Forms.TextBox txtBinaryDescription;
        private System.Windows.Forms.CheckBox cbBinaryDescriptionCS;
        private System.Windows.Forms.Label lblChooseBinary;
        private System.Windows.Forms.ComboBox cbBinaryToLoad;
        private System.Windows.Forms.Button btnCreateNewRequest;
        private System.Windows.Forms.PictureBox pbReflash;
        private System.Windows.Forms.Panel panelReflash;
        private System.Windows.Forms.Label lblChooseBinarytoUpload;
        private System.Windows.Forms.Label lblCreateRequest;
        private System.Windows.Forms.TabControl tabControlReflash;
        private System.Windows.Forms.TabPage tabReflashCar;
        private System.Windows.Forms.TabPage tabReflashUpload;
        private System.Windows.Forms.Button btnSearchReflashFile;
        private System.Windows.Forms.TextBox txtEcuNumbertoSearch;
        private System.Windows.Forms.Label lblEcuNumbertoSearch;
        private System.Windows.Forms.TabPage tabNews;
        private System.Windows.Forms.Label lblNews;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraTreeList.TreeList tlNews;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.PictureBox pbNews;
        private System.Windows.Forms.Button btnRefreshNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn FullInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn reflashDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn binaryFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnSendReview;
    }
}

