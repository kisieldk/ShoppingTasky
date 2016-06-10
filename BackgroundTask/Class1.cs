
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace BackgroundTask
{
    public sealed class NotiTask : IBackgroundTask
    {
       
        public void Run(IBackgroundTaskInstance taskInstance)
        {

            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
    
                textElements[0].AppendChild(toastXml.CreateTextNode("Planujesz zakupy?"));
                textElements[1].AppendChild(toastXml.CreateTextNode("Dodaj rzeczy, które chcesz kupić aby nie zapomnieć"));


            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
}
