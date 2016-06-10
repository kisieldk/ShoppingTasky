using MyShoppingTasky.Helpers;
using MyShoppingTasky.Model;
using MyShoppingTasky.ViewModel;
using MyShoppingTasky.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MyShoppingTasky
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ShoppingViewModel _shoppingViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
            _shoppingViewModel = new ShoppingViewModel();
            _shoppingViewModel.GetShoppingsList();
            this.DataContext = _shoppingViewModel;
         
        }
        private void NewThing_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(ShoppingDetail), new object[] {((Shopping)(e.ClickedItem)).Id });
        }

        private void btnGoToAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddShopping));
        }
    }
}
