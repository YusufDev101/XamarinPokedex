using System;
using Xamarin.Forms;
using XamarinPokedex.ViewModels;

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
                mainViewModel.GetPokemon();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Pokemon Not Found", ex.Message, "OK");
            }
        }
    }
}
