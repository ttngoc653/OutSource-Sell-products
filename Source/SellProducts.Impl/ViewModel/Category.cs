using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.ViewModel
{
    public class Category: INotifyPropertyChanged
    {

        Model.CATEGORY _cat = null;
        Category _parent = null;
        IList<Category> _childs = null;

        public Category(Model.CATEGORY cat)
        {
            _cat = cat;
        }

        public int Id
        {
            get => _cat.id;
            set { _cat.id = value; }
        }

        public string Name
        {
            get => _cat.name;
            set { _cat.name = value; }
        }

        public Category Parent
        {
            get
            {
                if (_parent==null)
                {
                    _parent = new Category(Common.ConnectDB.Get.Categories().Where(i => i.id == _cat.cat_parent).FirstOrDefault());

                    _cat.cat_parent = _parent.Id;
                }

                return _parent;
            }
            set
            {
                if (value!=null)
                {
                    _cat.cat_parent = value.Id;
                }
                else
                {
                    _cat.cat_parent = null;
                }

                _parent = value;
            }
        }

        public IList<Category> Childs
        {
            get
            {
                if (_childs == null || (_childs != null && _childs.Count == 0))
                {
                    IList<Model.CATEGORY> cs = Common.ConnectDB.Get.Categories().Where(i => i.cat_parent == _cat.id).ToList();

                    _childs = new List<Category>();
                    foreach (Model.CATEGORY item in cs)
                    {
                        _childs.Add(new Category(item));
                    }
                }
                return _childs;
            }
            set { _childs = value; }
        }

        public bool Insert()
        {
            if (Common.ConnectDB.Get.Categories().Where(i=>i.name==_cat.name).Count()>0)
            {
                return false;
            }

            return true;
        }

        public bool Update()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
