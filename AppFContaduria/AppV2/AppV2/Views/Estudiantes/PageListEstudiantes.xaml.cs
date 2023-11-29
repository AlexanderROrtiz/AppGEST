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

namespace AppV2.Views.Estudiantes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListEstudiantes : ContentPage
    {
        public List<EstudianteModels> oListaEstudiante;
        public PageListEstudiantes()
        {
            InitializeComponent();
            obtenerCurso();
        }
        private async void obtenerCurso()
        {
            //oListaEstudiante = await ApiServiceFirebase.ObtenerEstudiantes();

            //ListViewEstudiante.ItemsSource = oListaEstudiante;
        }

        private void BtnpantallaCrearEstudiante_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new PopTaskEstudianteView());
        }
        private void BtnCerrarS(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageLogin();
        }
    }
}