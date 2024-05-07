using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProducts
{
    public partial class ClientForm : Form
    {

        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int clientId = -1;
        public string clientName;
        public  string clientPhone;

        public ClientForm(NpgsqlConnection conn)
        {
            /*
             Метод-конструктор для вставки данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
        }

        public ClientForm(NpgsqlConnection conn, int clientId, string clientName, string clientPhone)
        {
            /*
             Метод-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.clientId = clientId;
            this.clientName = clientName;
            this.clientPhone = clientPhone;
            textBoxName.Text = clientName;
            textBoxPhone.Text = clientPhone;
        }



        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
               Метод, который подтверждает вставку/изменение данных
           */

            //для вставки
            if (this.clientId == -1)
            {
                if (textBoxName.Text != "" && textBoxPhone.Text != "")
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = @"
                    INSERT 
                    INTO Clients (client_name, phone) 
                    VALUES (:client_name,  :phone)";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("client_name", textBoxName.Text);
                        command.Parameters.AddWithValue("phone", textBoxPhone.Text);
                        command.ExecuteNonQuery();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Не удалось добавить запись!\nУбедитесь, что вы ввели все данные корректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //для изменения
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.clientId + "?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = @"
                    UPDATE Clients 
                    SET client_name = :client_name, phone = :phone 
                    WHERE client_id = :client_id";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("client_id", this.clientId);
                    command.Parameters.AddWithValue("client_name", textBoxName.Text);
                    command.Parameters.AddWithValue("phone", textBoxPhone.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            /*
           Метод, который корректно закрывает форму
           */

            DialogResult result = MessageBox.Show("Текущие изменения не будут сохранены! Вы действительно хотите закрыть окно?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
