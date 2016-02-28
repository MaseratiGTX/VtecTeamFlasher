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

namespace VtecTeamFlasher
{
    public partial class RequestWithCommentsForm : Form
    {
        public RequestWithCommentsForm()
        {
            InitializeComponent();
        }

        public RequestWithCommentsForm(ReflashRequest request)
        {
            InitializeComponent();

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
        }
    }
}
