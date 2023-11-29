using AppV2.Models;
using AppV2.Service;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Profesores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListProfesores : ContentPage
    {
        public List<ProfesorModels> oListaProfesor;
        public PageListProfesores()
        {
            InitializeComponent();
            obtenerProfesor();
        }
        private async void obtenerProfesor()
        {
            //oListaProfesor = await ApiServiceFirebase.ObtenerProfesores();
            //ListViewProfesor.ItemsSource = oListaProfesor;
        }

        private void BtnpantallaCrearProfesor_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new PopTaskProfesorView());
        }
        private void BtnCerrarS(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageLogin();
        }
    }
}