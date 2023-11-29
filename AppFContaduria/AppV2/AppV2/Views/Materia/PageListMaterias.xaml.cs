using AppV2.Models;
using AppV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Materia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListMaterias : ContentPage
    {
        private ApiServiceMongo apiService;
        public List<SubjectModel> oListSubject;
        

        public PageListMaterias()
        {
            InitializeComponent();
            apiService = new ApiServiceMongo();
            ListSubject();
            listaMaterias.ItemSelected += ListViewClase_ItemSelected;

        }
        private async void ListSubject()
        {
            oListSubject = await apiService.ListSubjectForEstudent();
            // Asignar la lista al ListView
            listaMaterias.ItemsSource = oListSubject;
        }
        private void ListViewClase_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
                return;

            var selectedItem = (SubjectModel)e.SelectedItem;

            // Usamos MainPage.Navigation para realizar la navegación
            Application.Current.MainPage = new PageDetallesMateria(selectedItem);
            // Desmarca el elemento seleccionado
            listaMaterias.SelectedItem = null;
        }

        private async void UrlFupInformacion(object sender, EventArgs e)
        {
            string url = "https://fup.edu.co/"; // Reemplaza con la URL
            await Launcher.OpenAsync(new Uri(url));
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
