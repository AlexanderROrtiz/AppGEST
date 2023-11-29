using AppV2.Models;
using AppV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Materia.Tematica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetallesBibliografia : ContentPage
    {
        private ApiServiceMongo apiService;
        public List<BibliographyModel> oListSubject;
        private SubjectModel oSubject;

        public PageDetallesBibliografia(string _idSubject)
        {
            InitializeComponent();
            apiService = new ApiServiceMongo();
            ListSubject(_idSubject);
            // Asignar la lista al ListView
            bibliographyListView.ItemsSource = oListSubject;

            oSubject = new SubjectModel { _id = _idSubject, name = Application.Current.Properties["nameSubject"].ToString() };
        }
        private async void ListSubject(string _idSubject)
        {
            oListSubject = await apiService.ListBibliographyForSubject(_idSubject);
            // Asignar la lista al ListView
            bibliographyListView.ItemsSource = oListSubject;
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

        public async void OnInicioClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            Application.Current.MainPage = new PageListMaterias();

        }
        public async void OnAtrasClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageDetallesMateria(oSubject);
        }

    }
}