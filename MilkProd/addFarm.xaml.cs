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
    /// Логика взаимодействия для addFarm.xaml
    /// </summary>
    public partial class addFarm : Window, System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
        private Farm _Sub = new Farm();
        public Farm Sub
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
        public addFarm(Farm fr = null)
        {
            InitializeComponent();
            if (fr != null)
            {
                changed = true;
                Sub = fr;
            }
            grid1.DataContext = Sub;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource farmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("farmViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
             farmViewSource.Source = MainWindow.bd.Farm.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!changed)
                {
                    MainWindow.bd.Farm.Add(Sub);
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
