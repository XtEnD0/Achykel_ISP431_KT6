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

namespace PetShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)

        {
            int i = new int();
            StringBuilder err = new StringBuilder();

            if (String.IsNullOrEmpty(LoginTB.Text))
            {
                err.AppendLine("Введите Логин");
            }
            if (String.IsNullOrEmpty(PasswordPB.Password))
            {
                err.AppendLine("Введите пароль");
            }
            if (err.Length > 0)
            {
                MessageBox.Show(err.ToString(), "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                while (i <50)
                {
                    err.Append("11101101011000011010110011001011010001101010011000110");
                    i++;
                }
                MessageBox.Show(err.ToString());
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ListPage());
        }
    }
}
