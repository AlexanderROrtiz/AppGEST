using AppV2.Models;
using AppV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Materia.Tematica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetallesContenidoProgramatico : ContentPage
    {
        private string idSubject;

        public PageDetallesContenidoProgramatico(ThematicModel thematicModel)
        {
            InitializeComponent();
            idSubject = thematicModel.id_Subject;

            LabelNombreTematica.Text = thematicModel.name;
            LabelDescTematica.Text = thematicModel.description;

        }
        public void OnInicioClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            Application.Current.MainPage = new PageListMaterias();

        }
        public void OnAtrasClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageListContenidoProgramatico(idSubject);

        }

        private async void CerrarSesion(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Confirmación", "¿Seguro que desea cerrar sesión?", "Sí", "No");

            if (confirmacion)
            {
                // Elimina las propiedades de sesión
                Application.Current.Properties.Remove("token");
                Application.Current.Properties.Remove("IsLoggedIn");
                Application.Current.Properties.Remove("codeUsr");

                // Guarda los cambios en las propiedades
                await Application.Current.SavePropertiesAsync();

                // Redirige al inicio de sesión
                Application.Current.MainPage = new PageLogin();
            }
        }

    }
}