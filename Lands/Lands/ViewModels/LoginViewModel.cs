namespace Lands.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region events
        #endregion

        #region Properties

        private string email;
        public string Email
        {
            get {return email; }
            set {  SetValue(ref email, value);  }
        }

        private string password;
        public string Password
        {
            get { return password;  }
            set {  SetValue(ref password, value);  }
        }

        private bool isRunning;
        public bool IsRunning
        {
            get {return isRunning;  }
            set {SetValue(ref isRunning, value);}
        }

        private bool isRemembered;
        public bool IsRemembered
        {
            get { return isRemembered; }
            set { SetValue(ref isRemembered, value);}
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }

        #endregion

        #region Commands

        async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please, enter a email", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please, enter a password", "OK");
                return;
            }

            if (Email == "sebas" && Password == "1234")
            {
                Email = string.Empty;
                Password = string.Empty;
                await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            }

            else
            {
                Password = string.Empty;
                await Application.Current.MainPage.DisplayAlert("Error", "Email or password invalid", "Ok");
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            IsRemembered = false;
            IsEnabled = true;
        }

        #endregion
    }
}