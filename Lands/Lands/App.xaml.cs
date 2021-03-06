﻿namespace Lands
{
    using Xamarin.Forms;
    using Views;

    public partial class App : Application
	{
        public static NavigationPage Navigator { get; internal set; }

        public App ()
		{
			InitializeComponent();
            NavigationPage main = new NavigationPage(new LandsPage());
            main.BarBackgroundColor = Color.FromHex("#234B5A");
            main.BarTextColor = Color.White;

            MainPage = main;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
