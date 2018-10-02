using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lands.Models;

namespace Lands.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Land> LandsList
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;
        }

        public LandViewModel Land
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Lands = new LandsViewModel();
            LoadMenu();
        }

        private void LoadMenu()
        {
            Menus = new ObservableCollection<MenuItemViewModel>();

            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_email.png",
                Tittle = "Contacto",
                PageName = "LandTabbedPage"
            });

            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_email.png",
                Tittle = "Contacto",
                PageName = "LandTabbedPage"
            });
        }
        #endregion

        #region Methods

        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion  
    }
}