using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using VkusProektAdmin.Models;

namespace VkusProektAdmin
{

    public partial class AdministrationWindow : Window
    {
        public AdministrationWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            //DataGridTest.ItemsSource = SingleTon.DB.Users.ToArray();  //мб ToList
            DataGridVkusProekt.ItemsSource = SingleTon.DBvkus.Orders.ToArray();
        }

        private void RedactButton1_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SingleTon.DBvkus.Update(DataGridVkusProekt.SelectedItem);
                    SingleTon.DBvkus.SaveChanges();
                    MessageBox.Show("Успешно изменено!", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
                    DataGridVkusProekt.ItemsSource = null;
                    LoadData();
                }
                else if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
            catch  
            {
                MessageBox.Show("Вы ничего не выбрали!", "Изменение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    SingleTon.DBvkus.Remove(DataGridVkusProekt.SelectedItem);
                    SingleTon.DBvkus.SaveChanges();
                    MessageBox.Show("Успешно удалено!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DataGridVkusProekt.ItemsSource = null;
                    LoadData();
                }
                else if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Вы ничего не выбрали!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }      

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            if (newOrderWindow.ShowDialog() == true)
            {
                Order order = new()
                {
                    Name = newOrderWindow.NameTextBox.Text,
                    Surname = newOrderWindow.SurnameTextBox.Text,
                    Adress = newOrderWindow.AdressTextBox.Text,
                    Email = newOrderWindow.EmailTextBox.Text,
                    Phone = newOrderWindow.PhoneTextBox.Text,
                    OrderTime = DateTime.Now,
                };
                SingleTon.DBvkus.Orders.Add(order);
                SingleTon.DBvkus.SaveChanges();
            }
            DataGridVkusProekt.ItemsSource = null;
            LoadData();
        }

        private void ButtonDisplayUsers_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.ShowDialog();
        }
    }
}
