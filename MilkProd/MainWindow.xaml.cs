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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MilkProd
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bdmilkprodEntities bd = new bdmilkprodEntities();
        public MainWindow()
        {
            InitializeComponent();
        }


        public static int role;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            role = 0;
            
            if (string.IsNullOrWhiteSpace(lgnTB.Text) || string.IsNullOrWhiteSpace(pswTB.Password))
            {
                MessageBox.Show("Введите все данные");
                return;
            }

            var AUser = bd.Worker.FirstOrDefault(x => x.login_worker == lgnTB.Text && x.password_worker == pswTB.Password);
            if (AUser != null)
            {
                if (AUser.id_type == 1)
                {
                    role = 1;
                }
                

                AdminMainMenu menu = new AdminMainMenu();
                menu.Closed += (asd, dsa) => Show();
                Hide();
                menu.Show();
            }
            else
                MessageBox.Show("Неверные данные");
            
        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
