using MailKit.Net.Smtp;
using Microsoft.VisualBasic.ApplicationServices;
using MimeKit;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace FormOptions
{
    public partial class LogicForm : Form
    {
        private string generatedCode; //змінна для зберігання випадкового коду підтвердження
        bool isDarkMode = false; //змінна для відстеження поточної теми
        string configPath = "appsettings.json"; //шлях до файлу з налаштуваннями теми

        public LogicForm()
        {
            InitializeComponent();

            //підписуюсь на зміну тексту, щоб прибирати написи про помилки, коли користувач починає друкувати
            txtEmail.TextChanged += (s, e) => ClearErrorOnInput(txtEmail, label11);
            txtPassword.TextChanged += (s, e) => ClearErrorOnInput(txtPassword, label12);
        }

        private void LogicForm_Load(object sender, EventArgs e)
        {
            LoadSettings(); //завантажую збережену тему (світлу або темну)
            ApplyTheme(); //застосовую кольори до елементів форми
        }

        // --- Керування темою ---
        private void btnChangeStyles_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode; //змінюю стан теми на протилежний
            ApplyTheme(); //одинаково оновлюю кольори всіх контролів
            SaveSettings(); //зберігаю вибір у конфігураційний файл
        }

        private void ApplyTheme()
        {
            bool dark = isDarkMode; //створюю локальну змінну для зручності перевірки
            this.BackColor = dark ? Color.FromArgb(26, 26, 26) : SystemColors.Control; //змінюю колір фону самої форми

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    //якщо це мітка помилки (Tag="error"), то ставлю червоний колір, інакше - адаптивний під тему
                    lbl.ForeColor = (lbl.Tag?.ToString() == "error")
                        ? (dark ? Color.LightCoral : Color.Red)
                        : (dark ? Color.White : Color.Black);
                }
                if (ctrl is Button btn)
                {
                    btn.BackColor = dark ? Color.DimGray : Color.White; //фон кнопок стає сірим у темній темі
                    btn.ForeColor = dark ? Color.White : Color.Black; //текст кнопок стає білим у темній темі
                }
            }
            btnChangeStyles.Text = dark ? "Світла" : "Темна"; //оновлюю текст на кнопці перемикання теми
        }

        private void LoadSettings() { /* твій код завантаження без змін */ }
        private void SaveSettings() { /* твій код збереження без змін */ }

        // --- Логіка входу ---
        private void ClearErrorOnInput(TextBox textBox, Label errorLabel)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text)) errorLabel.Visible = false; //ховаємо помилку, якщо в полі з'явився текст
        }

        private string hashPasswordMD5(string password)
        {
            //створюю MD5 хеш для пароля, щоб порівнювати його з зашифрованим паролем у базі даних
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes); //повертаю результат у вигляді рядка
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            //валідація: якщо поля порожні, показуємо червоні написи
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { label11.Visible = true; hasError = true; }
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) { label12.Visible = true; hasError = true; }
            if (hasError) return;

            string filePath = "storage.json";
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath); //читаю список користувачів
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                    string inputHashedPassword = hashPasswordMD5(txtPassword.Text); //хешую введений пароль

                    //шукаємо користувача, у якого збігаються і пошта, і хеш пароля
                    User foundUser = users.FirstOrDefault(u => u.Email == txtEmail.Text && u.Password == inputHashedPassword);

                    if (!foundUser.Equals(default(User)))
                    {
                        MessageBox.Show("Вхід успішний!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        string fileAuthUser = "auth.bin";
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(foundUser); // інформація про користувача
                        File.WriteAllText(fileAuthUser, json);
                        //Це означає, що кристувач успішно зайшов
                        DialogResult = DialogResult.OK;
                        //MessageBox.Show("Вхід успішний!", "Вітаємо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //new MainForm().ShowDialog(); //відкриваємо головну форму
                        //this.Close(); //закриваємо форму входу
                    }
                    else MessageBox.Show("Невірна пошта або пароль!"); //повідомляємо про помилку авторизації
                }
                catch (Exception ex) { MessageBox.Show($"Помилка даних: {ex.Message}"); }
            }
        }

        // --- ВІДНОВЛЕННЯ ПАРОЛЯ ---
        private async void btnRestoreRequest_Click(object sender, EventArgs e)
        {
            //беремо пошту безпосередньо з текстового поля на формі, щоб відновити пароль саме для цього акаунта
            string email = txtEmail.Text;

            //якщо користувач не ввів пошту в поле, показуємо попередження і зупиняємо процес
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Будь ласка, спочатку введіть вашу пошту в поле 'Пошта'", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = "storage.json"; //шлях до нашої бази даних користувачів

            //перевіряємо чи існує файл бази, щоб зчитати дані
            if (File.Exists(filePath))
            {
                //читаємо JSON файл і перетворюємо його на список об'єктів для роботи в коді
                var json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

                //перевірка: чи є в нашій базі користувач із такою поштою, щоб не надсилати листи на неіснуючі акаунти
                if (!users.Any(u => u.Email == email))
                {
                    MessageBox.Show("Користувача з такою поштою не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; //якщо пошти немає в базі, припиняємо виконання методу
                }
            }

            //якщо пошта пройшла перевірку, генеруємо випадковий шестизначний код для підтвердження особи
            Random rnd = new Random();
            generatedCode = rnd.Next(100000, 999999).ToString();

            string subject = "Код підтвердження"; //тема листа
            string body = $"<h3>Ваш код для відновлення: <b style='color:blue;'>{generatedCode}</b></h3>"; //красиво оформлене тіло листа з кодом

            //відправляємо лист на вказану пошту асинхронно, щоб програма не "зависла" під час очікування відповіді сервера
            await MySendEmail(subject, body, "", email);


            //викликаємо вікно для введення отриманого коду
            string userCode = Microsoft.VisualBasic.Interaction.InputBox("Введіть код із пошти:", "Перевірка", "");


            if (userCode == generatedCode) //якщо код, який ввів користувач, збігається з тим, що ми відправили
            {
                //запитуємо новий пароль через діалогове вікно
                //запитуємо новий пароль у користувача перший раз
                string newPass = Microsoft.VisualBasic.Interaction.InputBox("Введіть новий пароль:", "Зміна пароля", "");

                //працюємо далі лише якщо користувач не залишив поле порожнім і не натиснув "Скасувати"
                if (!string.IsNullOrWhiteSpace(newPass))
                {
                    //зчитуємо актуальні дані з бази, щоб знайти поточний пароль користувача
                    var json = File.ReadAllText(filePath);
                    var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                    var currentUser = users.FirstOrDefault(u => u.Email == email);

                    //хешуємо введений пароль для першої перевірки
                    string newHash = hashPasswordMD5(newPass);

                    //використовуємо цикл whil, він буде крутитися доти, доки новий пароль збігається зі старим із бази
                    while (currentUser.Password == newHash)
                    {
                        //виводимо попередження про те, що пароль має бути новим
                        MessageBox.Show("Паролі не можуть збігатися з попереднім, створіть новий", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        //запитуємо пароль знову всередині циклу
                        newPass = Microsoft.VisualBasic.Interaction.InputBox("Введіть інший новий пароль:", "Зміна пароля", "");

                        //якщо користувач передумав і закрив вікно (пусто), виходимо з методу, щоб не зациклитись
                        if (string.IsNullOrWhiteSpace(newPass)) return;

                        //оновлюємо хеш для наступної ітерації перевірки в циклі
                        newHash = hashPasswordMD5(newPass);
                    }

                    //якщо ми вийшли з циклу, значить пароль нарешті унікальний — оновлюємо його в JSON файлі
                    UpdatePasswordInJson(email, newPass);
                }
            }
            else if (!string.IsNullOrEmpty(userCode))
            {
                //якщо введено неправильний код, повідомляємо користувача про помилку
                MessageBox.Show("Невірний код! Перевірте пошту ще раз.");
            }
        }

        private void UpdatePasswordInJson(string email, string newPassword)
        {
            string filePath = "storage.json";
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

                int index = users.FindIndex(u => u.Email == email); //шукаємо індекс користувача в списку за поштою
                if (index != -1)
                {
                    User updatedUser = users[index]; //беремо структуру користувача
                    updatedUser.Password = hashPasswordMD5(newPassword); //записуємо новий захешований пароль
                    users[index] = updatedUser; //кладемо оновлені дані назад у список

                    //зберігаємо оновлений список користувачів у файл JSON
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
                    MessageBox.Show("Пароль успішно змінено! Тепер ви можете увійти.");
                }
                else MessageBox.Show("Користувача з такою поштою не знайдено.");
            }
        }

        async Task MySendEmail(string subject, string body, string file, string toEmail)
        {
            //дані для підключення до сервера ukr.net
            string password = "aumJIbpaRwg9zPYr"; //пароль додатка
            string smtpServer = "smtp.ukr.net"; //адреса сервера
            int port = 2525; //порт для SMTP
            string from = "dominikavo@ukr.net"; //адреса відправника

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Адміністрація", from)); //ім'я відправника
            emailMessage.To.Add(new MailboxAddress("Користувач", toEmail)); //адреса отримувача
            emailMessage.Subject = subject; //тема листа

            var bodyHtml = new TextPart("html") { Text = body }; //створюємо частину листа з HTML текстом
            var multipart = new Multipart("mixed") { bodyHtml }; //створюємо контейнер для тексту та файлів

            //якщо передано шлях до файлу і він існує - додаємо його як вкладення
            if (!string.IsNullOrEmpty(file) && File.Exists(file))
            {
                var attachment = new MimePart("image", "webp")
                {
                    Content = new MimeContent(File.OpenRead(file), ContentEncoding.Default),
                    FileName = Path.GetFileName(file)
                };
                multipart.Add(attachment);
            }

            emailMessage.Body = multipart; //встановлюємо вміст листа

            using var client = new SmtpClient(); //використовуємо MailKit для відправки
            try
            {
                await client.ConnectAsync(smtpServer, port, true); //підключаємось до сервера через SSL
                await client.AuthenticateAsync(from, password); //авторизуємось за допомогою логіна і пароля додатка
                await client.SendAsync(emailMessage); //надсилаємо повідомлення
                await client.DisconnectAsync(true); //закриваємо з'єднання
                MessageBox.Show("Код надіслано на вашу пошту!"); //підтверджуємо успішну відправку
            }
            catch (Exception ex) { MessageBox.Show($"Помилка відправки: {ex.Message}"); }
        }

        private void btnToRee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVissiblePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar; //перемикаю видимість пароля, якщо він був захищений, то роблю його видимим, і навпаки
        }
    }
}