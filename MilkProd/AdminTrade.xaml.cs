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
using Excel = Microsoft.Office.Interop.Excel;

namespace MilkProd
{
    /// <summary>
    /// Логика взаимодействия для AdminTrade.xaml
    /// </summary>
    public partial class AdminTrade : Window
    {
        public AdminTrade()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource tradeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tradeViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            tradeViewSource.Source = MainWindow.bd.Trade.ToList();
            if (MainWindow.role != 1)
            {
                delBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addTrade add = new addTrade();
            add.Closed += (asd, dsa) => { Show(); Refresh(); };
            Hide();
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tradeDataGrid.SelectedItem != null)
            {
                addTrade add = new addTrade(tradeDataGrid.SelectedItem as Trade);
                add.Closed += (asd, dsa) => { Show(); Refresh(); };
                Hide();
                add.Show();
            }
            else
                MessageBox.Show("Выберите заказ для внесения изменений");
        }
        void Refresh()
        {
            tradeDataGrid.DataContext = null;
            tradeDataGrid.DataContext = MainWindow.bd.Trade.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (tradeDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для удаления!");
                return;
            }
            var Subject = tradeDataGrid.SelectedItem as Trade;
            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.bd.Trade.Remove(Subject);
                    MainWindow.bd.SaveChanges();

                }
                catch
                {
                    MessageBox.Show("Произошла ошибка удаления!");
                }
            }
            Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
