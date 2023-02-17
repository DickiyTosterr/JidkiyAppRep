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
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            CBRole.ItemsSource = App.DB.Role.ToList();
        }

        private void GBBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var filter = App.DB.User.ToList();
            var role = CBRole.SelectedItem as Role;

            if (string.IsNullOrWhiteSpace(TBSearch.Text) == false)
                filter = filter.Where(x => x.Name.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            if (CBRole.SelectedItem != null)
                filter = filter.Where(r => r.idRole == role.id).ToList();
            DGUser.ItemsSource = filter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(new User()));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = DGUser.SelectedItem as User;

            if(selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            NavigationService.Navigate(new AddPage(selectedUser));
            
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delete = DGUser.SelectedItem as User;

            if(delete == null)
            {
                MessageBox.Show("Выберите для удаления");
                return;
            }
            App.DB.User.Remove(delete);
            App.DB.SaveChanges();
            Refresh();
        }
    }
}
