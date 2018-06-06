namespace MIK
{
    partial class newRequest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.dgv_clients = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.Label();
            this.btn_new = new System.Windows.Forms.Button();
            this.recipient_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipient_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipient_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_shipment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.type_payment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.type_delivery = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sender_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender_passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_clients
            // 
            this.dgv_clients.AllowUserToAddRows = false;
            this.dgv_clients.AllowUserToDeleteRows = false;
            this.dgv_clients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_clients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sender_name,
            this.sender_passport,
            this.sender_city,
            this.sender_index,
            this.type_delivery,
            this.type_payment,
            this.type_shipment,
            this.recipient_name,
            this.recipient_city,
            this.recipient_index,
            this.recipient_address});
            this.dgv_clients.Location = new System.Drawing.Point(16, 81);
            this.dgv_clients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_clients.Name = "dgv_clients";
            this.dgv_clients.Size = new System.Drawing.Size(1631, 156);
            this.dgv_clients.TabIndex = 16;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(711, 11);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(314, 31);
            this.title.TabIndex = 17;
            this.title.Text = "Создание новой заявки";
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(759, 281);
            this.btn_new.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(241, 53);
            this.btn_new.TabIndex = 18;
            this.btn_new.Text = "Создать заявку";
            this.btn_new.UseVisualStyleBackColor = true;
            // 
            // recipient_address
            // 
            this.recipient_address.HeaderText = "Адрес";
            this.recipient_address.Name = "recipient_address";
            // 
            // recipient_index
            // 
            this.recipient_index.HeaderText = "Индекс";
            this.recipient_index.Name = "recipient_index";
            this.recipient_index.Width = 60;
            // 
            // recipient_city
            // 
            this.recipient_city.HeaderText = "Город";
            this.recipient_city.Name = "recipient_city";
            // 
            // recipient_name
            // 
            this.recipient_name.HeaderText = "Ф.И.О. получателя";
            this.recipient_name.Name = "recipient_name";
            this.recipient_name.Width = 200;
            // 
            // type_shipment
            // 
            this.type_shipment.HeaderText = "Тип отправления";
            this.type_shipment.Items.AddRange(new object[] {
            "Письмо",
            "Бандероль",
            "Посылочка",
            "Заказное письмо"});
            this.type_shipment.Name = "type_shipment";
            this.type_shipment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type_shipment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // type_payment
            // 
            this.type_payment.HeaderText = "Тип оплаты";
            this.type_payment.Items.AddRange(new object[] {
            "Наличными",
            "Безнал"});
            this.type_payment.Name = "type_payment";
            this.type_payment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type_payment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.type_payment.Width = 60;
            // 
            // type_delivery
            // 
            this.type_delivery.HeaderText = "Тип доставки";
            this.type_delivery.Items.AddRange(new object[] {
            "Стандартная",
            "Срочная",
            "Заказная"});
            this.type_delivery.Name = "type_delivery";
            this.type_delivery.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type_delivery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sender_index
            // 
            this.sender_index.HeaderText = "Индекс";
            this.sender_index.Name = "sender_index";
            this.sender_index.Width = 60;
            // 
            // sender_city
            // 
            this.sender_city.HeaderText = "Город";
            this.sender_city.Name = "sender_city";
            this.sender_city.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // sender_passport
            // 
            this.sender_passport.HeaderText = "Серия номер паспорта";
            this.sender_passport.Name = "sender_passport";
            this.sender_passport.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // sender_name
            // 
            this.sender_name.HeaderText = "Ф.И.О. отправителя";
            this.sender_name.Name = "sender_name";
            this.sender_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sender_name.Width = 200;
            // 
            // newRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 348);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.title);
            this.Controls.Add(this.dgv_clients);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "newRequest";
            this.Text = "Создание новой заявки";
            this.Load += new System.EventHandler(this.newRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_clients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_clients;
        public System.Windows.Forms.Label title;
        public System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender_index;
        private System.Windows.Forms.DataGridViewComboBoxColumn type_delivery;
        private System.Windows.Forms.DataGridViewComboBoxColumn type_payment;
        private System.Windows.Forms.DataGridViewComboBoxColumn type_shipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipient_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipient_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipient_address;
    }
}