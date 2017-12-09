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
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<Registrosusuarios> Items { get; set; }

        public static MobileServiceClient cliente;
        public static IMobileServiceTable<Registrosusuarios> Tabla;
        public static MobileServiceUser usuario;
        public static string id, nombre, apellido, correo, tipousu, contrasena;


        public DataPage()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<Registrosusuarios>();
            //Navigation.PushModalAsync(new Regis_usu());

        }

        private async void btn_Login_Clicked(object sender, EventArgs e)
        {
            if (txtUser.Text == null || txtPass.Text == null)
            {
                if (txtUser.Text == null) { txtUser.BackgroundColor = Color.Pink; }
                if (txtPass.Text == null) { txtPass.BackgroundColor = Color.Pink; }
                if (txtUser.Text != null) { txtUser.BackgroundColor = Color.Default; }
                if (txtPass.Text != null) { txtPass.BackgroundColor = Color.Default; }
            }
            else
            {
                try
                {
                    
                    IEnumerable<Registrosusuarios> elementos = await Tabla.Where(todoItem => todoItem.Id == txtUser.Text && todoItem.Contrasena == txtPass.Text).ToEnumerableAsync();
                    Items = new ObservableCollection<Registrosusuarios>(elementos);
                    int cont = Items.Count;
                    id = Items[0].Id;
                    nombre = Items[0].Nombre;
                    apellido = Items[0].Apellido;
                    correo = Items[0].Correo;
                    tipousu = Items[0].Tipousu;

                    if (cont == 1)
                    {
                        await DisplayAlert("Correcto", "Bienvenido " + id + " " + nombre + " " , "Ok");
                        if (tipousu == "Administrador")
                        {
                            await Navigation.PushModalAsync(new Administrador());
                        }else if (tipousu == "Usuario comun")

                        {
                            await Navigation.PushModalAsync(new Usuarrio());
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Ok");
                    }
                }
                catch
                {

                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (usuario != null)
            {
                LeerTabla();
            }
        }

        private async void LeerTabla()
        {
            IEnumerable<Registrosusuarios> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<Registrosusuarios>(elementos);
            BindingContext = this;
            //Lista.ItemsSource = Items;
        }

        private void btn_Registrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Regis_usu());
        }
    }
}