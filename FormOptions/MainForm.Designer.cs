namespace FormOptions
{
    partial class MainForm
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
            lblUserInfo = new Label();
            btnLogout = new Button();
            btnGoTest = new Button();
            label1 = new Label();
            btnChangeStyles = new Button();
            SuspendLayout();
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblUserInfo.Location = new Point(28, 38);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(417, 38);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Інформація про користувача";
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnLogout.Location = new Point(28, 280);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(216, 68);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Вихід з акаунту";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnGoTest
            // 
            btnGoTest.FlatAppearance.BorderSize = 0;
            btnGoTest.FlatStyle = FlatStyle.Flat;
            btnGoTest.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnGoTest.Location = new Point(250, 280);
            btnGoTest.Name = "btnGoTest";
            btnGoTest.Size = new Size(216, 68);
            btnGoTest.TabIndex = 1;
            btnGoTest.Text = "Пройти тест";
            btnGoTest.UseVisualStyleBackColor = true;
            btnGoTest.Click += btnGoTest_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(539, 21);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 4;
            label1.Text = "ТЕМА :";
            // 
            // btnChangeStyles
            // 
            btnChangeStyles.BackColor = Color.White;
            btnChangeStyles.FlatAppearance.BorderSize = 0;
            btnChangeStyles.FlatStyle = FlatStyle.Flat;
            btnChangeStyles.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangeStyles.Location = new Point(616, 13);
            btnChangeStyles.Margin = new Padding(3, 4, 3, 4);
            btnChangeStyles.Name = "btnChangeStyles";
            btnChangeStyles.Size = new Size(97, 47);
            btnChangeStyles.TabIndex = 3;
            btnChangeStyles.Text = "Темна";
            btnChangeStyles.UseVisualStyleBackColor = false;
            btnChangeStyles.Click += btnChangeStyles_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 369);
            Controls.Add(label1);
            Controls.Add(btnChangeStyles);
            Controls.Add(btnGoTest);
            Controls.Add(btnLogout);
            Controls.Add(lblUserInfo);
            Name = "MainForm";
            Text = "Головна сторінка";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserInfo;
        private Button btnLogout;
        private Button btnGoTest;
        private Label label1;
        private Button btnChangeStyles;
    }
}