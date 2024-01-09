using Android.Content;

namespace USBTurnOn
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // 取得按鈕
            Button button = FindViewById<Button>(Resource.Id.btnToggleUSBDebugging);

            // 設置按鈕點擊事件
            button.Click += (sender, e) =>
            {
                // 呼叫切換USB偵錯模式的方法
                ToggleUSBDebugging();
            };


           

        }

        private void ToggleUSBDebugging()
        {
            // 使用Android的Intent啟動開關USB偵錯模式的設置
            Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDevelopmentSettings);
            StartActivity(intent);
        }


    }
}