namespace WinFormProducts
{
    partial class ClientForm
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
            buttonConfirm = new Button();
            textBoxPhone = new TextBox();
            textBoxName = new TextBox();
            labelPhone = new Label();
            labelName = new Label();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.RosyBrown;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonCancel.ForeColor = SystemColors.ButtonFace;
            buttonCancel.Location = new Point(156, 216);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(118, 34);
            buttonCancel.TabIndex = 23;
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
            buttonConfirm.Location = new Point(12, 216);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(135, 34);
            buttonConfirm.TabIndex = 22;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = false;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // textBoxPhone
            // 
            textBoxPhone.BackColor = Color.Gainsboro;
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Montserrat", 12F);
            textBoxPhone.Location = new Point(12, 117);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(262, 27);
            textBoxPhone.TabIndex = 21;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.Gainsboro;
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Font = new Font("Montserrat", 12F);
            textBoxName.Location = new Point(12, 34);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(262, 27);
            textBoxName.TabIndex = 20;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Montserrat", 12F);
            labelPhone.Location = new Point(12, 91);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(152, 22);
            labelPhone.TabIndex = 19;
            labelPhone.Text = "Номер телефона";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Montserrat", 12F);
            labelName.Location = new Point(12, 9);
            labelName.Name = "labelName";
            labelName.Size = new Size(46, 22);
            labelName.TabIndex = 18;
            labelName.Text = "Имя";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(294, 266);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxName);
            Controls.Add(labelPhone);
            Controls.Add(labelName);
            Name = "ClientForm";
            Text = "СlientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonConfirm;
        private TextBox textBoxPhone;
        private TextBox textBoxName;
        private Label labelPhone;
        private Label labelName;
    }
}