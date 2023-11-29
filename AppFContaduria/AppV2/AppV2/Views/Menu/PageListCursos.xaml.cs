using AppV2.Models;
using AppV2.Service;
using AppV2.ViewModels;
using Microcharts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Cursos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListCursos : ContentPage
    {
        public List<CursosModels> oListaCurso;
        
        public PageListCursos()
        {
            InitializeComponent();
            
            obtenerCurso();
            
        }
        private async void obtenerCurso()
        {
            //oListaCurso = await ApiServiceFirebase.ObtenerCurso();
            //ListViewCurso.ItemsSource = oListaCurso;
        }
        private void BtnpantallaCrearCurso_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new PopTaskCursoView());
        }
        private void BtnCerrarS(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageLogin();

        }
    }
}