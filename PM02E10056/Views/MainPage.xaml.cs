using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PM02E10056.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       

        private async  void newUbicacion_Clicked(object sender, EventArgs e)
        {
            var localizacion = await Geolocation.GetLocationAsync();

            if (localizacion != null)
            {
                var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
                txtLatitud.Text = $"{result.Latitude}";
                txtLongitud.Text = $"{result.Longitude}";
            }
            else
            {
                await DisplayAlert("Error", "Debe activar el gps", "OK");
            }

        }

        
        private async void ubicacionesSave_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.UbicacionesPage());
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (txtLatitud.Text == null)
            {
                await DisplayAlert("Error", "Es necesario tener una Latitud", "OK");
                return;
            }
            if (txtLongitud.Text == null)
            {
                await DisplayAlert("Error", "Es necesario tener una Longitud", "OK");
                return;
            }
            if (txtDescripcion.Text == null)
            {
                await DisplayAlert("Error", "Es decribir la ubicacion", "OK");
                return;
            }
            if (txtDescripcionCorta.Text == null)
            {
                await DisplayAlert("Error", "Es decribir una ubicacion corta", "OK");
                return;
            }
            try
            {
               

                var ubicacion = new Models.Localizacion()
                {
                    Latitud = txtLatitud.Text,
                    Longitud = txtLongitud.Text,
                    Descripcion = txtDescripcion.Text,
                    DescripcionCorta = txtDescripcionCorta.Text
                };

               

                var resultado = await App.BaseDatos.GuardarUbicacion(ubicacion);

                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Ingreso Exitoso", "OK");
                    //ClearScreen();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la ubicacion", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }
        }

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.UbicacionesPage());
        }

        
        private void ClearScreen()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtLongitud.Text = string.Empty;
            this.txtLatitud.Text = string.Empty;
            this.txtDescripcionCorta.Text = string.Empty;
        }

        private async void mapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.MapPage());
        }
    }
}
