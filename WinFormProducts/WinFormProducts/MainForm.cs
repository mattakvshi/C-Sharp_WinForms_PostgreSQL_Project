using Npgsql;

namespace WinFormProducts
{
    public partial class MainForm : Form
    {

        //все используемые панели
        public ClientsUC clientsUC;
        public ProductsUC productsUC;
        public ContractProductUC contractProductUC;
        public ReportingUC reportingUC;
        public ReportDebtorsUC reportDebtorsUC;

        //объект-соединение с бд
        public NpgsqlConnection conn;

        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            Connection();
            LoadUserControls();
        }

        public void Connection()
        {
            /*
             Метод, отвечающая за установку и открытие соеднинения с бд
             */

            string connData = @"
            Server=localhost; 
            Port=5432; 
            UserID=postgres; 
            Password=vvsimax2003; 
            Database=C#_Sidorenko_Products";
            conn = new NpgsqlConnection(connData);
            conn.Open();
        }

        public void CenterUserControl(Control control)
        {
            /*
             Метод, который центрирует панель для корректного отображения внутри формы
             */

            int newX = (this.ClientSize.Width - control.Width) / 2;
            int newY = (this.ClientSize.Height - control.Height) / 2;
            control.Location = new Point(newX, newY);
        }

        public void LoadUserControls()
        {
            /*
             Метод, который инициализирует все панели перед началом использования
             */

            clientsUC = new ClientsUC(conn);
            this.Controls.Add(clientsUC);
            CenterUserControl(clientsUC);
            clientsUC.Visible = false;

            productsUC = new ProductsUC(conn);
            this.Controls.Add(productsUC);
            CenterUserControl(productsUC);
            productsUC.Visible = false;

            contractProductUC = new ContractProductUC(conn);
            this.Controls.Add(contractProductUC);
            CenterUserControl(contractProductUC);
            contractProductUC.Visible = false;

            /*
             Для панели с отчётностью нужно заранее загрузить и передать все нужные данные, потому что
             эта панель фактически является формой (при её создании сразу нужно отображать данные)
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
            string[] clientsNamesArr = clientsNames.ToArray();


            reportingUC = new ReportingUC(conn, clientsNamesArr);
            this.Controls.Add(reportingUC);
            CenterUserControl(reportingUC);
            reportingUC.Visible = false;

            reportDebtorsUC = new ReportDebtorsUC(conn);
            this.Controls.Add(reportDebtorsUC);
            CenterUserControl(reportDebtorsUC);
            reportDebtorsUC.Visible = false;
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
                Метод для корректного отображения панели "Клиенты"
            */

            clientsUC.Visible = true;
            productsUC.Visible = false;
            contractProductUC.Visible = false;
            reportingUC.Visible = false;
            reportDebtorsUC.Visible = false;
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
               Метод для корректного отображения панели "Товары"
           */

            clientsUC.Visible = false;
            productsUC.Visible = true;
            contractProductUC.Visible = false;
            reportingUC.Visible = false;
            reportDebtorsUC.Visible = false;
        }

        private void ContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
              Метод для корректного отображения панели "Договоров"
          */

            clientsUC.Visible = false;
            productsUC.Visible = false;
            contractProductUC.Visible = true;
            reportingUC.Visible = false;
            reportDebtorsUC.Visible = false;
        }

        private void ReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             Метод, который переинициализирует панель при повторном открытии, так как могут появиться
             новые данные, которые нужно будет заного получить и передать
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
            string[] clientsNamesArr = clientsNames.ToArray();


            reportingUC = new ReportingUC(conn, clientsNamesArr);
            this.Controls.Add(reportingUC);
            CenterUserControl(reportingUC);

            clientsUC.Visible = false;
            productsUC.Visible = false;
            contractProductUC.Visible = false;
            reportingUC.Visible = true;
            reportDebtorsUC.Visible = false;
        }

        private void отчётПоДнямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Метод для корректного отображения панели "Отчёта по дням"
            */

            clientsUC.Visible = false;
            productsUC.Visible = false;
            contractProductUC.Visible = false;
            reportingUC.Visible = false;
            reportDebtorsUC.Visible = true;
        }
    }
}
