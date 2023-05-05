using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UchebPrackt326.Pages;

namespace UchebPrackt326
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MainPages());
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(App.WindowOpen == 0)
            {
                App.WindowOpen = 1;
                WindowAdminMod windowAdminMod = new WindowAdminMod();
                if (App.Admin == 1)
                {
                    App.Admin = 0;
                    MainFrame.NavigationService.Navigate(new MainPages());
                }
                else
                    
                windowAdminMod.Show();

            }
         
          
            
          
        }
    }
}
