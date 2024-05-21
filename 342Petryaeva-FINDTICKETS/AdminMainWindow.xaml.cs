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

namespace _342Petryaeva_FINDTICKETS
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        testEntities entities = new testEntities();
        public AdminMainWindow()
        {
            InitializeComponent();
            gridFlight.ItemsSource = entities.Flight.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddFlight addflight = new AddFlight();
            addflight.Show();
            this.Close();
        }
    

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
           DeleteFlight deleteflight = new DeleteFlight();
           deleteflight.Show();
           this.Close();
        }
    }
}
