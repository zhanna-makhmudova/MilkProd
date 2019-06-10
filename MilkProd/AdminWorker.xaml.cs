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
    /// Логика взаимодействия для AdminWorker.xaml
    /// </summary>
    public partial class AdminWorker : Window
    {
        public AdminWorker()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource workerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("workerViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            workerViewSource.Source = MainWindow.bd.Worker.ToList();
            // var role = MainWindow.bd.TypeWorker.FirstOrDefault
            if (MainWindow.role != 1)
            {
                edBtn.Visibility = Visibility.Collapsed;
                addBtn.Visibility = Visibility.Collapsed;
                delBtn.Visibility = Visibility.Collapsed;
                workerDataGrid.Columns[4].Visibility = Visibility.Collapsed;
                workerDataGrid.Columns[5].Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addWorker add = new addWorker();
            add.Closed += (asd, dsa) => { Show(); Refresh(); };
            Hide();
            add.Show();
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (workerDataGrid.SelectedItem != null)
            {
                addWorker add = new addWorker(workerDataGrid.SelectedItem as Worker);
                add.Closed += (asd, dsa) => { Show(); Refresh(); };
                Hide();
                add.Show();
            }
            else
                MessageBox.Show("Выберите сотрудника для внесения изменений");
        }
        void Refresh()
        {
            workerDataGrid.DataContext = null;
            workerDataGrid.DataContext = MainWindow.bd.Worker.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (workerDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Не выбран элемент для удаления!");
                return;
            }
            var Subject = workerDataGrid.SelectedItem as Worker;
            if (MessageBox.Show("Вы уверены что хотите удалить данный элемент?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MainWindow.bd.Worker.Remove(Subject);
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
