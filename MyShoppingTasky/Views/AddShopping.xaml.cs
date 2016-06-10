using MyShoppingTasky.Helpers;
using MyShoppingTasky.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyShoppingTasky.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddShopping : Page
    {
        private Shopping _shopping;
        public AddShopping()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            _shopping = new Shopping();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += (sender, args) =>
            {
                args.Handled = true;
                this.Frame.Navigate(typeof(MainPage),new object[] { _shopping.Id });
            };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)CbShoppingGroup.SelectedItem;
            if (!String.IsNullOrEmpty(tBName.Text) && !String.IsNullOrEmpty(tBPriority.Text) && !String.IsNullOrEmpty(cbi.Content.ToString()) &&
                !String.IsNullOrEmpty(tBPrice.Text) && !String.IsNullOrEmpty(tBComment.Text))
            {
               
                double price = 0.00;
                Double.TryParse(tBPrice.Text, out price);
                _shopping.ToBuyName = tBName.Text;
                _shopping.ToBuyPriority = tBPriority.Text;  
                _shopping.ShoppingGroup = cbi.Content.ToString();
                _shopping.ToBuyPrice = price;
                _shopping.Comments = tBComment.Text;
                _shopping.CreationDate = DateTime.Now.ToString();
                switch (cbi.Content.ToString())
                {
                    case "Spożywcze różne": _shopping.ImagePath = "/Assets/spozywcze.png"; break;
                    case "Chemia": _shopping.ImagePath = "/Assets/chemia.png"; break;
                    case "Obiad": _shopping.ImagePath = "/Assets/obiad.png"; break;
                    case "Rożne": _shopping.ImagePath = "/Assets/rozne.png"; break;
                }
                DataBaseHelper Db_Helper = new DataBaseHelper();
                Db_Helper.Insert(_shopping);
                MessageDialog messageDialog = new MessageDialog("Sukces! Dodano do listy zakupów");
                await messageDialog.ShowAsync();
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Wypełnij wszystkie dane");  
                await messageDialog.ShowAsync();
           }
        }
    }
}
