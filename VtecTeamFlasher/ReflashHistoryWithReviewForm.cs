using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAndServerCommons.DataClasses;
using VtecTeamFlasher.Helpers;

namespace VtecTeamFlasher
{
    public partial class ReflashHistoryWithReviewForm : Form
    {
        private ReflashHistory history;
        
        public ReflashHistoryWithReviewForm()
        {
            InitializeComponent();
        }

        public ReflashHistoryWithReviewForm(ReflashHistory history)
        {
            InitializeComponent(); 
            this.history = history;
            txtBynaryFileName.Text = history.BinaryFileName;
            txtVin.Text = history.CarVin;
            txtPreviousBinaryName.Text = history.PreviousBinaryName;
            txtReflashDate.Text = history.ReflashDate.ToString();
            txtPrice.Text = history.Price;
            txtStatus.Text = StatusResolver.ResolveReflashStatus(history.Status);

            if(history.Review == null)
            {
                txtCarOvner.Enabled = true;
                txtReview.Enabled = true;
                btnSendReview.Enabled = true;
            }
            else
            {
                txtCarOvner.Text = history.Review.UserName;
                txtReview.Text = history.Review.UserReview;
                chbEditReview.Visible = true;
            }
        }

        private async void btnSendReview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCarOvner.Text) || string.IsNullOrEmpty(txtReview.Text))
            {
                MessageBox.Show(@"Поле Номер 'Имя владельца авто' и 'Отзыв' обязательны для заполнения");
                return;
            }

            var currentStatus = PanelRefresh.StartRefresh(this, pbReview);
            await Task.Run(() =>
            {
                var review = new Review
                {
                    ReviewDateTime = DateTime.Now,
                    SourceUrl = null,
                    UserName = txtCarOvner.Text,
                    UserReview = txtReview.Text
                };
                history.Review = review;
                RequestExecutor.Execute(()=>
                {
                    var result = WCFServiceFactory.CreateVtecTeamService().UpdateReflashHistory(history);

                    this.Invoke(() => pbReview.Image = !result ? Properties.Resources.Error : null);
                    MessageBox.Show(result ? "Запрос успешно отправлен" : "Не удалось отправить запрос.");
                });
                
            });
            pbReview.Visible = false;
            PanelRefresh.StopRefresh(currentStatus);
        }

        private void chbEditReview_CheckedChanged(object sender, EventArgs e)
        {
            if(chbEditReview.Checked)
            {
                txtCarOvner.Enabled = true;
                txtReview.Enabled = true;
                btnSendReview.Enabled = true;
            }
            else
            {
                txtCarOvner.Enabled = false;
                txtReview.Enabled = false;
                btnSendReview.Enabled = false;
            }
        }
    }
}
