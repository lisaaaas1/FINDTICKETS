using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class DeleteFlight : Window
    {
        private string connectionString = "data source=DESKTOP-8DH28R0\\SQLEXPRESS;initial catalog=test;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework";
        testEntities entities = new testEntities();
        public DeleteFlight()
        {
            InitializeComponent();

            cmbIdFlight.ItemsSource = entities.Flight.ToList();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (cmbIdFlight.SelectedValue != null)
            {
                Flight selectedFlight = (Flight)cmbIdFlight.SelectedItem; // Получаем выбранный рейс
                int selectedId = selectedFlight.id; // Получаем идентификатор выбранного рейса
                
                DeleteRow(selectedId);
            }
        }

        private void DeleteRow(int rowId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Flight WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", rowId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Строка успешно удалена.");
                        SuccesfullyDeleteFlight succesfully = new SuccesfullyDeleteFlight();
                        succesfully.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Строка не была найдена или не удалось удалить.");
                    }
                }
            }
        }
    }
}
