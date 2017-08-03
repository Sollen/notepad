using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblProductName.Text = $@"Product Name: {Application.ProductName}";
            lblProductVersion.Text = $@"Version: {Application.ProductVersion}";
            lblCopyright.Text = @"Copyright ©  2017 by Sollen";


        }
    }
}
