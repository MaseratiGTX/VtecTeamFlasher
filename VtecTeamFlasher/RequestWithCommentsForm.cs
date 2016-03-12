using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Statuses;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraTreeList.Nodes;
using VtecTeamFlasher.Helpers;

namespace VtecTeamFlasher
{
    public partial class RequestWithCommentsForm : Form
    {
        private ReflashRequest request;
        public RequestWithCommentsForm()
        {
            InitializeComponent();
        }

        public RequestWithCommentsForm(ReflashRequest request)
        {
            InitializeComponent();

            this.request = request;

            this.Text = string.Format("{0} - {1}", this.Text, request.Id);
            lblWachRequest.Text = string.Format("{0} - {1}", lblWachRequest.Text, request.Id);
            txtEcuNumber.Text = request.EcuNumber;
            txtEcuBinaryNumber.Text = request.BinaryNumber;
            txtRequestCarDescription.Text = request.CarDescription;
            txtAdditionalInfo.Text = request.RequestDetails;
            if (request.StockBinary != null)
            {
                txtStockFilePath.Text = request.StockBinaryName;
                btnOpenFile.Enabled = false;
            }

            if (request.EcuPhoto != null)
                txtEcuPhotoStatus.Text = request.EcuPhotoFilename;
            txtUserName.Text = Session.CurrentUser.FirstName;
            txtExpectedDate.Text = request.ExpectedResolveDate == null ? txtExpectedDate.Text : request.ExpectedResolveDate.ToString();
        }

        private async void btnRefreshRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequestCarDescription.Text))
            {
                MessageBox.Show("Поле Номер Машина обязательно для заполнения");
                return;
            }
            
            var currentStatus = PanelRefresh.StartRefresh(this, pbRefreshRequest);
            await Task.Run(() =>
            {

                request.BinaryNumber = txtEcuBinaryNumber.Text;
                request.CarDescription = txtRequestCarDescription.Text;
                request.EcuNumber = txtEcuNumber.Text;

                request.RequestDetails = txtAdditionalInfo.Text;
                request.UserId = Session.CurrentUser.Id;
                request.RequestDate = DateTime.Now;
                request.Status = (int) RequestStatuses.New;
                
                if (File.Exists(txtEcuPhotoStatus.Text))
                {
                    request.EcuPhoto = File.ReadAllBytes(txtEcuPhotoStatus.Text);
                    request.EcuPhotoFilename = Path.GetFileName(txtEcuPhotoStatus.Text);
                }
                
                RequestExecutor.Execute(()=>
                {
                    var result = WCFServiceFactory.CreateVtecTeamService().SendRequest(request);

                    this.Invoke(() => pbRefreshRequest.Image = !result ? Properties.Resources.Error : null);
                    MessageBox.Show(result ? "Запрос успешно отправлен" : "Не удалось отправить запрос.");
                });
                
            });
            pbRefreshRequest.Visible = false;
            PanelRefresh.StopRefresh(currentStatus);
        }


        private void btnRequestUploadEcuPhoto_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "Все картинки|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|Все файлы|*.*" };

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            txtEcuPhotoStatus.Text = fileDialog.FileName;

        }

        private void RequestWithCommentsForm_Load(object sender, EventArgs e)
        {
            tlComments.BackColor = Color.Transparent;
            foreach (var comment in request.Comments)
                AddNode(comment.User.FirstName, comment.CommentText, comment.CommentDate);
        }

        private void AddNode(string userName, string comment, DateTime date)
        {
            var nameNode = tlComments.AppendNode(null, null);
            nameNode.SetValue("info", string.Format("{0}     {1}", userName, date));
            var commentNode = tlComments.AppendNode(null, nameNode);
            commentNode.SetValue("info", comment);
            tlComments.ExpandAll();
        }

        private async void btnSendComment_Click(object sender, EventArgs e)
        {
            var currentStatus = PanelRefresh.StartRefresh(this, pbSendComment);
            await Task.Run(() =>
            {
                var comment = new Comment
                {
                    CommentDate = DateTime.Now,
                    CommentText = txtComment.Text,
                    RequestId = request.Id,
                    //UserId = Session.CurrentUser.Id,
                    User = Session.CurrentUser
                };

                RequestExecutor.Execute(()=>
                {
                    var savedComment = WCFServiceFactory.CreateVtecTeamService().SendComment(comment);

                    this.Invoke(() => pbRefreshRequest.Image = !savedComment.Result ? Properties.Resources.Error : null);
                    this.Invoke(() =>
                    {
                        if (savedComment.Result)
                        {
                            AddNode(txtUserName.Text, comment.CommentText, comment.CommentDate);
                            txtComment.Text = "";

                            comment.Id = savedComment.EntityId;
                            // fucking magic to add new item in fixed size array
                            var commentsArray = request.Comments.ToArray();
                            Array.Resize(ref commentsArray, commentsArray.Length + 1);
                            commentsArray[commentsArray.Length - 1] = comment;
                            request.Comments = commentsArray;
                        }
                        else
                            MessageBox.Show("Не удалось отправить комментарий.");
                    });
                });

            });
            pbSendComment.Visible = false;
            PanelRefresh.StopRefresh(currentStatus);
        }

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.ParentNode == null)
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        }


    }

}
