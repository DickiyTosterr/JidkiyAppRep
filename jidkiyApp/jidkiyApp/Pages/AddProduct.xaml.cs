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

namespace jidkiyApp.Pages
{
    
    public partial class AddProduct : Page
    {
        Product contextProduct;
        public AddProduct(Product product)
        {
            InitializeComponent();
            contextProduct = product;
            DataContext = contextProduct;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = "";

            if (string.IsNullOrWhiteSpace(contextProduct.Name) == true)
                error += "нет имени\n";
            if (contextProduct.Price == 0 || contextProduct.Price < 0)
                error += "нет цены\n";
            if(string.IsNullOrWhiteSpace(error) == false)
            {
                MessageBox.Show(error);
                return;
            }
            App.DB.Product.Add(contextProduct);
            App.DB.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
