using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingTasky.Model
{
    public class Shopping : BindableBase
    {
      
        int _id;
        string _shoppingGroup;
        string _toBuyName;
        string _toBuyPriority;
        string _comments;
        double _toBuyPrice;
        string _creationDate;
        string _imagePath;
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id
        {
            get { return this._id; }
            set { this.SetProperty(ref this._id, value); }
        }
        public string ShoppingGroup
        {
            get { return this._shoppingGroup; }
            set { this.SetProperty(ref this._shoppingGroup, value); }
        }
        public string ToBuyName
        {
            get { return this._toBuyName; }
            set { this.SetProperty(ref this._toBuyName, value); }
        }
        public string ToBuyPriority
        {
            get { return this._toBuyPriority; }
            set { this.SetProperty(ref this._toBuyPriority, value); }
        }
        public string Comments
        {
            get { return this._comments; }
            set { this.SetProperty(ref this._comments, value); }
        }
        public double ToBuyPrice
        {
            get { return this._toBuyPrice; }
            set { this.SetProperty(ref this._toBuyPrice, value); }
        }
        public string CreationDate
        {
            get { return this._creationDate; }
            set { this.SetProperty(ref this._creationDate, value); }
        }
        public string ImagePath
        {
            get { return this._imagePath; }
            set { this.SetProperty(ref this._imagePath, value); }
        }
    }
}
