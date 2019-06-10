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

namespace MilkProd
{
    /// <summary>
    /// Логика взаимодействия для addWorker.xaml
    /// </summary>
    public partial class addWorker : Window, System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
        private Worker _Sub = new Worker();
        public Worker Sub
        {
            get => _Sub;
            set
            {
                if (_Sub != value)
                {
                    _Sub = value;
                    OnPropertyChanged("Sub");
                }
            }
        }
        bool changed = false;
        public addWorker(Worker wr = null)
        {
            InitializeComponent();
            id_typeTextBox.ItemsSource = MainWindow.bd.TypeWorker.ToList();
            if (wr != null)
            {
                changed = true;
                Sub = wr;
            }
            grid1.DataContext = Sub;
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource workerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("workerViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // workerViewSource.Source = [универсальный источник данных]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!changed)
                {
                    MainWindow.bd.Worker.Add(Sub);
                }
                MainWindow.bd.SaveChanges();
                Close();
            }
            catch
            {
                MessageBox.Show("Введены неверные данные!");
            }
        }
    }
}
