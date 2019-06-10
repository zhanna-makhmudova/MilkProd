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
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class AdminMainMenu : Window
    {
        
        public AdminMainMenu()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminProduct menu = new AdminProduct();
            menu.Closed += (asd, dsa) => Show();
            Hide();
            menu.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminClients menu = new AdminClients();
            menu.Closed += (asd, dsa) => Show();
            Hide();
            menu.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdminWorker menu = new AdminWorker();
            menu.Closed += (asd, dsa) => Show();
            Hide();
            menu.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AdminTrade menu = new AdminTrade();
            menu.Closed += (asd, dsa) => Show();
            Hide();
            menu.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AdminType menu = new AdminType();
            menu.Closed += (asd, dsa) => Show();
            Hide();
            menu.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AdminFarm menu = new AdminFarm();
            menu.Closed += (asd, dsa) => Show();
            Hide();
            menu.Show();
        }
    }
}
