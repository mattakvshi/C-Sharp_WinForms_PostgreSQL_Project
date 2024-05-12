namespace WinFormProducts
{
    partial class ReportingUC
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
            dateTimePickerTextReportFrom = new DateTimePicker();
            labelSignedDate = new Label();
            dateTimePickerTextReportTo = new DateTimePicker();
            label1 = new Label();
            labelReportClient = new Label();
            checkedListBoxClient = new CheckedListBox();
            richTextBoxReportClient = new RichTextBox();
            buttonMakeUp = new Button();
            buttonExport = new Button();
            SuspendLayout();
            // 
            // dateTimePickerTextReportFrom
            // 
            dateTimePickerTextReportFrom.CalendarFont = new Font("Montserrat", 12F);
            dateTimePickerTextReportFrom.CalendarForeColor = SystemColors.Desktop;
            dateTimePickerTextReportFrom.CalendarMonthBackground = Color.Gainsboro;
            dateTimePickerTextReportFrom.Font = new Font("Montserrat", 12F);
            dateTimePickerTextReportFrom.Location = new Point(193, 90);
            dateTimePickerTextReportFrom.Name = "dateTimePickerTextReportFrom";
            dateTimePickerTextReportFrom.Size = new Size(265, 27);
            dateTimePickerTextReportFrom.TabIndex = 29;
            // 
            // labelSignedDate
            // 
            labelSignedDate.AutoSize = true;
            labelSignedDate.Font = new Font("Montserrat", 12F);
            labelSignedDate.Location = new Point(193, 65);
            labelSignedDate.Name = "labelSignedDate";
            labelSignedDate.Size = new Size(187, 22);
            labelSignedDate.TabIndex = 28;
            labelSignedDate.Text = "Дата начала периода";
            // 
            // dateTimePickerTextReportTo
            // 
            dateTimePickerTextReportTo.CalendarFont = new Font("Montserrat", 12F);
            dateTimePickerTextReportTo.CalendarForeColor = SystemColors.Desktop;
            dateTimePickerTextReportTo.CalendarMonthBackground = Color.Gainsboro;
            dateTimePickerTextReportTo.Font = new Font("Montserrat", 12F);
            dateTimePickerTextReportTo.Location = new Point(193, 157);
            dateTimePickerTextReportTo.Name = "dateTimePickerTextReportTo";
            dateTimePickerTextReportTo.Size = new Size(265, 27);
            dateTimePickerTextReportTo.TabIndex = 31;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 12F);
            label1.Location = new Point(193, 132);
            label1.Name = "label1";
            label1.Size = new Size(179, 22);
            label1.TabIndex = 30;
            label1.Text = "Дата конца периода";
            // 
            // labelReportClient
            // 
            labelReportClient.AutoSize = true;
            labelReportClient.Font = new Font("Montserrat", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelReportClient.Location = new Point(193, 12);
            labelReportClient.Name = "labelReportClient";
            labelReportClient.Size = new Size(249, 33);
            labelReportClient.TabIndex = 32;
            labelReportClient.Text = "Отчёт по клиентам";
            // 
            // checkedListBoxClient
            // 
            checkedListBoxClient.BackColor = Color.Gainsboro;
            checkedListBoxClient.BorderStyle = BorderStyle.None;
            checkedListBoxClient.Font = new Font("Montserrat", 12F);
            checkedListBoxClient.FormattingEnabled = true;
            checkedListBoxClient.Location = new Point(193, 211);
            checkedListBoxClient.Name = "checkedListBoxClient";
            checkedListBoxClient.Size = new Size(265, 308);
            checkedListBoxClient.TabIndex = 33;
            // 
            // richTextBoxReportClient
            // 
            richTextBoxReportClient.BackColor = Color.Gainsboro;
            richTextBoxReportClient.BorderStyle = BorderStyle.None;
            richTextBoxReportClient.Font = new Font("Montserrat", 12F);
            richTextBoxReportClient.ForeColor = SystemColors.WindowFrame;
            richTextBoxReportClient.Location = new Point(517, 15);
            richTextBoxReportClient.Name = "richTextBoxReportClient";
            richTextBoxReportClient.Size = new Size(643, 615);
            richTextBoxReportClient.TabIndex = 34;
            richTextBoxReportClient.Text = "";
            // 
            // buttonMakeUp
            // 
            buttonMakeUp.BackColor = SystemColors.Highlight;
            buttonMakeUp.FlatAppearance.BorderSize = 0;
            buttonMakeUp.FlatStyle = FlatStyle.Flat;
            buttonMakeUp.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonMakeUp.ForeColor = SystemColors.ButtonFace;
            buttonMakeUp.Location = new Point(193, 543);
            buttonMakeUp.Name = "buttonMakeUp";
            buttonMakeUp.Size = new Size(265, 34);
            buttonMakeUp.TabIndex = 35;
            buttonMakeUp.Text = "Сформировать отчёт";
            buttonMakeUp.UseVisualStyleBackColor = false;
            buttonMakeUp.Click += buttonMakeUp_Click;
            // 
            // buttonExport
            // 
            buttonExport.BackColor = SystemColors.GrayText;
            buttonExport.FlatAppearance.BorderSize = 0;
            buttonExport.FlatStyle = FlatStyle.Flat;
            buttonExport.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonExport.ForeColor = SystemColors.ButtonFace;
            buttonExport.Location = new Point(193, 596);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(265, 34);
            buttonExport.TabIndex = 36;
            buttonExport.Text = "Экспорт в Excel";
            buttonExport.UseVisualStyleBackColor = false;
            buttonExport.Click += buttonExport_Click;
            // 
            // ReportingUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonExport);
            Controls.Add(buttonMakeUp);
            Controls.Add(richTextBoxReportClient);
            Controls.Add(checkedListBoxClient);
            Controls.Add(labelReportClient);
            Controls.Add(dateTimePickerTextReportTo);
            Controls.Add(label1);
            Controls.Add(dateTimePickerTextReportFrom);
            Controls.Add(labelSignedDate);
            ForeColor = SystemColors.WindowFrame;
            Name = "ReportingUC";
            Size = new Size(1200, 650);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerTextReportFrom;
        private Label labelSignedDate;
        private DateTimePicker dateTimePickerTextReportTo;
        private Label label1;
        private Label labelReportClient;
        private CheckedListBox checkedListBoxClient;
        private RichTextBox richTextBoxReportClient;
        private Button buttonMakeUp;
        private Button buttonExport;
    }
}
