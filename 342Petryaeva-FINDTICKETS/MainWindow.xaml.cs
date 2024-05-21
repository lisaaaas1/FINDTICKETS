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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _342Petryaeva_FINDTICKETS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        testEntities entities = new testEntities();
        Users user = new Users();
        public MainWindow(Users _user)
        {
            InitializeComponent();
            try 
            { 
                user = user;
                GridFlight.ItemsSource = entities.Flight.ToList();
                cmbTo.ItemsSource = entities.Country.ToList();
                cmbFrom.ItemsSource = entities.Country.ToList();
            }
            catch 
            {
                MessageBox.Show("Что-то пошло не так. Мы исправим все в ближайшее время");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Country currentCountry = cmbFrom.SelectedValue as Country;

            if (currentCountry != null)
            {
                GridFlight.ItemsSource = null;
                GridFlight.ItemsSource = entities.Flight.Where(x => x.ID_Departure_Airoport == currentCountry.id).ToList();

            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Country currentCountry = cmbTo.SelectedValue as Country;

            if (currentCountry != null)
            {
                GridFlight.ItemsSource = null;
                GridFlight.ItemsSource = entities.Flight.Where(x => x.ID_Arrival_Airoport == currentCountry.id).ToList();
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking(user);
            booking.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            Ticket_Type tickettype = cmbTicketType.SelectedValue as Ticket_Type;
            if (tickettype != null)
            {
                GridFlight.ItemsSource = null;
                GridFlight.ItemsSource = entities.Flight.Where(x => x.ID_TicketType == tickettype.id).ToList();
                //GridFlight.ItemsSource = entities.Flight.Where(x => x.ID_Departure_Airoport == currentCountry.id).ToList();
            }
        }

    }
}
