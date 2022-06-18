using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02E10056.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private void ClearScreen()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtLongitud.Text = string.Empty;
            this.txtLatitud.Text = string.Empty;
            this.txtDescripcionCorta.Text = string.Empty;
        }

        private async void ToollBarActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ubicacion = new Models.Localizacion()
                {
                    codigo = Convert.ToInt32(txtId.Text),
                    Longitud = txtLongitud.Text,
                    Latitud = txtLatitud.Text,
                    Descripcion = txtDescripcion.Text,
                    DescripcionCorta = txtDescripcionCorta.Text


                };

                var resultado = await App.BaseDatos.GuardarUbicacion(ubicacion);

                if (resultado > 0)
                {
                    await DisplayAlert("Actilizar", "Datos actuliazados correctamente", "OK");
                    await Navigation.PushAsync(new Views.UbicacionesPage());
                    ClearScreen();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo actualizar la ubicacion", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "OK");
            }
        }

        private async void ToolBarEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ubicacion = new Models.Localizacion()
                {
                    codigo = Convert.ToInt32(txtId.Text),
                    Longitud = txtLongitud.Text,
                    Latitud = txtLatitud.Text,
                    Descripcion = txtDescripcion.Text,
                    DescripcionCorta = txtDescripcionCorta.Text


                };

                var resultado = await App.BaseDatos.EliminarUbicacion(ubicacion);

                if (resultado > 0)
                {
                    await DisplayAlert("Eliminar", "Datos eliminados correctamente", "OK");
                    await Navigation.PushAsync(new Views.UbicacionesPage());
                    ClearScreen();
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

        private async void Principal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.UbicacionesPage());
        }
    }
}