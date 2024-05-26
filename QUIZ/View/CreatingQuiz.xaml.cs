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

namespace QUIZ
{
    /// <summary>
    /// Logika interakcji dla klasy CreatingQuiz.xaml
    /// </summary>
    public partial class CreatingQuiz : Window
    {
        public CreatingQuiz()
        {
            InitializeComponent();
        }

       

        private void Back_to_menu_click(object sender, RoutedEventArgs e)
        {
            TakingQuiz objTakingQuiz = new TakingQuiz();
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            objTakingQuiz.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
    }
}
