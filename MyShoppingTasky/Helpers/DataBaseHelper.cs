using MyShoppingTasky.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingTasky.Helpers
{
    public class DataBaseHelper
    {
        SQLiteConnection dbConn;

        //Create Tabble   
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Shopping>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific contact from the database.   
        public Shopping ReadShopping(int shoppingid)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingconact = dbConn.Query<Shopping>("select * from Shopping where Id =" + shoppingid).FirstOrDefault();
                return existingconact;
            }
        }
        // Retrieve the all contact list from the database.   
        public ObservableCollection<Shopping> ReadShoppings()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Shopping> myCollection = dbConn.Table<Shopping>().ToList<Shopping>();
                ObservableCollection<Shopping> ShoppingsList = new ObservableCollection<Shopping>(myCollection);
                return ShoppingsList;
            }
        }

        //Update existing conatct   
        public void UpdateShopping(Shopping shopping)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingShopping = dbConn.Query<Shopping>("select * from Shopping where Id =" + shopping.Id).FirstOrDefault();
                if (existingShopping != null)
                {
                    existingShopping.ToBuyName = shopping.ToBuyName;
                    existingShopping.ToBuyPriority = shopping.ToBuyPriority;
                    existingShopping.CreationDate = shopping.CreationDate;
                    existingShopping.ToBuyPrice = shopping.ToBuyPrice;
                    existingShopping.Comments = shopping.Comments;
                    existingShopping.ImagePath = shopping.ImagePath;
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Update(existingShopping);
                    });
                }
            }
        }
        // Insert the new contact in the Contacts table.   
        public void Insert(Shopping newShopping)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newShopping);
                });
            }
        }

        //Delete specific contact   
        public void DeleteShopping(int Id)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingShopping = dbConn.Query<Shopping>("select * from Shopping where Id =" + Id).FirstOrDefault();
                if (existingShopping != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(existingShopping);
                    });
                }
            }
        }
        //Delete all contactlist or delete Contacts table   
        public void DeleteAllShoppings()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() =>   
                //   {   
                dbConn.DropTable<Shopping>();
                dbConn.CreateTable<Shopping>();
                dbConn.Dispose();
                dbConn.Close();
                //});   
            }
        }
    }
}
