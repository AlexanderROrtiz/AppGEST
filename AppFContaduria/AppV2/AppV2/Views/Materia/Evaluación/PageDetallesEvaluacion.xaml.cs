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
    public partial class PageDetallesEvaluacion : ContentPage
    {
        private ApiServiceMongo apiService;
        public List<Semi_annual_cut_offModels> oSemi_annual_cut_offModels;
        private SubjectModel oSubject;
        
        public PageDetallesEvaluacion(string idSubj)
        {
            InitializeComponent();
            apiService = new ApiServiceMongo();
            ListSemi_annual_cut_off(idSubj);

            oSubject = new SubjectModel { _id = idSubj, name = Application.Current.Properties["nameSubject"].ToString() };

        }
        private async void ListSemi_annual_cut_off(string _idSubject)
        {
            oSemi_annual_cut_offModels = await apiService.ListSemi_annual_cut_offForSubject(_idSubject);
            // Asignar la lista al ListView
            corte1ListView.ItemsSource = oSemi_annual_cut_offModels;
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