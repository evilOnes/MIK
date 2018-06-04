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
        public object[] row;
        public newRequest()
        {
            InitializeComponent();
        }

        private void btn_create(object sender, EventArgs e)
        {
            //new request
        }
        private void btn_edit(object sender, EventArgs e)
        {
            //edit request
        }
        private void newRequest_Load(object sender, EventArgs e)
        {
            if (!editMode)
            {
                title.Text = "Создание новой заявки";
                btn_new.Text = "Создать заявку";
                btn_new.Click += new EventHandler(btn_create);
            }
            else
            {
                title.Text = "Редактирование заявки";
                btn_new.Text = "Сохранить изменения";
                btn_new.Click += new EventHandler(btn_edit);
                
                dgv_clients.Rows.Add(row);
            }
        }
    }
}
