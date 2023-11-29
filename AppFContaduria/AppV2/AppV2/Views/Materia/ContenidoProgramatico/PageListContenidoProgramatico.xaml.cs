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
    public partial class PageListContenidoProgramatico : ContentPage
    {
        private ApiServiceMongo apiService;
        public List<ThematicModel> oListSThematic;
        private SubjectModel oSubject;

        public PageListContenidoProgramatico(string _id)
        {
            InitializeComponent();
            apiService = new ApiServiceMongo();
            ListThematict(_id);
            ListSThematicView.ItemSelected += ListViewClase_ItemSelected;
            oSubject = new SubjectModel { _id = _id, name = Application.Current.Properties["nameSubject"].ToString() };
        }
        private async void ListThematict(string _id)
        {
            oListSThematic = await apiService.ListThematicForSubject(_id);
            // Asignar la lista al ListView
            ListSThematicView.ItemsSource = oListSThematic;
        }
        private void ListViewClase_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
                return;

            var selectedItem = (ThematicModel)e.SelectedItem;

            // Usamos MainPage.Navigation para realizar la navegación
            Application.Current.MainPage = new PageDetallesContenidoProgramatico(selectedItem);
            // Desmarca el elemento seleccionado
            ListSThematicView.SelectedItem = null;
        }
        private void OnTematicaClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string nombreTematica = button.Text;

            // Aquí puedes navegar a PageDetallesTematicas y pasar el nombreTematica como parámetro
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