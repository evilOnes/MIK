using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIK
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            ClientsList f = new ClientsList();
            Hide();
            f.Show();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register f = new Register();
            f.ShowDialog();

        }
    }
}
