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

namespace jidkiyApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = TBLogin.Text;
            var password = TBPass.Text;

            var user = App.DB.User.FirstOrDefault(u => u.Login == login);
            if(user == null)
            {
                MessageBox.Show("Не тот логин");
                return;
            }
            if(user.Password != password)
            {
                MessageBox.Show("Не тот пароль");
                return;
            }
              
            App.LoggedUser = user;
            if(user.idRole == 2)
            {
                NavigationService.Navigate(new UserPage());
            }
            if(user.idRole == 1)
            {
                NavigationService.Navigate(new OrderPage());
            }
        }
    }
}
