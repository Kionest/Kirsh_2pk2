using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Игра
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
            string difficulty = (DifficultyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            MessageBox.Show($"Вы выбрали уровень сложности: {difficulty}");
            
        }

        private void RulesButton_Click(object sender, RoutedEventArgs e)
        {
            Правила правила = new Правила();
            правила.Show();
        }
        private void AttensButton_Click(object sender, RoutedEventArgs e)
        {
            Предупреждение предупреждение = new Предупреждение();
            предупреждение.Show();
        }
        private void StartButton_Click1(object sender, RoutedEventArgs e)
        {
            string difficulty = (DifficultyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            Угадай_число gameWindow = new Угадай_число(difficulty);
            gameWindow.Show();
            this.Close(); 
        }
    }
}
    
