namespace WinFormProducts
{
    partial class ContractProductUC
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            buttonAddContract = new Button();
            buttonDeleteContract = new Button();
            buttonChangeContract = new Button();
            label1 = new Label();
            dataGridViewContract = new DataGridView();
            label2 = new Label();
            buttonAddCP = new Button();
            buttonDeleteCP = new Button();
            buttonChangeCP = new Button();
            buttonSelect = new Button();
            buttonEXL = new Button();
            buttonUnSelect = new Button();
            dataGridViewContractProduct = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContractProduct).BeginInit();
            SuspendLayout();
            // 
            // buttonAddContract
            // 
            buttonAddContract.BackColor = SystemColors.Highlight;
            buttonAddContract.FlatAppearance.BorderSize = 0;
            buttonAddContract.FlatStyle = FlatStyle.Flat;
            buttonAddContract.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddContract.ForeColor = SystemColors.ButtonFace;
            buttonAddContract.Location = new Point(183, 316);
            buttonAddContract.Name = "buttonAddContract";
            buttonAddContract.Size = new Size(118, 34);
            buttonAddContract.TabIndex = 17;
            buttonAddContract.Text = "Добавить";
            buttonAddContract.UseVisualStyleBackColor = false;
            buttonAddContract.Click += buttonAddContract_Click;
            // 
            // buttonDeleteContract
            // 
            buttonDeleteContract.BackColor = Color.RosyBrown;
            buttonDeleteContract.FlatAppearance.BorderSize = 0;
            buttonDeleteContract.FlatStyle = FlatStyle.Flat;
            buttonDeleteContract.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDeleteContract.ForeColor = SystemColors.ButtonFace;
            buttonDeleteContract.Location = new Point(431, 316);
            buttonDeleteContract.Name = "buttonDeleteContract";
            buttonDeleteContract.Size = new Size(118, 34);
            buttonDeleteContract.TabIndex = 16;
            buttonDeleteContract.Text = "Удалить";
            buttonDeleteContract.UseVisualStyleBackColor = false;
            buttonDeleteContract.Click += buttonDeleteContract_Click;
            // 
            // buttonChangeContract
            // 
            buttonChangeContract.BackColor = SystemColors.ButtonShadow;
            buttonChangeContract.FlatAppearance.BorderSize = 0;
            buttonChangeContract.FlatStyle = FlatStyle.Flat;
            buttonChangeContract.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonChangeContract.ForeColor = SystemColors.ButtonFace;
            buttonChangeContract.Location = new Point(307, 316);
            buttonChangeContract.Name = "buttonChangeContract";
            buttonChangeContract.Size = new Size(118, 34);
            buttonChangeContract.TabIndex = 15;
            buttonChangeContract.Text = "Изменить";
            buttonChangeContract.UseVisualStyleBackColor = false;
            buttonChangeContract.Click += buttonChangeContract_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat Medium", 16F, FontStyle.Bold);
            label1.Location = new Point(654, 14);
            label1.Name = "label1";
            label1.Size = new Size(119, 30);
            label1.TabIndex = 14;
            label1.Text = "Договор";
            // 
            // dataGridViewContract
            // 
            dataGridViewContract.BackgroundColor = Color.Gainsboro;
            dataGridViewContract.BorderStyle = BorderStyle.None;
            dataGridViewContract.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewContract.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gainsboro;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewContract.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewContract.EnableHeadersVisualStyles = false;
            dataGridViewContract.GridColor = SystemColors.ScrollBar;
            dataGridViewContract.Location = new Point(183, 54);
            dataGridViewContract.Name = "dataGridViewContract";
            dataGridViewContract.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gainsboro;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewContract.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewContract.Size = new Size(1014, 256);
            dataGridViewContract.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Montserrat Medium", 16F, FontStyle.Bold);
            label2.Location = new Point(564, 350);
            label2.Name = "label2";
            label2.Size = new Size(300, 30);
            label2.TabIndex = 19;
            label2.Text = "Продукты по договору";
            // 
            // buttonAddCP
            // 
            buttonAddCP.BackColor = SystemColors.Highlight;
            buttonAddCP.FlatAppearance.BorderSize = 0;
            buttonAddCP.FlatStyle = FlatStyle.Flat;
            buttonAddCP.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddCP.ForeColor = SystemColors.ButtonFace;
            buttonAddCP.Location = new Point(183, 605);
            buttonAddCP.Name = "buttonAddCP";
            buttonAddCP.Size = new Size(118, 34);
            buttonAddCP.TabIndex = 22;
            buttonAddCP.Text = "Добавить";
            buttonAddCP.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteCP
            // 
            buttonDeleteCP.BackColor = Color.RosyBrown;
            buttonDeleteCP.FlatAppearance.BorderSize = 0;
            buttonDeleteCP.FlatStyle = FlatStyle.Flat;
            buttonDeleteCP.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDeleteCP.ForeColor = SystemColors.ButtonFace;
            buttonDeleteCP.Location = new Point(431, 606);
            buttonDeleteCP.Name = "buttonDeleteCP";
            buttonDeleteCP.Size = new Size(118, 34);
            buttonDeleteCP.TabIndex = 21;
            buttonDeleteCP.Text = "Удалить";
            buttonDeleteCP.UseVisualStyleBackColor = false;
            // 
            // buttonChangeCP
            // 
            buttonChangeCP.BackColor = SystemColors.ButtonShadow;
            buttonChangeCP.FlatAppearance.BorderSize = 0;
            buttonChangeCP.FlatStyle = FlatStyle.Flat;
            buttonChangeCP.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonChangeCP.ForeColor = SystemColors.ButtonFace;
            buttonChangeCP.Location = new Point(307, 605);
            buttonChangeCP.Name = "buttonChangeCP";
            buttonChangeCP.Size = new Size(118, 34);
            buttonChangeCP.TabIndex = 20;
            buttonChangeCP.Text = "Изменить";
            buttonChangeCP.UseVisualStyleBackColor = false;
            // 
            // buttonSelect
            // 
            buttonSelect.BackColor = Color.Tan;
            buttonSelect.FlatAppearance.BorderSize = 0;
            buttonSelect.FlatStyle = FlatStyle.Flat;
            buttonSelect.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSelect.ForeColor = SystemColors.ButtonFace;
            buttonSelect.Location = new Point(346, 12);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(100, 36);
            buttonSelect.TabIndex = 23;
            buttonSelect.Text = "Выбрать";
            buttonSelect.UseVisualStyleBackColor = false;
            // 
            // buttonEXL
            // 
            buttonEXL.BackColor = SystemColors.ControlDarkDark;
            buttonEXL.FlatAppearance.BorderSize = 0;
            buttonEXL.FlatStyle = FlatStyle.Flat;
            buttonEXL.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonEXL.ForeColor = SystemColors.ButtonFace;
            buttonEXL.Location = new Point(183, 12);
            buttonEXL.Name = "buttonEXL";
            buttonEXL.Size = new Size(157, 36);
            buttonEXL.TabIndex = 24;
            buttonEXL.Text = "Экспорт в Excel";
            buttonEXL.UseVisualStyleBackColor = false;
            // 
            // buttonUnSelect
            // 
            buttonUnSelect.BackColor = Color.Tan;
            buttonUnSelect.FlatAppearance.BorderSize = 0;
            buttonUnSelect.FlatStyle = FlatStyle.Flat;
            buttonUnSelect.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonUnSelect.ForeColor = SystemColors.ButtonFace;
            buttonUnSelect.Location = new Point(1022, 606);
            buttonUnSelect.Name = "buttonUnSelect";
            buttonUnSelect.Size = new Size(175, 33);
            buttonUnSelect.TabIndex = 25;
            buttonUnSelect.Text = "Показать все";
            buttonUnSelect.UseVisualStyleBackColor = false;
            // 
            // dataGridViewContractProduct
            // 
            dataGridViewContractProduct.BackgroundColor = Color.Gainsboro;
            dataGridViewContractProduct.BorderStyle = BorderStyle.None;
            dataGridViewContractProduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Gainsboro;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewContractProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewContractProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Gainsboro;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewContractProduct.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewContractProduct.EnableHeadersVisualStyles = false;
            dataGridViewContractProduct.GridColor = SystemColors.ScrollBar;
            dataGridViewContractProduct.Location = new Point(183, 383);
            dataGridViewContractProduct.Name = "dataGridViewContractProduct";
            dataGridViewContractProduct.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Gainsboro;
            dataGridViewCellStyle6.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridViewContractProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewContractProduct.Size = new Size(1014, 216);
            dataGridViewContractProduct.TabIndex = 26;
            // 
            // ContractProductUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewContractProduct);
            Controls.Add(buttonUnSelect);
            Controls.Add(buttonEXL);
            Controls.Add(buttonSelect);
            Controls.Add(buttonAddCP);
            Controls.Add(buttonDeleteCP);
            Controls.Add(buttonChangeCP);
            Controls.Add(label2);
            Controls.Add(buttonAddContract);
            Controls.Add(buttonDeleteContract);
            Controls.Add(buttonChangeContract);
            Controls.Add(label1);
            Controls.Add(dataGridViewContract);
            Name = "ContractProductUC";
            Size = new Size(1200, 650);
            Load += ContractProductUC_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewContract).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContractProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddContract;
        private Button buttonDeleteContract;
        private Button buttonChangeContract;
        private Label label1;
        private DataGridView dataGridViewContract;
        private Label label2;
        private Button buttonAddCP;
        private Button buttonDeleteCP;
        private Button buttonChangeCP;
        private Button buttonSelect;
        private Button buttonEXL;
        private Button buttonUnSelect;
        private DataGridView dataGridViewContractProduct;
    }
}
