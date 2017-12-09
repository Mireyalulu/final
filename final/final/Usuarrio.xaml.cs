using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuarrio : ContentPage
    {
        private static IMobileServiceTable<Registrosusuarios> tabla;
        public static MobileServiceClient cliente;
        public ObservableCollection<Registrosusuarios> Items { get; set; }
        public Usuarrio()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            tabla = cliente.GetTable<Registrosusuarios>();
            leerAlumnos();
        }
        private async void leerAlumnos()
        {
            IEnumerable<Registrosusuarios> elementos = await tabla.ToEnumerableAsync();
            Items = new ObservableCollection<Registrosusuarios>(elementos);
            BindingContext = this;
            InitializeComponent();
        }


        private async void btnreg_Clicked(object sender, EventArgs e)
        {
            if (txtuser.Text == null || txtnombre.Text == null || txtapellido.Text == null || txtcorreo.Text == null || txttipousu.Text == null)
            {
                await DisplayAlert("Error", "Debe llenar todos los campos", "Ok");
            }
            else
            {
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtuser.Text);
                string result = Convert.ToBase64String(encryted);
                var datos = new Registrosusuarios
                {
                    Id = txtuser.Text,
                    Nombre = txtnombre.Text,
                    Apellido = txtapellido.Text,
                    Correo = txtcorreo.Text,
                    Tipousu = txttipousu.Text,
                    Contrasena = result
                };

                try
                {
                    await tabla.InsertAsync(datos);
                    await DisplayAlert("Correcto", "El Usuario se a agregado correctamente", "Ok");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "Ok");
                }
            }
        }

    }
}