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
    public partial class ProductForm : Form
    {

        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int productId = -1;
        public string productName;
        public decimal productPrice;

        public ProductForm(NpgsqlConnection conn)
        {
            /*
             Метод-конструктор для вставки данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
        }


        public ProductForm(NpgsqlConnection conn, int productId, string productName, decimal productPrice)
        {
            /*
             Метод-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.productId = productId;
            this.productName = productName;
            this.productPrice = productPrice;
            textBoxName.Text = productName;
            textBoxPrice.Text = productPrice.ToString();
        }


        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
                Метод, который подтверждает вставку/изменение данных
            */

            //для вставки
            if (this.productId == -1)
            {
                decimal res;
                if (textBoxName.Text != "" && decimal.TryParse(textBoxPrice.Text, out res))
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = @"
                    INSERT 
                    INTO Products (product_name, price) 
                    VALUES (:product_name,  :price)";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("product_name", textBoxName.Text);
                        command.Parameters.AddWithValue("price", decimal.Parse(textBoxPrice.Text));
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
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.productId + "?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = @"
                    UPDATE Products 
                    SET product_name = :product_name, price = :price 
                    WHERE product_id = :product_id";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("product_id", this.productId);
                    command.Parameters.AddWithValue("product_name", textBoxName.Text);
                    command.Parameters.AddWithValue("price", decimal.Parse(textBoxPrice.Text));
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






        //Мусора наплодил

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPrice_Click(object sender, EventArgs e)
        {

        }

      
    }
}
