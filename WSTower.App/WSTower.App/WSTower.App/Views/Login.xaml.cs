using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notesAppLogin.txt");
        bool _message = false;

        public Login()
        {
            InitializeComponent();
        }

        private async void User_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var user = emailEntry.Text ?? "";

                if (!string.IsNullOrEmpty(user) && user.Length >= 4)
                {
                    var usuarios = await App.Database.GetUsuarioAsync();

                    var usuario = usuarios.Where(p => p.Email == user && p.Password != "").FirstOrDefault();

                    if (usuario != null)
                    {
                        var result = await DisplayAlert("", "Existe uma senha salva para esse usuário, deseja usar esta senha?", "SIM", "NÃO");

                        if (result)
                        {
                            passwordEntry.Text = usuario.Password;
                            passwordEntry.IsPassword = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async void Entrar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await App.Database.GetUsuarioAsync();

                emailEntry.Text = passwordEntry.Text = string.Empty;

                Navigation.PushAsync(new Principal());
            }

            var button = sender as Button;
            await button.TranslateTo(100, 0, 500, Easing.SpringOut);
            await button.TranslateTo(-100, 0, 500, Easing.SpringOut);
            await button.TranslateTo(0, 0);
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    listView.ItemsSource = await App.Database.GetUsuarioAsync();
        //}

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());

            var button = sender as Button;
            await button.TranslateTo(100, 0, 500, Easing.SpringOut);
            await button.TranslateTo(-100, 0, 500, Easing.SpringOut);
            await button.TranslateTo(0, 0);
        }
    }
}