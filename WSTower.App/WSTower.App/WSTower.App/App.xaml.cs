using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower.App
{
    public partial class App : Application
    {
        static UsuarioRepository database;

        public static UsuarioRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new UsuarioRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "person.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new Splash();
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
