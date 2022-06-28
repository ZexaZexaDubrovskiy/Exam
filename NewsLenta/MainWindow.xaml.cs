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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsLenta
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

        private void newsPageButton_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(new Pages.NewsPage());
        }

        private void commentsPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kategoriesPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UsersPageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
