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
    public partial class ClientsUC : UserControl
    {

        //соединение с бд и работа с отображением данных
        public NpgsqlConnection conn;
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        public ClientsUC(NpgsqlConnection conn)
        {
            /*
             Метод-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void UsersUC_Load(object sender, EventArgs e)
        {
            /*
            Метод, который отоюражает данные при загрузки панели
            */

            Update();
        }

        private void Update()
        {
            /*
             Метод, который перезагружает и показывает данные
             */

            dt.Clear();
            string sql = @"
            SELECT * 
            FROM Clients";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].HeaderText = "Код клиента";
            dataGridView.Columns[1].HeaderText = "Имя";
            dataGridView.Columns[2].HeaderText = "Номер телефона";
            dataGridView.Sort(dataGridView.Columns["client_id"], ListSortDirection.Ascending);
            dataGridView.Refresh();
            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonAdd_13_Click(object sender, EventArgs e)
        {
            /*
             Метод, который вызывает форму для вставки данных
             */

            ClientForm clientForm = new ClientForm(conn);
            clientForm.ShowDialog();
            Update();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            /*
             Метод, который вызывает форму для редактирования данных
             */

            int clientId = (int)dataGridView.CurrentRow.Cells["client_id"].Value;
            string clientName = (string)dataGridView.CurrentRow.Cells["client_name"].Value.ToString();
            string clientPhone = (string)dataGridView.CurrentRow.Cells["phone"].Value.ToString();
            ClientForm clientForm = new ClientForm(conn, clientId, clientName, clientPhone);
            clientForm.ShowDialog();
            Update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            /*
             Метод, который удаляет данные без вызова формы
             */

            int clientId = (int)dataGridView.CurrentRow.Cells["client_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + clientId + "?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE 
                FROM Clients 
                WHERE client_id = :client_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("client_id", clientId);
                command.ExecuteNonQuery();
                Update();
            }
        }
    }
}
