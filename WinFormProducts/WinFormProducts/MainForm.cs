using Npgsql;

namespace WinFormProducts
{
    public partial class MainForm : Form
    {

        //все используемые панели
        public ClientsUC clientsUC;
        public ProductsUC productsUC;
        public ContractProductUC contractProductUC;

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
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
                Метод для корректного отображения панели "Клиенты"
            */

            clientsUC.Visible = true;
            productsUC.Visible = false;
            contractProductUC.Visible = false;
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
               Метод для корректного отображения панели "Товары"
           */

            clientsUC.Visible = false;
            productsUC.Visible = true;
            contractProductUC.Visible = false;
        }

        private void ContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
              Метод для корректного отображения панели "Товары"
          */

            clientsUC.Visible = false;
            productsUC.Visible = false;
            contractProductUC.Visible = true;
        }
    }
}
