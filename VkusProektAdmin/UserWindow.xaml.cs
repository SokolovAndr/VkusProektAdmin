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
using VkusProektAdmin.Models;

namespace VkusProektAdmin
{

    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow();
            if (newUserWindow.ShowDialog() == true)
            {
                Users users = new()
                {
                    Login = newUserWindow.LoginTexBox.Text,
                    Password = newUserWindow.PasswordTextBox.Text,
                };
                SingleTon.DB.Users.Add(users);
                SingleTon.DB.SaveChanges();
            }
            DataGridTest.ItemsSource = null;
            LoadData();
        }

        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                SingleTon.DB.Update(DataGridTest.SelectedItem);
                SingleTon.DB.SaveChanges();
                MessageBox.Show("Успешно изменено!", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridTest.ItemsSource = null;
                LoadData();
            }
            else if (result == MessageBoxResult.No)
            {
                return;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                SingleTon.DB.Remove(DataGridTest.SelectedItem);
                SingleTon.DB.SaveChanges();
                MessageBox.Show("Успешно удалено!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridTest.ItemsSource = null;
                LoadData();
            }
            else if (result == MessageBoxResult.No)
            {
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DataGridTest.ItemsSource = SingleTon.DB.Users.ToArray();  
        }
    }
}
