using ParkMyTruck.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkMyTruck.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScannerPage : ContentPage
	{
		public ScannerPage ()
		{
			InitializeComponent ();
		}

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }
            }
            catch (Exception ex)
            {
                txtBarcode.Text = ex.Message;
                throw;
            }
        }

        private async void btnScan2_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode2.Text = result;
                }
            }
            catch (Exception ex)
            {
                txtBarcode2.Text = ex.Message;
                throw;
            }
        }

        private void btnAppairage_Clicked(object sender, EventArgs e)
        {
            try
            {
                 txtAppairage.Text = "Système appairé";
                
            }
            catch (Exception ex)
            {
                txtAppairage.Text = ex.Message;
                throw;
            }
        }
    }
}