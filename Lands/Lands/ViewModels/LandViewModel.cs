using System;
using Lands.Models;

namespace Lands.ViewModels
{
    public class LandViewModel : BaseViewModel
    {
        public Land Land
        {
            get;
            set;
        }

        #region Constructors
        public LandViewModel(Land Land)
        {
            this.Land = Land;
        }
        #endregion
    }
}
