using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace English4Kids
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class studywithvideo : ContentPage
    {
        public ObservableCollection<url> Urls { get; set; } = new ObservableCollection<url>();
        public studywithvideo()
        {
            InitializeComponent();

            Urls.Add(new url("https://www.youtube.com/watch?v=mnMpjBvUopA"));
            Urls.Add(new url("https://www.youtube.com/watch?v=snqcokDiSdU"));
            Urls.Add(new url("https://www.youtube.com/watch?v=2e0D2A8uBvw"));
            Urls.Add(new url("https://www.youtube.com/watch?v=85M1yxIcHpw"));
            Urls.Add(new url("https://www.youtube.com/watch?v=IZsg_WNpB_Y"));
            Urls.Add(new url("https://www.youtube.com/watch?v=IEF8_q5yDYc"));
            BindingContext = this;
        }
        private void btn_home_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
        void OnImageTapped(object sender, EventArgs e)
        {
            try
            {
                url URL = (url)CV.CurrentItem;
                App.Current.MainPage = new Video(URL._url);
            }
            catch 
            {
                DisplayAlert("Fail", "", "Ok");
            }
        }
    }
}