namespace VtecTeamFlasher
{
    partial class ReviewForm
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
            this.txtCarOvner.Location = new System.Drawing.Point(128, 10);
            this.txtCarOvner.Name = "txtCarOvner";
            this.txtCarOvner.Size = new System.Drawing.Size(341, 20);
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
            this.txtReview.Location = new System.Drawing.Point(56, 44);
            this.txtReview.Multiline = true;
            this.txtReview.Name = "txtReview";
            this.txtReview.Size = new System.Drawing.Size(413, 201);
            this.txtReview.TabIndex = 1;
            // 
            // btnSendReview
            // 
            this.btnSendReview.Location = new System.Drawing.Point(338, 255);
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
            this.pbReview.Location = new System.Drawing.Point(287, 255);
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
            this.pnlReview.Location = new System.Drawing.Point(3, 0);
            this.pnlReview.Name = "pnlReview";
            this.pnlReview.Size = new System.Drawing.Size(472, 249);
            this.pnlReview.TabIndex = 4;
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 307);
            this.Controls.Add(this.pnlReview);
            this.Controls.Add(this.pbReview);
            this.Controls.Add(this.btnSendReview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReviewForm";
            this.Text = "ReviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbReview)).EndInit();
            this.pnlReview.ResumeLayout(false);
            this.pnlReview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCarOvner;
        private System.Windows.Forms.TextBox txtCarOvner;
        private System.Windows.Forms.Label lblReview;
        private System.Windows.Forms.TextBox txtReview;
        private System.Windows.Forms.Button btnSendReview;
        private System.Windows.Forms.PictureBox pbReview;
        private System.Windows.Forms.Panel pnlReview;
    }
}