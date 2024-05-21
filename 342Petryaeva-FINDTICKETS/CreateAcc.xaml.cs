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
    /// Логика взаимодействия для CreateAcc.xaml
    /// </summary>
    public partial class CreateAcc : Window
    {
        testEntities entities = new testEntities();
        
        public CreateAcc()

        {
            InitializeComponent();

            cmbBenefits.ItemsSource = entities.Benefit.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show((cmbBenefits.SelectedItem as Benefit).id.ToString());

            try
            {
                Users user = new Users();                                                           
                user.name = txtLog.Text;                                                            
                user.email = txtEmail.Text;
                user.password = txtPassword.Text;
                user.ID_Role = 1;                                                                   
                user.ID_Benefit = (cmbBenefits.SelectedItem as Benefit).id;         
                                                                                        
                entities.Users.Add(user);                                                           
                entities.SaveChanges();                                                         
                                                                                                      
                MainWindow mainWindow = new MainWindow(user);                                           
                mainWindow.Show();
                this.Close();
            }

            catch
            {
                MessageBox.Show("Что-то пошло не так. Проверьте правильность введенных данных");
            }

        }
    }
}
