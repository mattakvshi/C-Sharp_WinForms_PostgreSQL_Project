namespace WinFormProducts
{
    partial class ContranctForm
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
            buttonCancel = new Button();
            textBoxAdvancedPayment = new TextBox();
            labelAdvancePayment = new Label();
            comboBoxClientName = new ComboBox();
            labelClientName = new Label();
            labelSignedDate = new Label();
            dateTimePicker = new DateTimePicker();
            labelPaymentStatus = new Label();
            comboBoxSipmentStatus = new ComboBox();
            labelSipmentStatus = new Label();
            buttonConfirm = new Button();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.RosyBrown;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.ForeColor = SystemColors.ButtonFace;
            buttonCancel.Location = new Point(187, 325);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(118, 34);
            buttonCancel.TabIndex = 23;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxAdvancedPayment
            // 
            textBoxAdvancedPayment.BackColor = Color.Gainsboro;
            textBoxAdvancedPayment.BorderStyle = BorderStyle.FixedSingle;
            textBoxAdvancedPayment.Font = new Font("Montserrat", 12F);
            textBoxAdvancedPayment.Location = new Point(31, 179);
            textBoxAdvancedPayment.Name = "textBoxAdvancedPayment";
            textBoxAdvancedPayment.Size = new Size(262, 27);
            textBoxAdvancedPayment.TabIndex = 20;
            textBoxAdvancedPayment.TextChanged += textBoxName_TextChanged;
            // 
            // labelAdvancePayment
            // 
            labelAdvancePayment.AutoSize = true;
            labelAdvancePayment.Font = new Font("Montserrat", 12F);
            labelAdvancePayment.Location = new Point(31, 154);
            labelAdvancePayment.Name = "labelAdvancePayment";
            labelAdvancePayment.Size = new Size(160, 22);
            labelAdvancePayment.TabIndex = 18;
            labelAdvancePayment.Text = "Внесённая сумма";
            labelAdvancePayment.Click += labelName_Click;
            // 
            // comboBoxClientName
            // 
            comboBoxClientName.BackColor = Color.Gainsboro;
            comboBoxClientName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClientName.Font = new Font("Montserrat", 12F);
            comboBoxClientName.FormattingEnabled = true;
            comboBoxClientName.Location = new Point(31, 37);
            comboBoxClientName.Name = "comboBoxClientName";
            comboBoxClientName.Size = new Size(262, 30);
            comboBoxClientName.TabIndex = 24;
            // 
            // labelClientName
            // 
            labelClientName.AutoSize = true;
            labelClientName.Font = new Font("Montserrat", 12F);
            labelClientName.Location = new Point(31, 12);
            labelClientName.Name = "labelClientName";
            labelClientName.Size = new Size(118, 22);
            labelClientName.TabIndex = 25;
            labelClientName.Text = "Имя клиента";
            // 
            // labelSignedDate
            // 
            labelSignedDate.AutoSize = true;
            labelSignedDate.Font = new Font("Montserrat", 12F);
            labelSignedDate.Location = new Point(31, 83);
            labelSignedDate.Name = "labelSignedDate";
            labelSignedDate.Size = new Size(265, 22);
            labelSignedDate.TabIndex = 26;
            labelSignedDate.Text = "Дата формирования договора";
            // 
            // dateTimePicker
            // 
            dateTimePicker.CalendarFont = new Font("Montserrat", 12F);
            dateTimePicker.CalendarForeColor = SystemColors.Desktop;
            dateTimePicker.CalendarMonthBackground = Color.Gainsboro;
            dateTimePicker.Font = new Font("Montserrat", 12F);
            dateTimePicker.Location = new Point(31, 108);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(265, 27);
            dateTimePicker.TabIndex = 27;
            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.AutoSize = true;
            labelPaymentStatus.Font = new Font("Montserrat", 12F);
            labelPaymentStatus.Location = new Point(31, 226);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new Size(0, 22);
            labelPaymentStatus.TabIndex = 29;
            // 
            // comboBoxSipmentStatus
            // 
            comboBoxSipmentStatus.AutoCompleteCustomSource.AddRange(new string[] { "не отгруженно", "отгруженно" });
            comboBoxSipmentStatus.BackColor = Color.Gainsboro;
            comboBoxSipmentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSipmentStatus.Font = new Font("Montserrat", 12F);
            comboBoxSipmentStatus.FormattingEnabled = true;
            comboBoxSipmentStatus.Location = new Point(31, 251);
            comboBoxSipmentStatus.Name = "comboBoxSipmentStatus";
            comboBoxSipmentStatus.Size = new Size(262, 30);
            comboBoxSipmentStatus.TabIndex = 28;
            // 
            // labelSipmentStatus
            // 
            labelSipmentStatus.AutoSize = true;
            labelSipmentStatus.Font = new Font("Montserrat", 12F);
            labelSipmentStatus.Location = new Point(31, 226);
            labelSipmentStatus.Name = "labelSipmentStatus";
            labelSipmentStatus.Size = new Size(143, 22);
            labelSipmentStatus.TabIndex = 30;
            labelSipmentStatus.Text = "Статус отгрузки";
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = SystemColors.Highlight;
            buttonConfirm.FlatAppearance.BorderSize = 0;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonConfirm.ForeColor = SystemColors.ButtonFace;
            buttonConfirm.Location = new Point(31, 325);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(138, 34);
            buttonConfirm.TabIndex = 22;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // ContranctForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(341, 377);
            Controls.Add(labelSipmentStatus);
            Controls.Add(labelPaymentStatus);
            Controls.Add(comboBoxSipmentStatus);
            Controls.Add(dateTimePicker);
            Controls.Add(labelSignedDate);
            Controls.Add(labelClientName);
            Controls.Add(comboBoxClientName);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxAdvancedPayment);
            Controls.Add(labelAdvancePayment);
            Name = "ContranctForm";
            Text = "ContranctForm";
            Load += ContranctForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private TextBox textBoxAdvancedPayment;
        private Label labelAdvancePayment;
        private ComboBox comboBoxClientName;
        private Label labelClientName;
        private Label labelSignedDate;
        private DateTimePicker dateTimePicker;
        private Label labelPaymentStatus;
        private ComboBox comboBoxSipmentStatus;
        private Label labelSipmentStatus;
        private Button buttonConfirm;
    }
}