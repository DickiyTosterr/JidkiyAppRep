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
using jidkiyApp.Models;
using jidkiyApp.Pages;

namespace jidkiyApp.Pages
{
   
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            if(App.LoggedUser.idRole == 1)
            {
                SPBtn.Visibility = Visibility.Collapsed;
            }
            if(App.LoggedUser.idRole == 2)
            {
                SPBtn.Visibility = Visibility.Visible;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(new User()));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = LVUser.SelectedItem as User;
            if(selectedUser == null)
            {
                MessageBox.Show("Выбери попуска");
                return;
            }
            NavigationService.Navigate(new AddPage(selectedUser));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delete = LVUser.SelectedItem as User;

            if(delete == null)
            {
                MessageBox.Show("Не выбран пользователь для удаления");
                return;
            }
            App.DB.User.Remove(delete);
            App.DB.SaveChanges();
            Refresh();
        }
        private void Refresh()
        {
            LVUser.ItemsSource = App.DB.User.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void GBBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DGBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }
    }
}
