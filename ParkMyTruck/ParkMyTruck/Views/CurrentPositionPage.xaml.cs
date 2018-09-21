using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParkMyTruck.ViewModels;
using ParkMyTruck.Models;

namespace ParkMyTruck.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentPositionPage : ContentPage
	{
        CurrentPositionViewModel viewModel;   
		public CurrentPositionPage (CurrentPositionViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = this.viewModel = viewModel; 
		}
        public CurrentPositionPage()
        {
            InitializeComponent();

            var position = new Position
            {
                Latitude = "not defined",
                Longitude = "not defined",
                Altitude = "not defined"
            };

            viewModel = new CurrentPositionViewModel(position);
            BindingContext = viewModel;
        }
	}
}