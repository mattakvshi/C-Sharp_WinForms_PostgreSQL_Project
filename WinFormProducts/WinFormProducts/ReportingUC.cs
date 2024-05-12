using Microsoft.Office.Interop.Excel;
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
    public partial class ReportingUC : UserControl
    {

        //соединение с бд и данные для листБоксов
        public NpgsqlConnection conn;
        public string[] clientsNames;



        public ReportingUC(NpgsqlConnection conn, string[] clientsNames)
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
            this.clientsNames = clientsNames;
            this.checkedListBoxClient.Items.AddRange(clientsNames);

        }

        private void buttonMakeUp_Click(object sender, EventArgs e)
        {
            /*
     Функция, которая создаёт отчёт для выбранных клиентов по товарам, положенным к отгрузке, но не отгруженным
     */

            DateTime reportFrom = dateTimePickerTextReportFrom.Value;
            DateTime reportTo = dateTimePickerTextReportTo.Value;
            List<string> clientsNamesChecked = new List<string>();
            for (int i = 0; i < checkedListBoxClient.CheckedItems.Count; i++)
            {
                clientsNamesChecked.Add(checkedListBoxClient.CheckedItems[i].ToString());
            }

            string result = "----------\n";
            result += "Отчёт за период с " + reportFrom.ToShortDateString() + " по " + reportTo.ToShortDateString() + "\n";
            result += "----------\n";

            foreach (string clientName in clientsNamesChecked)
            {
                // Запрос к базе данных для получения информации о неотгруженных товарах для каждого клиента
                string sql = @"
                SELECT 
                    cl.client_name,
                    c.date_signed,
                    string_agg(p.product_name || ' - Количество: ' || cp.quantity::text || ' - Сумма за количество: ' || cp.total_price, ', ') AS product_details,
                    c.total_amount,
                    c.prepayment,
                    c.advance_payment,
                    c.payment_status
                FROM 
                    Contracts c
                JOIN 
                    Clients cl ON c.client_id = cl.client_id
                JOIN 
                    Contract_Products cp ON c.contract_id = cp.contract_id
                JOIN 
                    Products p ON cp.product_id = p.product_id
                WHERE 
                    c.date_signed BETWEEN :reportFrom AND :reportTo 
                    AND c.payment_status != 'не оплачено' 
                    AND c.shipment_status != 'отгружено'
                    AND cl.client_name = :clientName
                GROUP BY 
                    cl.client_name, c.date_signed, c.total_amount, c.prepayment, c.advance_payment, c.payment_status
                ORDER BY 
                    cl.client_name";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("reportFrom", reportFrom);
                command.Parameters.AddWithValue("reportTo", reportTo);
                command.Parameters.AddWithValue("clientName", clientName);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string client_name = reader.GetString(0);
                    DateTime date_signed = reader.GetDateTime(1);
                    string product_details = reader.GetString(2);
                    decimal total_amount = reader.GetDecimal(3);
                    decimal prepayment = reader.GetDecimal(4);
                    decimal advancedPayment = reader.GetDecimal(5);
                    string payment_status = reader.GetString(6);

                    result += "Клиент: " + client_name + "\n";
                    result += "Дата подписания: " + date_signed.ToShortDateString() + "\n";
                    result += "Детали товаров: " + product_details + "\n";
                    result += "Общая сумма: " + total_amount + "\n";
                    result += "Необходимая предоплата: " + prepayment + "\n";
                    result += "Внесённая сумма: " + advancedPayment + "\n";
                    result += "Статус платежа: " + payment_status + "\n";
                    result += "----------\n";
                }
                reader.Close();
            }

            richTextBoxReportClient.Text = result;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

            DateTime reportFrom = dateTimePickerTextReportFrom.Value;
            DateTime reportTo = dateTimePickerTextReportTo.Value;

            System.Data.DataTable dtReport = new System.Data.DataTable();
            DataSet dsReport = new DataSet();
            
            // Очистка DataTable
            dtReport.Clear();

            // SQL запрос для получения данных о договорах и продуктах
            string sql = @"
            SELECT 
                cl.client_name,
                c.date_signed,
                string_agg(p.product_name || ' - Количество: ' || cp.quantity::text || ' - Сумма за количество: ' || cp.total_price, ', ') AS product_details,
                c.total_amount,
                c.prepayment,
                c.advance_payment,
                c.payment_status
            FROM 
                Contracts c
            JOIN 
                Clients cl ON c.client_id = cl.client_id
            JOIN 
                Contract_Products cp ON c.contract_id = cp.contract_id
            JOIN 
                Products p ON cp.product_id = p.product_id
            WHERE (c.date_signed BETWEEN :reportFrom AND :reportTo) AND (c.payment_status != 'не оплачено' AND c.shipment_status != 'отгружено')
            GROUP BY 
                cl.client_name, c.date_signed, c.total_amount, c.prepayment, c.advance_payment, c.payment_status
            ORDER BY 
                cl.client_name;";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("reportFrom", reportFrom);
            command.Parameters.AddWithValue("reportTo", reportTo);

            // Адаптер для заполнения DataSet
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            dsReport.Reset();
            da.Fill(dsReport);
            dtReport = dsReport.Tables[0];

            // Создание объекта Excel
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            Workbook wb = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            // Заголовки столбцов
            List<string> headers = new List<string> { "Имя клиента", "Дата подписания", "Детали продуктов", "Общая сумма", "Предоплата", "Авансовый платеж", "Статус платежа" };
            for (int i = 0; i < headers.Count; i++)
            {
                ws.Cells[1, i + 1] = headers[i];
            }

            // Заполнение данных
            try
            {
                for (int row = 0; row < dtReport.Rows.Count; row++)
                {
                    DataRow dr = dtReport.Rows[row];
                    for (int col = 0; col < dtReport.Columns.Count; col++)
                    {
                        ws.Cells[row + 2, col + 1] = dr[col].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при экспорте данных: " + ex.Message);
            }

            // Сохранение файла Excel
            wb.SaveAs("D:\\КУБИК\\3 курс 6 семак\\Разработка в интегрированных средах\\Итоговый проект\\MyC#IndividualWork\\ExportedData.xlsx", XlFileFormat.xlWorkbookDefault);
            wb.Close();
            excelApp.Quit();
        }
    }
}
