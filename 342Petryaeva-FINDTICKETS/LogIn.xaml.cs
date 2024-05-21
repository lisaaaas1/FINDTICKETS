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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    
    public partial class LogIn : Window
    {
        testEntities entities = new testEntities();
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = entities.Users.Where(x => x.email == txtEmail.Text && x.password == txtPassword.Text).FirstOrDefault();
                if (user is null)
                {
                    MessageBox.Show("Неверный логин / пароль");
                }
                else if (user.ID_Role == 1)
                {
                    MainWindow mainWindow = new MainWindow(user);
                    this.Close();
                    mainWindow.Show();
                }
                else if (user.ID_Role == 2)
                {
                    AdminMainWindow adminmainWindow = new AdminMainWindow();
                    this.Close();
                    adminmainWindow.Show();
                }
            }
            catch { MessageBox.Show("Что-то пошло не так. Проверьте чтобы все поля были заполнены верно"); }
        }
    }
}
