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
    public partial class Principal : ContentPage
    {
        List<string> eventos = new List<string>
        {
            "Congressos",
            "Cursos",
            "Convenções",
            "Festas de confraternização",
            "Lançamentos de produtos",
            "Premiações",
            "Palestras",
            "Treinamentos",
            "Workshop"
        };

        private void SearchConteudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Keyword = SearchConteudo.Text;

            if (Keyword.Length>= 1)
            {
                var sugestao = eventos.Where(c => c.ToLower().Contains(Keyword.ToLower()));

                listaEvento.ItemsSource = sugestao;
                listaEvento.IsVisible = true;
            }
            else
            {
                listaEvento.IsVisible = false;
            }
        }

        private void ListaEvento_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item as string == null)
            {
                return;
            }
            else
            {
                listaEvento.ItemsSource = eventos.Where(c => c.Equals(e.Item as string));
                listaEvento.IsVisible = true;
                SearchConteudo.Text = e.Item as string;
            }
        }

        public Principal()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}