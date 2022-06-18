using PM02E10056.Controls;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02E10056
{
    public partial class App : Application
    {
        static DataBaseSqlite basedatos;
        public static DataBaseSqlite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DataBaseSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02.db3"));
                }
                return basedatos;
            }

        }
        public App()
        {
            InitializeComponent();


            
            MainPage = new NavigationPage(new Views.MainPage())
            {
                BarBackgroundColor = Color.MidnightBlue,
                BarTextColor = Color.White
            };
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
