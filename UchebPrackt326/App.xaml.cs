using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UchebPrackt326.Compnent;

namespace UchebPrackt326
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceDataBaseEntities db = new ServiceDataBaseEntities();
        public static int Admin = 0;
        public static int WindowOpen = 0;
    }
}
