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
    /// Логика взаимодействия для addTrade.xaml
    /// </summary>
    public partial class addTrade : Window, System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
        private Trade _Sub = new Trade();
        public Trade Sub
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
    
        public addTrade(Trade tr = null)
        {
            InitializeComponent();
            id_clientTextBox.ItemsSource = MainWindow.bd.Client.ToList();
            id_workerTextBox.ItemsSource = MainWindow.bd.Worker.ToList();
            if (tr != null)
            {
                changed = true;
                Sub = tr;
            }
            grid1.DataContext = Sub;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource tradeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tradeViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // tradeViewSource.Source = [универсальный источник данных]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!changed)
                {
                    MainWindow.bd.Trade.Add(Sub);
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
