using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ParkMyTruck.Services;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(ParkMyTruck.Droid.Services.QrScanningService))]

namespace ParkMyTruck.Droid.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                UseCustomOverlay = false,
                TopText = "Scannez le code",
                BottomText = "Positionner la ligne rouge sur le code"
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}