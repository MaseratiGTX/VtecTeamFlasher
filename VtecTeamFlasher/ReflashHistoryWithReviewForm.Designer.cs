namespace VtecTeamFlasher
{
    partial class ReflashHistoryWithReviewForm
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
            this.lblCarOvner = new System.Windows.Forms.Label();
            this.txtCarOvner = new System.Windows.Forms.TextBox();
            this.lblReview = new System.Windows.Forms.Label();
            this.txtReview = new System.Windows.Forms.TextBox();
            this.btnSendReview = new System.Windows.Forms.Button();
            this.pbReview = new System.Windows.Forms.PictureBox();
            this.pnlReview = new System.Windows.Forms.Panel();
            this.lblBynaryFileName = new System.Windows.Forms.Label();
            this.txtBynaryFileName = new System.Windows.Forms.TextBox();
            this.txtVin = new System.Windows.Forms.TextBox();
            this.lblVin = new System.Windows.Forms.Label();
            this.txtPreviousBinaryName = new System.Windows.Forms.TextBox();
            this.lblPreviousBinaryName = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtReflashDate = new System.Windows.Forms.TextBox();
            this.lblReflashDate = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnReturnToStock = new System.Windows.Forms.Button();
            this.chbEditReview = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbReview)).BeginInit();
            this.pnlReview.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCarOvner
            // 
            this.lblCarOvner.AutoSize = true;
            this.lblCarOvner.Location = new System.Drawing.Point(10, 13);
            this.lblCarOvner.Name = "lblCarOvner";
            this.lblCarOvner.Size = new System.Drawing.Size(112, 13);
            this.lblCarOvner.TabIndex = 0;
            this.lblCarOvner.Text = "Имя владельца авто";
            // 
            // txtCarOvner
            // 
            this.txtCarOvner.Enabled = false;
            this.txtCarOvner.Location = new System.Drawing.Point(128, 10);
            this.txtCarOvner.Name = "txtCarOvner";
            this.txtCarOvner.Size = new System.Drawing.Size(385, 20);
            this.txtCarOvner.TabIndex = 1;
            // 
            // lblReview
            // 
            this.lblReview.AutoSize = true;
            this.lblReview.Location = new System.Drawing.Point(10, 47);
            this.lblReview.Name = "lblReview";
            this.lblReview.Size = new System.Drawing.Size(40, 13);
            this.lblReview.TabIndex = 0;
            this.lblReview.Text = "Отзыв";
            // 
            // txtReview
            // 
            this.txtReview.Enabled = false;
            this.txtReview.Location = new System.Drawing.Point(56, 44);
            this.txtReview.Multiline = true;
            this.txtReview.Name = "txtReview";
            this.txtReview.Size = new System.Drawing.Size(457, 201);
            this.txtReview.TabIndex = 1;
            // 
            // btnSendReview
            // 
            this.btnSendReview.Enabled = false;
            this.btnSendReview.Location = new System.Drawing.Point(399, 448);
            this.btnSendReview.Name = "btnSendReview";
            this.btnSendReview.Size = new System.Drawing.Size(134, 39);
            this.btnSendReview.TabIndex = 2;
            this.btnSendReview.Text = "Отправить отзыв";
            this.btnSendReview.UseVisualStyleBackColor = true;
            this.btnSendReview.Click += new System.EventHandler(this.btnSendReview_Click);
            // 
            // pbReview
            // 
            this.pbReview.Image = global::VtecTeamFlasher.Properties.Resources.Animation;
            this.pbReview.Location = new System.Drawing.Point(348, 448);
            this.pbReview.Name = "pbReview";
            this.pbReview.Size = new System.Drawing.Size(45, 39);
            this.pbReview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReview.TabIndex = 3;
            this.pbReview.TabStop = false;
            this.pbReview.Visible = false;
            // 
            // pnlReview
            // 
            this.pnlReview.Controls.Add(this.txtReview);
            this.pnlReview.Controls.Add(this.lblCarOvner);
            this.pnlReview.Controls.Add(this.lblReview);
            this.pnlReview.Controls.Add(this.txtCarOvner);
            this.pnlReview.Location = new System.Drawing.Point(17, 193);
            this.pnlReview.Name = "pnlReview";
            this.pnlReview.Size = new System.Drawing.Size(516, 249);
            this.pnlReview.TabIndex = 4;
            // 
            // lblBynaryFileName
            // 
            this.lblBynaryFileName.AutoSize = true;
            this.lblBynaryFileName.Location = new System.Drawing.Point(25, 13);
            this.lblBynaryFileName.Name = "lblBynaryFileName";
            this.lblBynaryFileName.Size = new System.Drawing.Size(117, 13);
            this.lblBynaryFileName.TabIndex = 5;
            this.lblBynaryFileName.Text = "Имя файла прошивки";
            // 
            // txtBynaryFileName
            // 
            this.txtBynaryFileName.Enabled = false;
            this.txtBynaryFileName.Location = new System.Drawing.Point(148, 10);
            this.txtBynaryFileName.Name = "txtBynaryFileName";
            this.txtBynaryFileName.Size = new System.Drawing.Size(385, 20);
            this.txtBynaryFileName.TabIndex = 1;
            // 
            // txtVin
            // 
            this.txtVin.Enabled = false;
            this.txtVin.Location = new System.Drawing.Point(148, 36);
            this.txtVin.Name = "txtVin";
            this.txtVin.Size = new System.Drawing.Size(385, 20);
            this.txtVin.TabIndex = 1;
            // 
            // lblVin
            // 
            this.lblVin.AutoSize = true;
            this.lblVin.Location = new System.Drawing.Point(25, 39);
            this.lblVin.Name = "lblVin";
            this.lblVin.Size = new System.Drawing.Size(92, 13);
            this.lblVin.TabIndex = 5;
            this.lblVin.Text = "Вин код машины";
            // 
            // txtPreviousBinaryName
            // 
            this.txtPreviousBinaryName.Enabled = false;
            this.txtPreviousBinaryName.Location = new System.Drawing.Point(215, 62);
            this.txtPreviousBinaryName.Name = "txtPreviousBinaryName";
            this.txtPreviousBinaryName.Size = new System.Drawing.Size(318, 20);
            this.txtPreviousBinaryName.TabIndex = 1;
            // 
            // lblPreviousBinaryName
            // 
            this.lblPreviousBinaryName.AutoSize = true;
            this.lblPreviousBinaryName.Location = new System.Drawing.Point(25, 65);
            this.lblPreviousBinaryName.Name = "lblPreviousBinaryName";
            this.lblPreviousBinaryName.Size = new System.Drawing.Size(184, 13);
            this.lblPreviousBinaryName.TabIndex = 5;
            this.lblPreviousBinaryName.Text = "Имя файла предыдущей прошивки";
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(148, 88);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(385, 20);
            this.txtStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(25, 91);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Статус";
            // 
            // txtReflashDate
            // 
            this.txtReflashDate.Enabled = false;
            this.txtReflashDate.Location = new System.Drawing.Point(148, 114);
            this.txtReflashDate.Name = "txtReflashDate";
            this.txtReflashDate.Size = new System.Drawing.Size(385, 20);
            this.txtReflashDate.TabIndex = 1;
            // 
            // lblReflashDate
            // 
            this.lblReflashDate.AutoSize = true;
            this.lblReflashDate.Location = new System.Drawing.Point(25, 117);
            this.lblReflashDate.Name = "lblReflashDate";
            this.lblReflashDate.Size = new System.Drawing.Size(86, 13);
            this.lblReflashDate.TabIndex = 5;
            this.lblReflashDate.Text = "Дата прошивки";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(148, 140);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(385, 20);
            this.txtPrice.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(25, 143);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Цена";
            // 
            // btnReturnToStock
            // 
            this.btnReturnToStock.Location = new System.Drawing.Point(5, 534);
            this.btnReturnToStock.Name = "btnReturnToStock";
            this.btnReturnToStock.Size = new System.Drawing.Size(249, 39);
            this.btnReturnToStock.TabIndex = 2;
            this.btnReturnToStock.Text = "Запрос на возврат в сток";
            this.btnReturnToStock.UseVisualStyleBackColor = true;
            this.btnReturnToStock.Click += new System.EventHandler(this.btnSendReview_Click);
            // 
            // chbEditReview
            // 
            this.chbEditReview.AutoSize = true;
            this.chbEditReview.Location = new System.Drawing.Point(17, 449);
            this.chbEditReview.Name = "chbEditReview";
            this.chbEditReview.Size = new System.Drawing.Size(111, 17);
            this.chbEditReview.TabIndex = 6;
            this.chbEditReview.Text = "Изменить отзыв";
            this.chbEditReview.UseVisualStyleBackColor = true;
            this.chbEditReview.Visible = false;
            this.chbEditReview.CheckedChanged += new System.EventHandler(this.chbEditReview_CheckedChanged);
            // 
            // ReflashHistoryWithReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 581);
            this.Controls.Add(this.chbEditReview);
            this.Controls.Add(this.lblPreviousBinaryName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblReflashDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblVin);
            this.Controls.Add(this.lblBynaryFileName);
            this.Controls.Add(this.pnlReview);
            this.Controls.Add(this.pbReview);
            this.Controls.Add(this.txtPreviousBinaryName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtReflashDate);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtVin);
            this.Controls.Add(this.txtBynaryFileName);
            this.Controls.Add(this.btnReturnToStock);
            this.Controls.Add(this.btnSendReview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReflashHistoryWithReviewForm";
            this.Text = "ReviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbReview)).EndInit();
            this.pnlReview.ResumeLayout(false);
            this.pnlReview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCarOvner;
        private System.Windows.Forms.TextBox txtCarOvner;
        private System.Windows.Forms.Label lblReview;
        private System.Windows.Forms.TextBox txtReview;
        private System.Windows.Forms.Button btnSendReview;
        private System.Windows.Forms.PictureBox pbReview;
        private System.Windows.Forms.Panel pnlReview;
        private System.Windows.Forms.Label lblBynaryFileName;
        private System.Windows.Forms.TextBox txtBynaryFileName;
        private System.Windows.Forms.TextBox txtVin;
        private System.Windows.Forms.Label lblVin;
        private System.Windows.Forms.TextBox txtPreviousBinaryName;
        private System.Windows.Forms.Label lblPreviousBinaryName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtReflashDate;
        private System.Windows.Forms.Label lblReflashDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnReturnToStock;
        private System.Windows.Forms.CheckBox chbEditReview;
    }
}