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
    public partial class ProductsUC : UserControl
    {

        //соединение с бд и работа с отображением данных
        public NpgsqlConnection conn;
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();


        public ProductsUC(NpgsqlConnection conn)
        {
            /*
             Метод-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void ProductsUC_Load(object sender, EventArgs e)
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
            FROM Products";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].HeaderText = "Код товара";
            dataGridView.Columns[1].HeaderText = "Наименование";
            dataGridView.Columns[2].HeaderText = "Цена";
            dataGridView.Sort(dataGridView.Columns["product_id"], ListSortDirection.Ascending);
            dataGridView.Refresh();
            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            /*
             Метод, который вызывает форму для вставки данных
             */

            ProductForm productForm = new ProductForm(conn);
            productForm.ShowDialog();
            Update();
        }

        

        private void buttonChange_Click(object sender, EventArgs e)
        {
            /*
             Метод, который вызывает форму для редактирования данных
             */

            int productId = (int)dataGridView.CurrentRow.Cells["product_id"].Value;
            string productName = (string)dataGridView.CurrentRow.Cells["product_name"].Value.ToString();
            decimal productPrice = (decimal)dataGridView.CurrentRow.Cells["price"].Value;
            ProductForm productForm = new ProductForm(conn, productId, productName, productPrice);
            productForm.ShowDialog();
            Update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            /*
             Метод, который удаляет данные без вызова формы
             */

            int productId = (int)dataGridView.CurrentRow.Cells["product_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + productId + "?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE 
                FROM Products 
                WHERE product_id = :product_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("product_id", productId);
                command.ExecuteNonQuery();
                Update();
            }
        }
    }
}
