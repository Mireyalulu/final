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
    public partial class Administrador : ContentPage
    {
        public Administrador()
        {
            InitializeComponent();
            lbldata0.Text = "Id: " + final.DataPage.id;
            lbldata1.Text = "Nombre: " + final.DataPage.nombre + " " + final.DataPage.apellido + " ";
            lbldata2.Text = "Correo: " + final.DataPage.correo;
        }

        private async void btnPos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Tareas());
        }

        private async void btnUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Usuarrio());
        }

    }
}