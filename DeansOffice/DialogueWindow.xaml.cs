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

namespace DeansOffice
{
    /// <summary>
    /// Логика взаимодействия для DialogueWindow.xaml
    /// </summary>
    public partial class DialogueWindow : Window
    {
        MainWindow mainWindow;
        public DialogueWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Tak_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Delete();
            Close();
        }

        private void Nie_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
