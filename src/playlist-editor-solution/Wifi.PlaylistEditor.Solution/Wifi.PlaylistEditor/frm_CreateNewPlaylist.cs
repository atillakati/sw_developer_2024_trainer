using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.CommonTypes;

namespace Wifi.PlaylistEditor
{
    public partial class frm_CreateNewPlaylist : Form, ICreatePlaylist
    {
        public frm_CreateNewPlaylist()
        {
            InitializeComponent();
        }

        public string Title => txt_title.Text;
        public string Author => txt_author.Text;

        public DialogResult StartDialog()
        {
            return ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
