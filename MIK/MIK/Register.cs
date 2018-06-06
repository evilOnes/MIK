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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            ClientsList.Open();
            ClientsList.cmd.CommandText = "insert into user (ulogin, upass) values ('" + tb_login.Text + "', '" + tb_pwd.Text + "')";
            ClientsList.cmd.ExecuteNonQuery();
            ClientsList.c.Close();
            MessageBox.Show("Регистрация прошла успешно.");
        }
    }
}
