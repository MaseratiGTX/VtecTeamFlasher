using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAndServerCommons.DataClasses;
using VtecTeamFlasher.Helpers;

namespace VtecTeamFlasher
{
    public partial class ReviewForm : Form
    {
        private int historyId;
        
        public ReviewForm()
        {
            InitializeComponent();
        }

        public ReviewForm(int historyId)
        {
            InitializeComponent(); 
            this.historyId = historyId;
        }

        private async void btnSendReview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCarOvner.Text) || string.IsNullOrEmpty(txtReview.Text))
            {
                MessageBox.Show(@"Поле Номер 'Имя владельца авто' и 'Отзыв' обязательны для заполнения");
                return;
            }

            pnlReview.Enabled = false;
            btnSendReview.Enabled = false;
            pbReview.Visible = true;
            pbReview.Image = Properties.Resources.Animation;
            await Task.Run(() =>
            {
                var review = new Review
                {
                    ReflashHistoryId = historyId,
                    ReviewDateTime = DateTime.Now,
                    SourceUrl = null,
                    UserName = txtCarOvner.Text,
                    UserReview = txtReview.Text
                };

                var result = WCFServiceFactory.CreateVtecTeamService().SendReview(review);

                this.Invoke(() => pbReview.Image = !result ? Properties.Resources.Error : null);
                MessageBox.Show(result ? "Запрос успешно отправлен" : "Не удалось отправить запрос.");
            });
            pnlReview.Enabled = true;
            btnSendReview.Enabled = true;
        }
    }
}
