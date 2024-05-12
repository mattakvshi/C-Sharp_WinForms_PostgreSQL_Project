namespace WinFormProducts
{
    partial class ReportDebtorsUC
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
            buttonMakeUp = new Button();
            richTextBoxReportDay = new RichTextBox();
            labelReportClient = new Label();
            dateTimePickerDayReportTo = new DateTimePicker();
            label1 = new Label();
            dateTimePickerDayReportFrom = new DateTimePicker();
            labelSignedDate = new Label();
            buttonExportToChart = new Button();
            SuspendLayout();
            // 
            // buttonMakeUp
            // 
            buttonMakeUp.BackColor = SystemColors.Highlight;
            buttonMakeUp.FlatAppearance.BorderSize = 0;
            buttonMakeUp.FlatStyle = FlatStyle.Flat;
            buttonMakeUp.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonMakeUp.ForeColor = SystemColors.ButtonFace;
            buttonMakeUp.Location = new Point(182, 209);
            buttonMakeUp.Name = "buttonMakeUp";
            buttonMakeUp.Size = new Size(265, 34);
            buttonMakeUp.TabIndex = 44;
            buttonMakeUp.Text = "Сформировать отчёт";
            buttonMakeUp.UseVisualStyleBackColor = false;
            buttonMakeUp.Click += buttonMakeUp_Click;
            // 
            // richTextBoxReportDay
            // 
            richTextBoxReportDay.BackColor = Color.Gainsboro;
            richTextBoxReportDay.BorderStyle = BorderStyle.None;
            richTextBoxReportDay.Font = new Font("Montserrat", 12F);
            richTextBoxReportDay.ForeColor = SystemColors.WindowFrame;
            richTextBoxReportDay.Location = new Point(483, 13);
            richTextBoxReportDay.Name = "richTextBoxReportDay";
            richTextBoxReportDay.Size = new Size(688, 615);
            richTextBoxReportDay.TabIndex = 43;
            richTextBoxReportDay.Text = "";
            // 
            // labelReportClient
            // 
            labelReportClient.AutoSize = true;
            labelReportClient.Font = new Font("Montserrat", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelReportClient.ForeColor = SystemColors.WindowFrame;
            labelReportClient.Location = new Point(182, 10);
            labelReportClient.Name = "labelReportClient";
            labelReportClient.Size = new Size(194, 33);
            labelReportClient.TabIndex = 41;
            labelReportClient.Text = "Отчёт по дням";
            // 
            // dateTimePickerDayReportTo
            // 
            dateTimePickerDayReportTo.CalendarFont = new Font("Montserrat", 12F);
            dateTimePickerDayReportTo.CalendarForeColor = SystemColors.Desktop;
            dateTimePickerDayReportTo.CalendarMonthBackground = Color.Gainsboro;
            dateTimePickerDayReportTo.Font = new Font("Montserrat", 12F);
            dateTimePickerDayReportTo.Location = new Point(182, 155);
            dateTimePickerDayReportTo.Name = "dateTimePickerDayReportTo";
            dateTimePickerDayReportTo.Size = new Size(265, 27);
            dateTimePickerDayReportTo.TabIndex = 40;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat", 12F);
            label1.ForeColor = SystemColors.WindowFrame;
            label1.Location = new Point(182, 130);
            label1.Name = "label1";
            label1.Size = new Size(179, 22);
            label1.TabIndex = 39;
            label1.Text = "Дата конца периода";
            // 
            // dateTimePickerDayReportFrom
            // 
            dateTimePickerDayReportFrom.CalendarFont = new Font("Montserrat", 12F);
            dateTimePickerDayReportFrom.CalendarForeColor = SystemColors.Desktop;
            dateTimePickerDayReportFrom.CalendarMonthBackground = Color.Gainsboro;
            dateTimePickerDayReportFrom.Font = new Font("Montserrat", 12F);
            dateTimePickerDayReportFrom.Location = new Point(182, 88);
            dateTimePickerDayReportFrom.Name = "dateTimePickerDayReportFrom";
            dateTimePickerDayReportFrom.Size = new Size(265, 27);
            dateTimePickerDayReportFrom.TabIndex = 38;
            // 
            // labelSignedDate
            // 
            labelSignedDate.AutoSize = true;
            labelSignedDate.Font = new Font("Montserrat", 12F);
            labelSignedDate.ForeColor = SystemColors.WindowFrame;
            labelSignedDate.Location = new Point(182, 63);
            labelSignedDate.Name = "labelSignedDate";
            labelSignedDate.Size = new Size(187, 22);
            labelSignedDate.TabIndex = 37;
            labelSignedDate.Text = "Дата начала периода";
            // 
            // buttonExportToChart
            // 
            buttonExportToChart.BackColor = SystemColors.GrayText;
            buttonExportToChart.FlatAppearance.BorderSize = 0;
            buttonExportToChart.FlatStyle = FlatStyle.Flat;
            buttonExportToChart.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonExportToChart.ForeColor = SystemColors.ButtonFace;
            buttonExportToChart.Location = new Point(182, 258);
            buttonExportToChart.Name = "buttonExportToChart";
            buttonExportToChart.Size = new Size(265, 34);
            buttonExportToChart.TabIndex = 45;
            buttonExportToChart.Text = "Сформировать график";
            buttonExportToChart.UseVisualStyleBackColor = false;
            buttonExportToChart.Click += buttonExportToChart_Click;
            // 
            // ReportDebtorsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonExportToChart);
            Controls.Add(buttonMakeUp);
            Controls.Add(richTextBoxReportDay);
            Controls.Add(labelReportClient);
            Controls.Add(dateTimePickerDayReportTo);
            Controls.Add(label1);
            Controls.Add(dateTimePickerDayReportFrom);
            Controls.Add(labelSignedDate);
            Name = "ReportDebtorsUC";
            Size = new Size(1200, 650);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonMakeUp;
        private RichTextBox richTextBoxReportDay;
        private Label labelReportClient;
        private DateTimePicker dateTimePickerDayReportTo;
        private Label label1;
        private DateTimePicker dateTimePickerDayReportFrom;
        private Label labelSignedDate;
        private Button buttonExportToChart;
    }
}
