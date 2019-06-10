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

namespace MilkProd
{
    /// <summary>
    /// Логика взаимодействия для AdminProduct.xaml
    /// </summary>
    public partial class AdminProduct : Window
    {
        public AdminProduct()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            productViewSource.Source = MainWindow.bd.Product.ToList();
            if (MainWindow.role != 1)
            {
                delBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addProduct add = new addProduct();
            add.Closed += (asd, dsa) => { Show(); Refresh(); };
            Hide();
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null)
            {
                addProduct add = new addProduct(productDataGrid.SelectedItem as Product);
                add.Closed += (asd, dsa) => { Show(); Refresh(); };
                Hide();
                add.Show();
            }
            else
                MessageBox.Show("Выберите продукт для внесения изменений");
        }
        void Refresh()
        {
            productDataGrid.DataContext = null;
            productDataGrid.DataContext = MainWindow.bd.Product.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для удаления!");
                return;
            }
            var Subject = productDataGrid.SelectedItem as Product;
            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.bd.Product.Remove(Subject);
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
