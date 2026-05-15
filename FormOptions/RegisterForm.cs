using System.Text.Json;
namespace FormOptions
{
    public partial class RegisterForm : Form
    {
        // Налаштування теми
        bool isDarkMode = false;
        string configPath = "appsettings.json";


        public RegisterForm()
        {
            InitializeComponent();

            txtName.TextChanged += (s, e) => ClearErrorOnInput(txtName, label8); //використовується для очищення помилки
            txtLastName.TextChanged += (s, e) => ClearErrorOnInput(txtLastName, label9);
            txtGroup.TextChanged += (s, e) => ClearErrorOnInput(txtGroup, label10);
            txtEmail.TextChanged += (s, e) => ClearErrorOnInput(txtEmail, label11);
            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, label12);
            txtPasswordCheck.TextChanged += (s, e) => ClearErrorOnInput(txtPasswordCheck, label13);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings(); //завантажую налаштування при завантаженні форми
            ApplyTheme(); //застосовую тему при завантаженні форми
        }

        // --- Теми та налаштування ---
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;//перемикаю режим
            ApplyTheme();//застосовую тему
            SaveSettings();//зберігаю налаштування
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode; //для зручності створюю змінну, щоб не писати isDarkMode кожного разу
            this.BackColor = dark ? Color.FromArgb(26, 26, 26) : SystemColors.Control;//змінюю фон форми

            foreach (Control ctrl in this.Controls)
            {
                //для Label з тегом "error" встановлюю червоний колір, для інших - білий або чорний в залежності від теми
                if (ctrl is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "error")
                    {
                        lbl.ForeColor = dark ? Color.LightCoral : Color.Red; //помилки виділяю червоним кольором, але в темній темі використовую світло-червоний, щоб було краще видно
                    }
                    else
                    {
                        lbl.ForeColor = dark ? Color.White : Color.Black; //для інших Label встановлюю білий або чорний колір в залежності від теми
                    }
                }


                if (ctrl is Button btn)
                {
                    btn.BackColor = dark ? Color.DimGray : Color.White; //для Button змінюю фон в залежності від теми
                    btn.ForeColor = dark ? Color.White : Color.Black; //для Button змінюю колір тексту в залежності від теми
                }
            }
            btnChangeStyles.Text = dark ? "Світла" : "Темна"; //змінюю текст кнопки в залежності від поточної теми, щоб було зрозуміло, яку тему можна вибрати
        }

        private void LoadSettings()
        {
            //завантажую налаштування з файлу, якщо він існує, і встановлюю режим теми відповідно до збережених даних
            try
            {
                if (File.Exists(configPath))
                {
                    string jsonString = File.ReadAllText(configPath); //читаю вміст файлу
                    using (JsonDocument doc = JsonDocument.Parse(jsonString)) //перетворюю в JSON
                    {
                        isDarkMode = (doc.RootElement.GetProperty("theme").GetString() == "dark"); //встановлюю режим в залежності від значення властивості "theme" в JSON
                    }
                }
            }
            catch { }
        }

        private void SaveSettings()
        {
            //зберігаю налаштування в файл у форматі JSON, щоб при наступному запуску програми можна було завантажити вибір користувача
            try
            {
                var data = new { theme = isDarkMode ? "dark" : "light" }; //створюю анонімний тип 
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }); //перетворюю дані в формат JSON з відступами для кращої читабельності
                File.WriteAllText(configPath, jsonString);//записую JSON у файл
            }
            catch { }
        }
        private void ClearErrorOnInput(TextBox textBox, Label errorLabel)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorLabel.Visible = false; //коли користувач починає вводити текст, якщо поле не порожнє, то ховаю відповідну помилку
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            // Валідація полів
            if (string.IsNullOrWhiteSpace(txtName.Text)) { label8.Visible = true; hasError = true; }
            if (string.IsNullOrWhiteSpace(txtLastName.Text)) { label9.Visible = true; hasError = true; }
            if (string.IsNullOrWhiteSpace(txtGroup.Text)) { label10.Visible = true; hasError = true; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { label11.Visible = true; hasError = true; }
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) { label12.Visible = true; hasError = true; }

            if (string.IsNullOrWhiteSpace(txtPasswordCheck.Text) || txtPassword.Text != txtPasswordCheck.Text)
            {
                label13.Visible = true;
                hasError = true;
            }

            if (!hasError)
            {
                List<User> users = new List<User>();
                string storagePath = "storage.json";

                if (File.Exists(storagePath))
                {
                    string existingJson = File.ReadAllText(storagePath);
                    // Використовуємо Newtonsoft.Json, як у вашому прикладі
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
                }

                // ПЕРЕВІРКА: чи існує вже такий email
                // Якщо User - це struct, використовуємо .Any() або порівнюємо результат
                if (users.Any(u => u.Email == txtEmail.Text))
                {
                    MessageBox.Show("Користувач з цією поштою вже зареєстрований!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Створення нового користувача
                User newUser = new User()
                {
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    Group = txtGroup.Text,
                    Email = txtEmail.Text,
                    Password = hashPasswordMD5(txtPassword.Text)
                };

                users.Add(newUser);

                // ЗБЕРЕЖЕННЯ: Перезаписуємо весь файл оновленим списком
                string updatedJson = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(storagePath, updatedJson);

                MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Перехід до логіну
                btnToLogin_Click(sender, e);

                ToLoginForm();
            }
        
        }
        private void btnToLogin_Click(object sender, EventArgs e)
        {
            //відкриваю форму для входу і закриваю поточну
            ToLoginForm();
        }
        
        private void ToLoginForm()
        {
            LogicForm logicForm = new LogicForm();
            this.Hide();
            logicForm.ShowDialog();
            Close();
        }

        private void btnVissiblePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar; //перемикаю видимість пароля, якщо він був захищений, то роблю його видимим, і навпаки
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            txtPasswordCheck.UseSystemPasswordChar = !txtPasswordCheck.UseSystemPasswordChar; //перемикаю видимість поля для підтвердження пароля, якщо він був захищений, то роблю його видимим, і навпаки
        }

        private string hashPasswordMD5(string password)
        {
            //створюю MD5 хеш для пароля, щоб зберігати його в зашифрованому вигляді для безпеки, використовуючи стандартну бібліотеку System.Security.Cryptography
            using var md5 = System.Security.Cryptography.MD5.Create(); //створюю екземпляр MD5 для хешування
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password); //перетворюю пароль в масив байтів, використовуючи ASCII кодування, оскільки MD5 працює з байтами
            byte[] hashBytes = md5.ComputeHash(inputBytes); //хешую пароль і отримую масив байтів з результатом хешування
            return Convert.ToHexString(hashBytes); //перетворюю масив байтів в шістнадцятковий рядок для зручного зберігання
        }
    }
}