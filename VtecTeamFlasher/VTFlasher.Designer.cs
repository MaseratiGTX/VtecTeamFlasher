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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnReadErrors = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnEraseErrors = new System.Windows.Forms.Button();
            this.btnResetAdaptation = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.cbControlSum = new System.Windows.Forms.CheckBox();
            this.gbModule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(372, 50);
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
            this.cbAdapter.Location = new System.Drawing.Point(86, 23);
            this.cbAdapter.Name = "cbAdapter";
            this.cbAdapter.Size = new System.Drawing.Size(361, 21);
            this.cbAdapter.TabIndex = 1;
            this.cbAdapter.SelectedIndexChanged += new System.EventHandler(this.cbAdapter_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(372, 581);
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
            this.lbAdapter.Location = new System.Drawing.Point(26, 26);
            this.lbAdapter.Name = "lbAdapter";
            this.lbAdapter.Size = new System.Drawing.Size(49, 13);
            this.lbAdapter.TabIndex = 3;
            this.lbAdapter.Text = "Адаптер";
            // 
            // gbModule
            // 
            this.gbModule.Controls.Add(this.btnResetAdaptation);
            this.gbModule.Controls.Add(this.btnEraseErrors);
            this.gbModule.Controls.Add(this.btnRestart);
            this.gbModule.Controls.Add(this.btnInitialize);
            this.gbModule.Controls.Add(this.btnReadErrors);
            this.gbModule.Controls.Add(this.btnIdentify);
            this.gbModule.Controls.Add(this.cbModules);
            this.gbModule.Location = new System.Drawing.Point(29, 92);
            this.gbModule.Name = "gbModule";
            this.gbModule.Size = new System.Drawing.Size(418, 122);
            this.gbModule.TabIndex = 4;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "Модуль";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbControlSum);
            this.groupBox1.Controls.Add(this.btnRead);
            this.groupBox1.Controls.Add(this.btnWrite);
            this.groupBox1.Controls.Add(this.btnOpenFileDialog);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Location = new System.Drawing.Point(29, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
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
            this.txtStatus.Location = new System.Drawing.Point(29, 329);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(418, 246);
            this.txtStatus.TabIndex = 6;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(7, 47);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(121, 29);
            this.btnIdentify.TabIndex = 2;
            this.btnIdentify.Text = "Идентификация";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnReadErrors
            // 
            this.btnReadErrors.Location = new System.Drawing.Point(151, 47);
            this.btnReadErrors.Name = "btnReadErrors";
            this.btnReadErrors.Size = new System.Drawing.Size(121, 29);
            this.btnReadErrors.TabIndex = 2;
            this.btnReadErrors.Text = "Прочитать ошибки";
            this.btnReadErrors.UseVisualStyleBackColor = true;
            this.btnReadErrors.Click += new System.EventHandler(this.btnReadErrors_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(291, 47);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(121, 29);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Перезагрузка";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(7, 82);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(121, 29);
            this.btnInitialize.TabIndex = 2;
            this.btnInitialize.Text = "Инициализация";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnEraseErrors
            // 
            this.btnEraseErrors.Location = new System.Drawing.Point(151, 82);
            this.btnEraseErrors.Name = "btnEraseErrors";
            this.btnEraseErrors.Size = new System.Drawing.Size(121, 29);
            this.btnEraseErrors.TabIndex = 2;
            this.btnEraseErrors.Text = "Стереть ошибки";
            this.btnEraseErrors.UseVisualStyleBackColor = true;
            this.btnEraseErrors.Click += new System.EventHandler(this.btnEraseErrors_Click);
            // 
            // btnResetAdaptation
            // 
            this.btnResetAdaptation.Location = new System.Drawing.Point(291, 82);
            this.btnResetAdaptation.Name = "btnResetAdaptation";
            this.btnResetAdaptation.Size = new System.Drawing.Size(121, 29);
            this.btnResetAdaptation.TabIndex = 2;
            this.btnResetAdaptation.Text = "Сброс адаптации";
            this.btnResetAdaptation.UseVisualStyleBackColor = true;
            this.btnResetAdaptation.Click += new System.EventHandler(this.btnResetAdaptation_Click);
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
            // VTFlasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 616);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbModule);
            this.Controls.Add(this.lbAdapter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbAdapter);
            this.Controls.Add(this.btnSettings);
            this.Name = "VTFlasher";
            this.Text = "VTFlasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VTFlasher_FormClosing);
            this.Load += new System.EventHandler(this.VTFlasher_Load);
            this.gbModule.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

