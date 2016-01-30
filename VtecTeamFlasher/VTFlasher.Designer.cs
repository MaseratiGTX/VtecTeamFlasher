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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
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
            this.btnExit.Location = new System.Drawing.Point(372, 489);
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
            this.gbModule.Controls.Add(this.cbModules);
            this.gbModule.Location = new System.Drawing.Point(29, 92);
            this.gbModule.Name = "gbModule";
            this.gbModule.Size = new System.Drawing.Size(418, 161);
            this.gbModule.TabIndex = 4;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "Модуль";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenFileDialog);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Location = new System.Drawing.Point(29, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 92);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(6, 17);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(362, 20);
            this.txtFilePath.TabIndex = 0;
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
            // VTFlasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 534);
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
    }
}

