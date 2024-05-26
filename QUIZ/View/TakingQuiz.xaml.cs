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
    /// Logika interakcji dla klasy TakingQuiz.xaml
    /// </summary>
    public partial class TakingQuiz : Window
    {
        public TakingQuiz()
        {
            InitializeComponent();
        }

        private void Back_to_menu_click(object sender, RoutedEventArgs e)
        {
            
            CreatingQuiz objCreatingQuiz = new CreatingQuiz();
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            objCreatingQuiz.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

       
    }
}
