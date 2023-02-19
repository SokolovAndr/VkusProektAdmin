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
using VkusProektAdmin.Models;

namespace VkusProektAdmin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var user = SingleTon.DB.Users.Where(u => u.Login == LoginTextBox.Text && u.Password == PasswordTextBox.Password).FirstOrDefault();
        
            if(user == null)
            {
                MessageBox.Show("Пользователь не найден!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SingleTon.User = user;
            AdministrationWindow administrationWindow = new AdministrationWindow();

            LoginTextBox.Text = null;
            PasswordTextBox.Password = null;
            this.Close();
            administrationWindow.ShowDialog();
        }
    }
}
