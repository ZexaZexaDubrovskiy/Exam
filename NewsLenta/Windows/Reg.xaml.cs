using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewsLenta.Windows
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg(Base.NewsLentaEntities DataBase)
        {
            InitializeComponent();
            this.DataBase = DataBase;
        }
        private Base.NewsLentaEntities DataBase;


        private void addNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Base.Users User = new Base.Users();
            var hasNumber = new Regex(@"[0-9]");
            var hasUpperCase = new Regex(@"[A-Z]");
            var hasCount= new Regex(@".{8,}");
            var hasSpec = new Regex(@"[!@$)(]");
            
            var validate = hasNumber.IsMatch(userPassword.Text) &&
                hasUpperCase.IsMatch(userPassword.Text) &&
                hasCount.IsMatch(userPassword.Text) &&
                hasSpec.IsMatch(userPassword.Text);

            if (validate)
            {
                User.login = userLogin.Text;
                User.password = userPassword.Text;
                DataBase.Users.Add(User);
                DataBase.SaveChanges();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            } else MessageBox.Show("Проверьте правильность ввода данных");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Close();
        }
    }
}
