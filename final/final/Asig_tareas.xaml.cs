using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using Acr.UserDialogs;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Asig_tareas : ContentPage
    {
        public ObservableCollection<asignaciontareas> Items { get; set; }

        public static MobileServiceClient cliente;
        public static IMobileServiceTable<asignaciontareas> Tabla;
        public static MobileServiceUser usuario;
        public ObservableCollection<asignaciontareas> Items2 { get; set; }
        public static MobileServiceClient cliente2;
        public static IMobileServiceTable<asignaciontareas> Tabla2;
        string tarea;
        string dependencia, prioridad;

        public Asig_tareas(object selectedItem)
        {
            var dato = selectedItem as Registrosusuarios;
            BindingContext = dato;
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<asignaciontareas>();
            cliente2 = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla2 = cliente.GetTable<asignaciontareas>();
            LeerTareas();
            LeerTareasAsignada();

        }
        private async void LeerTareas()
        {

            IEnumerable<asignaciontareas> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<asignaciontareas>(elementos);
            int cont1 = Items.Count;
            await DisplayAlert("", "" + cont1, "ok");
            var List = new List<string>();
            for (int i = 0; i < cont1; i++)
            {
                List.Add(Items[i].Tarea);
            }
            pkrTarea.ItemsSource = List;

        }

        private async void LeerTareasAsignada()
        {
            IEnumerable<asignaciontareas> elementos2 = await Tabla2.ToEnumerableAsync();
            Items2 = new ObservableCollection<asignaciontareas>(elementos2);
            int cont = Items2.Count;
            var List = new List<string>();
            for (int i = 0; i < cont; i++)
            {
                List.Add(Items2[i].Tarea);
            }
            pkrDependenciaUser.ItemsSource = List;

        }
        private async void btnFecha_Clicked(object sender, EventArgs e)
        {
            var result = await UserDialogs.Instance.DatePromptAsync("Select date", DateTime.Now);
            if (result.Ok)
                txtFecha.Text = String.Format("{0:yyyy-MM-dd}", result.SelectedDate);
        }



        private void pkrTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                tarea = (string)picker.ItemsSource[selectedIndex];
            }

        }

        private void pkrPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                prioridad = (string)picker.ItemsSource[selectedIndex];
            }
        }


        private void pkrDependenciaUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex != -1)
            {
                dependencia = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            var data = new asignaciontareas
            {
                Asignado = txtid.Text,
                Tarea = tarea,
                Prioridad = prioridad,
                FechaAsig = Convert.ToDateTime(fecha),
                FechaTerm = Convert.ToDateTime(txtFecha.Text),
                Estatus = "Creada"
            };

            try
            {
                await Tabla2.InsertAsync(data);
                LeerTareasAsignada();
                await DisplayAlert("Correcto", "Tarea asignada correctamente", "Ok");

            }
            catch (Exception error)
            {
                await DisplayAlert("error", "" + error, "Ok");
            }
        }

    }



}