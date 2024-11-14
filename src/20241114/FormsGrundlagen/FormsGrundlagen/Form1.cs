using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsGrundlagen
{
    public partial class frm_MainApp : Form
    {
        public frm_MainApp()
        {
            InitializeComponent();
        }

        private void btt_save_Click(object sender, EventArgs e)
        {
            lbl_mainInfo.Text = "Hello " + txt_name.Text;
            txt_name.Text = string.Empty;
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            lbl_mainInfo.Text = "Hello World Application V1.0";
            txt_name.Text = string.Empty;
        }
    }
}
