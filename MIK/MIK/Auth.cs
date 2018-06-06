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
        public static int userID;
        public static string log;
        public static string pwd;
        public Auth()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            ClientsList.Open();
            ClientsList.cmd.CommandText = "select IDu, ulogin from user where upass = '" + tb_pwd.Text + "'";
            ClientsList.reader = ClientsList.cmd.ExecuteReader();
            while(ClientsList.reader.Read())
            {
                userID = (int)ClientsList.reader[0];
                log = ClientsList.reader[1].ToString();
            }
            ClientsList.reader.Close();
            ClientsList.c.Close();

            if (log != null)
            {
                ClientsList f = new ClientsList();
                Hide();
                f.Show();
            }
            else
                MessageBox.Show("Ошибка");
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register f = new Register();
            f.ShowDialog();

        }

        private void Auth_Load(object sender, EventArgs e)
        {
            tb_login.Text = "VitktoriaA";
            tb_pwd.Text = "23er45ty";
        }
    }
}
