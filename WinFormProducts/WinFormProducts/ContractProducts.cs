using Microsoft.VisualBasic;
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

namespace WinFormProducts
{
    public partial class ContractProducts : Form
    {

        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int contractProductId = -1;
        public string contractCode;
        public List<String> contractsCodes;
        public string productName;
        public List<String> productsNames;
        public int productQuantity;

        public ContractProducts(NpgsqlConnection conn, List<String> contractsCodes, List<String> productsNames)
        {
            /*
             Функция-конструктор для вставки данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.contractsCodes = contractsCodes;
            this.comboBoxContractCode.DataSource = contractsCodes;
            this.productsNames = productsNames;
            this.comboBoxProductName.DataSource = productsNames;
        }

        public ContractProducts(NpgsqlConnection conn, int contractProductId, string contractCode, List<String> contractsCodes, string productName, List<String> productsNames, int productQuantity)
        {
            /*
            Функция-конструктор для изменения данных
            */

            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.contractProductId = contractProductId;
            this.contractCode = contractCode;
            this.productName = productName;
            this.productQuantity = productQuantity;
            this.contractsCodes = contractsCodes;
            this.productsNames = productsNames;
            this.comboBoxContractCode.DataSource = contractsCodes;
            this.comboBoxProductName.DataSource = productsNames;
            this.textBoxProductQuantity.Text = productQuantity.ToString();
        }

        private void ContractProducts_Load(object sender, EventArgs e)
        {
            /*
             Функция, которая загружает содержимое в комбоБоксы при загрузки формы
             */

            this.comboBoxContractCode.SelectedItem = contractCode;
            this.comboBoxProductName.SelectedItem = productName;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая подтверждает вставку/изменение данных
             */

            //для вставки
            if (this.contractProductId == -1)
            {
                int res;
                if (comboBoxContractCode.SelectedItem != null && comboBoxProductName.SelectedItem != null && int.TryParse(textBoxProductQuantity.Text, out res))
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные? Это приведёт к автоматическому обновлению данных в таблице Договоров!", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        int contractId = Convert.ToInt32(comboBoxContractCode.SelectedItem.ToString());

                        /*string sql = @"
                        SELECT contract_id 
                        FROM Contracts 
                        WHERE contract_id = :contract_id";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("contract_id", comboBoxContractCode.SelectedItem.ToString());
                        object contractIdObj = command.ExecuteScalar();
                        int contractId = Convert.ToInt32(contractIdObj);*/

                        string sql = @"
                        SELECT product_id 
                        FROM Products 
                        WHERE product_name = :product_name";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("product_name", comboBoxProductName.SelectedItem.ToString());
                        object productIdObj = command.ExecuteScalar();
                        int productId = Convert.ToInt32(productIdObj);

                        sql = @"
                        INSERT 
                        INTO Contract_Products (contract_id, product_id, quantity) 
                        VALUES (:contract_id, :product_id, :quantity)";
                        command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("contract_id", contractId);
                        command.Parameters.AddWithValue("product_id", productId);
                        command.Parameters.AddWithValue("quantity", int.Parse(this.textBoxProductQuantity.Text));
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
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.contractProductId + "? Это приведёт к автоматическому изменению соответствующей записи в таблице Договоров!", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    int contractId = Convert.ToInt32(comboBoxContractCode.SelectedItem.ToString());
                    /*string sql = @"
                        SELECT contract_id 
                        FROM Contracts 
                        WHERE contract_id = :contract_id";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("contract_id", comboBoxContractCode.SelectedItem.ToString());
                    object contractIdObj = command.ExecuteScalar();
                    int contractId = Convert.ToInt32(contractIdObj);*/

                    string sql = @"
                        SELECT product_id 
                        FROM Products 
                        WHERE product_name = :product_name";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("product_name", comboBoxProductName.SelectedItem.ToString());
                    object productIdObj = command.ExecuteScalar();
                    int productId = Convert.ToInt32(productIdObj);

                    sql = @"
                    UPDATE Contract_Products 
                    SET contract_id = :contract_id, product_id = :product_id, quantity = :quantity 
                    WHERE contract_product_id = :contract_product_id";
                    command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("contract_product_id", this.contractProductId);
                    command.Parameters.AddWithValue("contract_id", contractId);
                    command.Parameters.AddWithValue("product_id", productId);
                    command.Parameters.AddWithValue("quantity", int.Parse(this.textBoxProductQuantity.Text));
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
    } 
}
