using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinPokedex.ViewModels;

using Entry = Microcharts.ChartEntry;

namespace XamarinPokedex
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel mainViewModel;


        List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="January",
                ValueLabel = "200"
            },
            new Entry(400)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "March",
                ValueLabel = "400"
            },
            new Entry(-100)
            {
                Color =  SKColor.Parse("#00CED1"),
                Label = "Octobar",
                ValueLabel = "-100"
            },
            };

        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;



           
            var chartplaisir = new LineChart()
            {
                Entries = entries,
                BackgroundColor = SKColors.Transparent
            };

            Chart1.Chart = chartplaisir;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //your code here;
        }

        private async void ButtonSearch_Clicked(object sender, EventArgs e)
        {
            try
            {
                mainViewModel.GetPokemon();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Pokemon Not Found", ex.Message, "OK");
            }
        }
    }
}
