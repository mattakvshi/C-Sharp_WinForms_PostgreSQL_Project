namespace WinFormProducts
{
    partial class ContractProducts
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
            labelPaymentStatus = new Label();
            labelClientName = new Label();
            comboBoxContractCode = new ComboBox();
            buttonCancel = new Button();
            buttonConfirm = new Button();
            textBoxProductQuantity = new TextBox();
            labelAdvancePayment = new Label();
            label1 = new Label();
            comboBoxProductName = new ComboBox();
            SuspendLayout();
            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.AutoSize = true;
            labelPaymentStatus.Font = new Font("Montserrat", 12F);
            labelPaymentStatus.Location = new Point(22, 223);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new Size(0, 22);
            labelPaymentStatus.TabIndex = 40;
            // 
            // labelClientName
            // 
            labelClientName.AutoSize = true;
            labelClientName.Font = new Font("Montserrat", 12F);
            labelClientName.Location = new Point(22, 9);
            labelClientName.Name = "labelClientName";
            labelClientName.Size = new Size(123, 22);
            labelClientName.TabIndex = 36;
            labelClientName.Text = "Код договора";
            // 
            // comboBoxContractCode
            // 
            comboBoxContractCode.BackColor = Color.Gainsboro;
            comboBoxContractCode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxContractCode.Font = new Font("Montserrat", 12F);
            comboBoxContractCode.FormattingEnabled = true;
            comboBoxContractCode.Location = new Point(22, 34);
            comboBoxContractCode.Name = "comboBoxContractCode";
            comboBoxContractCode.Size = new Size(262, 30);
            comboBoxContractCode.TabIndex = 35;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.RosyBrown;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.ForeColor = SystemColors.ButtonFace;
            buttonCancel.Location = new Point(166, 236);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(118, 34);
            buttonCancel.TabIndex = 34;
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
            buttonConfirm.Location = new Point(22, 236);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(138, 34);
            buttonConfirm.TabIndex = 33;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // textBoxProductQuantity
            // 
            textBoxProductQuantity.BackColor = Color.Gainsboro;
            textBoxProductQuantity.BorderStyle = BorderStyle.FixedSingle;
            textBoxProductQuantity.Font = new Font("Montserrat", 12F);
            textBoxProductQuantity.Location = new Point(22, 176);
            textBoxProductQuantity.Name = "textBoxProductQuantity";
            textBoxProductQuantity.Size = new Size(262, 27);
            textBoxProductQuantity.TabIndex = 32;
            // 
            // labelAdvancePayment
            // 
            labelAdvancePayment.AutoSize = true;
            labelAdvancePayment.Font = new Font("Montserrat", 12F);
            labelAdvancePayment.Location = new Point(22, 151);
            labelAdvancePayment.Name = "labelAdvancePayment";
            labelAdvancePayment.Size = new Size(180, 22);
            labelAdvancePayment.TabIndex = 31;
            labelAdvancePayment.Text = "Колличество товара";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 12F);
            label1.Location = new Point(22, 84);
            label1.Name = "label1";
            label1.Size = new Size(199, 22);
            label1.TabIndex = 42;
            label1.Text = "Наименование товара";
            // 
            // comboBoxProductName
            // 
            comboBoxProductName.BackColor = Color.Gainsboro;
            comboBoxProductName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductName.Font = new Font("Montserrat", 12F);
            comboBoxProductName.FormattingEnabled = true;
            comboBoxProductName.Location = new Point(22, 109);
            comboBoxProductName.Name = "comboBoxProductName";
            comboBoxProductName.Size = new Size(262, 30);
            comboBoxProductName.TabIndex = 41;
            // 
            // ContractProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 295);
            Controls.Add(label1);
            Controls.Add(comboBoxProductName);
            Controls.Add(labelPaymentStatus);
            Controls.Add(labelClientName);
            Controls.Add(comboBoxContractCode);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxProductQuantity);
            Controls.Add(labelAdvancePayment);
            Name = "ContractProducts";
            Text = "ContractProducts";
            Load += ContractProducts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPaymentStatus;
        private Label labelClientName;
        private ComboBox comboBoxContractCode;
        private Button buttonCancel;
        private Button buttonConfirm;
        private TextBox textBoxProductQuantity;
        private Label labelAdvancePayment;
        private Label label1;
        private ComboBox comboBoxProductName;
    }
}