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
            this.gbModule = new System.Windows.Forms.GroupBox();
            this.btnResetAdaptation = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnEraseErrors = new System.Windows.Forms.Button();
            this.btnReadErrors = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbControlSum = new System.Windows.Forms.CheckBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabReflash = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbErrors = new System.Windows.Forms.TextBox();
            this.cbCarModel = new System.Windows.Forms.ComboBox();
            this.cbCarManufacture = new System.Windows.Forms.ComboBox();
            this.panelKeyUnavailible = new System.Windows.Forms.Panel();
            this.labelKeyUnavailible = new System.Windows.Forms.Label();
            this.btnReloadFlasher = new System.Windows.Forms.Button();
            this.tabRequest = new System.Windows.Forms.TabPage();
            this.pbRequestHistory = new System.Windows.Forms.PictureBox();
            this.btnRefreshRequests = new System.Windows.Forms.Button();
            this.reflashRequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtStockFilePath = new System.Windows.Forms.TextBox();
            this.txtAdditionalInfo = new System.Windows.Forms.TextBox();
            this.txtEcuNumber = new System.Windows.Forms.TextBox();
            this.lblStockFile = new System.Windows.Forms.Label();
            this.lblAdditionalInfo = new System.Windows.Forms.Label();
            this.lblEcuNumber = new System.Windows.Forms.Label();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.pbReflashHistory = new System.Windows.Forms.PictureBox();
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.dgReflashHistory = new System.Windows.Forms.DataGridView();
            this.cvnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reslashFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reflashDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reflashStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reflashHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.pnlSendRequest = new System.Windows.Forms.Panel();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.stockFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EcuCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRequests = new System.Windows.Forms.DataGridView();
            this.pbRequest = new System.Windows.Forms.PictureBox();
            this.pnlRequestsHistory = new System.Windows.Forms.Panel();
            this.gbModule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabReflash.SuspendLayout();
            this.panelKeyUnavailible.SuspendLayout();
            this.tabRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequestHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashRequestBindingSource)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReflashHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReflashHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashHistoryBindingSource)).BeginInit();
            this.tabPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalInfo)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            this.pnlSendRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequest)).BeginInit();
            this.pnlRequestsHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1062, 50);
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
            this.cbAdapter.Location = new System.Drawing.Point(117, 16);
            this.cbAdapter.Name = "cbAdapter";
            this.cbAdapter.Size = new System.Drawing.Size(361, 21);
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
            this.cbModules.Location = new System.Drawing.Point(6, 19);
            this.cbModules.Name = "cbModules";
            this.cbModules.Size = new System.Drawing.Size(406, 21);
            this.cbModules.TabIndex = 1;
            this.cbModules.SelectedIndexChanged += new System.EventHandler(this.cbModules_SelectedIndexChanged);
            // 
            // lbAdapter
            // 
            this.lbAdapter.AutoSize = true;
            this.lbAdapter.Location = new System.Drawing.Point(26, 19);
            this.lbAdapter.Name = "lbAdapter";
            this.lbAdapter.Size = new System.Drawing.Size(49, 13);
            this.lbAdapter.TabIndex = 3;
            this.lbAdapter.Text = "Адаптер";
            // 
            // gbModule
            // 
            this.gbModule.Controls.Add(this.btnResetAdaptation);
            this.gbModule.Controls.Add(this.cbModules);
            this.gbModule.Controls.Add(this.btnInitialize);
            this.gbModule.Controls.Add(this.btnRestart);
            this.gbModule.Location = new System.Drawing.Point(719, 92);
            this.gbModule.Name = "gbModule";
            this.gbModule.Size = new System.Drawing.Size(418, 122);
            this.gbModule.TabIndex = 4;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "Модуль";
            // 
            // btnResetAdaptation
            // 
            this.btnResetAdaptation.Location = new System.Drawing.Point(291, 67);
            this.btnResetAdaptation.Name = "btnResetAdaptation";
            this.btnResetAdaptation.Size = new System.Drawing.Size(121, 29);
            this.btnResetAdaptation.TabIndex = 2;
            this.btnResetAdaptation.Text = "Сброс адаптации";
            this.btnResetAdaptation.UseVisualStyleBackColor = true;
            this.btnResetAdaptation.Click += new System.EventHandler(this.btnResetAdaptation_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(17, 67);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(121, 29);
            this.btnInitialize.TabIndex = 2;
            this.btnInitialize.Text = "Инициализация";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(154, 67);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(121, 29);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Перезагрузка";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnEraseErrors
            // 
            this.btnEraseErrors.Location = new System.Drawing.Point(29, 198);
            this.btnEraseErrors.Name = "btnEraseErrors";
            this.btnEraseErrors.Size = new System.Drawing.Size(119, 29);
            this.btnEraseErrors.TabIndex = 2;
            this.btnEraseErrors.Text = "Стереть ошибки";
            this.btnEraseErrors.UseVisualStyleBackColor = true;
            this.btnEraseErrors.Click += new System.EventHandler(this.btnEraseErrors_Click);
            // 
            // btnReadErrors
            // 
            this.btnReadErrors.Location = new System.Drawing.Point(29, 154);
            this.btnReadErrors.Name = "btnReadErrors";
            this.btnReadErrors.Size = new System.Drawing.Size(121, 29);
            this.btnReadErrors.TabIndex = 2;
            this.btnReadErrors.Text = "Прочитать ошибки";
            this.btnReadErrors.UseVisualStyleBackColor = true;
            this.btnReadErrors.Click += new System.EventHandler(this.btnReadErrors_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdentify.Location = new System.Drawing.Point(29, 109);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(121, 29);
            this.btnIdentify.TabIndex = 2;
            this.btnIdentify.Text = "Идентификация";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbControlSum);
            this.groupBox1.Controls.Add(this.btnRead);
            this.groupBox1.Controls.Add(this.btnWrite);
            this.groupBox1.Controls.Add(this.btnOpenFileDialog);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Location = new System.Drawing.Point(719, 231);
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
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(256, 45);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 27);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Чтение";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
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
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(719, 329);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(418, 246);
            this.txtStatus.TabIndex = 6;
            // 
            // tabControlMain
            // 
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
            // tabReflash
            // 
            this.tabReflash.Controls.Add(this.textBox1);
            this.tabReflash.Controls.Add(this.tbErrors);
            this.tabReflash.Controls.Add(this.cbCarModel);
            this.tabReflash.Controls.Add(this.btnEraseErrors);
            this.tabReflash.Controls.Add(this.cbCarManufacture);
            this.tabReflash.Controls.Add(this.lbAdapter);
            this.tabReflash.Controls.Add(this.cbAdapter);
            this.tabReflash.Controls.Add(this.btnReadErrors);
            this.tabReflash.Controls.Add(this.btnIdentify);
            this.tabReflash.Controls.Add(this.panelKeyUnavailible);
            this.tabReflash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReflash.Location = new System.Drawing.Point(4, 29);
            this.tabReflash.Name = "tabReflash";
            this.tabReflash.Padding = new System.Windows.Forms.Padding(3);
            this.tabReflash.Size = new System.Drawing.Size(607, 504);
            this.tabReflash.TabIndex = 0;
            this.tabReflash.Text = "Прошивка";
            this.tabReflash.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 109);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(310, 29);
            this.textBox1.TabIndex = 7;
            // 
            // tbErrors
            // 
            this.tbErrors.Location = new System.Drawing.Point(168, 154);
            this.tbErrors.Multiline = true;
            this.tbErrors.Name = "tbErrors";
            this.tbErrors.Size = new System.Drawing.Size(310, 73);
            this.tbErrors.TabIndex = 6;
            // 
            // cbCarModel
            // 
            this.cbCarModel.FormattingEnabled = true;
            this.cbCarModel.Location = new System.Drawing.Point(117, 70);
            this.cbCarModel.Name = "cbCarModel";
            this.cbCarModel.Size = new System.Drawing.Size(361, 21);
            this.cbCarModel.TabIndex = 5;
            this.cbCarModel.SelectedIndexChanged += new System.EventHandler(this.cbCarModel_SelectedIndexChanged);
            // 
            // cbCarManufacture
            // 
            this.cbCarManufacture.FormattingEnabled = true;
            this.cbCarManufacture.Location = new System.Drawing.Point(117, 52);
            this.cbCarManufacture.Name = "cbCarManufacture";
            this.cbCarManufacture.Size = new System.Drawing.Size(361, 21);
            this.cbCarManufacture.TabIndex = 4;
            this.cbCarManufacture.SelectedIndexChanged += new System.EventHandler(this.cbCarManufacture_SelectedIndexChanged);
            // 
            // panelKeyUnavailible
            // 
            this.panelKeyUnavailible.Controls.Add(this.labelKeyUnavailible);
            this.panelKeyUnavailible.Controls.Add(this.btnReloadFlasher);
            this.panelKeyUnavailible.Location = new System.Drawing.Point(6, 6);
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
            this.btnReloadFlasher.Location = new System.Drawing.Point(190, 291);
            this.btnReloadFlasher.Name = "btnReloadFlasher";
            this.btnReloadFlasher.Size = new System.Drawing.Size(229, 23);
            this.btnReloadFlasher.TabIndex = 0;
            this.btnReloadFlasher.Text = "OK";
            this.btnReloadFlasher.UseVisualStyleBackColor = true;
            this.btnReloadFlasher.Click += new System.EventHandler(this.btnReloadFlasher_Click);
            // 
            // tabRequest
            // 
            this.tabRequest.Controls.Add(this.pnlRequestsHistory);
            this.tabRequest.Controls.Add(this.pnlSendRequest);
            this.tabRequest.Location = new System.Drawing.Point(4, 29);
            this.tabRequest.Name = "tabRequest";
            this.tabRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequest.Size = new System.Drawing.Size(607, 504);
            this.tabRequest.TabIndex = 1;
            this.tabRequest.Text = "Запросы";
            this.tabRequest.UseVisualStyleBackColor = true;
            // 
            // pbRequestHistory
            // 
            this.pbRequestHistory.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbRequestHistory.Location = new System.Drawing.Point(329, 179);
            this.pbRequestHistory.Name = "pbRequestHistory";
            this.pbRequestHistory.Size = new System.Drawing.Size(28, 29);
            this.pbRequestHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRequestHistory.TabIndex = 6;
            this.pbRequestHistory.TabStop = false;
            this.pbRequestHistory.Visible = false;
            // 
            // btnRefreshRequests
            // 
            this.btnRefreshRequests.Location = new System.Drawing.Point(363, 185);
            this.btnRefreshRequests.Name = "btnRefreshRequests";
            this.btnRefreshRequests.Size = new System.Drawing.Size(235, 23);
            this.btnRefreshRequests.TabIndex = 5;
            this.btnRefreshRequests.Text = "Получить\\Обновить данные";
            this.btnRefreshRequests.UseVisualStyleBackColor = true;
            this.btnRefreshRequests.Click += new System.EventHandler(this.btnRefreshRequests_Click);
            // 
            // reflashRequestBindingSource
            // 
            this.reflashRequestBindingSource.DataSource = typeof(ClientAndServerCommons.DataClasses.ReflashRequest);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(511, 194);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(81, 25);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Открыть";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtStockFilePath
            // 
            this.txtStockFilePath.Location = new System.Drawing.Point(148, 194);
            this.txtStockFilePath.Name = "txtStockFilePath";
            this.txtStockFilePath.Size = new System.Drawing.Size(357, 22);
            this.txtStockFilePath.TabIndex = 1;
            // 
            // txtAdditionalInfo
            // 
            this.txtAdditionalInfo.Location = new System.Drawing.Point(148, 53);
            this.txtAdditionalInfo.Multiline = true;
            this.txtAdditionalInfo.Name = "txtAdditionalInfo";
            this.txtAdditionalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdditionalInfo.Size = new System.Drawing.Size(444, 131);
            this.txtAdditionalInfo.TabIndex = 1;
            // 
            // txtEcuNumber
            // 
            this.txtEcuNumber.Location = new System.Drawing.Point(148, 24);
            this.txtEcuNumber.Name = "txtEcuNumber";
            this.txtEcuNumber.Size = new System.Drawing.Size(177, 22);
            this.txtEcuNumber.TabIndex = 1;
            // 
            // lblStockFile
            // 
            this.lblStockFile.AutoSize = true;
            this.lblStockFile.Location = new System.Drawing.Point(31, 194);
            this.lblStockFile.Name = "lblStockFile";
            this.lblStockFile.Size = new System.Drawing.Size(110, 16);
            this.lblStockFile.TabIndex = 0;
            this.lblStockFile.Text = "Стоковый файл";
            // 
            // lblAdditionalInfo
            // 
            this.lblAdditionalInfo.AutoSize = true;
            this.lblAdditionalInfo.Location = new System.Drawing.Point(31, 51);
            this.lblAdditionalInfo.Name = "lblAdditionalInfo";
            this.lblAdditionalInfo.Size = new System.Drawing.Size(111, 16);
            this.lblAdditionalInfo.TabIndex = 0;
            this.lblAdditionalInfo.Text = "Дополнительно";
            // 
            // lblEcuNumber
            // 
            this.lblEcuNumber.AutoSize = true;
            this.lblEcuNumber.Location = new System.Drawing.Point(60, 24);
            this.lblEcuNumber.Name = "lblEcuNumber";
            this.lblEcuNumber.Size = new System.Drawing.Size(82, 16);
            this.lblEcuNumber.TabIndex = 0;
            this.lblEcuNumber.Text = "Номер ECU";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.pbReflashHistory);
            this.tabHistory.Controls.Add(this.btnRefreshHistory);
            this.tabHistory.Controls.Add(this.dgReflashHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 29);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(607, 504);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "История";
            this.tabHistory.UseVisualStyleBackColor = true;
            this.tabHistory.Click += new System.EventHandler(this.tabHistory_Click);
            // 
            // pbReflashHistory
            // 
            this.pbReflashHistory.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbReflashHistory.Location = new System.Drawing.Point(371, 473);
            this.pbReflashHistory.Name = "pbReflashHistory";
            this.pbReflashHistory.Size = new System.Drawing.Size(29, 28);
            this.pbReflashHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReflashHistory.TabIndex = 2;
            this.pbReflashHistory.TabStop = false;
            this.pbReflashHistory.Visible = false;
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Location = new System.Drawing.Point(406, 473);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(198, 28);
            this.btnRefreshHistory.TabIndex = 1;
            this.btnRefreshHistory.Text = "Обновить";
            this.btnRefreshHistory.UseVisualStyleBackColor = true;
            this.btnRefreshHistory.Click += new System.EventHandler(this.btnRefreshHistory_Click);
            // 
            // dgReflashHistory
            // 
            this.dgReflashHistory.AutoGenerateColumns = false;
            this.dgReflashHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReflashHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cvnDataGridViewTextBoxColumn,
            this.reslashFileNameDataGridViewTextBoxColumn,
            this.vinDataGridViewTextBoxColumn,
            this.reflashDateTimeDataGridViewTextBoxColumn,
            this.reflashStatusDataGridViewTextBoxColumn,
            this.paymentStatusDataGridViewTextBoxColumn});
            this.dgReflashHistory.DataSource = this.reflashHistoryBindingSource;
            this.dgReflashHistory.Location = new System.Drawing.Point(3, 20);
            this.dgReflashHistory.Name = "dgReflashHistory";
            this.dgReflashHistory.Size = new System.Drawing.Size(601, 447);
            this.dgReflashHistory.TabIndex = 0;
            // 
            // cvnDataGridViewTextBoxColumn
            // 
            this.cvnDataGridViewTextBoxColumn.DataPropertyName = "Cvn";
            this.cvnDataGridViewTextBoxColumn.HeaderText = "Cvn";
            this.cvnDataGridViewTextBoxColumn.Name = "cvnDataGridViewTextBoxColumn";
            // 
            // reslashFileNameDataGridViewTextBoxColumn
            // 
            this.reslashFileNameDataGridViewTextBoxColumn.DataPropertyName = "ReslashFileName";
            this.reslashFileNameDataGridViewTextBoxColumn.HeaderText = "Имя рефлеш файла";
            this.reslashFileNameDataGridViewTextBoxColumn.Name = "reslashFileNameDataGridViewTextBoxColumn";
            // 
            // vinDataGridViewTextBoxColumn
            // 
            this.vinDataGridViewTextBoxColumn.DataPropertyName = "Vin";
            this.vinDataGridViewTextBoxColumn.HeaderText = "Vin";
            this.vinDataGridViewTextBoxColumn.Name = "vinDataGridViewTextBoxColumn";
            // 
            // reflashDateTimeDataGridViewTextBoxColumn
            // 
            this.reflashDateTimeDataGridViewTextBoxColumn.DataPropertyName = "ReflashDateTime";
            this.reflashDateTimeDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.reflashDateTimeDataGridViewTextBoxColumn.Name = "reflashDateTimeDataGridViewTextBoxColumn";
            // 
            // reflashStatusDataGridViewTextBoxColumn
            // 
            this.reflashStatusDataGridViewTextBoxColumn.DataPropertyName = "ReflashStatus";
            this.reflashStatusDataGridViewTextBoxColumn.HeaderText = "Статус прошивки";
            this.reflashStatusDataGridViewTextBoxColumn.Name = "reflashStatusDataGridViewTextBoxColumn";
            // 
            // paymentStatusDataGridViewTextBoxColumn
            // 
            this.paymentStatusDataGridViewTextBoxColumn.DataPropertyName = "PaymentStatus";
            this.paymentStatusDataGridViewTextBoxColumn.HeaderText = "Статус платежа";
            this.paymentStatusDataGridViewTextBoxColumn.Name = "paymentStatusDataGridViewTextBoxColumn";
            // 
            // reflashHistoryBindingSource
            // 
            this.reflashHistoryBindingSource.DataSource = typeof(ClientAndServerCommons.DataClasses.ReflashHistory);
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
            this.panelLogin.Size = new System.Drawing.Size(637, 802);
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
            // pnlSendRequest
            // 
            this.pnlSendRequest.Controls.Add(this.txtEcuNumber);
            this.pnlSendRequest.Controls.Add(this.lblEcuNumber);
            this.pnlSendRequest.Controls.Add(this.pbRequest);
            this.pnlSendRequest.Controls.Add(this.lblAdditionalInfo);
            this.pnlSendRequest.Controls.Add(this.txtAdditionalInfo);
            this.pnlSendRequest.Controls.Add(this.txtStockFilePath);
            this.pnlSendRequest.Controls.Add(this.btnSendRequest);
            this.pnlSendRequest.Controls.Add(this.lblStockFile);
            this.pnlSendRequest.Controls.Add(this.btnOpenFile);
            this.pnlSendRequest.Location = new System.Drawing.Point(0, 3);
            this.pnlSendRequest.Name = "pnlSendRequest";
            this.pnlSendRequest.Size = new System.Drawing.Size(608, 281);
            this.pnlSendRequest.TabIndex = 7;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(388, 238);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(204, 29);
            this.btnSendRequest.TabIndex = 3;
            this.btnSendRequest.Text = "Отправить запрос";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // stockFileNameDataGridViewTextBoxColumn
            // 
            this.stockFileNameDataGridViewTextBoxColumn.DataPropertyName = "StockFileName";
            this.stockFileNameDataGridViewTextBoxColumn.HeaderText = "Имя сток файла";
            this.stockFileNameDataGridViewTextBoxColumn.Name = "stockFileNameDataGridViewTextBoxColumn";
            // 
            // additionalMessageDataGridViewTextBoxColumn
            // 
            this.additionalMessageDataGridViewTextBoxColumn.DataPropertyName = "AdditionalMessage";
            this.additionalMessageDataGridViewTextBoxColumn.HeaderText = "Дополнительно";
            this.additionalMessageDataGridViewTextBoxColumn.Name = "additionalMessageDataGridViewTextBoxColumn";
            // 
            // requestDateTimeDataGridViewTextBoxColumn
            // 
            this.requestDateTimeDataGridViewTextBoxColumn.DataPropertyName = "RequestDateTime";
            this.requestDateTimeDataGridViewTextBoxColumn.HeaderText = "Дата запроса";
            this.requestDateTimeDataGridViewTextBoxColumn.Name = "requestDateTimeDataGridViewTextBoxColumn";
            // 
            // requestStatusDataGridViewTextBoxColumn
            // 
            this.requestStatusDataGridViewTextBoxColumn.DataPropertyName = "RequestStatus";
            this.requestStatusDataGridViewTextBoxColumn.HeaderText = "Статус запроса";
            this.requestStatusDataGridViewTextBoxColumn.Name = "requestStatusDataGridViewTextBoxColumn";
            // 
            // EcuCode
            // 
            this.EcuCode.DataPropertyName = "EcuCode";
            this.EcuCode.HeaderText = "Номер компьютера";
            this.EcuCode.Name = "EcuCode";
            // 
            // dgRequests
            // 
            this.dgRequests.AutoGenerateColumns = false;
            this.dgRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EcuCode,
            this.requestStatusDataGridViewTextBoxColumn,
            this.requestDateTimeDataGridViewTextBoxColumn,
            this.additionalMessageDataGridViewTextBoxColumn,
            this.stockFileNameDataGridViewTextBoxColumn});
            this.dgRequests.DataSource = this.reflashRequestBindingSource;
            this.dgRequests.Location = new System.Drawing.Point(0, 3);
            this.dgRequests.Name = "dgRequests";
            this.dgRequests.Size = new System.Drawing.Size(601, 170);
            this.dgRequests.TabIndex = 4;
            // 
            // pbRequest
            // 
            this.pbRequest.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbRequest.Location = new System.Drawing.Point(354, 238);
            this.pbRequest.Name = "pbRequest";
            this.pbRequest.Size = new System.Drawing.Size(28, 29);
            this.pbRequest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRequest.TabIndex = 6;
            this.pbRequest.TabStop = false;
            this.pbRequest.Visible = false;
            // 
            // pnlRequestsHistory
            // 
            this.pnlRequestsHistory.Controls.Add(this.dgRequests);
            this.pnlRequestsHistory.Controls.Add(this.btnRefreshRequests);
            this.pnlRequestsHistory.Controls.Add(this.pbRequestHistory);
            this.pnlRequestsHistory.Location = new System.Drawing.Point(3, 287);
            this.pnlRequestsHistory.Name = "pnlRequestsHistory";
            this.pnlRequestsHistory.Size = new System.Drawing.Size(605, 221);
            this.pnlRequestsHistory.TabIndex = 8;
            // 
            // VTFlasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 803);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbModule);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Name = "VTFlasher";
            this.Text = "VTFlasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VTFlasher_FormClosing);
            this.Load += new System.EventHandler(this.VTFlasher_Load);
            this.gbModule.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabReflash.ResumeLayout(false);
            this.tabReflash.PerformLayout();
            this.panelKeyUnavailible.ResumeLayout(false);
            this.panelKeyUnavailible.PerformLayout();
            this.tabRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRequestHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashRequestBindingSource)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReflashHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReflashHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reflashHistoryBindingSource)).EndInit();
            this.tabPerson.ResumeLayout(false);
            this.tabPerson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalInfo)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            this.pnlSendRequest.ResumeLayout(false);
            this.pnlSendRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequest)).EndInit();
            this.pnlRequestsHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox cbAdapter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbModules;
        private System.Windows.Forms.Label lbAdapter;
        private System.Windows.Forms.GroupBox gbModule;
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
        private System.Windows.Forms.Button btnRead;
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
        private System.Windows.Forms.TextBox tbErrors;
        private System.Windows.Forms.ComboBox cbCarModel;
        private System.Windows.Forms.ComboBox cbCarManufacture;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelKeyUnavailible;
        private System.Windows.Forms.Label labelKeyUnavailible;
        private System.Windows.Forms.Button btnReloadFlasher;
        private System.Windows.Forms.Label lblErrLogin;
        private System.Windows.Forms.Label lblEcuNumber;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cvnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reslashFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reflashDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reflashStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentStatusDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn EcuCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlRequestsHistory;
    }
}

