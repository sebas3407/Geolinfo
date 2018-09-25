namespace Lands.Views
{
    using Xamarin.Forms;

	public partial class LandsPage : ContentPage
    {
        public LandsPage()
        {
            InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);
	//		Application.Current.MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.FromHex("#234B5A"));
		//	Application.Current.MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);

			if (Device.RuntimePlatform == Device.Android)
			{
				SearchBar.BackgroundColor = Color.White;
				SearchBar.Margin = new Thickness(10,0);
			}
		}

		protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
