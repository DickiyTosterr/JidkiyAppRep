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
    
    public partial class AddPage : Page
    {
        User contextUser;


        public AddPage(User user)
        {
            InitializeComponent();
            CBRole.ItemsSource = App.DB.Role.ToList();
            CBGen.ItemsSource = App.DB.Gender.ToList();
            
            contextUser = user;
            DataContext = contextUser;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = "";
            var selectedRole = CBRole.SelectedItem as Role;
            var selectedGender = CBGen.SelectedItem as Gender;

            if (string.IsNullOrWhiteSpace(contextUser.Name) == true)
                error += "press Name\n";
            if (selectedRole == null)
                error += "press Role\n";
            if (selectedGender == null)
                error += "press Gender\n";
            if (string.IsNullOrWhiteSpace(contextUser.Login) == true)
                error += "press Login\n";
            if (string.IsNullOrWhiteSpace(contextUser.Password) == true)
                error += "press Password\n";
            if(string.IsNullOrWhiteSpace(error) == false)
            {
                MessageBox.Show(error);
                return;
            }
            if(contextUser.id == 0)
            {
                App.DB.User.Add(contextUser);
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }

        private void GBButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
