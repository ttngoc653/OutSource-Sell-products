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

namespace SellProducts
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public Impl.ViewModel.Login login { get; }

        public LoginWindow()
        {
            InitializeComponent();

            login = new Impl.ViewModel.Login();
            this.DataContext = login;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (new Common.ConnectDB.Manager().Get(login.UserName,login.Password)!=null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Sai tài khoản.");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
