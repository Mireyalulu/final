using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regis_usu : ContentPage
    {
        public Regis_usu()
        {
            InitializeComponent();
        }

        private async void btn_Registrarse_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtApellido.Text == null || txtCorreo.Text == null || txtTipousu.Text == null || txtContrasena.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new Registrosusuarios
                {
                    Id = txtID.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Correo = txtCorreo.Text,
                    Tipousu = txtTipousu.Text,
                    Contrasena = txtContrasena.Text


                };

                try
                {
                    await DataPage.Tabla.InsertAsync(datos);
                    await DisplayAlert("Exitoso", "Usuario agregado correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");
                }
            }
        }
    }
}

