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
    public sealed partial class ShoppingDetail : Page
    {
        private Shopping _shopping;
        public ShoppingDetail()
        {
            this.InitializeComponent();
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
                this.Frame.Navigate(typeof(MainPage));

            };


            if (e.Parameter != null)
            {
                DataBaseHelper Db_Helper = new DataBaseHelper();
                var navigationData = (object[])e.Parameter;
                _shopping = Db_Helper.ReadShopping(Int32.Parse(navigationData[0].ToString()));
            }

            this.DataContext = _shopping;
        }

        private async void abtEdit_Click(object sender, RoutedEventArgs e)
        {
            var dialogBox = new CdEdit();

            dialogBox.DataContext = (Shopping)this.DataContext;

            var result = await dialogBox.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                DataBaseHelper Db_Helper = new DataBaseHelper();
                Db_Helper.UpdateShopping(_shopping);
            }
  
            this.DataContext = _shopping;
            this.Frame.Navigate(typeof(MainPage));
        }
        private async void abtDelete_Click(object sender, RoutedEventArgs e)
        {
            DataBaseHelper Db_Helper = new DataBaseHelper();
            Db_Helper.DeleteShopping(_shopping.Id);
            MessageDialog messageDialog = new MessageDialog("Usunięto");
            await messageDialog.ShowAsync();
             this.Frame.Navigate(typeof(MainPage));
        }

    }
}



