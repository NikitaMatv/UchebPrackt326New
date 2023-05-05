using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для EditServPages.xaml
    /// </summary>
    public partial class EditServPages : Page
    {
        Service contextService;
        public EditServPages(Service service)
        {
            InitializeComponent();
            contextService = service;
            DataContext = contextService;
            Update();
            contextService.Discount *= 100; 
            contextService.DurationInSeconds /= 60;
            if(contextService.ID == 0)
            {
                SpDopPhoto.Visibility = Visibility.Collapsed;
                SpButtonForLvDopPhoto.Visibility = Visibility.Collapsed;
                TbId.Visibility = Visibility.Collapsed;
            }
            TbDiscount.Text = contextService.Discount.ToString();
        }

        private void BtAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                contextService.MainImage = File.ReadAllBytes(openFileDialog.FileName);
                DataContext = null;
                DataContext = contextService;
            }
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            contextService.Discount /= 100;
            contextService.DurationInSeconds *= 60;
            string error = "";
            if (TbTitle.Text.Length == 0 )
            {
                error += "Заполните название услуги";
            }
            if (TbDiscount.Text.Length == 0)
            {
                error += "Заполните скидку услуги";
            }
            if (TbTime.Text.Length == 0 || int.Parse(contextService.DurationInSeconds.ToString()) > 14400)
            {
                error += "Заполните вреия услуги в секундах (Не болие 4ч)";
            }
            if (TbCost.Text.Length == 0)
            {
                error += "Заполните цену услуги";
            }
            if (ImMainImage == null)
            {
                error += "Загрузите картинку";
            }
            if (error != "")
            {
                MessageBox.Show($"{error}");
                return;
            }
          
            if (contextService.ID == 0)
            {
                if(App.db.Service.FirstOrDefault(x => x.Title == contextService.Title) != null)
                {
                    MessageBox.Show($"Заполните уникально название");
                }
                App.db.Service.Add(contextService);
            }
            App.db.SaveChanges();
            NavigationService.Navigate(new MainPages());
        
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
            contextService.Discount /= 100;
            contextService.DurationInSeconds *= 60;
            NavigationService.Navigate(new MainPages());
        }

     
   

        private void BtRught_Click(object sender, RoutedEventArgs e)
        {
            numberPage++;
            if (LvDopPhoto.Items.Count < 4)
                numberPage--;
            Update();
        }

        private void BtLeft_Click(object sender, RoutedEventArgs e)
        {
            numberPage--;
            if (numberPage < 0)
                numberPage = 0;
            Update();
        }
        int numberPage = 0;
        int count = 4;
        private void Update()
        {
            IEnumerable<ServicePhoto> servicePhotoList = App.db.ServicePhoto.Where(x => x.ServiceID == contextService.ID);
            servicePhotoList = servicePhotoList.Skip(count * numberPage).Take(count);
            LvDopPhoto.ItemsSource = servicePhotoList;
        }
        private void BtSaveDopPhot_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {

                ServicePhoto servicePhoto = new ServicePhoto();
                servicePhoto.PhotoPath = File.ReadAllBytes(openFileDialog.FileName);
                servicePhoto.ServiceID = contextService.ID;
                App.db.ServicePhoto.Add(servicePhoto);
                App.db.SaveChanges();
                LvDopPhoto.ItemsSource = App.db.ServicePhoto.ToList();
            }
        }

        private void BrDellDopPhoto_Click(object sender, RoutedEventArgs e)
        {
            var Select = LvDopPhoto.SelectedItem as ServicePhoto;
            App.db.ServicePhoto.Remove(Select);
            App.db.SaveChanges();
            LvDopPhoto.ItemsSource = App.db.ServicePhoto.ToList();
        }

        private void TbDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9,]") == false)
            {
                e.Handled = true;
            }
           
          



        }

      
    }
}
