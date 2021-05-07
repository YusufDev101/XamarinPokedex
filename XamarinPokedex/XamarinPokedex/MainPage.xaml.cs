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

        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            BindingContext = mainViewModel;
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
                await mainViewModel.GetPokemon();

                // Get chart
                var chartObj = new LineChart()
                {
                    Entries = mainViewModel.BuildChat(),
                    BackgroundColor = SKColors.Transparent
                };

                Chart1.Chart = chartObj;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Pokemon Not Found", ex.Message, "OK");
            }
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            try
            {
                await mainViewModel.GetShinies();               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Pokemon Not Found", ex.Message, "OK");
            }
        }
    }
}
