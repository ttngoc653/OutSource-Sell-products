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

        private void txtCustomerFind_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnProductImportCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductImportProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbbProductCategoryName_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void cbbProductCategoryPage_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void btnProductCategoryAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductCategorySee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductCategoryDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductProductAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductProductUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtProductFindName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rsProductFindLimitPrice_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void btnOrderActAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderActDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderActUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderSee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dpOrderFindStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dpOrderFindEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnOrderFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbbCustomerPage_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void btnCustomerSeeList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCustomerAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCustomerUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReportSale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReportProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbSettingSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSettingItemPerPage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
