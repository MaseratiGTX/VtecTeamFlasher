namespace VtecTeamFlasher
{
    partial class RequestWithCommentsForm
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
            this.lblWachRequest = new System.Windows.Forms.Label();
            this.btnRequestUploadEcuPhoto = new System.Windows.Forms.Button();
            this.lblCarDescription = new System.Windows.Forms.Label();
            this.txtRequestCarDescription = new System.Windows.Forms.TextBox();
            this.txtEcuPhotoStatus = new System.Windows.Forms.TextBox();
            this.txtEcuBinaryNumber = new System.Windows.Forms.TextBox();
            this.lblEcuPhoto = new System.Windows.Forms.Label();
            this.lblBinaryNumber = new System.Windows.Forms.Label();
            this.lblEcuNumber = new System.Windows.Forms.Label();
            this.txtEcuNumber = new System.Windows.Forms.TextBox();
            this.lblAdditionalInfo = new System.Windows.Forms.Label();
            this.txtAdditionalInfo = new System.Windows.Forms.TextBox();
            this.txtStockFilePath = new System.Windows.Forms.TextBox();
            this.lblStockFile = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWachRequest
            // 
            this.lblWachRequest.AutoSize = true;
            this.lblWachRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWachRequest.Location = new System.Drawing.Point(229, 7);
            this.lblWachRequest.Name = "lblWachRequest";
            this.lblWachRequest.Size = new System.Drawing.Size(169, 20);
            this.lblWachRequest.TabIndex = 30;
            this.lblWachRequest.Text = "Просмотр Запроса";
            // 
            // btnRequestUploadEcuPhoto
            // 
            this.btnRequestUploadEcuPhoto.Location = new System.Drawing.Point(500, 113);
            this.btnRequestUploadEcuPhoto.Name = "btnRequestUploadEcuPhoto";
            this.btnRequestUploadEcuPhoto.Size = new System.Drawing.Size(98, 25);
            this.btnRequestUploadEcuPhoto.TabIndex = 29;
            this.btnRequestUploadEcuPhoto.Text = "Загрузить";
            this.btnRequestUploadEcuPhoto.UseVisualStyleBackColor = true;
            // 
            // lblCarDescription
            // 
            this.lblCarDescription.AutoSize = true;
            this.lblCarDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCarDescription.Location = new System.Drawing.Point(27, 167);
            this.lblCarDescription.Name = "lblCarDescription";
            this.lblCarDescription.Size = new System.Drawing.Size(48, 13);
            this.lblCarDescription.TabIndex = 28;
            this.lblCarDescription.Text = "Машина";
            // 
            // txtRequestCarDescription
            // 
            this.txtRequestCarDescription.Location = new System.Drawing.Point(135, 155);
            this.txtRequestCarDescription.Multiline = true;
            this.txtRequestCarDescription.Name = "txtRequestCarDescription";
            this.txtRequestCarDescription.Size = new System.Drawing.Size(463, 105);
            this.txtRequestCarDescription.TabIndex = 27;
            // 
            // txtEcuPhotoStatus
            // 
            this.txtEcuPhotoStatus.Enabled = false;
            this.txtEcuPhotoStatus.Location = new System.Drawing.Point(135, 114);
            this.txtEcuPhotoStatus.Name = "txtEcuPhotoStatus";
            this.txtEcuPhotoStatus.Size = new System.Drawing.Size(352, 20);
            this.txtEcuPhotoStatus.TabIndex = 26;
            this.txtEcuPhotoStatus.Text = "не загружен";
            this.txtEcuPhotoStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEcuBinaryNumber
            // 
            this.txtEcuBinaryNumber.Location = new System.Drawing.Point(135, 76);
            this.txtEcuBinaryNumber.Name = "txtEcuBinaryNumber";
            this.txtEcuBinaryNumber.Size = new System.Drawing.Size(463, 20);
            this.txtEcuBinaryNumber.TabIndex = 25;
            // 
            // lblEcuPhoto
            // 
            this.lblEcuPhoto.AutoSize = true;
            this.lblEcuPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEcuPhoto.Location = new System.Drawing.Point(27, 117);
            this.lblEcuPhoto.Name = "lblEcuPhoto";
            this.lblEcuPhoto.Size = new System.Drawing.Size(69, 13);
            this.lblEcuPhoto.TabIndex = 24;
            this.lblEcuPhoto.Text = "Фото мозга";
            // 
            // lblBinaryNumber
            // 
            this.lblBinaryNumber.AutoSize = true;
            this.lblBinaryNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBinaryNumber.Location = new System.Drawing.Point(27, 79);
            this.lblBinaryNumber.Name = "lblBinaryNumber";
            this.lblBinaryNumber.Size = new System.Drawing.Size(94, 13);
            this.lblBinaryNumber.TabIndex = 23;
            this.lblBinaryNumber.Text = "Номер прошивки";
            // 
            // lblEcuNumber
            // 
            this.lblEcuNumber.AutoSize = true;
            this.lblEcuNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEcuNumber.Location = new System.Drawing.Point(27, 42);
            this.lblEcuNumber.Name = "lblEcuNumber";
            this.lblEcuNumber.Size = new System.Drawing.Size(75, 13);
            this.lblEcuNumber.TabIndex = 22;
            this.lblEcuNumber.Text = "Номер мозга";
            // 
            // txtEcuNumber
            // 
            this.txtEcuNumber.Location = new System.Drawing.Point(135, 39);
            this.txtEcuNumber.Name = "txtEcuNumber";
            this.txtEcuNumber.Size = new System.Drawing.Size(463, 20);
            this.txtEcuNumber.TabIndex = 18;
            // 
            // lblAdditionalInfo
            // 
            this.lblAdditionalInfo.AutoSize = true;
            this.lblAdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblAdditionalInfo.Location = new System.Drawing.Point(27, 278);
            this.lblAdditionalInfo.Name = "lblAdditionalInfo";
            this.lblAdditionalInfo.Size = new System.Drawing.Size(65, 13);
            this.lblAdditionalInfo.TabIndex = 16;
            this.lblAdditionalInfo.Text = "Пожелания";
            // 
            // txtAdditionalInfo
            // 
            this.txtAdditionalInfo.Location = new System.Drawing.Point(135, 275);
            this.txtAdditionalInfo.Multiline = true;
            this.txtAdditionalInfo.Name = "txtAdditionalInfo";
            this.txtAdditionalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdditionalInfo.Size = new System.Drawing.Size(463, 131);
            this.txtAdditionalInfo.TabIndex = 19;
            // 
            // txtStockFilePath
            // 
            this.txtStockFilePath.Enabled = false;
            this.txtStockFilePath.Location = new System.Drawing.Point(135, 416);
            this.txtStockFilePath.Name = "txtStockFilePath";
            this.txtStockFilePath.Size = new System.Drawing.Size(352, 20);
            this.txtStockFilePath.TabIndex = 20;
            this.txtStockFilePath.Text = "не загружен";
            this.txtStockFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStockFile
            // 
            this.lblStockFile.AutoSize = true;
            this.lblStockFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblStockFile.Location = new System.Drawing.Point(27, 419);
            this.lblStockFile.Name = "lblStockFile";
            this.lblStockFile.Size = new System.Drawing.Size(86, 13);
            this.lblStockFile.TabIndex = 17;
            this.lblStockFile.Text = "Стоковый файл";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(500, 415);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(98, 25);
            this.btnOpenFile.TabIndex = 21;
            this.btnOpenFile.Text = "Загрузить";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // RequestWithCommentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 497);
            this.Controls.Add(this.lblWachRequest);
            this.Controls.Add(this.btnRequestUploadEcuPhoto);
            this.Controls.Add(this.lblCarDescription);
            this.Controls.Add(this.txtRequestCarDescription);
            this.Controls.Add(this.txtEcuPhotoStatus);
            this.Controls.Add(this.txtEcuBinaryNumber);
            this.Controls.Add(this.lblEcuPhoto);
            this.Controls.Add(this.lblBinaryNumber);
            this.Controls.Add(this.lblEcuNumber);
            this.Controls.Add(this.txtEcuNumber);
            this.Controls.Add(this.lblAdditionalInfo);
            this.Controls.Add(this.txtAdditionalInfo);
            this.Controls.Add(this.txtStockFilePath);
            this.Controls.Add(this.lblStockFile);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "RequestWithCommentsForm";
            this.Text = "История запроса с комментариями";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWachRequest;
        private System.Windows.Forms.Button btnRequestUploadEcuPhoto;
        private System.Windows.Forms.Label lblCarDescription;
        private System.Windows.Forms.TextBox txtRequestCarDescription;
        private System.Windows.Forms.TextBox txtEcuPhotoStatus;
        private System.Windows.Forms.TextBox txtEcuBinaryNumber;
        private System.Windows.Forms.Label lblEcuPhoto;
        private System.Windows.Forms.Label lblBinaryNumber;
        private System.Windows.Forms.Label lblEcuNumber;
        private System.Windows.Forms.TextBox txtEcuNumber;
        private System.Windows.Forms.Label lblAdditionalInfo;
        private System.Windows.Forms.TextBox txtAdditionalInfo;
        private System.Windows.Forms.TextBox txtStockFilePath;
        private System.Windows.Forms.Label lblStockFile;
        private System.Windows.Forms.Button btnOpenFile;

    }
}