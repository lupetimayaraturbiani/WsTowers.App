using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower.App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : IMasterDetailPageController
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new Login());
            IsPresented = false;
        }

        //private void btnprincipal_clicked(object sender, eventargs e)
        //{
        //    detail = new navigationpage(new principal());
        //    ispresented = false;
        //}

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Login());
            IsPresented = false;
        }

        private void BtnSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Sobre());
            IsPresented = false;
        }

        //private void BtnSair_Clicked(object sender, EventArgs e)
        //{
        //    Detail = new NavigationPage(new Login());
        //    IsPresented = false;
        //}
    }
}