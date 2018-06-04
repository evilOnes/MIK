using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MIK
{
    public partial class ClientsList : Form
    {
        public static MySqlConnection c = new MySqlConnection("Server=localhost; Database=test21; User id=root; Password=;");
        public static MySqlCommand cmd = c.CreateCommand();
        public static MySqlDataReader reader;

        public static void Open()
        {
            if (c.State != ConnectionState.Open)
                c.Open();
        }

        public ClientsList()
        {
            InitializeComponent();
        }

        void UpdateDgv()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Список клиентов";
            dt.Columns.Add("Ф.И.О. отправителя");
            dt.Columns.Add("Город отправления");
            dt.Columns.Add("Тип доставки");
            dt.Columns.Add("Тип отправления");
            dt.Columns.Add("Ф.И.О. получателя");
            dt.Columns.Add("Город получателя");
            dt.Columns.Add("№ заявки");

            //fill dt
            cmd.CommandText = "select kfio from klient";

            Open();

            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                dt.Rows.Add(new object[] { reader[0] });
            }
            reader.Close();

            c.Close();


            //bind
            dgv_clients.DataSource = dt;

        }

        private void ClientsList_Load(object sender, EventArgs e)
        {
            UpdateDgv();
        }

        private void ClientsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        

        private void btn_print_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            newRequest f = new newRequest();
            f.editMode = false;
            f.ShowDialog();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            object[] r = new object[11];
            newRequest f = new newRequest();
            //fill row
            f.row = r;
            f.editMode = true;
            f.ShowDialog();
        }
    }
    public class 
}
