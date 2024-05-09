using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Provider;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormProducts
{
    public partial class ContranctForm : Form
    {

        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int contractId = -1;
        public DateTime signedDate;
        public string clientName;
        public List<String> clientsNames;
        public List<String> shipmentsStatuses = ["не отгружено", "отгружено"];
        public decimal advancedPayment;
        public string shipmentStatus;

        public ContranctForm(NpgsqlConnection conn, List<String> clientsNames)
        {
            /*
             Функция-конструктор для вставки данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.clientsNames = clientsNames;
            this.comboBoxClientName.DataSource = clientsNames;
        }

        public ContranctForm(NpgsqlConnection conn, int contractId, DateTime signedDate, string clientName, List<String> clientsNames, decimal advancedPayment, string shipmentStatus)
        {
            /*
             Функция-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.contractId = contractId;
            this.signedDate = signedDate;
            this.dateTimePicker.Value = signedDate;
            this.clientName = clientName;
            this.comboBoxClientName.DataSource = clientsNames;
            this.advancedPayment = advancedPayment;
            this.textBoxAdvancedPayment.Text = advancedPayment.ToString();
            this.shipmentStatus = shipmentStatus;
            this.comboBoxSipmentStatus.SelectedItem = shipmentStatus;
        }


        private void ContranctForm_Load(object sender, EventArgs e)
        {
            /*
             Функция, которая загружает содержимое в комбоБокс при загрузки формы
             */

            this.comboBoxClientName.SelectedItem = clientName;
            this.comboBoxSipmentStatus.DataSource = shipmentsStatuses;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая подтверждает вставку/изменение данных
             */

            //для вставки
            if (this.contractId == -1)
            {
                decimal res;
                if (comboBoxSipmentStatus.SelectedItem != null && comboBoxClientName.SelectedItem != null && decimal.TryParse(textBoxAdvancedPayment.Text, out res))
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = @"
                        SELECT client_id 
                        FROM Clients 
                        WHERE client_name = :client_name";
                            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                            command.Parameters.AddWithValue("client_name", comboBoxClientName.SelectedItem.ToString());
                            object clientIdObj = command.ExecuteScalar();
                            int clientId = Convert.ToInt32(clientIdObj);

                        sql = @"
                        INSERT 
                        INTO Contracts (client_id, date_signed, total_amount, advance_payment, shipment_status) 
                        VALUES (:client_id, :date_signed, :total_amount, :advance_payment, :shipment_status)";
                            command = new NpgsqlCommand(sql, conn);
                            command.Parameters.AddWithValue("client_id", clientId);
                            command.Parameters.AddWithValue("date_signed", dateTimePicker.Value);
                            command.Parameters.AddWithValue("total_amount", 0.00);
                            command.Parameters.AddWithValue("advance_payment", decimal.Parse(this.textBoxAdvancedPayment.Text));
                            command.Parameters.AddWithValue("shipment_status", comboBoxSipmentStatus.SelectedItem.ToString());
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
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.contractId + "?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = @"
                    SELECT client_id 
                    FROM Clients 
                    WHERE client_name = :client_name";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("client_name", comboBoxClientName.SelectedItem.ToString());
                    object clientIdObj = command.ExecuteScalar();
                    int clientId = Convert.ToInt32(clientIdObj);

                    sql = @"
                    UPDATE Contracts 
                    SET client_id = :client_id, date_signed = :date_signed, advance_payment = :advance_payment, shipment_status = :shipment_status
                    WHERE contract_id = :contract_id";
                    command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("contract_id", this.contractId);
                    command.Parameters.AddWithValue("client_id", clientId);
                    command.Parameters.AddWithValue("date_signed", dateTimePicker.Value);
                    command.Parameters.AddWithValue("advance_payment", decimal.Parse(this.textBoxAdvancedPayment.Text));
                    command.Parameters.AddWithValue("shipment_status", comboBoxSipmentStatus.SelectedItem.ToString());
                    command.ExecuteNonQuery();
                    Close();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

            /*
             Функция, которая корректно закрывает форму
             */

            DialogResult result = MessageBox.Show("Вы действительно хотите закрыть окно?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }


        //Мусора наплодил 

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }
    }
}
