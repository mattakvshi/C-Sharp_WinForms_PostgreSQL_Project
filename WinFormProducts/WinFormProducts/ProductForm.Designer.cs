namespace WinFormProducts
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxPrice = new TextBox();
            textBoxName = new TextBox();
            labelPrice = new Label();
            labelName = new Label();
            buttonCancel = new Button();
            buttonConfirm = new Button();
            SuspendLayout();
            // 
            // textBoxPrice
            // 
            textBoxPrice.BackColor = Color.LightGray;
            textBoxPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxPrice.Font = new Font("Montserrat", 12F);
            textBoxPrice.Location = new Point(12, 140);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(262, 27);
            textBoxPrice.TabIndex = 13;
            textBoxPrice.TextChanged += textBoxPrice_TextChanged;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.LightGray;
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Montserrat", 12F);
            textBoxName.Location = new Point(12, 55);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(262, 27);
            textBoxName.TabIndex = 11;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Montserrat", 12F);
            labelPrice.Location = new Point(12, 114);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(53, 22);
            labelPrice.TabIndex = 10;
            labelPrice.Text = "Цена";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Montserrat", 12F);
            labelName.Location = new Point(12, 30);
            labelName.Name = "labelName";
            labelName.Size = new Size(138, 22);
            labelName.TabIndex = 8;
            labelName.Text = "Наименование";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.RosyBrown;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.ForeColor = SystemColors.ButtonFace;
            buttonCancel.Location = new Point(165, 239);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(118, 34);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = SystemColors.Highlight;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonConfirm.ForeColor = SystemColors.ButtonFace;
            buttonConfirm.Location = new Point(12, 239);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(138, 34);
            buttonConfirm.TabIndex = 16;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(306, 296);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxName);
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Name = "ProductForm";
            Text = "ProductForm";
            Load += ProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxPrice;
        private TextBox textBoxMeasurementUnit;
        private TextBox textBoxName;
        private Label labelPrice;
        private Label labelMeasurementUnit;
        private Label labelName;
        private Button buttonCancel;
        private Button buttonConfirm;
    }
}