﻿using System.Collections.ObjectModel;
using System.Linq;
using Lands.Models;

namespace Lands.ViewModels
{
	public class LandViewModel : BaseViewModel
	{
		#region Properties
		private ObservableCollection<Border> borders;
		public ObservableCollection<Border> Borders
		{
			get { return borders; }
			set { SetValue(ref borders, value); }
		}

		public Land Land
		{
			get;
			set;
		}
		#endregion

		#region Methods
		private void LoadBorders()
		{
			this.borders = new ObservableCollection<Border>();
			foreach (var border in Land.Borders)
			{
				var land = MainViewModel.GetInstance().LandsList.Where(
					l => l.Alpha3Code == border.ToString()).FirstOrDefault();

				if (land != null)
				{
					this.Borders.Add(new Border(land.Alpha3Code, land.Name));
				}
			}
		}
		#endregion

		#region Constructors
		public LandViewModel(Land Land)
		{
			this.Land = Land;
			LoadBorders();
		}
		#endregion
	}
}
