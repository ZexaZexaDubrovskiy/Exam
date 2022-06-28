using System.Linq;
using System.Windows;

namespace NewsLenta.Windows
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
            try
            {
                DataBase = new Base.NewsLentaEntities();
            }
            catch
            {
                MessageBox.Show("Не удалось подключчиться к базе данных!");
                Close();
            }
        }
        private Base.NewsLentaEntities DataBase;


        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            Base.Users users = DataBase.Users.SingleOrDefault(U => U.login == userLogin.Text && U.password == userPassword.Text);
            if (users != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else MessageBox.Show("Не существует такого аккаунта");
        }

        private void LogUp_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg(DataBase);
            reg.Show();
            Close();
        }
    }
}
