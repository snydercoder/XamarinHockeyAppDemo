using System;
using System.Collections.Generic;
using HockeyApp;

using Xamarin.Forms;

namespace XamarinHockeyAppDemo.Ui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnThrowErrorButtonClicked(object sender, EventArgs e)
        {
            throw new Exception($"This error brought to you by the error-making button.");
        }

		void OnTrackEventButtonClicked(object sender, EventArgs e)
		{
			HockeyApp.MetricsManager.TrackEvent(
                "Track Button Clicked",
                new Dictionary<string, string>() {{"SomeProperty", "Some Value"}},
                new Dictionary<string, double>() { { "ExecutionTime", 3.14 } }
            );
		}

		void OnSendFeedbackButtonClicked(object sender, EventArgs e)
		{
            App.ShowFeedbackScreenAction();
		}
    }
}
