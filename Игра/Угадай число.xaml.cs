using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Игра
{
    /// <summary>
    /// Логика взаимодействия для Угадай_число.xaml
    /// </summary>
    public partial class Угадай_число : Window
    {
        private int _targetNumber;
        private int _attempts;
        private int _maxAttempts;

        public Угадай_число(string Трудность)
        {
            InitializeComponent();
            SetDifficulty(Трудность);
            StartGame();
        }

        private void SetDifficulty(string Трудность)
        {
            switch (Трудность)
            {
                case "Легкий":
                    _targetNumber = new Random().Next(1, 11); 
                    _maxAttempts = 5;
                    break;
                case "Средний":
                    _targetNumber = new Random().Next(1, 51); 
                    _maxAttempts = 4;
                    break;
                case "Сложный":
                    _targetNumber = new Random().Next(1, 101); 
                    _maxAttempts = 3;
                    break;
            }
        }

        private void StartGame()
        {
            _attempts = 5;
            MessageTextBlock.Text = $"Угадайте число от 1 до {_targetNumber + 10}. У вас 3 попытки.";
            GuessTextBox.Clear();
            GuessTextBox.Focus();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(GuessTextBox.Text, out int guess))
            {
                _attempts++;
                if (guess == _targetNumber)
                {
                    MessageBox.Show($"ОГО, Поздравляю! Вы угадали число {_targetNumber} за {_attempts} попытки.");
                    RestartButton.Visibility = Visibility.Visible;
                    SubmitButton.IsEnabled = false;
                }
                else if (_attempts >= _maxAttempts)
                {
                    MessageBox.Show($"Вы исчерпали все попытки, вы лузер ХА ХА! Загаданное число было {_targetNumber}).");
                    RestartButton.Visibility = Visibility.Visible;
                    SubmitButton.IsEnabled = false;
                }
                else
                {
                    string подсказка = guess < _targetNumber ? "больше." : "меньше.";
                    MessageTextBlock.Text = $"Попробуйте снова! Загаданное число {подсказка}. У вас осталось {_maxAttempts - _attempts} попытки.";
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное число.");
            }

            GuessTextBox.Clear();
            GuessTextBox.Focus();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
            RestartButton.Visibility = Visibility.Collapsed;
            SubmitButton.IsEnabled = true;
        }
    }
}
