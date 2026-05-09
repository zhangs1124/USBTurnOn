using Android.App.Admin;
using Android.Content;
using Android.OS;

namespace USBTurnOn
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Exported = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // 取得按鈕
            Button button = FindViewById<Button>(Resource.Id.btnToggleUSBDebugging);
            Button buttonTurnOffScreen = FindViewById<Button>(Resource.Id.buttonTurnOffScreen);

            // 設置按鈕點擊事件
            button.Click += (sender, e) =>
            {
                // 呼叫切換USB偵錯模式的方法
                ToggleUSBDebugging();
            };

            buttonTurnOffScreen.Click += (sender, e) =>
            {
                // 呼叫關閉螢幕的方法
                TurnOffScreen();
            };


        }

        private void ToggleUSBDebugging()
        {
            // 使用Android的Intent啟動開關USB偵錯模式的設置
            Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDevelopmentSettings);
            StartActivity(intent);
        }


        private void TurnOffScreen()
        {
            DevicePolicyManager devicePolicyManager = (DevicePolicyManager)GetSystemService(DevicePolicyService);
            ComponentName adminComponent = new ComponentName(this, Java.Lang.Class.FromType(typeof(MyAdminReceiver)));

            if (!devicePolicyManager.IsAdminActive(adminComponent))
            {
                Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
                intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, adminComponent);
                intent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "Please grant device admin permission to enable this feature.");
                StartActivityForResult(intent, 1);
            }
            else
            {
                devicePolicyManager.LockNow();
            }

        }



        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1)
            {
                if (resultCode == Result.Ok)
                {
                    // Device admin permission granted
                    Toast.MakeText(this, "Device admin permission granted.", ToastLength.Short).Show();
                    // Lock the screen after permission granted
                    DevicePolicyManager devicePolicyManager = (DevicePolicyManager)GetSystemService(DevicePolicyService);
                    ComponentName adminComponent = new ComponentName(this, Java.Lang.Class.FromType(typeof(MyAdminReceiver)));
                    devicePolicyManager.LockNow();
                }
                else
                {
                    // Device admin permission not granted
                    Toast.MakeText(this, "Device admin permission not granted.", ToastLength.Short).Show();
                }
            }
        }


    }
}