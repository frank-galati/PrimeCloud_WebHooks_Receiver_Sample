using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using System.Collections.Concurrent;

namespace Receiver.WebHooks
{
    public class CustomWebHookHandler : WebHookHandler
    {
        public static readonly ConcurrentQueue<IDictionary<string, object>> notifications = new ConcurrentQueue<IDictionary<string, object>>();

        public CustomWebHookHandler()
        {
            this.Receiver = CustomWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Get data from WebHook
            CustomNotifications data = context.GetDataOrDefault<CustomNotifications>();

            // Get data from each notification in this WebHook
            foreach (IDictionary<string, object> notification in data.Notifications)
            {
                // Process data
                notifications.Enqueue(notification);
            }

            return Task.FromResult(true);
        }
    }
}