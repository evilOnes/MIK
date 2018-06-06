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
    public partial class newRequest : Form
    {
        public bool editMode = false;
        public int idZ, idD, idK, idP;
        public DataGridViewRow row;
        public newRequest()
        {
            InitializeComponent();
        }

        private void btn_create(object sender, EventArgs e)
        {
            var dd = (dgv_clients.SelectedCells[0].OwningRow.Cells[6] as DataGridViewComboBoxCell);
            string dk = dgv_clients.SelectedCells[0].OwningRow.Cells[0].Value.ToString();//sender
            string dp = dgv_clients.SelectedCells[0].OwningRow.Cells[7].Value.ToString();//recipient
            int idd, idk, idu, idp;
            idd = dd.Items.IndexOf(dd.Value)+1;
            idu = Auth.userID;

            idk = setIDk(dk);
            idp = setIDp(dp);


            //new request
            ClientsList.Open();
            ClientsList.cmd.CommandText = "insert into zayavka (IDd, IDk, IDu, IDp) values (" + idd + ", " + idk + ", " + idu + ", " + idp + ")";
            MessageBox.Show(ClientsList.cmd.CommandText);
            Clipboard.SetText(ClientsList.cmd.CommandText); 
            ClientsList.cmd.ExecuteNonQuery();
            ClientsList.c.Close();
            Close();
        }
        int setIDk(string dk)
        {
            string stRes;
            int res = 0;
            var row = dgv_clients.SelectedCells[0].OwningRow.Cells;

            if (!Exists("klient", "kfio", dk, "IDk", ref res))
            {
                ClientsList.Open();
                ClientsList.cmd.CommandText = "insert into klient (kfio, kserialnumber, IDc) values ('" + 
                    row[0].Value.ToString() + "', '" + 
                    row[1].Value.ToString() + "', " +
                    ClientsList.cities.Find(x => x.name == row[2].Value.ToString()).id + ")";
                ClientsList.cmd.ExecuteNonQuery();
                ClientsList.c.Close();
                Exists("klient", "kfio", dk, "IDk", ref res);
            }
            
            return res;
        }
        int setIDp(string dp)
        {
            string stRes;
            int res = 0;
            var row = dgv_clients.SelectedCells[0].OwningRow.Cells;

            if (!Exists("poluchatel", "pFIO", dp, "IDp", ref res))
            {
                ClientsList.Open();
                ClientsList.cmd.CommandText = "insert into poluchatel (pFIO, IDc) values ('" +
                    row[7].Value.ToString() + "', " +
                    ClientsList.cities.Find(x => x.name == row[8].Value.ToString()).id + ")";
                ClientsList.cmd.ExecuteNonQuery();
                ClientsList.c.Close();
                Exists("poluchatel", "pFIO", dp, "IDp", ref res);
            }
            
            return res;
        }

        int setIDpEdit(string d)
        {
            int res = 0;

            var row = dgv_clients.SelectedCells[0].OwningRow.Cells;

            if (!Exists("poluchatel", "pFIO", d, "IDp", ref res))
            {
                ClientsList.cmd.CommandText = "insert into poluchatel (pFIO, IDc) values ('" +
                    row[7].Value.ToString() + "', " +
                    ClientsList.cities.Find(x => x.name == row[8].Value.ToString()).id + ")";
            }
            else
            {
                ClientsList.cmd.CommandText = "update poluchatel set pFIO = '" + row[7].Value.ToString() +
                    "', IDc = " + ClientsList.cities.Find(x => x.name == row[8].Value.ToString()).id + " where IDp = " + idP;
            }
            ClientsList.Open();
            MessageBox.Show(ClientsList.cmd.CommandText);
            ClientsList.cmd.ExecuteNonQuery();
            ClientsList.c.Close();

            Exists("poluchatel", "pFIO", d, "IDp", ref res);
            return res;
        }
        int setIDkEdit(string d)
        {
            int res = 0;
            var row = dgv_clients.SelectedCells[0].OwningRow.Cells;

            if (Exists("klient", "kfio", d, "IDk", ref res))
            {
                ClientsList.cmd.CommandText = "update klient set kfio = '" + row[0].Value.ToString() +
                    "', kserialnumber = '" + row[1].Value.ToString() +
                    "', IDc = " + ClientsList.cities.Find(x => x.name == row[8].Value.ToString()).id +
                    " where IDk = " + idK;
            }
            else
            {
                ClientsList.cmd.CommandText = "insert into klient (kfio, kserialnumber, IDc) values ('" +
                    row[0].Value.ToString() + "', '" +
                    row[1].Value.ToString() + "', " +
                    ClientsList.cities.Find(x => x.name == row[2].Value.ToString()).id + ")";
            }
            ClientsList.Open();
            MessageBox.Show(ClientsList.cmd.CommandText);
            ClientsList.cmd.ExecuteNonQuery();
            ClientsList.c.Close();

            Exists("klient", "kfio", row[0].Value.ToString(), "IDk", ref res);
            return res;
        }

        void setTypes()
        {
            var row = dgv_clients.SelectedCells[0].OwningRow.Cells;
            
            ClientsList.cmd.CommandText = "update dostavka set tdost = '" + row[6].Value.ToString() + "'";
            ClientsList.Open();
            ClientsList.cmd.ExecuteNonQuery();

            ClientsList.c.Close();
        }

        bool Exists(string t, string c, string v, string r, ref int result)
        {
            bool res = true;

            ClientsList.Open();
            ClientsList.cmd.CommandText = "select " + r + " from " + t + " where " + c + " = '" + v + "'";
            MessageBox.Show(ClientsList.cmd.CommandText);
            result = 0;
            ClientsList.reader = ClientsList.cmd.ExecuteReader();
            while (ClientsList.reader.Read())
                result = (int)ClientsList.reader[0];
            if (result == 0)
                res = false;
            ClientsList.c.Close();

            return res;

        }
        private void btn_edit(object sender, EventArgs e)
        {
            var dd = (dgv_clients.SelectedCells[0].OwningRow.Cells[6] as DataGridViewComboBoxCell);
            string dk = dgv_clients.SelectedCells[0].OwningRow.Cells[0].Value.ToString();//sender
            string dp = dgv_clients.SelectedCells[0].OwningRow.Cells[7].Value.ToString();//recipient
            int idd, idk, idu, idp;
            idd = dd.Items.IndexOf(dd.Value) + 1;
            idu = Auth.userID;

            idk = setIDkEdit(dk);
            idp = setIDpEdit(dp);
            setTypes();

            //edit request
            ClientsList.Open();
            ClientsList.cmd.CommandText = "update zayavka set IDd = " + idd + ", IDk  = " + idk + ", IDu = " + idu + ", IDp = " + idp + " where IDz = " + idZ;
            MessageBox.Show(ClientsList.cmd.CommandText);
            Clipboard.SetText(ClientsList.cmd.CommandText);
            ClientsList.cmd.ExecuteNonQuery();
            ClientsList.c.Close();
            Close();
        }
        private void newRequest_Load(object sender, EventArgs e)
        {
            dgv_clients.Rows.Add();
            if (!editMode)
            {
                title.Text = "Создание новой заявки";
                btn_new.Text = "Создать заявку";
                btn_new.Click += new EventHandler(btn_create);

                dgv_clients.AllowUserToAddRows = true;
                dgv_clients.AllowUserToDeleteRows = true;
                dgv_clients.AllowUserToOrderColumns = true;
            }
            else
            {
                title.Text = "Редактирование заявки";
                btn_new.Text = "Сохранить изменения";
                btn_new.Click += new EventHandler(btn_edit);

                dgv_clients.AllowUserToAddRows = false;
                dgv_clients.AllowUserToDeleteRows = false;
                dgv_clients.AllowUserToOrderColumns = false;
                
            }
        }
    }
}
