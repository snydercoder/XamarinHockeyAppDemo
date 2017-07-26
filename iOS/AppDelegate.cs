using System;
using System.Collections.Generic;
using System.Linq;
using HockeyApp.iOS;

using Foundation;
using UIKit;

namespace XamarinHockeyAppDemo.Ui.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private string _appId = "PUT_YOUR_HOCKEYAPP_APP_ID_HERE";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure(_appId);
            manager.DisableMetricsManager = false;
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation();

            global::Xamarin.Forms.Forms.Init();

            App.ShowFeedbackScreenAction = ShowFeedbackScreen;

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public void ShowFeedbackScreen()
        {
			var feedbackManager = BITHockeyManager.SharedHockeyManager.FeedbackManager;
			feedbackManager.ShowFeedbackListView();
        }
    }
}
