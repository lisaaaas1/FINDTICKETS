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
    /// Логика взаимодействия для AddFlight.xaml
    /// </summary>
    public partial class AddFlight : Window
    {
        testEntities entities = new testEntities();
        public AddFlight()
        {
            InitializeComponent();

            cmbFrom.ItemsSource = entities.Country.ToList();
            cmbTo.ItemsSource = entities.Country.ToList();
            cmbTicketType.ItemsSource = entities.Ticket_Type.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Flight flight = new Flight();
                flight.ID_Departure_Airoport = (cmbFrom.SelectedItem as Country).id;
                flight.ID_Arrival_Airoport = (cmbTo.SelectedItem as Country).id;
                flight.num_of_seats = Convert.ToInt32(txtSeats.Text);
                flight.time_departure = Convert.ToDateTime(dpDeparture.Text);
                flight.ID_TicketType = (cmbTicketType.SelectedItem as Ticket_Type).id;

                entities.Flight.Add(flight);
                entities.SaveChanges();
                MessageBox.Show("все ок");

                SuccesfullyAddFlight succesfully = new SuccesfullyAddFlight();
                succesfully.Show();
                this.Close();
            }

            catch
            {
                MessageBox.Show("что-то пошло не так. Проверьте правильность введенных данных");
            }
        }
    }
}
