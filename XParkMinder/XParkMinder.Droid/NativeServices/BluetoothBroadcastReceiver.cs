using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XParkMinder.Droid.NativeServices
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { BluetoothDevice.ActionAclConnected, BluetoothDevice.ActionAclDisconnected })]
    public class BluetoothBroadcastReceiver : BroadcastReceiver
    {

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == BluetoothDevice.ActionAclDisconnected)
            {
                SendNotificationToXParkMinderApp(context);
            }
        }

        private void SendNotificationToXParkMinderApp(Context context)
        {
            var pendingIntent = GetPendingIntentForXParkMinderApp(context);
            var notification = GetNotificationForXParkMinderApp(context, pendingIntent);
            SendNotificationUsingNotificationManager(context, notification);
        }

        private void SendNotificationUsingNotificationManager(Context context, Notification notification)
        {
            var notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            notificationManager?.Notify(0, notification);
        }

        private Notification GetNotificationForXParkMinderApp(Context context, PendingIntent pendingIntent)
        {
            var notification = new Notification.Builder(context)
                .SetContentTitle("Conexión con Bluetooth")
                .SetContentText("Se ha conectado un dispositivo bluetooth a tu teléfono")
                .SetContentIntent(pendingIntent)
                .SetSmallIcon(Resource.Drawable.icon)
                .Build();

            return notification;
        }

        private PendingIntent GetPendingIntentForXParkMinderApp(Context context)
        {
            var newIntent = new Intent(context, typeof(MainActivity));
            var pendingIntent = PendingIntent.GetActivity(context, 0, newIntent, PendingIntentFlags.OneShot);
            return pendingIntent;
        }

    }
}