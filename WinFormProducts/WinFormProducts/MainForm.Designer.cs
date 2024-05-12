namespace WinFormProducts
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            UsersToolStripMenuItem = new ToolStripMenuItem();
            ProductsToolStripMenuItem = new ToolStripMenuItem();
            ContractToolStripMenuItem = new ToolStripMenuItem();
            ReportToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveBorder;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.Items.AddRange(new ToolStripItem[] { UsersToolStripMenuItem, ProductsToolStripMenuItem, ContractToolStripMenuItem, ReportToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(185, 661);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // UsersToolStripMenuItem
            // 
            UsersToolStripMenuItem.Font = new Font("Montserrat", 10F);
            UsersToolStripMenuItem.Name = "UsersToolStripMenuItem";
            UsersToolStripMenuItem.Size = new Size(172, 24);
            UsersToolStripMenuItem.Text = "Клиенты";
            UsersToolStripMenuItem.Click += UsersToolStripMenuItem_Click;
            // 
            // ProductsToolStripMenuItem
            // 
            ProductsToolStripMenuItem.Font = new Font("Montserrat", 10F);
            ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem";
            ProductsToolStripMenuItem.Size = new Size(172, 24);
            ProductsToolStripMenuItem.Text = "Товары";
            ProductsToolStripMenuItem.Click += ProductsToolStripMenuItem_Click;
            // 
            // ContractToolStripMenuItem
            // 
            ContractToolStripMenuItem.Font = new Font("Montserrat", 10F);
            ContractToolStripMenuItem.Name = "ContractToolStripMenuItem";
            ContractToolStripMenuItem.Size = new Size(172, 24);
            ContractToolStripMenuItem.Text = "Договор и накладная";
            ContractToolStripMenuItem.Click += ContractToolStripMenuItem_Click;
            // 
            // ReportToolStripMenuItem
            // 
            ReportToolStripMenuItem.Font = new Font("Montserrat", 10F);
            ReportToolStripMenuItem.Name = "ReportToolStripMenuItem";
            ReportToolStripMenuItem.Size = new Size(172, 24);
            ReportToolStripMenuItem.Text = "Отчёт";
            ReportToolStripMenuItem.Click += ReportToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1284, 661);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Контроль оплаты и отгрузки отваров";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem UsersToolStripMenuItem;
        private ToolStripMenuItem ProductsToolStripMenuItem;
        private ToolStripMenuItem ContractToolStripMenuItem;
        private ToolStripMenuItem ReportToolStripMenuItem;
    }
}
