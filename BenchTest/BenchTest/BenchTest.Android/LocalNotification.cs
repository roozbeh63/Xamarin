using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace BenchTest.Droid
{
    public class LocalNotification : Java.Lang.Object, Services.INotification
    {
        public void NotifyError(string text)
        {
            Context ctx = Forms.Context;
            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(ctx)
                .SetContentTitle("Error")
                .SetContentText(text)
                .SetPriority((int)NotificationPriority.High)
                .SetSmallIcon(Resource.Drawable.notification_bg_normal_pressed)
                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
            .SetVibrate(new long[0]);
            

            // Build the notification:
            Notification notification = builder.Build();
            
            // Get the notification manager:
            NotificationManager notificationManager =
        (NotificationManager)ctx.GetSystemService(Context.NotificationService);

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }


        public void NotifyWarning(string text)
        {
            Context ctx = Forms.Context;
            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(ctx)
                .SetContentTitle("Warning")
                .SetContentText(text)
                .SetPriority((int)NotificationPriority.Default)
                .SetSmallIcon(Resource.Drawable.notification_bg_normal_pressed)
                .SetDefaults(NotificationDefaults.Vibrate)
            .SetVibrate(new long[0]);


            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =
        (NotificationManager)ctx.GetSystemService(Context.NotificationService);

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
    }
}