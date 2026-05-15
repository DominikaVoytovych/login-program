namespace FormOptions
{
    partial class RegisterForm
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
            btnChangeStyles = new Button();
            label1 = new Label();
            lbQuestion = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtGroup = new TextBox();
            label6 = new Label();
            txtPassword = new TextBox();
            label7 = new Label();
            txtPasswordCheck = new TextBox();
            btnSave = new Button();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            btnVissiblePassword = new Button();
            btnCheck = new Button();
            btnToLogin = new Button();
            SuspendLayout();
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.BackColor = Color.White;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeStyles.Location = new Point(610, 7);
            btnChangeStyles.Margin = new Padding(3, 4, 3, 4);
            btnChangeStyles.Name = "btnChangeStyles";
            btnChangeStyles.Size = new Size(97, 46);
            btnChangeStyles.TabIndex = 0;
            btnChangeStyles.Text = "Темна";
            btnChangeStyles.UseVisualStyleBackColor = false;
            btnChangeStyles.Click += btnChangeStyles_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(533, 15);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 2;
            label1.Text = "ТЕМА :";
            // 
            // lbQuestion
            // 
            lbQuestion.AutoSize = true;
            lbQuestion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbQuestion.ForeColor = Color.Black;
            lbQuestion.Location = new Point(194, 10);
            lbQuestion.Name = "lbQuestion";
            lbQuestion.Size = new Size(299, 35);
            lbQuestion.TabIndex = 3;
            lbQuestion.Text = "Створити новий акаунт";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(31, 91);
            label2.Name = "label2";
            label2.Size = new Size(63, 35);
            label2.TabIndex = 3;
            label2.Text = "Ім'я";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(387, 91);
            label3.Name = "label3";
            label3.Size = new Size(136, 35);
            label3.TabIndex = 3;
            label3.Text = "Прізвище";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(31, 203);
            label4.Name = "label4";
            label4.Size = new Size(83, 35);
            label4.TabIndex = 3;
            label4.Text = "Група";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(387, 203);
            label5.Name = "label5";
            label5.Size = new Size(95, 35);
            label5.TabIndex = 3;
            label5.Text = "Пошта";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtName.Location = new Point(31, 129);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(320, 43);
            txtName.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtLastName.Location = new Point(387, 129);
            txtLastName.Multiline = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(320, 43);
            txtLastName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtEmail.Location = new Point(387, 241);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 43);
            txtEmail.TabIndex = 4;
            // 
            // txtGroup
            // 
            txtGroup.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtGroup.Location = new Point(31, 241);
            txtGroup.Multiline = true;
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(320, 43);
            txtGroup.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(31, 319);
            label6.Name = "label6";
            label6.Size = new Size(107, 35);
            label6.TabIndex = 3;
            label6.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtPassword.Location = new Point(31, 357);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 38);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(387, 319);
            label7.Name = "label7";
            label7.Size = new Size(237, 35);
            label7.TabIndex = 3;
            label7.Text = "Перевірка пароля";
            // 
            // txtPasswordCheck
            // 
            txtPasswordCheck.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtPasswordCheck.Location = new Point(387, 357);
            txtPasswordCheck.Name = "txtPasswordCheck";
            txtPasswordCheck.Size = new Size(320, 38);
            txtPasswordCheck.TabIndex = 4;
            txtPasswordCheck.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(409, 445);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 57);
            btnSave.TabIndex = 5;
            btnSave.Text = "Реєстрація";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(31, 175);
            label8.Name = "label8";
            label8.Size = new Size(198, 25);
            label8.TabIndex = 3;
            label8.Tag = "error";
            label8.Text = "⚠Вкажіть ваше ім'я";
            label8.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(387, 175);
            label9.Name = "label9";
            label9.Size = new Size(247, 25);
            label9.TabIndex = 3;
            label9.Tag = "error";
            label9.Text = "⚠Вкажіть ваше прізвище";
            label9.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(31, 285);
            label10.Name = "label10";
            label10.Size = new Size(213, 25);
            label10.TabIndex = 3;
            label10.Tag = "error";
            label10.Text = "⚠Вкажіть вашу групу";
            label10.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(387, 285);
            label11.Name = "label11";
            label11.Size = new Size(220, 25);
            label11.TabIndex = 3;
            label11.Tag = "error";
            label11.Text = "⚠Вкажіть вашу пошту";
            label11.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(31, 403);
            label12.Name = "label12";
            label12.Size = new Size(218, 25);
            label12.TabIndex = 3;
            label12.Tag = "error";
            label12.Text = "⚠Вкажіть ваш пароль";
            label12.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(387, 403);
            label13.Name = "label13";
            label13.Size = new Size(195, 25);
            label13.TabIndex = 3;
            label13.Tag = "error";
            label13.Text = "⚠Повторіть пароль";
            label13.Visible = false;
            // 
            // btnVissiblePassword
            // 
            btnVissiblePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnVissiblePassword.Location = new Point(318, 357);
            btnVissiblePassword.Name = "btnVissiblePassword";
            btnVissiblePassword.Size = new Size(33, 38);
            btnVissiblePassword.TabIndex = 6;
            btnVissiblePassword.Text = "👁️";
            btnVissiblePassword.UseVisualStyleBackColor = true;
            btnVissiblePassword.Click += btnVissiblePassword_Click;
            // 
            // btnCheck
            // 
            btnCheck.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCheck.Location = new Point(674, 357);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(33, 38);
            btnCheck.TabIndex = 6;
            btnCheck.Text = "👁️";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // btnToLogin
            // 
            btnToLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnToLogin.Location = new Point(173, 445);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(205, 57);
            btnToLogin.TabIndex = 5;
            btnToLogin.Text = "Перейти до входу";
            btnToLogin.UseVisualStyleBackColor = true;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(746, 543);
            Controls.Add(btnCheck);
            Controls.Add(btnVissiblePassword);
            Controls.Add(btnToLogin);
            Controls.Add(btnSave);
            Controls.Add(txtGroup);
            Controls.Add(txtPasswordCheck);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(txtLastName);
            Controls.Add(label6);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(lbQuestion);
            Controls.Add(label1);
            Controls.Add(btnChangeStyles);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Реєстрація користувача";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChangeStyles;
        private Label label1;
        private Label lbQuestion;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtGroup;
        private Label label6;
        private TextBox txtPassword;
        private Label label7;
        private TextBox txtPasswordCheck;
        private Button btnSave;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button btnVissiblePassword;
        private Button btnCheck;
        private Button btnToLogin;
    }
}
