﻿using Microsoft.EntityFrameworkCore;
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
            DataGridTest.ItemsSource = SingleTon.DB.Users.ToArray();  //мб ToList
        }

        private void CreareButton_Click(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow();
            if(newUserWindow.ShowDialog() == DialogResult.OK)
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
    }
}
