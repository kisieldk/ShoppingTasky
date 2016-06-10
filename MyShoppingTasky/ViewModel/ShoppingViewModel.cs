using MyShoppingTasky.Helpers;
using MyShoppingTasky.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingTasky.ViewModel
{
   public  class ShoppingViewModel : BindableBase
    {
        ObservableCollection<Shopping> _shoppings = new ObservableCollection<Shopping>();

        public ObservableCollection<Shopping> Shoppings
        {
            get { return this._shoppings; }
            set { this.SetProperty(ref this._shoppings, value); }
        }
        List<KeyedList<string, Shopping>> groupedShoppings;
        public List<KeyedList<string, Shopping>> GroupedShoppings
        {
            get
            {
                if (groupedShoppings == null || groupedShoppings.Count == 0)
                {

                    groupedShoppings = (from shopping in Shoppings
                                        orderby shopping.ShoppingGroup
                                        group shopping by shopping.ShoppingGroup into shgroupShoppings
                                        select new KeyedList<string, Shopping>(shgroupShoppings.Key, shgroupShoppings)).ToList();
                }
                return groupedShoppings;
            }
        }

        public void GetShoppingsList()
        {
            DataBaseHelper Db_Helper = new DataBaseHelper();
           _shoppings = Db_Helper.ReadShoppings();
        }
    }
}
