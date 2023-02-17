using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using jidkiyApp.Models;

namespace jidkiyApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ShishkaDB2Entities DB = new ShishkaDB2Entities();
        public static User LoggedUser;
    }
}
