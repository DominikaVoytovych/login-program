namespace FormOptions
{
    partial class LogicForm
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
            btnVissiblePassword = new Button();
            btnToRee = new Button();
            btnSave = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label12 = new Label();
            label11 = new Label();
            lbQuestion = new Label();
            label1 = new Label();
            btnChangeStyles = new Button();
            btnRestoreRequest = new Button();
            SuspendLayout();
            // 
            // btnVissiblePassword
            // 
            btnVissiblePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnVissiblePassword.Location = new Point(697, 124);
            btnVissiblePassword.Name = "btnVissiblePassword";
            btnVissiblePassword.Size = new Size(33, 38);
            btnVissiblePassword.TabIndex = 30;
            btnVissiblePassword.Text = "👁️";
            btnVissiblePassword.UseVisualStyleBackColor = true;
            btnVissiblePassword.Click += btnVissiblePassword_Click;
            // 
            // btnToRee
            // 
            btnToRee.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnToRee.Location = new Point(148, 252);
            btnToRee.Name = "btnToRee";
            btnToRee.Size = new Size(244, 57);
            btnToRee.TabIndex = 29;
            btnToRee.Text = "Перейти до реєстрації";
            btnToRee.UseVisualStyleBackColor = true;
            btnToRee.Click += btnToRee_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(410, 252);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 57);
            btnSave.TabIndex = 28;
            btnSave.Text = "Вхід";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtPassword.Location = new Point(410, 124);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 38);
            txtPassword.TabIndex = 24;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            txtEmail.Location = new Point(33, 124);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 43);
            txtEmail.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(410, 86);
            label6.Name = "label6";
            label6.Size = new Size(107, 35);
            label6.TabIndex = 20;
            label6.Text = "Пароль";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(33, 86);
            label5.Name = "label5";
            label5.Size = new Size(95, 35);
            label5.TabIndex = 19;
            label5.Text = "Пошта";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(410, 170);
            label12.Name = "label12";
            label12.Size = new Size(218, 25);
            label12.TabIndex = 14;
            label12.Tag = "error";
            label12.Text = "⚠Вкажіть ваш пароль";
            label12.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(33, 168);
            label11.Name = "label11";
            label11.Size = new Size(220, 25);
            label11.TabIndex = 13;
            label11.Tag = "error";
            label11.Text = "⚠Вкажіть вашу пошту";
            label11.Visible = false;
            // 
            // lbQuestion
            // 
            lbQuestion.AutoSize = true;
            lbQuestion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbQuestion.ForeColor = Color.Black;
            lbQuestion.Location = new Point(272, 20);
            lbQuestion.Name = "lbQuestion";
            lbQuestion.Size = new Size(174, 35);
            lbQuestion.TabIndex = 9;
            lbQuestion.Text = "Вхід в акаунт";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(529, 25);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 8;
            label1.Text = "ТЕМА :";
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.BackColor = Color.White;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeStyles.Location = new Point(606, 17);
            btnChangeStyles.Margin = new Padding(3, 4, 3, 4);
            btnChangeStyles.Name = "btnChangeStyles";
            btnChangeStyles.Size = new Size(97, 46);
            btnChangeStyles.TabIndex = 7;
            btnChangeStyles.Text = "Темна";
            btnChangeStyles.UseVisualStyleBackColor = false;
            btnChangeStyles.Click += btnChangeStyles_Click;
            // 
            // btnRestoreRequest
            // 
            btnRestoreRequest.FlatAppearance.BorderSize = 0;
            btnRestoreRequest.FlatStyle = FlatStyle.Flat;
            btnRestoreRequest.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRestoreRequest.ForeColor = Color.SteelBlue;
            btnRestoreRequest.Location = new Point(314, 209);
            btnRestoreRequest.Name = "btnRestoreRequest";
            btnRestoreRequest.Size = new Size(159, 37);
            btnRestoreRequest.TabIndex = 31;
            btnRestoreRequest.Text = "Забули пароль?";
            btnRestoreRequest.UseVisualStyleBackColor = true;
            btnRestoreRequest.Click += btnRestoreRequest_Click;
            // 
            // LogicForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 321);
            Controls.Add(btnRestoreRequest);
            Controls.Add(btnVissiblePassword);
            Controls.Add(btnToRee);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(lbQuestion);
            Controls.Add(label1);
            Controls.Add(btnChangeStyles);
            Name = "LogicForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Вхід";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnVissiblePassword;
        private Button btnToRee;
        private Button btnSave;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label6;
        private Label label5;
        private Label label12;
        private Label label11;
        private Label lbQuestion;
        private Label label1;
        private Button btnChangeStyles;
        private Button btnRestoreRequest;
    }
}