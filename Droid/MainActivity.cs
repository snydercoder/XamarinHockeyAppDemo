using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

namespace XamarinHockeyAppDemo.Ui.Droid
{
    [Activity(Label = "XamarinHockeyAppDemo.Ui.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		private string _appId = "PUT_YOUR_HOCKEYAPP_APP_ID_HERE";

        protected override void OnCreate(Bundle bundle)
        {
            MetricsManager.Register(Application, _appId);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            App.ShowFeedbackScreenAction = ShowFeedbackScreen;

            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();

            CrashManager.Register(this, _appId);
        }

		public void ShowFeedbackScreen()
		{
            FeedbackManager.ShowFeedbackActivity(ApplicationContext);
		}
    }
}
