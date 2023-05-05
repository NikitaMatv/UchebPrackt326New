using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddClientInServPages.xaml
    /// </summary>
    public partial class AddClientInServPages : Page
    {
        Service contextClientServive;
        public AddClientInServPages(Service clientService)
        {
            InitializeComponent();
            contextClientServive = clientService;
            DataContext = contextClientServive;
            TbDiscInPr.Text = $" {contextClientServive.Discount * 100}%";
            TbInMinuts.Text = $" {contextClientServive.DurationInSeconds / 60} минут";
            CbClient.ItemsSource = App.db.Client.ToList();
            TbTimes.Text = DateTime.Now.ToString("t");
            DbStart.Text = DateTime.Now.ToString();
        }

        private void BtAddImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextClientServive.MainImage = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextClientServive;
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string times = DbStart.Text + " " + TbTimes.Text;
            if (CbClient.SelectedItem != null && DbStart.SelectedDate != null && DateTime.Parse(times) > DateTime.Now + TimeSpan.FromMinutes(10))
            {
               
          
                ClientService clientService1 = new ClientService();
                clientService1.ServiceID = contextClientServive.ID;
                clientService1.ClientID = (CbClient.SelectedItem as Client).ID;
                clientService1.StartTime =  DateTime.Parse(times);
                App.db.ClientService.Add(clientService1);

                App.db.SaveChanges();
                NavigationService.Navigate(new MainPages());
            }
            else
            {
                MessageBox.Show("Выберите дату и клиента");
                return;
            }
            }
            catch
            {
                MessageBox.Show("Дата не коректна");
            }
        }

        private void TbPhone_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[A-zА-я]") == false)
            {
                e.Handled = true;
            }
        }
        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }

        private void TbTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbInMinuts.Text = $"{contextClientServive.DurationInSeconds / 60} минут";
        }

        private void TbDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbDiscInPr.Text = $" {contextClientServive.Discount * 100}%";
        }

        private void TbTimes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9:]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
