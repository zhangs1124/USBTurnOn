using Android.Content;
using Android.OS;
using Android.Widget;

namespace USBTurnOn
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Exported = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // 閮剔蔭?恍雿?
            SetContentView(Resource.Layout.activity_main);

            // ????
            Button button = FindViewById<Button>(Resource.Id.btnToggleUSBDebugging);

            // 閮剔蔭??暺?鈭辣嚗?亥歲頧?鈭箏?賊?
            button.Click += (sender, e) =>
            {
                try
                {
                    Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDevelopmentSettings);
                    intent.AddFlags(ActivityFlags.NewTask);
                    StartActivity(intent);
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, "?⊥???閮剖?: " + ex.Message, ToastLength.Long).Show();
                }
            };
        }
    }
}