using MyShoppingTasky.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using MyShoppingTasky.Helpers;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MyShoppingTasky.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListView : Page
    {
        private ShoppingViewModel _shoppingViewModel;
        public ListView()
        {
            this.InitializeComponent();
            _shoppingViewModel = new ShoppingViewModel();
            _shoppingViewModel.GetShoppingsList();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = _shoppingViewModel;
        }

        private void NewThing_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataBaseHelper Db_Helper = new DataBaseHelper();
            var a = Db_Helper.ReadShopping(1);
            ToastTemplateType toastType = ToastTemplateType.ToastText02;

            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastType);

            XmlNodeList toastTextElement = toastXml.GetElementsByTagName("text");
            toastTextElement[0].AppendChild(toastXml.CreateTextNode("Hello C# Corner"));
            toastTextElement[1].AppendChild(toastXml.CreateTextNode("I am poping you from a Winmdows Phone App"));

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
