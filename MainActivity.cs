using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VTUMCASyllabus
{
    [Activity(Theme ="@android:style/Theme.Black.NoTitleBar", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // **int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button skip = FindViewById<Button>(Resource.Id.btn_skip);
            skip.Click += delegate {
                var activity = new Intent(this, typeof(HomeActivity));
                StartActivity(activity);
            };
            // Get our button from the layout resource,
            // and attach an event to it
          // **  Button button = FindViewById<Button>(Resource.Id.MyButton);

           //** button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

