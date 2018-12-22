using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace microsoftAds
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static bool isVideoAd = false;
        public MainPage()
        {
            this.InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += dispatcherTimer_Tick;
            timer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            this.textBlock1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void NativeAdsBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NativeAdPage));
        }

        private void InterstitialVideoAdsBtn_Click(object sender, RoutedEventArgs e)
        {
            isVideoAd = true;
            Frame.Navigate(typeof(InterstitialAdPage));
        }

        private void InterstitialDisplayAdsBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InterstitialAdPage));
        }
    }
}
