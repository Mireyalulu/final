using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productos : ContentPage
    {
        public ObservableCollection<productos> Items { get; set; }

        public static MobileServiceClient cliente;
        public static IMobileServiceTable<productos> Tabla;
        public static MobileServiceUser usuario;

        public Productos()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<productos>();
            if (usuario != null) { LeerTabla(); };
        }

        private async void LeerTabla()
        {
            IEnumerable<productos> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<productos>(elementos);
            BindingContext = this;
            //Lista.ItemsSource = Items;
        }

        private async void btn_Producto_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtDescripcion.Text == null || txtPrecio.Text == null || txtImagen.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new productos
                {

                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = txtPrecio.Text,
                    Imagen = txtImagen.Text

                };

                try
                {
                    await Tabla.InsertAsync(datos);
                    await DisplayAlert("Agregado", "Producto Agregado Correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");
                }
            }
        }

        private async void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtDescripcion.Text == null || txtPrecio.Text == null || txtImagen.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new productos
                {
                    Id = txtID.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = txtPrecio.Text,
                    Imagen = txtImagen.Text
                };
                try
                {
                    await Tabla.UpdateAsync(datos);
                    await DisplayAlert("Actualizacion", "Tarea Actualizada correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");

                }
            }
        }

        private async void Button_Eliminar_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtDescripcion.Text == null || txtPrecio.Text == null || txtImagen.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new productos
                {
                    Id = txtID.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = txtPrecio.Text,
                    Imagen = txtImagen.Text
                };
                try
                {
                    await Tabla.DeleteAsync(datos);
                    await DisplayAlert("Eliminado", "Tarea Eliminada correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");

                }
            }
        }
    }
}