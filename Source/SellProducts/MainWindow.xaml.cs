using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace SellProducts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private string username;

        public MainWindow()
        {
            try
            {

                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                bool result = false;
                while (true)
                {
                    result = SellProducts.Common.ConnectDB.General.ConnectDB.CheckConnect();

                    if (result)
                    {
                        break;
                    }

                    string connectionStrNew = Interaction.InputBox(Properties.Resources.ChangeConnectionStringDialog, Properties.Resources.QuestionDialog);
                }

                LoginWindow window = new LoginWindow();
                bool? resultLogin = window.ShowDialog();
                if (resultLogin == true)
                {
                    username = window.Getlogin().UserName;
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuGoHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuBackuUpDatabase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuRestoreDatabase_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
