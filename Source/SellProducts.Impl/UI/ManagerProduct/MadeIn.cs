using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerProduct
{
    public class MadeIn : IImpl, INotifyPropertyChanged
    {
        Model.MADEIN _m = null;

        public MadeIn(Model.MADEIN m)
        {
            _m = m;
        }

        public string Location { get =>_m.location; set => _m.location = value; }

        public string Detail { get => _m.detail; set => _m.detail = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static List<MadeIn> GetAll()
        {
            return Common.ConnectDB.Get.Madeins().Select(item => new MadeIn(item)).ToList();
        }

        public override bool Insert()
        {
            return Common.ConnectDB.Insert.Instance(_m);
        }

        public override bool Remove()
        {
            return Common.ConnectDB.Delete.Instance(_m)>0;
        }

        public override bool Update()
        {
            return Common.ConnectDB.Update.Instance(_m) > 0;
        }
    }
}
