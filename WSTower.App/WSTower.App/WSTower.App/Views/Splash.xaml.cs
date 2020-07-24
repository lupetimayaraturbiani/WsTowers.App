using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();

            navegacao();
        }

        private async void navegacao()
        {
            await Task.Delay(3000);

            await Task.WhenAll(
                ImgLogo.RotateTo(720, 3000),
                ImgLogo.FadeTo(0, 3000));

            await ImgLogo.FadeTo(0, 100);

           App.Current.MainPage = new NavigationPage(new Menu());
        }
    }
}