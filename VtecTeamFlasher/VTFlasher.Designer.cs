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
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.tabPerson = new System.Windows.Forms.TabPage();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.checkBoxSavePassword = new System.Windows.Forms.CheckBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblErrLogin = new System.Windows.Forms.Label();
            this.gbModule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabReflash.SuspendLayout();
            this.panelKeyUnavailible.SuspendLayout();
            this.panelLogin.SuspendLayout();
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
            this.tabControlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.ItemSize = new System.Drawing.Size(90, 25);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(615, 537);
            this.tabControlMain.TabIndex = 7;
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
            this.tabRequest.Location = new System.Drawing.Point(4, 29);
            this.tabRequest.Name = "tabRequest";
            this.tabRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequest.Size = new System.Drawing.Size(607, 504);
            this.tabRequest.TabIndex = 1;
            this.tabRequest.Text = "Запросы";
            this.tabRequest.UseVisualStyleBackColor = true;
            // 
            // tabHistory
            // 
            this.tabHistory.Location = new System.Drawing.Point(4, 29);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(607, 504);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "История";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // tabPerson
            // 
            this.tabPerson.Location = new System.Drawing.Point(4, 29);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.Size = new System.Drawing.Size(607, 504);
            this.tabPerson.TabIndex = 3;
            this.tabPerson.Text = "Персонализация";
            this.tabPerson.UseVisualStyleBackColor = true;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.lblErrLogin);
            this.panelLogin.Controls.Add(this.checkBoxSavePassword);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.labelLogin);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Location = new System.Drawing.Point(12, 12);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(647, 802);
            this.panelLogin.TabIndex = 8;
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
            // lblErrLogin
            // 
            this.lblErrLogin.AutoSize = true;
            this.lblErrLogin.BackColor = System.Drawing.SystemColors.Control;
            this.lblErrLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrLogin.ForeColor = System.Drawing.Color.Red;
            this.lblErrLogin.Location = new System.Drawing.Point(165, 112);
            this.lblErrLogin.Name = "lblErrLogin";
            this.lblErrLogin.Size = new System.Drawing.Size(0, 17);
            this.lblErrLogin.TabIndex = 6;
            // 
            // VTFlasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 803);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbModule);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.panelLogin);
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
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
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
    }
}

