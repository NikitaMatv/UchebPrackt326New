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
using System.Windows.Shapes;

namespace UchebPrackt326.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowAdminMod.xaml
    /// </summary>
    public partial class WindowAdminMod : Window
    {
        public WindowAdminMod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TbCode.Text == "0000")
            {
                App.Admin = 1;
                var window = Application.Current.MainWindow as MainWindow;
                if (window?.MainFrame.Content is MainPages menuPage)
                {
                    window?.MainFrame.Navigate(new MainPages());
                }
            }
            App.WindowOpen = 0;
            this.Close();


        }
    }
}
