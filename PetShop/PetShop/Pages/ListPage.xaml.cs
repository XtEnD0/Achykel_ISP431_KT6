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
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            MainListView.ItemsSource = Data.TradeEntities.GetContext().Product.ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Manager.MainFrame.CanGoBack)
            {
                Classes.Manager.MainFrame.GoBack();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddPage());
        }

        private void editbut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Приносим свои извинения, но данная функция приватизирована Шуникулом и только он имеет к ней доступ");
        }

        private void deletebut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Приносим свои извинения, но данная функция приватизирована Шуникулом и только он имеет к ней доступ");
        }
    }
}
