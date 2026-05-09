using Android.App;
using Android.App.Admin;
using Android.Content;

namespace USBTurnOn
{
    [BroadcastReceiver(Name = "com.companyname.USBTurnOn.MyAdminReceiver", Exported = true, Permission = "android.permission.BIND_DEVICE_ADMIN")]
    [MetaData("android.app.device_admin", Resource = "@xml/device_admin_receiver")]
    [IntentFilter(new[] { "android.app.action.DEVICE_ADMIN_ENABLED" })]
    public class MyAdminReceiver : DeviceAdminReceiver
    {
    }
}
