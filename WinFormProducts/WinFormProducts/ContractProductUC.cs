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
    public partial class ContractProductUC : UserControl
    {

        //соединение с бд и работа с отображением данных
        public NpgsqlConnection conn;
        public System.Data.DataTable dtContract = new System.Data.DataTable();
        public DataSet dsContract = new DataSet();
        public System.Data.DataTable dtContractProduct = new System.Data.DataTable();
        public DataSet dsContractProduct = new DataSet();


        public ContractProductUC(NpgsqlConnection conn)
        {/*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void ContractProductUC_Load(object sender, EventArgs e)
        {

            /*
             Функция, которая отоюражает данные при загрузки панели
             */

            UpdateContract();
            UpdateContractProduct();
        }


        private void UpdateContract()
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            dtContract.Clear();
            string sqlProductsInvoices = @"
            SELECT * 
            FROM Contracts";
            NpgsqlDataAdapter daProductsInvoices = new NpgsqlDataAdapter(sqlProductsInvoices, conn);
            dsContract.Reset();
            daProductsInvoices.Fill(dsContract);
            dtContract = dsContract.Tables[0];
            dataGridViewContract.DataSource = null;
            dataGridViewContract.DataSource = dtContract;
            dataGridViewContract.Columns[0].HeaderText = "Код договора";
            dataGridViewContract.Columns[1].HeaderText = "Код клиента";
            dataGridViewContract.Columns[2].HeaderText = "Дата подписания";
            dataGridViewContract.Columns[3].HeaderText = "Общая сумма";
            dataGridViewContract.Columns[4].HeaderText = "Оплаченная сумма";
            dataGridViewContract.Columns[5].HeaderText = "Статус оплаты";
            dataGridViewContract.Columns[6].HeaderText = "Статус отгрузки";
            dataGridViewContract.Columns[7].HeaderText = "Сумма предоплаты";
            dataGridViewContract.Sort(dataGridViewContract.Columns["contract_id"], ListSortDirection.Ascending);
            dataGridViewContract.Refresh();

            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridViewContract.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void UpdateContractProduct()
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            dtContractProduct.Clear();
            string sqlBillOfLanding = @"
            SELECT * 
            FROM Contract_Products";
            NpgsqlDataAdapter daBillOfLanding = new NpgsqlDataAdapter(sqlBillOfLanding, conn);
            dsContractProduct.Reset();
            daBillOfLanding.Fill(dsContractProduct);
            dtContractProduct = dsContractProduct.Tables[0];
            dataGridViewContractProduct.DataSource = null;
            dataGridViewContractProduct.DataSource = dtContractProduct;
            dataGridViewContractProduct.Columns[0].HeaderText = "Код записи";
            dataGridViewContractProduct.Columns[1].HeaderText = "Код договора";
            dataGridViewContractProduct.Columns[2].HeaderText = "Код продукта";
            dataGridViewContractProduct.Columns[3].HeaderText = "Количество";
            dataGridViewContractProduct.Columns[4].HeaderText = "К оплате за товар";
            dataGridViewContractProduct.Sort(dataGridViewContractProduct.Columns["contract_product_id"], ListSortDirection.Ascending);
            dataGridViewContractProduct.Refresh();

            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridViewContractProduct.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonAddContract_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для вставки данных
             */

            List<String> clientsNames = new List<String>();
            string sql = @"
            SELECT client_name 
            FROM Clients";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string clientName = reader.GetString(0);
                clientsNames.Add(clientName);
            }
            reader.Close();

            ContranctForm contractForm = new ContranctForm(conn, clientsNames);
            contractForm.ShowDialog();
            UpdateContract();
        }

        private void buttonChangeContract_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для редактирования данных
             */

            int contractId = (int)dataGridViewContract.CurrentRow.Cells["contract_id"].Value;
            int clientId = (int)dataGridViewContract.CurrentRow.Cells["client_id"].Value;
            DateTime signedDate;
            try
            {
                signedDate = (DateTime)dataGridViewContract.CurrentRow.Cells["date_signed"].Value;
            }
            catch (Exception ex)
            {
                signedDate = DateTime.Today;
            }
            decimal advancedPayment = (decimal)dataGridViewContract.CurrentRow.Cells["advance_payment"].Value;
            string shipmentStatus = (string)dataGridViewContract.CurrentRow.Cells["shipment_status"].Value;


            string sql = @"
            SELECT client_name 
            FROM Clients 
            WHERE client_id = :client_id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("client_id", clientId);
            object clientNameObj = command.ExecuteScalar();
            string clientName = Convert.ToString(clientNameObj);


            List<String> clientsNames = new List<String>();
            sql = @"
            SELECT client_name 
            FROM Clients";
            command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tmpClientName = reader.GetString(0);
                clientsNames.Add(tmpClientName);
            }
            reader.Close();


            ContranctForm contractForm = new ContranctForm(conn, contractId, signedDate, clientName, clientsNames, advancedPayment, shipmentStatus);
            contractForm.ShowDialog();
            UpdateContract();
        }

        private void buttonDeleteContract_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая удаляет данные без вызова формы
             */

            int contractId = (int)dataGridViewContract.CurrentRow.Cells["contract_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + contractId + "?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE FROM Contracts 
                WHERE contract_id = :contract_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("contract_id", contractId);
                command.ExecuteNonQuery();
                UpdateContract();
            }
        }
    }
}
