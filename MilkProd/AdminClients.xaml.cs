﻿using System;
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

namespace MilkProd
{
    /// <summary>
    /// Логика взаимодействия для AdminClients.xaml
    /// </summary>
    public partial class AdminClients : Window
    {
        public AdminClients()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource clientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            MainGrid.DataContext = MainWindow.bd.Client.ToList();
            if (MainWindow.role != 1)
            {
                delBtn.Visibility = Visibility.Collapsed;
            }
        }
        void Refresh()
        {
            MainGrid.DataContext = null;
            MainGrid.DataContext = MainWindow.bd.Client.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addClient add = new addClient();
            add.Closed += (asd, dsa) => { Show(); Refresh(); };
            Hide();
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (clientDataGrid.SelectedItem != null)
            {
                addClient add = new addClient(clientDataGrid.SelectedItem as Client);
                add.Closed += (asd, dsa) => { Show(); Refresh(); };
                Hide();
                add.Show();
            }
            else
                MessageBox.Show("Выберите клиента для внесения изменений");
           
        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (clientDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для удаления!");
                return;
            }
            var Subject = clientDataGrid.SelectedItem as Client;
            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.bd.Client.Remove(Subject);
                    MainWindow.bd.SaveChanges();
                    
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка удаления!");
                }
            }
            Refresh();
        }
       
    }
}
