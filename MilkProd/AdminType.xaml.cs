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
    /// Логика взаимодействия для AdminType.xaml
    /// </summary>
    public partial class AdminType : Window
    {
        public AdminType()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource typeProductViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeProductViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            typeProductViewSource.Source = MainWindow.bd.TypeProduct.ToList();
            if (MainWindow.role != 1)
            {
                delBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addType add = new addType();
            add.Closed += (asd, dsa) => { Show(); Refresh(); };
            Hide();
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (typeProductDataGrid.SelectedItem != null)
            {
                addType add = new addType(typeProductDataGrid.SelectedItem as TypeProduct);
                add.Closed += (asd, dsa) => { Show(); Refresh(); };
                Hide();
                add.Show();
            }
            else
                MessageBox.Show("Выберите тип товара для внесения изменений");
        }
        void Refresh()
        {
            typeProductDataGrid.DataContext = null;
            typeProductDataGrid.DataContext = MainWindow.bd.TypeProduct.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (typeProductDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для удаления!");
                return;
            }
            var Subject = typeProductDataGrid.SelectedItem as TypeProduct;
            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.bd.TypeProduct.Remove(Subject);
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
