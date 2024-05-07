namespace WinFormProducts
{
    partial class ClientsUC
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            buttonAdd_13 = new Button();
            buttonDelete = new Button();
            buttonChange = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat Medium", 16F, FontStyle.Bold);
            label1.Location = new Point(653, 10);
            label1.Name = "label1";
            label1.Size = new Size(123, 30);
            label1.TabIndex = 1;
            label1.Text = "Клиенты";
            // 
            // buttonAdd_13
            // 
            buttonAdd_13.BackColor = SystemColors.Highlight;
            buttonAdd_13.FlatAppearance.BorderSize = 0;
            buttonAdd_13.FlatStyle = FlatStyle.Flat;
            buttonAdd_13.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAdd_13.ForeColor = SystemColors.ButtonFace;
            buttonAdd_13.Location = new Point(518, 436);
            buttonAdd_13.Name = "buttonAdd_13";
            buttonAdd_13.Size = new Size(118, 34);
            buttonAdd_13.TabIndex = 12;
            buttonAdd_13.Text = "Добавить";
            buttonAdd_13.UseVisualStyleBackColor = false;
            buttonAdd_13.Click += buttonAdd_13_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.RosyBrown;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDelete.ForeColor = SystemColors.ButtonFace;
            buttonDelete.Location = new Point(786, 436);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(118, 34);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonChange
            // 
            buttonChange.BackColor = SystemColors.ButtonShadow;
            buttonChange.FlatAppearance.BorderSize = 0;
            buttonChange.FlatStyle = FlatStyle.Flat;
            buttonChange.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonChange.ForeColor = SystemColors.ButtonFace;
            buttonChange.Location = new Point(653, 436);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(118, 34);
            buttonChange.TabIndex = 10;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = false;
            buttonChange.Click += buttonChange_Click;
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = Color.Gainsboro;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Gainsboro;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Gainsboro;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = SystemColors.ScrollBar;
            dataGridView.Location = new Point(222, 43);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Gainsboro;
            dataGridViewCellStyle6.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView.Size = new Size(954, 376);
            dataGridView.TabIndex = 15;
            // 
            // ClientsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(buttonAdd_13);
            Controls.Add(buttonDelete);
            Controls.Add(buttonChange);
            Controls.Add(label1);
            Name = "ClientsUC";
            Size = new Size(1200, 500);
            Load += UsersUC_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button buttonAdd_13;
        private Button buttonDelete;
        private Button buttonChange;
        private DataGridView dataGridView;
    }
}
