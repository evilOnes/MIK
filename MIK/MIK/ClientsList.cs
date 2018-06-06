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

        public static List<City> cities = new List<City>();
        public static List<Shipment> shipments = new List<Shipment>();
        public static List<Sender> senders = new List<Sender>();
        public static List<Payment> payments = new List<Payment>();
        public static List<Recipient> recipients = new List<Recipient>();
        public static List<ShipmentType> shTypes = new List<ShipmentType>();
        public static List<PaymentType> pTypes = new List<PaymentType>();
        public static List<User> users = new List<User>();
        public static List<Request> requests = new List<Request>();


        public static void Open()
        {
            if (c.State != ConnectionState.Open)
                c.Open();
        }

        public ClientsList()
        {
            InitializeComponent();
        }

        void GetCities()
        {
            cities.Clear();
            City t;
            cmd.CommandText = "select * from city";

            Open();
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                t = new City();
                t.id = (int)reader[0];
                t.name = reader[1].ToString();
                t.index = (int)reader[2];
                t.address = reader[3].ToString();

                cities.Add(t);               
            }
            reader.Close();

            c.Close();
        }
        void GetShipments()
        {
            shipments.Clear();
            Shipment t;
            cmd.CommandText = "select * from dostavka";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Shipment();
                t.id = (int)reader[0];
                t.type = reader[1].ToString();
                t.idP = (int)reader[2];

                shipments.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void GetSenders()// get after cities
        {
            senders.Clear();
            Sender t;
            cmd.CommandText = "select * from klient";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Sender();
                t.id = (int)reader[0];
                t.name = reader[1].ToString();
                t.passport = reader[2].ToString();
                t.idC = (int)reader[3];
                t.city = cities.Find(x => x.id == t.idC).name;

                senders.Add(t);
            }
            reader.Close();

            c.Close();
        }

        void GetPayments()
        {
            payments.Clear();
            Payment t;
            cmd.CommandText = "select * from oplata";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Payment();
                t.id = (int)reader[0];
                t.idPt = (int)reader[1];
                t.dPrice = reader[2].ToString();
                t.idSt = (int)reader[3];

                payments.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void GetRecipients()
        {
            recipients.Clear();
            Recipient t;
            cmd.CommandText = "select * from poluchatel";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Recipient();
                t.id = (int)reader[0];
                t.name = reader[1].ToString();
                t.idC = (int)reader[2];

                t.city = cities.Find(x => x.id == t.idC).name;

                recipients.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void GetShipmentTypes()
        {
            shTypes.Clear();
            ShipmentType t;
            cmd.CommandText = "select * from type";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new ShipmentType();
                t.id = (int)reader[0];
                t.type = reader[1].ToString();

                shTypes.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void GetPaymentTypes()
        {
            pTypes.Clear();
            PaymentType t;
            cmd.CommandText = "select * from typeoplata";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new PaymentType();
                t.id = (int)reader[0];
                t.type = reader[1].ToString();

                pTypes.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void GetUsers()
        {
            users.Clear();
            User t;
            cmd.CommandText = "select * from user";

            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new User();
                t.id = (int)reader[0];
                t.login = reader[1].ToString();
                t.pwd = reader[2].ToString();

                users.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void GetRequests()
        {
            requests.Clear();
            Request t;
            cmd.CommandText = "select * from zayavka";
            
            Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Request();
                t.id = (int)reader[0];
                t.idS = (int)reader[1];
                t.idC = (int)reader[2];
                t.idU = (int)reader[3];
                t.idR = (int)reader[4];

                requests.Add(t);
            }
            reader.Close();

            c.Close();
        }
        void UpdateDgv()
        {
            //get all stuff
            GetCities();
            GetShipments();
            GetSenders();
            GetPayments();
            GetRecipients();
            GetShipmentTypes();
            GetPaymentTypes();
            GetUsers();
            GetRequests();

            DataTable dt = new DataTable();
            dt.TableName = "Список клиентов";
            dt.Columns.Add("Ф.И.О. отправителя");
            dt.Columns.Add("Город отправления");
            dt.Columns.Add("Тип доставки");
            dt.Columns.Add("Тип отправления");
            dt.Columns.Add("Ф.И.О. получателя");
            dt.Columns.Add("Город получателя");
            dt.Columns.Add("№ заявки");

            Sender s;
            ShipmentType st;
            Payment p;
            for (int i = 0; i < requests.Count; i++)
            {
                s = new Sender();
                p = new Payment();
                st = new ShipmentType();

                p = payments.Find(x1 => x1.id == shipments.Find(x2 => x2.id == requests[i].idS).idP);
                s = senders.Find(x => x.id == requests[i].idC);
                st = shTypes.Find(x => x.id == p.idSt);
                dt.Rows.Add(new object[]
                {
                    s.name,
                    s.city,
                    st.type,
                    shipments.Find(x => x.idP == p.id).type,
                    recipients.Find(x => x.id == requests[i].idR).name,
                    recipients.Find(x => x.id == requests[i].idR).city,
                    requests[i].id
                });
            }

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
            PrintDialog p = new PrintDialog();
            p.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var cr = dgv_clients.SelectedCells[0].OwningRow;

            Open();
            cmd.CommandText = "delete from zayavka where IDz = " + cr.Cells[6].Value;
            cmd.ExecuteNonQuery();
            c.Close();
            UpdateDgv();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            newRequest f = new newRequest();
            f.editMode = false;
            f.ShowDialog();
            UpdateDgv();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            newRequest f = new newRequest();
            
            var cr = dgv_clients.SelectedCells[0].OwningRow;

            MessageBox.Show(cr.Cells[0].Value.ToString());
            MessageBox.Show(senders.Find(x => x.name == cr.Cells[0].Value.ToString()).passport.ToString());
            MessageBox.Show(cr.Cells[1].Value.ToString());
            MessageBox.Show(cities.Find(x => x.name == cr.Cells[1].Value.ToString()).index.ToString());
            MessageBox.Show(cr.Cells[2].Value.ToString());
            MessageBox.Show(  pTypes.Find(x => x.id == payments.Find(x1 => x1.idSt == shipments.Find(x2 => x2.type == cr.Cells[3].Value.ToString()).idP).idPt).type.ToString());
            MessageBox.Show(cr.Cells[3].Value.ToString());
            MessageBox.Show(cr.Cells[4].Value.ToString());
            MessageBox.Show(cr.Cells[5].Value.ToString());
            MessageBox.Show(cities.Find(x => x.name == cr.Cells[5].Value.ToString()).index.ToString());
            MessageBox.Show(cities.Find(x => x.name == cr.Cells[5].Value.ToString()).address.ToString());

            f.dgv_clients.Rows.Clear();
            f.idZ = requests[cr.Index].id;
            f.idP = recipients.Find(x => x.name == cr.Cells[4].Value.ToString()).id;
            f.idK = senders.Find(x => x.name == cr.Cells[0].Value.ToString()).id;
            f.idD = shipments.Find(x => x.type == cr.Cells[3].Value.ToString()).id;
            f.dgv_clients.Rows.Add(new object[]
            {
                cr.Cells[0].Value,
                senders.Find(x => x.name == cr.Cells[0].Value.ToString()).passport,
                cr.Cells[1].Value,
                cities.Find(x => x.name == cr.Cells[1].Value.ToString()).index,
                null,
                null,
                null,
                //cr.Cells[2].Value,
                //pTypes.Find(x => x.id == payments.Find(x1 => x1.idSt == shipments.Find(x2 => x2.type == cr.Cells[3].Value.ToString()).idP).idPt).id-1,
                //cr.Cells[3].Value,
                cr.Cells[4].Value,
                cr.Cells[5].Value,
                cities.Find(x => x.name == cr.Cells[5].Value.ToString()).index,
                cities.Find(x => x.name == cr.Cells[5].Value.ToString()).address
            });
            
            f.editMode = true;
            f.ShowDialog();
            UpdateDgv();
        }
    }
    public class City
    {
        public int id;
        public string name;
        public int index;
        public string address;
    }
    public class Shipment
    {
        public int id;
        public string type;
        public int idP;//payment id
        public string Pt;//payment
    }
    public class Sender
    {
        public int id;
        public string name;
        public string passport;
        public int idC;
        public string city;
    }
    public class Payment
    {
        public int id;
        public int idPt;//payment type id
        public string dPrice;//department price
        public int idSt;//shipment type id
    }
    public class Recipient
    {
        public int id;
        public string name;
        public int idC;
        public string city;
    }
    public class ShipmentType
    {
        public int id;
        public string type;
    }
    public class PaymentType
    {
        public int id;
        public string type;
    }
    public class User
    {
        public int id;
        public string login;
        public string pwd;
    }
    public class Request
    {
        public int id;
        public int idS;//shipment id
        public int idC;//client id
        public int idU;//user id
        public int idR;//recipient id
    }


}
