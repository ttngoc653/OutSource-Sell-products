using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using SellProducts.Impl.UI.ManagerCustomer;

namespace SellProducts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private Impl.ViewModel.Login inforLogin;

        private uint numberItemPerPage = uint.MaxValue;

        public MainWindow()
        {
            string[] arg = Environment.GetCommandLineArgs();
            if (arg.Length > 1)
            {
                Common.ConnectDB.General.ConnectDB.SetConnectString(arg[1]);
            }

            Login();

            InitializeComponent();

            try
            {
                this.rbMenu.SelectionChanged += RbMenu_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetNumberItemPerPage()
        {
            try
            {
                return int.Parse(Common.ConnectDB.Get.Settings()
                                                                 .FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_PAGING).value);
            }
            catch (Exception)
            {
            }
            return 5;
        }


        private void Login()
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
                    inforLogin = window.Getlogin();

                    List<Model.SETTING> settings = Common.ConnectDB.Get.Settings().Where(w => w.account == inforLogin.UserName && SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST == w.name).ToList();
                    if (settings.Count > 0)
                    {
                        if (settings.ElementAt(0).value == true.ToString())
                        {
                            settings = Common.ConnectDB.Get.Settings().Where(w => w.account == inforLogin.UserName && SellProduct_CONSTANT.SETTING_FUNCTION_LAST_SAVED == w.name).ToList();

                            if (settings.Count > 0)
                            {
                                string nameControl = settings.ElementAt(0).value;

                                foreach (object item in UIManager.Children)
                                {
                                    if (item is Control)
                                    {
                                        Control control = item as Control;

                                        if (control.Name == settings.ElementAt(0).value)
                                        {
                                            control.Visibility = Visibility.Visible;
                                        }
                                    }
                                }
                            }
                        }
                    }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.rbMenu.IsMinimized = true;
            this.rbMenu.SelectedIndex = -1;
            ucProduct.ListProductChanged += ucProduct_ListProductChanged;
            ucProduct.ProductRemovedEvent += UcProduct_ProductRemovedEvent;
            ucCustomer.ListCustomerChanged += ucCustomer_ListCustomerChanged;

            Model.SETTING settingUCOpenAfterClose = Common.ConnectDB.Get.Settings().Where(s => s.account == inforLogin.UserName && s.name == SellProduct_CONSTANT.SETTING_FUNCTION_LAST_SAVED).FirstOrDefault();

            if (settingUCOpenAfterClose != null)
            {

            }
        }

        private void UcProduct_ProductRemovedEvent(int idProduct)
        {
            Impl.UI.ManagerProduct.PageProducts pageProducts = (Impl.UI.ManagerProduct.PageProducts)cbbProductCategoryPage.SelectedItem;
            Impl.UI.ManagerProduct.ProductInfor productInfor = pageProducts.Products.Where(i => i.Id == idProduct).FirstOrDefault();

            if (productInfor!=null)
            {
                pageProducts.Products.Remove(productInfor);
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuGoHome_Click(object sender, RoutedEventArgs e)
        {
            this.ucDashboard.Visibility = Visibility.Visible;
        }

        private void MenuBackuUpDatabase_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Chọn nơi lưu tệp backup cơ sở dữ liệu";
            saveFileDialog.Filter = "Backup Files (*.bak;*.trn)|*.bak;*.trn|All file (*)|*";

            if (saveFileDialog.ShowDialog().Value)
            {
                try
                {
                    if (Common.ConnectDB.General.ConnectDB.BackUpDb(saveFileDialog.FileName) == -1)
                    {
                        MessageBox.Show("Backup thành công");
                    }
                    else
                    {
                        throw new Exception("null");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup thất bại: " + ex.Message);
                }
            }
        }

        [Obsolete]
        private void MenuRestoreDatabase_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn tệp backup:";
            openFileDialog.Filter = "Backup Files (*.bak;*.trn)|*.bak;*.trn|All file (*)|*";

            if (openFileDialog.ShowDialog().Value)
            {
                try
                {
                    Common.ConnectDB.General.ConnectDB.Restore(openFileDialog.FileName);
                    MessageBox.Show("Backup thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Restore thất bại: " + ex.Message);
                }
            }
        }

        private void txtCustomerFind_KeyUp(object sender, KeyEventArgs e)
        {
            FilterAndGenPageCustomer();
        }

        private void btnProductImportCategory_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file excel:";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog().Value)
            {
                List<Model.CATEGORY> cs = new Common.Imports.Excel(openFileDialog.FileName).GetCategories();

                int numberAdded = 0;
                foreach (Model.CATEGORY item in cs)
                {
                    if (new Impl.UI.ManagerProduct.Category(item).Insert())
                        numberAdded++;
                }


                MessageBox.Show(string.Format("Đã thêm {0} loại sản phẩm", numberAdded));
            }
        }

        private void btnProductImportProducts_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file excel:";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog().Value)
            {
                List<Model.PRODUCT> cs = new Common.Imports.Excel(openFileDialog.FileName).GetProducts();

                int numberAdded = 0;
                foreach (Model.PRODUCT item in cs)
                {
                    try
                    {
                        if (new Impl.UI.ManagerProduct.ProductInfor(item).Insert())
                            numberAdded++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Cảnh báo");
                    }
                }


                MessageBox.Show(string.Format("Đã thêm {0} sản phẩm", numberAdded));
            }

            Window_Loaded(this, null);
        }

        private void btnProductCategoryAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProductCategorySee_Click(object sender, RoutedEventArgs e)
        {
            ucCMM.Visibility = Visibility.Visible;
        }

        private void btnProductProductAdd_Click(object sender, RoutedEventArgs e)
        {
            ucProduct.Visibility = Visibility.Visible;
        }

        private void btnProductProductUpdate_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Impl.UI.ManagerProduct.ProductInfor> productInfors = ((Impl.UI.ManagerProduct.PageProducts)cbbProductCategoryPage.SelectedItem).Products;

            foreach (Impl.UI.ManagerProduct.ProductInfor item in productInfors)
            {
                item.Update();
            }

            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void txtProductFindName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void rsProductFindLimitPrice_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void btnOrderActAdd_Click(object sender, RoutedEventArgs e)
        {
            this.ucOrderAddView.Visibility = Visibility.Visible;
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
            FilterAndGenPageOrder();
        }

        private void dpOrderFindEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndGenPageOrder();
        }

        private void btnOrderFind_Click(object sender, RoutedEventArgs e)
        {
            FilterAndGenPageOrder();
            cbbOrderPages.SelectedIndex = 1;
        }

        private void cbbCustomerPage_DropDownClosed(object sender, EventArgs e)
        {
            ucCustomer.Visibility = Visibility.Visible;

            ucCustomer.Customers = ((PageCustomers)cbbCustomerPage.SelectedItem).Customers;
            btnCustomerUpdate.IsEnabled = false;
        }

        private void btnCustomerSeeList_Click(object sender, RoutedEventArgs e)
        {
            ucCustomer.Visibility = Visibility.Visible;

            ucCustomer.Customers = ((PageCustomers)cbbCustomerPage.SelectedItem).Customers;
            btnCustomerUpdate.IsEnabled = false;
        }

        private void btnCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            ucCustomer.Visibility = Visibility.Visible;
        }

        private void btnCustomerUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Impl.UI.ManagerCustomer.Customer item in ucCustomer.Customers)
            {
                item.Update();
            }

            btnCustomerUpdate.IsEnabled = false;
        }

        private void btnReportSale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReportProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbSettingSave_Click(object sender, RoutedEventArgs e)
        {
            /// save setting auto login
            try
            {
                Util.SaveSettings(new Model.SETTING()
                {
                    account = inforLogin.UserName,
                    name = SellProduct_CONSTANT.SETTING_AUTO_LOGIN,
                    value = cbSettingAutoLogin.IsChecked.ToString()
                });
            }
            catch (Exception) { }

            /// load setting save user name
            try
            {
                Util.SaveSettings(new Model.SETTING()
                {
                    account = inforLogin.UserName,
                    name = SellProduct_CONSTANT.SETTING_REMEMBER_NAME,
                    value = cbSettingSaveLogin.IsChecked.ToString()
                });
                cbSettingSaveLogin.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_REMEMBER_NAME).value);
            }
            catch (Exception) { }

            /// load setting paging
            try
            {
                if (tbSettingItemPerPage.Background != Brushes.Red)
                {
                    Util.SaveSettings(new Model.SETTING()
                    {
                        account = inforLogin.UserName,
                        name = SellProduct_CONSTANT.SETTING_PAGING,
                        value = tbSettingItemPerPage.Value.ToString()
                    });
                }
                else
                {
                    MessageBox.Show("Số lượng phần từ trong 1 trang không hợp lệ. Vui lòng kiểm tra lại");
                    tbSettingItemPerPage.Value = tbSettingItemPerPage.Value;
                    tbSettingItemPerPage.Focus();
                }
            }
            catch (Exception) { }

            /// load setting open screen last
            try
            {
                Util.SaveSettings(new Model.SETTING()
                {
                    account = inforLogin.UserName,
                    name = SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST,
                    value = cbSettingOpenLastControl.IsChecked.ToString()
                });
            }
            catch (Exception) { }

            if (cbSettingSaveLogin.IsChecked == true)
            {
                Properties.Settings.Default.user = inforLogin.UserName;
            }
            if (cbSettingAutoLogin.IsChecked == true)
            {
                Properties.Settings.Default.pass = inforLogin.Password;
                Properties.Settings.Default.remember = cbSettingAutoLogin.IsEnabled;
            }

            Properties.Settings.Default.Save();
        }

        private void RbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is RibbonTab)
            {
                RibbonTab tab = e.AddedItems[0] as RibbonTab;
                if (tab == rtCustomer)
                {
                    LoadTabCustomer();
                }
                else if (tab == rtOrder)
                {
                    LoadTabOrder();
                }
                else if (tab == rtProduct)
                {
                    LoadTabProduct();
                }
                else if (tab == rtReport)
                {

                }
                else if (tab == rtSettings)
                {
                    LoadTabSettings();
                }
                else
                {
                    MessageBox.Show("Nhóm chức năng không có.");
                }
            }
        }

        private void LoadTabOrder()
        {
            dpOrderFindStart.SelectedDate = Impl.UI.ManagerOrder.Order.GetAll().OrderByDescending(o => o.DateTimeOrder).FirstOrDefault()?.DateTimeOrder;
            dpOrderFindEnd.SelectedDate = Impl.UI.ManagerOrder.Order.GetAll().OrderBy(o => o.DateTimeOrder).FirstOrDefault()?.DateTimeOrder;

            FilterAndGenPageOrder();
        }

        private void LoadTabProduct()
        {
            IList<Impl.UI.ManagerProduct.ProductInfor> ps = Impl.UI.ManagerProduct.ProductInfor.GetAll();
            int? maxPriceSale = ps.OrderByDescending(p => p.Price).FirstOrDefault()?.PriceSale;
            int? minPriceSale = ps.OrderBy(p => p.Price).FirstOrDefault()?.PriceSale;

            int? maxPrice = ps.OrderByDescending(p => p.Price).FirstOrDefault()?.Price;
            int? minPrice = ps.OrderBy(p => p.Price).FirstOrDefault()?.Price;

            rsProductFindLimitPrice.Maximum = Math.Max(maxPrice.Value, maxPriceSale.Value) * 1.25;
            rsProductFindLimitPrice.Minimum = rsProductFindLimitPrice.Maximum * (-0.01);

            rsProductFindLimitPrice.LowerValue = 0;
            rsProductFindLimitPrice.UpperValue = rsProductFindLimitPrice.Maximum;

            if (cbbProductCategoryPage.Items.IsEmpty)
            {
                FilterAndGenPageProduct(ps);
            }
        }

        private void FilterAndGenPageProduct(IList<Impl.UI.ManagerProduct.ProductInfor> products)
        {
            List<Impl.UI.ManagerProduct.PageProducts> pageProductInfor = new List<Impl.UI.ManagerProduct.PageProducts>();
            IList<Impl.UI.ManagerProduct.ProductInfor> psFilter = products.Where(p => p.Name.Contains(txtProductFindName.Text)).ToList();

            psFilter = psFilter.Where(p => (rsProductFindLimitPrice.LowerValue <= p.Price && p.Price <= rsProductFindLimitPrice.UpperValue) ||
                 (rsProductFindLimitPrice.LowerValue <= p.PriceSale && p.PriceSale <= rsProductFindLimitPrice.UpperValue)).ToList();

            if (cbbProductCategoryName.SelectedItem != null)
            {
                int idCategorySeleted = ((Impl.UI.ManagerProduct.Category)cbbProductCategoryName.SelectedItem).Id;
                psFilter = psFilter.Where(p => p.Categories.Where(c => c.Id == idCategorySeleted).Count() > 0).ToList();
            }

            pageProductInfor.Clear();
            pageProductInfor.Add(new Impl.UI.ManagerProduct.PageProducts()
            {
                IndexPage = 0,
                Products = new ObservableCollection<Impl.UI.ManagerProduct.ProductInfor>()
            });

            for (int i = 0; i < psFilter.Count; i++)
            {
                if (i % GetNumberItemPerPage() == 0)
                {
                    Impl.UI.ManagerProduct.PageProducts pageProducts = new Impl.UI.ManagerProduct.PageProducts()
                    {
                        IndexPage = pageProductInfor.Count,
                        Products = new ObservableCollection<Impl.UI.ManagerProduct.ProductInfor>() { products.ElementAt(i) }
                    };

                    pageProductInfor.Add(pageProducts);
                }
                else
                {
                    pageProductInfor.Last().Products.Add(products.ElementAt(i));
                }
            }

            cbbProductCategoryPage.ItemsSource = pageProductInfor;
            if (psFilter.Count == 0)
                ucProduct.ProductInfors = new ObservableCollection<Impl.UI.ManagerProduct.ProductInfor>();
            else
                cbbProductCategoryPage.SelectedIndex = 0;
        }

        private void LoadTabSettings()
        {
            /// load setting auto login
            try
            {
                cbSettingAutoLogin.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_AUTO_LOGIN).value);
            }
            catch (Exception) { }

            /// load setting save user name
            try
            {
                cbSettingSaveLogin.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_REMEMBER_NAME).value);
            }
            catch (Exception) { }

            /// load setting paging
            try
            {
                tbSettingItemPerPage.Value = int.Parse(Common.ConnectDB.Get.Settings()
                                                                 .FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_PAGING).value);
            }
            catch (Exception)
            {
                tbSettingItemPerPage.Value = 5;
            }
            numberItemPerPage = (uint)tbSettingItemPerPage.Value;

            /// load setting open screen last
            try
            {
                cbSettingOpenLastControl.IsChecked = bool.Parse(Common.ConnectDB.Get.Settings().FirstOrDefault(p => p.account == inforLogin.UserName && p.name == SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST).value);
            }
            catch (Exception) { }
        }

        private void LoadTabCustomer()
        {
            FilterAndGenPageCustomer();
        }

        private void FilterAndGenPageCustomer()
        {
            ObservableCollection<Customer> customers = Customer.GetAll();

            customers = new ObservableCollection<Customer>(customers.Where(p => p.Phone.Contains(txtCustomerFind.Text) || p.Name.Contains(txtCustomerFind.Text) || p.Address.Contains(txtCustomerFind.Text)));

            int itemPerPage = GetNumberItemPerPage();

            List<PageCustomers> pageCustomers = new List<PageCustomers>();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer item = customers[i];
                if (i % GetNumberItemPerPage() == 0)
                {
                    PageCustomers pageProducts = new PageCustomers()
                    {
                        IndexPage = pageCustomers.Count + 1,
                        Customers = new ObservableCollection<Customer>() { customers.ElementAt(i) }
                    };

                    pageCustomers.Add(pageProducts);
                }
                else
                {
                    pageCustomers.Last().Customers.Add(customers.ElementAt(i));
                }
            }

            cbbCustomerPage.Items.Clear();
            foreach (PageCustomers item in pageCustomers)
            {
                cbbCustomerPage.Items.Add(item);
            }
        }

        private void FilterAndGenPageOrder()
        {
            ObservableCollection<Impl.UI.ManagerOrder.Order> orders = Impl.UI.ManagerOrder.Order.GetAll();

            if (dpOrderFindStart.SelectedDate != null)
            {
                orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>(orders.Where(o => dpOrderFindStart.SelectedDate.Value.Date < o.DateTimeOrder));
            }
            if (dpOrderFindEnd.SelectedDate != null)
            {
                orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>(orders.Where(o => o.DateTimeOrder<= dpOrderFindEnd.SelectedDate.Value.AddDays(1).Date));
            }

            int itemPerPage = GetNumberItemPerPage();

            List<Impl.UI.ManagerOrder.PageOrders> pageOrders = new List<Impl.UI.ManagerOrder.PageOrders>();

            pageOrders.Add(new Impl.UI.ManagerOrder.PageOrders()
            {
                IndexPage = "",
                Orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>()
            });

            for (int i = 0; i < orders.Count; i++)
            {
                Impl.UI.ManagerOrder.Order item = orders[i];
                if (i % GetNumberItemPerPage() == 0)
                {
                    Impl.UI.ManagerOrder.PageOrders pageProducts = new Impl.UI.ManagerOrder.PageOrders()
                    {
                        IndexPage = pageOrders.Count.ToString(),
                        Orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>() { orders.ElementAt(i) }
                    };

                    pageOrders.Add(pageProducts);
                }
                else
                {
                    pageOrders.Last().Orders.Add(orders.ElementAt(i));
                }
            }

            cbbOrderPages.ItemsSource = pageOrders;
            if (orders.Count == 0)
                ucOrderView.Orders = new ObservableCollection<Impl.UI.ManagerOrder.Order>();
            else
                cbbOrderPages.SelectedIndex = 0;
        }

        private void tbSettingItemPerPage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            uint numberItemPerPage = 5;
            tbSettingItemPerPage.ToolTip = tbSettingItemPerPage.Value;

            try
            {
                if (!uint.TryParse(tbSettingItemPerPage.Value.Value.ToString(), out numberItemPerPage))
                {
                    throw new Exception();
                }
                else if (tbSettingItemPerPage.Background == Brushes.Red)
                {
                    tbSettingItemPerPage.Background = SystemColors.WindowBrush;
                }
            }
            catch (Exception)
            {
                tbSettingItemPerPage.Background = Brushes.Red;
            }
        }

        private void cbbProductCategoryName_DropDownOpened(object sender, EventArgs e)
        {
            IList<Impl.UI.ManagerProduct.Category> categories = Impl.UI.ManagerProduct.Category.GetAll();
            categories.Insert(0, new Impl.UI.ManagerProduct.Category(new Model.CATEGORY() { name = "" }));

            cbbProductCategoryName.Items.Clear();
            foreach (Impl.UI.ManagerProduct.Category item in categories)
            {
                cbbProductCategoryName.Items.Add(item);
            }
        }

        private void uc_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is UserControl)
            {
                UserControl userControl = sender as UserControl;

                Grid controlParent = (Grid)userControl.Parent;

                foreach (var item in controlParent.Children)
                {
                    Control control = item as Control;
                    if (control != sender)
                    {
                        control.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void cbbProductCategoryPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<Impl.UI.ManagerProduct.ProductInfor> productInfors = ((Impl.UI.ManagerProduct.PageProducts)cbbProductCategoryPage.SelectedItem).Products;

            ucProduct.ProductInfors = productInfors;
            ucProduct.Visibility = Visibility.Visible;
        }

        private void cbbProductCategoryName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void ucProduct_ListProductChanged(object sender, RoutedEventArgs e)
        {
            btnProductProductUpdate.IsEnabled = true;
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<Model.SETTING> settings = Common.ConnectDB.Get.Settings().Where(w => w.account == inforLogin.UserName && SellProduct_CONSTANT.SETTING_SAVE_FUNCTION_LAST == w.name).ToList();
            if (settings.Count <= 0)
            {
                return;
            }
            if (settings.ElementAt(0).value != true.ToString())
            {
                return;
            }
            settings = Common.ConnectDB.Get.Settings().Where(w => w.account == inforLogin.UserName && SellProduct_CONSTANT.SETTING_FUNCTION_LAST_SAVED == w.name).ToList();

            foreach (object item in UIManager.Children)
            {
                if (item is Control)
                {
                    Control control = item as Control;

                    if (control.Visibility == Visibility.Visible)
                    {
                        Model.SETTING settingSaveNameUI = new Model.SETTING()
                        {
                            account = inforLogin.UserName,
                            name = SellProduct_CONSTANT.SETTING_FUNCTION_LAST_SAVED,
                            value = control.Name
                        };


                        string strList = "";
                        if (item is Design.UI.ManagerCustomer.CustomerControl)
                        {
                            string[] phones = ucCustomer.Customers.Select(c => c.Phone).ToArray();
                            strList = string.Join("\n\r", phones);
                        }
                        else if (item is Design.UI.ManagerOrder.OrderControl)
                        {
                            int[] idOrders = ucOrderView.Orders.Select(o => o.Id).ToArray();
                            strList = string.Join("\n\r", idOrders);
                        }
                        else if (item is Design.UI.ManagerProduct.ProductControl)
                        {
                            int[] idProducts = ucProduct.ProductInfors.Select(p => p.Id).ToArray();
                            strList = string.Join("\n\r", idProducts);
                        }

                        Model.SETTING settingSaveListOpen = new Model.SETTING()
                        {
                            account = inforLogin.UserName,
                            name = SellProduct_CONSTANT.SETTING_LIST_ITEM_AFTER_CLOSE_WINDOW,
                            value = strList
                        };

                        try
                        {
                            if (Common.ConnectDB.Get.Settings().Where(s => s.account.Trim().Equals(settingSaveNameUI.account.Trim()) && s.name.Equals(settingSaveNameUI.name)).Count() > 0)
                                Common.ConnectDB.Update.Instance(settingSaveNameUI);
                            else
                                Common.ConnectDB.Insert.Instance(settingSaveNameUI);

                            if (Common.ConnectDB.Get.Settings().Where(s => s.account.Equals(settingSaveListOpen.account) && s.name.Equals(settingSaveListOpen.name)).Count() > 0)
                                Common.ConnectDB.Update.Instance(settingSaveListOpen);
                            else
                                Common.ConnectDB.Insert.Instance(settingSaveListOpen);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi lưu giao diện đang mở. " + Environment.NewLine+ex.Message);
                        }
                    }
                }
            }
        }

        private void ucCustomer_ListCustomerChanged(object sender, RoutedEventArgs e)
        {
            btnCustomerUpdate.IsEnabled = true;
        }

        private void cbbProductCategoryPage_DropDownOpened(object sender, EventArgs e)
        {
            FilterAndGenPageProduct(Impl.UI.ManagerProduct.ProductInfor.GetAll());
        }

        private void cbbOrderPages_DropDownOpened(object sender, EventArgs e)
        {
            FilterAndGenPageOrder();
        }

        private void cbbOrderPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbOrderPages.SelectedItem!=null)
            {
                ucOrderView.Orders = (cbbOrderPages.SelectedItem as Impl.UI.ManagerOrder.PageOrders).Orders;
            }
        }

        private void btnProductCategoryTree_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                ucCategory.Visibility = Visibility.Visible;
                if (ucCategory.Visibility==Visibility.Visible)
                {
                    break;
                }
            }
        }
    }
}
