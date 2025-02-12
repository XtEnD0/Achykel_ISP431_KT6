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
        public int imp = 0;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)

        {

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
                imp++;
                if (imp > 2)
                {
                    MessageBox.Show("Проверка на Шуникула пройдена успешно! доступ запрещен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoginButton.IsEnabled = false;
                    GuestButton.IsEnabled = false;
                }

            }
            else
            {
                if (Data.TradeEntities.GetContext().User.Any(d => d.UserLogin == LoginTB.Text &&
                d.UserPassword == PasswordPB.Password))
                {
                    var user = Data.TradeEntities.GetContext().User.Where(d => d.UserLogin == LoginTB.Text &&
                    d.UserPassword == PasswordPB.Password).FirstOrDefault();
                    
                    switch (user.Role.RoleName)
                    {
                        case "Администратор":
                            MessageBox.Show("Вы вошли как Администратор", "Успех!",MessageBoxButton.OK, MessageBoxImage.Information);
                            Classes.Manager.MainFrame.Navigate(new Pages.ListPage());
                            break;
                        case "Клиент":
                            MessageBox.Show("Вы вошли как Клиент", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                            Classes.Manager.MainFrame.Navigate(new Pages.ListPage());
                            break;
                        case "Менеджер":
                            MessageBox.Show("Вы вошли как Администратор", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                            Classes.Manager.MainFrame.Navigate(new Pages.ListPage());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный Логин или пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    imp++;
                    if (imp > 2)
                    {
                        MessageBox.Show("Проверка на Шуникула пройдена успешно! доступ запрещен!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                        LoginButton.IsEnabled = false;
                        GuestButton.IsEnabled = false;
                    }
                }
                
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ListPage());
        }
    }
}
