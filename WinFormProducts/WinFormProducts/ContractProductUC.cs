using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

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
            SELECT cp.contract_product_id, cp.contract_id, cp.product_id, p.product_name, cp.quantity, cp.total_price
            FROM Contract_Products cp
            JOIN Products p ON cp.product_id = p.product_id";
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

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая отображает товары для выбранного контракта
             */

            int contractId = (int)dataGridViewContract.CurrentRow.Cells["contract_id"].Value;
            dtContractProduct.Clear();
            string sql = @"
            SELECT * 
            FROM  Contract_Products
            WHERE contract_id = " + contractId;
            NpgsqlDataAdapter dtAlterContractProduct = new NpgsqlDataAdapter(sql, conn);
            dsContractProduct.Reset();
            dtAlterContractProduct.Fill(dsContractProduct);
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
        }

        private void buttonUnSelect_Click(object sender, EventArgs e)
        {

            /*
             Функция, которая перезагружает и показывает данные
             */

            UpdateContractProduct();
        }

        private void buttonAddCP_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для вставки данных
             */

            List<String> contractsCodes = new List<String>();
            string sql = @"
            SELECT contract_id 
            FROM Contracts";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int contractCode = reader.GetInt32(0);
                contractsCodes.Add(Convert.ToString(contractCode));
            }
            reader.Close();

            List<String> productsNames = new List<String>();
            sql = @"
            SELECT product_name 
            FROM Products";
            command = new NpgsqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string productName = reader.GetString(0);
                productsNames.Add(productName);
            }
            reader.Close();

            ContractProducts contractProductsForm = new ContractProducts(conn, contractsCodes, productsNames);
            contractProductsForm.ShowDialog();
            UpdateContract();
            UpdateContractProduct();
        }

        private void buttonChangeCP_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для редактирования данных
             */

            int contractProductId = (int)dataGridViewContractProduct.CurrentRow.Cells["contract_product_id"].Value;
            int contractId = (int)dataGridViewContractProduct.CurrentRow.Cells["contract_id"].Value;
            int productId = (int)dataGridViewContractProduct.CurrentRow.Cells["product_id"].Value;
            int productQuantity = (int)dataGridViewContractProduct.CurrentRow.Cells["quantity"].Value;


            string contractCode = Convert.ToString(contractId);
            /*string sql = @"
            SELECT contract_id 
            FROM Contracts 
            WHERE contract_id = :contract_id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("contract_id", contractId);
            object contractIdObj = command.ExecuteScalar();
            string contractCode = Convert.ToString(contractIdObj);*/

            string sql = @"
            SELECT product_name 
            FROM Products 
            WHERE product_id = :product_id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("product_id", productId);
            object productIdObj = command.ExecuteScalar();
            string productName = Convert.ToString(productIdObj);

            List<String> contractsCodes = new List<String>();
            sql = @"
            SELECT contract_id 
            FROM Contracts";
            command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int tmpContractCode = reader.GetInt32(0);
                contractsCodes.Add(Convert.ToString(tmpContractCode));
            }
            reader.Close();

            List<String> productsNames = new List<String>();
            sql = @"
            SELECT product_name 
            FROM Products";
            command = new NpgsqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tmpProductName = reader.GetString(0);
                productsNames.Add(tmpProductName);
            }
            reader.Close();

            ContractProducts contractProductsForm = new ContractProducts(conn, contractProductId, contractCode, contractsCodes, productName, productsNames, productQuantity);
            contractProductsForm.ShowDialog();
            UpdateContract();
            UpdateContractProduct();
        }

        private void buttonDeleteCP_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая удаляет данные без вызова формы
             */

            int contractProductId = (int)dataGridViewContractProduct.CurrentRow.Cells["contract_product_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + contractProductId + "?\nЭто автоматически изменит соответствующую запись из таблицы Договоров!", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE FROM Contract_Products 
                WHERE contract_product_id = :contract_product_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("contract_product_id", contractProductId);
                command.ExecuteNonQuery();
                UpdateContract();
                UpdateContractProduct();
            }
        }

        private void buttonEXL_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая экспортирует данные о договорах и связанных с ними продуктах в созданный Excel-файл
             */

            // Очистка DataTable
            dtContract.Clear();

            // SQL запрос для получения данных о договорах и продуктах
            string sql = @"
                SELECT 
                    c.contract_id,
                    cl.client_name,
                    c.date_signed,
                    string_agg(p.product_name || ' - ' || cp.quantity::text, ', ') AS product_details,
                    c.total_amount,
                    c.prepayment,
                    c.advance_payment,
                    c.payment_status,
                    c.shipment_status
                FROM 
                    Contracts c
                JOIN 
                    Clients cl ON c.client_id = cl.client_id
                JOIN 
                    Contract_Products cp ON c.contract_id = cp.contract_id
                JOIN 
                    Products p ON cp.product_id = p.product_id
                GROUP BY 
                    c.contract_id, cl.client_name, c.date_signed, c.total_amount, c.prepayment, c.advance_payment, c.payment_status, c.shipment_status
                ORDER BY 
                    c.contract_id;";

            // Адаптер для заполнения DataSet
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            dsContract.Reset();
            da.Fill(dsContract);
            dtContract = dsContract.Tables[0];

            // Создание объекта Excel
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filename = ofd.FileName;
            Microsoft.Office.Interop.Excel.Application excelObj = new Microsoft.Office.Interop.Excel.Application();
            excelObj.Visible = true;
            Workbook wb = excelObj.Workbooks.Open(filename, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Worksheet wsh = wb.Sheets[1];

            // Заголовки столбцов
            List<string> listInfo = new List<string> { "Код договора", "Имя клиента", "Дата подписания", "Продукты по договору и их количество", "Общая сумма", "Предоплата по договору", "Текущая внесённая сумма", "Статус платежа", "Статус отгрузки" };
            for (int i = 0; i < listInfo.Count; i++)
            {
                wsh.Cells[1, i + 1] = listInfo[i];
            }

            // Заполнение данных
            try
            {
                for (int row = 0; row < dtContract.Rows.Count; row++)
                {
                    DataRow dr = dtContract.Rows[row];
                    for (int col = 0; col < dtContract.Columns.Count; col++)
                    {
                        wsh.Cells[row + 2, col + 1] = dr[col].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при экспорте данных: " + ex.Message);
            }

            // Обновление интерфейса
            UpdateContract();
            UpdateContractProduct();
        }

        private void clickRow(object sender, DataGridViewCellEventArgs e)
        {

            /*
             Функция, которая отображает товары для выбранного контракта
             */

            int contractId = (int)dataGridViewContract.CurrentRow.Cells["contract_id"].Value;
            dtContractProduct.Clear();
            string sql = @"
            SELECT * 
            FROM  Contract_Products
            WHERE contract_id = " + contractId;
            NpgsqlDataAdapter dtAlterContractProduct = new NpgsqlDataAdapter(sql, conn);
            dsContractProduct.Reset();
            dtAlterContractProduct.Fill(dsContractProduct);
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
        }
    }
}
