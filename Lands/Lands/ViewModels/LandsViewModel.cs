using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lands.Models;
using Lands.Services;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Properties
        private ObservableCollection<Land> lands;
        public ObservableCollection<Land> Lands
        {
            get { return lands; }
            set { SetValue(ref lands, value); }
        }
        #endregion

        #region Methods
        async void LoadLands()
        {
            var response = await apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");

            if(!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = (List<Land>)response.Result;
            Lands = new ObservableCollection<Land>(list);
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            apiService = new ApiService();
            LoadLands();
        }
        #endregion
    }
}
