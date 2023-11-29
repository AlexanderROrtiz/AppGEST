using AppV2.Models;
using AppV2.Service;
using AppV2.Views.Profesores;
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
    public partial class PageDetallesCibergrafia : ContentPage
    {
        private ApiServiceMongo apiService;
        public List<CybergraphyModel> oListCybergraphyModel;
        private SubjectModel oSubject;

        public PageDetallesCibergrafia(string idSubject)
        {
            InitializeComponent();

            apiService = new ApiServiceMongo();
            ListSubject(idSubject);
            // Asignar la lista al ListView
            cibergraphyListView.ItemsSource = oListCybergraphyModel;

            oSubject = new SubjectModel { _id = idSubject, name = Application.Current.Properties["nameSubject"].ToString() };

        }
        private async void ListSubject(string _idSubject)
        {
            oListCybergraphyModel = await apiService.ListCybergraphyForSubject(_idSubject);
            // Asignar la lista al ListView
            cibergraphyListView.ItemsSource = oListCybergraphyModel;
        }
        private async void UrlLabelTapped(object sender, EventArgs e)
        {
            if (sender is Label label && label.Text is string url)
            {
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    {
                        url = "http://" + url; // Agrega http:// si no está presente
                    }
                    await Launcher.OpenAsync(new Uri(url));
                }
            }
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

        public void OnInicioClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            Application.Current.MainPage = new PageListMaterias();

        }
        public void OnAtrasClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageDetallesMateria(oSubject);

        }

    }
}