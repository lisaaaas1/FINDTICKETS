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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void ButtonREG_Click(object sender, RoutedEventArgs e)
        {
            CreateAcc createacc = new CreateAcc();
            createacc.Show();
            this.Close();
        }

        private void ButtonLOGIN_Click(object sender, RoutedEventArgs e)
        {
            LogIn log_in = new LogIn();
            log_in.Show();
            this.Close();
        }
    }
}
