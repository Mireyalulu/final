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
    public partial class Tareas : ContentPage
    {
        public ObservableCollection<Descripciones> Items { get; set; }
        public ObservableCollection<tareasmire> Items2 { get; set; }

        public static MobileServiceClient cliente;
        public static MobileServiceClient cliente2;
        public static IMobileServiceTable<Descripciones> Tabla;
        public static IMobileServiceTable<tareasmire> Tabla2;
        public static MobileServiceUser usuario;
        string descri;

 
            public Tareas()
        {
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            cliente2 = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<Descripciones>();
            Tabla2 = cliente2.GetTable<tareasmire>();
            
            LeerTareas();
        }

        private async void LeerTareas()
        {
            IEnumerable<tareasmire> elementos = await Tabla2.ToEnumerableAsync();
            Items2 = new ObservableCollection<tareasmire>(elementos);
            BindingContext = this;
            InitializeComponent();
        }


        

        private async void btntareas_Clicked(object sender, EventArgs e)
        {
            if (txtTarea.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new tareasmire
                {
                    Tarea = txtTarea.Text,
                    Descripcion = txtDescripcion.Text

                };
                try
                {
                    await Tabla2.InsertAsync(datos);
                    await DisplayAlert("Agregada", "Tarea agregada correctamente", "OK");
                   
                    LeerTareas();
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");
                }
            }

        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (txtTarea.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new tareasmire
                {
                    
                    Tarea = txtTarea.Text,
                    Descripcion = txtDescripcion.Text
                };
                try
                {
                    await Tabla2.UpdateAsync(datos);
                    await DisplayAlert("Actualizacion", "Tarea Actualizada correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");

                }
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            if (txtTarea.Text == null)
            {
                await DisplayAlert("Error", "Es obligatorio llenar todos los campos", "OK");
            }
            else
            {
                var datos = new tareasmire
                {
                    
                    Tarea = txtTarea.Text,
                    Descripcion = txtDescripcion.Text
                };
                try
                {
                    await Tabla2.DeleteAsync(datos);
                    await DisplayAlert("Eliminado", "Tarea Eliminada correctamente", "OK");
                }
                catch (Exception error)
                {
                    await DisplayAlert("error", "" + error, "OK");

                }
            }
        }

        private void ListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var dato = e.SelectedItem as tareasmire;
            DisplayAlert("Item Selected", "" + dato, "Ok");
            BindingContext = dato;

        }

       
    }
}