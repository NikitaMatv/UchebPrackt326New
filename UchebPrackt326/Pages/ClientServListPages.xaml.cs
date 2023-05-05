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
using UchebPrackt326.Compnent;

namespace UchebPrackt326.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientServListPages.xaml
    /// </summary>
    public partial class ClientServListPages : Page
    {
        IEnumerable<ClientService> filterProduct = App.db.ClientService.ToList();
        public ClientServListPages()
        {
            InitializeComponent();
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
         
            Update();
            TbPages.Text = $" {App.db.ClientService.Where(x => x.StartTime > DateTime.Now).Count()} из {App.db.ClientService.Count()} ";
        }

        private void BtServList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            DateTime dateTime = DateTime.Now.AddHours(23);
            IEnumerable<ClientService> products = App.db.ClientService.Where(x => x.StartTime < dateTime && x.StartTime > DateTime.Now).ToList();

            if (TbSelect.Text.Length > 0)
            {
                products = products.Where(x => x.Service.Title.ToLower().StartsWith(TbSelect.Text.ToLower()) || x.Service.Description.ToLower().StartsWith(TbSelect.Text.ToLower()));
            }
            LvSecv.ItemsSource = products.ToList();



        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second

            Update();

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
