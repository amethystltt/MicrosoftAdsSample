using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Advertising.WinRT.UI;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace microsoftAds
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InterstitialAdPage : Page
    {
        // Assign myAppId and myAdUnitId to test values. Replace these values with live values 
        // from Dev Center before you submit your app to the Store.
        InterstitialAd myInterstitialAd = null;
        string myAppId = "d25517cb-12d4-4699-8bdc-52040c712cab";
        string myAdUnitId = "test";

        public InterstitialAdPage()
        {
            this.InitializeComponent();

            myInterstitialAd = new InterstitialAd();
            myInterstitialAd.AdReady += MyInterstitialAd_AdReady;
            myInterstitialAd.ErrorOccurred += MyInterstitialAd_ErrorOccurred;
            myInterstitialAd.Completed += MyInterstitialAd_Completed;
            myInterstitialAd.Cancelled += MyInterstitialAd_Cancelled;

            if (MainPage.isVideoAd)
            {
                myInterstitialAd.RequestAd(AdType.Video, myAppId, myAdUnitId);
            }
            else
            {
                myInterstitialAd.RequestAd(AdType.Display, myAppId, myAdUnitId);
            }

            if (InterstitialAdState.Ready == myInterstitialAd.State)
            {
                myInterstitialAd.Show();
            }
        }

        private void requestAdButton_Click(object sender, RoutedEventArgs e)
        {
            myInterstitialAd.RequestAd(AdType.Video, myAppId, myAdUnitId);
        }

        // This method attempts to show the interstitial ad when the "Show ad" button is clicked.
        private void showAdButton_Click(object sender, RoutedEventArgs e)
        {
            if (InterstitialAdState.Ready == myInterstitialAd.State)
            {
                myInterstitialAd.Show();
            }
        }

        void MyInterstitialAd_AdReady(object sender, object e)
        {
            myInterstitialAd.Show();
        }

        void MyInterstitialAd_ErrorOccurred(object sender, AdErrorEventArgs e)
        {
            // Your code goes here.
        }

        void MyInterstitialAd_Completed(object sender, object e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        void MyInterstitialAd_Cancelled(object sender, object e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
