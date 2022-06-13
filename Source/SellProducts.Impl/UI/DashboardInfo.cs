using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI
{
    public class DashboardInfo : INotifyPropertyChanged
    {
        public DashboardInfo()
        {
            ProductSaling = Common.ConnectDB.Get.Products().Where(p => !p.is_hide && p.amount_current > 0).Count();

            DateTime dateTimeToday = DateTime.Today;

            DateTime firstDayInWeek = new DateTime(dateTimeToday.Year, dateTimeToday.Month, dateTimeToday.Day);

            while (firstDayInWeek.DayOfWeek != DayOfWeek.Monday)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            OrderWeek = Common.ConnectDB.Get.Orders().
                Where(p => firstDayInWeek < p.time && p.time < firstDayInWeek.AddDays(7)).Count();

            OrderMonth = Common.ConnectDB.Get.Orders().
                Where(p => p.time.Year == dateTimeToday.Year && p.time.Month == dateTimeToday.Month).Count();

            IList<Model.PRODUCT> products = Common.ConnectDB.Get.Products().Where(p => p.amount_current < 5).OrderBy(p => p.amount_current).ToList();

            ProductInfors = new ObservableCollection<ManagerProduct.ProductInfor>();

            for (int i = 0; i < Math.Min(products.Count, 5); i++)
            {
                Model.PRODUCT item = products[i];
                ProductInfors.Add(new ManagerProduct.ProductInfor(item));
            }
        }

        public int ProductSaling { get; set; }

        public int OrderWeek { get; set; }

        public int OrderMonth { get; set; }

        public ObservableCollection<ManagerProduct.ProductInfor> ProductInfors { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
