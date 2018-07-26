﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lands.Views
{
    public partial class LandsPage : ContentPage
    {
        public LandsPage()
        {
            InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);
			Application.Current.MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.FromHex("#234B5A"));
			Application.Current.MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
