using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace WSTower.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var gravaSenha = SalvaSenha_Toggle.IsToggled;

                if (gravaSenha)
                {
                    if (string.IsNullOrEmpty(passwordEntry.Text))
                    {
                        await DisplayAlert("ATENÇÃO", "Informe a senha", "OK");
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(emailEntry.Text))
                {
                    if (emailEntry.Text.Length >= 4)
                    {
                        await App.Database.SaveUsuarioAsync(new Usuario
                        {
                            Name = nameEntry.Text,
                            Email = emailEntry.Text,
                            Password = gravaSenha ? passwordEntry.Text : "",
                        });

                        emailEntry.Text = passwordEntry.Text = string.Empty;

                        await DisplayAlert("SUCESSO", "Usuário cadastrado com sucesso.", "OK");
                    }
                    else
                    {
                        await DisplayAlert("ATENÇÃO", "O nome do usuário deve possuir mais de 3 caracteres.", "OK");
                    }

                }
                else
                {
                    await DisplayAlert("ATENÇÃO", "Informe o nome do usuário e o email.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERRO", "Ocorreu um erro desconhecido.", "OK");
            }

            var button = sender as Button;
            await button.TranslateTo(100, 0, 500, Easing.SpringOut);
            await button.TranslateTo(-100, 0, 500, Easing.SpringOut);
            await button.TranslateTo(0, 0);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetUsuarioAsync();
        }
    }
}