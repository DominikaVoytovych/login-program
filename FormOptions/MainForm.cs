using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class MainForm : Form
    {
        bool isDarkMode = false;
        string configPath = "appsettings.json";
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string fileAuthUser = "auth.bin";
            if (File.Exists(fileAuthUser))
            {
                var json = File.ReadAllText(fileAuthUser);
                var authUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);

                // Виводимо дані в Label (назвіть свій Label, наприклад, lblUserInfo)
                lblUserInfo.Text = $"Вітаємо, {authUser.Name} {authUser.LastName}!\nГрупа: {authUser.Group}\nEmail: {authUser.Email}";
            }
            else
            {
                // Якщо файлу нема, вимагаємо вхід
                LogicForm dlgLogin = new LogicForm();
                if (dlgLogin.ShowDialog() == DialogResult.OK)
                {
                    // Перезавантажуємо дані після входу
                    var json = File.ReadAllText(fileAuthUser);
                    var authUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);
                    lblUserInfo.Text = $"Вітаємо, {authUser.Name} {authUser.LastName}!";
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете вийти?", "Вихід", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Видаляємо файл сесії
                if (File.Exists("auth.bin")) File.Delete("auth.bin");

                // Повертаємося до логіну
                this.Hide();
                new LogicForm().ShowDialog();
                this.Close();
            }
        }
        private void btnGoTest_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            this.Hide();
            testForm.ShowDialog();
            this.Show();
        }
        //Зміна теми
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode;
            this.BackColor = dark ? Color.FromArgb(26, 26, 26) : SystemColors.Control;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is RadioButton)
                    ctrl.ForeColor = dark ? Color.White : Color.Black;

                if (ctrl is Button btn)
                {
                    btn.BackColor = dark ? Color.DimGray : Color.White;
                    btn.ForeColor = dark ? Color.White : Color.Black;
                }
            }
            btnChangeStyles.Text = dark ? "Світла" : "Темна";
        }

        private void LoadSettings()
        {
            //перевіряю, чи існує файл налаштувань, якщо так - завантажую його і встановлюю тему
            try
            {
                if (File.Exists(configPath))
                {
                    string jsonString = File.ReadAllText(configPath);
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        isDarkMode = (doc.RootElement.GetProperty("theme").GetString() == "dark");
                    }
                }
            }
            catch { }
        }

        private void SaveSettings()
        {
            //створюю об'єкт з налаштуваннями і записую його у файл у форматі JSON
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" };
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, jsonString);
            }
            catch { }
        }
    }
}
