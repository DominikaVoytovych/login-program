using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace FormOptions
{
    public partial class TestForm : Form
    {
        // Налаштування теми
        bool isDarkMode = false;
        string configPath = "appsettings.json";

        // Логіка тесту
        private int currentQuestionIndex = 0;
        private int score = 0;

        private List<Question> questions = new List<Question>
        {
            new Question {
                Text = "Яка подія вважається початком Другої світової війни?",
                Answers = new[] { "Напад на Польщу", "Аншлюс Австрії", "Перл-Гарбор", "Пакт М-Р" },
                CorrectAnswerIndex = 0
            },
            new Question {
                Text = "Як називався німецький план нападу на СРСР?",
                Answers = new[] { "Вайс", "Барбаросса", "Оверлорд", "Гельб" },
                CorrectAnswerIndex = 1
            },
            new Question {
                Text = "В якому році відбулася висадка в Нормандії?",
                Answers = new[] { "1941", "1943", "1944", "1945" },
                CorrectAnswerIndex = 2
            },
            new Question {
                Text = "Що намалювали вандали на електричці?",
                Answers = new[] { "Свастику", "Смайлик", "ЦОЙ ЖИВ", "Інше" },
                CorrectAnswerIndex = 0
            }
        };

        public TestForm()
        {
            InitializeComponent();

            // Підписуємо всі радіобатони на подію активації кнопки
            rdBtnAnswer1.CheckedChanged += AnyRadioButton_CheckedChanged;
            rdBtnAnswer2.CheckedChanged += AnyRadioButton_CheckedChanged;
            rdBtnAnswer3.CheckedChanged += AnyRadioButton_CheckedChanged;
            rdBtnAnswer4.CheckedChanged += AnyRadioButton_CheckedChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Закинемо усі питання у json файл.
            //Як questions перетворити у json?
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(questions,
                Newtonsoft.Json.Formatting.Indented); // включаючи дочірні елементи
            
            File.WriteAllText("questions.json", str);

            LoadSettings();
            ApplyTheme();
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var q = questions[currentQuestionIndex];

                lbQuestion.Text = q.Text;
                rdBtnAnswer1.Text = q.Answers[0];
                rdBtnAnswer2.Text = q.Answers[1];
                rdBtnAnswer3.Text = q.Answers[2];
                rdBtnAnswer4.Text = q.Answers[3];

                // Скидаємо вибір
                rdBtnAnswer1.Checked = false;
                rdBtnAnswer2.Checked = false;
                rdBtnAnswer3.Checked = false;
                rdBtnAnswer4.Checked = false;

                // РОБИМО КНОПКУ НЕАКТИВНОЮ
                btnCont.Enabled = false;
            }
            else
            {
                MessageBox.Show($"Тест закінчено! Правильних відповідей: {score} з {questions.Count}", "Результат");
                currentQuestionIndex = 0;
                score = 0;
                DisplayQuestion();
            }
        }

        // Подія: якщо будь-яка кнопка обрана — активуємо "Далі"
        private void AnyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                btnCont.Enabled = true;
            }
        }

        private void btnCont_Click(object sender, EventArgs e)
        {
            // визначаю, яка відповідь вибрана
            RadioButton[] answers = { rdBtnAnswer1, rdBtnAnswer2, rdBtnAnswer3, rdBtnAnswer4 };
            int selectedIndex = -1;
            // проходимо по радіокнопках і шукаємо ту, яка вибрана
            for (int i = 0; i < answers.Length; i++)
            {
                // якщо ця кнопка вибрана, запам'ятовуємо її індекс і виходимо з циклу
                if (answers[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }
            // перевіряємо, чи вибрана відповідь правильна 
            if (selectedIndex == questions[currentQuestionIndex].CorrectAnswerIndex)
            {
                score++;
            }

            currentQuestionIndex++;
            DisplayQuestion();
        }

        // --- Теми та налаштування ---
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