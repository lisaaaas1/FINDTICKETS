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
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        testEntities entities = new testEntities();
        Users user = new Users();
        public Booking(Users _user)
        {
            InitializeComponent();

            cmbTicketType.ItemsSource = entities.Ticket_Type.ToList();
            cmbIdFlight.ItemsSource = entities.Flight.ToList();

            user = _user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bookings booking = new Bookings();
                booking.ID_User = user.id;
                booking.ID_Ticket_Type = (cmbTicketType.SelectedItem as Ticket_Type).id;
                booking.ID_Flight = (cmbIdFlight.SelectedItem as Flight).id;


                entities.Users.Add(user);
                entities.SaveChanges();
                MessageBox.Show("все ок");

                SuccesfullyBooking succesfully = new SuccesfullyBooking();
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
