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
    /// Логика взаимодействия для addType.xaml
    /// </summary>
    public partial class addType : Window, System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
        private TypeProduct _Sub = new TypeProduct();
        public TypeProduct Sub
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
    
        public addType(TypeProduct tp = null)
        {
            InitializeComponent();
            if (tp != null)
            {
                changed = true;
                Sub = tp;
            }
            grid1.DataContext = Sub;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource typeProductViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeProductViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // typeProductViewSource.Source = [универсальный источник данных]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!changed)
                {
                    MainWindow.bd.TypeProduct.Add(Sub);
                }
                MainWindow.bd.SaveChanges();
                Close();
            }
            catch
            {
                MessageBox.Show("Введены неверные данные");
            }
        }
    }
}
