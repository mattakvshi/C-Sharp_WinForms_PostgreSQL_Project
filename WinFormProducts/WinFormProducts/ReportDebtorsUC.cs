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
    public partial class ReportDebtorsUC : UserControl
    {

        //соединение с бд и данные для листБоксов
        public NpgsqlConnection conn;


        public ReportDebtorsUC(NpgsqlConnection conn)
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void buttonMakeUp_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая создаёт отчёт по дням, отображающий суммы отгруженных но не оплаченных товаров
             */

            DateTime reportFrom = dateTimePickerDayReportFrom.Value;
            DateTime reportTo = dateTimePickerDayReportTo.Value;

            string result = "----------\n";
            result += "Отчёт за период с " + reportFrom.ToShortDateString() + " по " + reportTo.ToShortDateString() + "\n";
            result += "----------\n";

            // Запрос к базе данных для получения сумм отгруженных но не оплаченных товаров по дням
            string sql = @"
                SELECT 
                    DATE(c.date_signed) as date_signed,
                    SUM(c.total_amount) as total_unpaid_amount
                FROM 
                    Contracts c
                WHERE 
                    c.date_signed BETWEEN :reportFrom AND :reportTo 
                    AND c.payment_status != 'оплачено' 
                    AND c.shipment_status = 'отгружено'
                GROUP BY 
                    date_signed 
                ORDER BY 
                    date_signed";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("reportFrom", reportFrom);
            command.Parameters.AddWithValue("reportTo", reportTo);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime dateSigned = reader.GetDateTime(0);
                int totalUnpaidAmount = reader.GetInt32(1);
                result += "Дата: " + dateSigned.ToShortDateString() + "\n";
                result += "Сумма неоплаченных товаров: " + totalUnpaidAmount + "\n";
                result += "----------\n";
            }
            reader.Close();

            richTextBoxReportDay.Text = result;
        }

        private void buttonExportToChart_Click(object sender, EventArgs e)
        {

            /*
            Функция, которая получает все данные для постройки графика по дням для периода с информацие об отгруженных, но не оплаченных товарах
            */

            try
            {
                DateTime reportFrom = dateTimePickerDayReportFrom.Value;
                DateTime reportTo = dateTimePickerDayReportTo.Value;

                // Запрос к базе данных для получения данных для графика
                string sql = @"
                    SELECT 
                        DATE(c.date_signed) as date_signed,
                        SUM(c.total_amount) as total_unpaid_amount
                    FROM 
                        Contracts c
                    WHERE 
                        c.date_signed BETWEEN :reportFrom AND :reportTo 
                        AND c.payment_status != 'оплачено' 
                        AND c.shipment_status = 'отгружено'
                    GROUP BY 
                        date_signed 
                    ORDER BY 
                        date_signed";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("reportFrom", reportFrom);
                command.Parameters.AddWithValue("reportTo", reportTo);
                NpgsqlDataReader reader = command.ExecuteReader();

                // Собираем результаты в список для графика
                List<Tuple<DateTime, decimal>> graphData = new List<Tuple<DateTime, decimal>>();
                while (reader.Read())
                {
                    DateTime dateSigned = reader.GetDateTime(0);
                    decimal totalUnpaidAmount = reader.GetDecimal(1);
                    graphData.Add(Tuple.Create(dateSigned, totalUnpaidAmount));
                }
                reader.Close();

                // Передача данных в форму с графиком и её отображение
                GraphForm GraphtForm = new GraphForm(graphData);
                GraphtForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
