using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellProducts.Impl.UI.ManagerProduct
{
    public class Category : IImpl, INotifyPropertyChanged
    {

        Model.CATEGORY _cat = null;
        Category _parent = null;
        ObservableCollection<Category> _childs = null;

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
                    List<Model.CATEGORY> categoriesParent = Common.ConnectDB.Get.Categories().Where(i => i.id == _cat.cat_parent).ToList();

                    if (categoriesParent.Count>0)
                    {
                        _parent = new Category(categoriesParent.FirstOrDefault());

                        if (_parent != null)
                        {
                            _cat.cat_parent = _parent.Id;
                        }
                    }
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

        public ObservableCollection<Category> Childs
        {
            get
            {
                if (_childs == null || (_childs != null && _childs.Count == 0))
                {
                    IList<Model.CATEGORY> cs = Common.ConnectDB.Get.Categories().Where(i => i.cat_parent == _cat.id).ToList();

                    _childs = new ObservableCollection<Category>();
                    foreach (Model.CATEGORY item in cs)
                    {
                        _childs.Add(new Category(item));
                    }
                }
                return _childs;
            }
            set
            {
                foreach (Category item in value)
                {
                    item._cat.cat_parent = Id;
                }

                _childs = value;
            }
        }

        public override bool Insert()
        {
            if (Common.ConnectDB.Get.Categories().Where(i => i.name == _cat.name).Count() > 0)
                return false;

            Common.ConnectDB.Insert.Instance(_cat);

            return true;
        }

        public override bool Update()
        {
            if (this.Id != 0)
            {
                Common.ConnectDB.Update.Instance(this._cat);

                if (_parent != null)
                {
                    _parent.Update();
                }

                if (_childs != null)
                {
                    foreach (Category item in _childs)
                    {
                        item.Update();
                    }
                }
            }

            return true;
        }

        public static ObservableCollection<Category> GetAll()
        {
            return new ObservableCollection<Category>(Common.ConnectDB.Get.Categories().Select(item => new Category(item)).ToList());
        }

        public override bool Remove()
        {
            foreach (var item in _childs)
            {
                item._cat.cat_parent = null;

                item.Update();
            }

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
