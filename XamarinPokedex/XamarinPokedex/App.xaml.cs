using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPokedex.HttpHelpers;

namespace XamarinPokedex
{
    public partial class App : Application
    {
        public static HttpWebRequest HttpWebRequest { get; private set; }

        public App()
        {
            InitializeComponent();

            // Instantiate objects.
            HttpWebRequest = new HttpWebRequest();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
