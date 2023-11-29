using AppV2.Models;
using AppV2.Service;
using AppV2.ViewModels;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Graficas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageGraficas : ContentPage
	{
        public List<CursosModels> oListaCurso;
        public List<EstudianteModels> oListaEstudiante;
        public List<ProfesorModels> oListaProfesor;
        Microcharts_Data data = new Microcharts_Data();
        public PageGraficas ()
		{
			InitializeComponent ();
            obtenerRegistros();

        }
        private async void obtenerRegistros()
        {
            //oListaCurso = await ApiServiceFirebase.ObtenerCurso();
            //oListaEstudiante = await ApiServiceFirebase.ObtenerEstudiantes();
            //oListaProfesor = await ApiServiceFirebase.ObtenerProfesores();
            //Chartedemo1.Chart = new DonutChart { Entries = data.GetChart(oListaCurso, oListaEstudiante, oListaProfesor) };
        }
        private void BtnCerrarS(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageLogin();
        }
    }
}