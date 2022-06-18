using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02E10056.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionesPage : ContentPage
    {
        
        Models.Localizacion item;
        public UbicacionesPage()
        {
            InitializeComponent();
        }

        private  void lsUbicacion_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            item = (Models.Localizacion)e.Item;
        }


     
        private async void Mapa_Clicked_1(object sender, EventArgs e)
        {
            if (item == null)
            {
                await DisplayAlert("Error", "Debe seleccionar una fila", "OK");
                return;
            }

            bool answer = await DisplayAlert("Accion", "Desea ir a la ubicacion indicada?", "Si", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                if (!Double.TryParse(item.Latitud, out double lat))
                {
                    return;

                }
                if (!Double.TryParse(item.Longitud, out double lng))
                {
                    return;

                }

                await Map.OpenAsync(lat, lng, new MapLaunchOptions
                {
                    Name =item.Descripcion,
                    NavigationMode = NavigationMode.None

                });



            }

        }

        private async void Actualizar_Clicked(object sender, EventArgs e)

        {
            if (item == null)
            {
                await DisplayAlert("Error", "Debe seleccionar una fila", "OK");
                return;
            }

            try
            {

                var ubicacion = new Models.Localizacion()
                {
                    codigo = item.codigo,
                    Latitud = item.Latitud,
                    Longitud = item.Longitud,
                    Descripcion = item.Descripcion,
                    DescripcionCorta = item.DescripcionCorta,
                };



                var resultado = await App.BaseDatos.EliminarUbicacion(ubicacion);

                bool answer = await DisplayAlert("Accion", "Desea eliminar este registro?", "Si", "No");
                Debug.WriteLine("Answer: " + answer);
                if (answer == true)
                {
                   
                    await Navigation.PushAsync(new Views.UbicacionesPage());

                }
                else
                {
                    await DisplayAlert("Error", "No se pudo eliminar la ubicacion", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }


}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listaUbicaciones = await App.BaseDatos.ObtenerListaUbicacion();
            lsUbicacion.ItemsSource = listaUbicaciones;
        }

        
    }
}