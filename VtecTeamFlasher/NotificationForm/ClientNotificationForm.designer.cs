namespace VtecTeamFlasher.NotificationForm
{
    partial class ClientNotificationForm
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
            this.lblNotification = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNotification
            // 
            this.lblNotification.BackColor = System.Drawing.Color.White;
            this.lblNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNotification.Location = new System.Drawing.Point(0, 0);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(373, 64);
            this.lblNotification.TabIndex = 0;
            this.lblNotification.Text = "Подождите, идет загрузка";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblNotification);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(373, 64);
            this.pnlMain.TabIndex = 1;
            // 
            // ClientNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 64);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientNotificationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientNotificationForm";
            this.TopMost = true;
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Panel pnlMain;
    }
}