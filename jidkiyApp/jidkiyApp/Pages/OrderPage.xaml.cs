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
    
    public partial class OrderPage : Page
    {
        Order contextOrder = new Order() { User = App.LoggedUser, Date = DateTime.Now };
        List<OrderProduct> orderProducts = new List<OrderProduct>();
        public OrderPage()
        {
            InitializeComponent();
            CBProduct.ItemsSource = App.DB.Product.ToList();
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CBProduct.SelectedItem == null)
            {
                MessageBox.Show("Не выбран продукт");
                return;
            }
            orderProducts.Add(new OrderProduct() { Order = contextOrder, Product = CBProduct.SelectedItem as Product });
            Refresh();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delete = DGProduct.SelectedItem as OrderProduct;

            if(delete == null)
            {
                MessageBox.Show("Выберите продукт");
                return;
            }
            orderProducts.Remove(delete);
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            DGProduct.ItemsSource = orderProducts.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(orderProducts.Count == 0)
            {
                MessageBox.Show("Ничего нет");
                return;
            }
            App.DB.Order.Add(contextOrder);
            App.DB.OrderProduct.AddRange(orderProducts);
            App.DB.SaveChanges();
            MessageBox.Show("Ваш заказ успешно сохранен");
        }

        private void DelGoodBtn_Click(object sender, RoutedEventArgs e)
        {
            var deleteGoods = CBProduct.SelectedItem as Product;

            if(deleteGoods == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            App.DB.Product.Remove(deleteGoods);
            App.DB.SaveChanges();
            Refresh();
        }
    }
}
