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
    /// Логика взаимодействия для AdminFarm.xaml
    /// </summary>
    public partial class AdminFarm : Window
    {
        public AdminFarm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource farmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("farmViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            farmViewSource.Source = MainWindow.bd.Farm.ToList();
            if (MainWindow.role != 1)
            {
                delBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addFarm add = new addFarm();
            add.Closed += (asd, dsa) => { Show(); Refresh(); };
            Hide();
            add.Show();
        }
        void Refresh()
        {
            farmDataGrid.DataContext = null;
            farmDataGrid.DataContext = MainWindow.bd.Farm.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (farmDataGrid.SelectedItem != null)
            {
                addFarm add = new addFarm(farmDataGrid.SelectedItem as Farm);
                add.Closed += (asd, dsa) => { Show(); Refresh(); };
                Hide();
                add.Show();
            }
            else
                MessageBox.Show("Выберите ферму для внесения изменений");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (farmDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для удаления!");
                return;
            }
            var Subject = farmDataGrid.SelectedItem as Farm;
            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.bd.Farm.Remove(Subject);
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
