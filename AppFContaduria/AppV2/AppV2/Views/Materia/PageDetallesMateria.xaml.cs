using AppV2.Models;
using AppV2.Views.Materia.Tematica;
using AppV2.Views.Profesores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Materia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetallesMateria : ContentPage
    {
        private string idSubject;
        public PageDetallesMateria(SubjectModel subjectModel)
        {
            InitializeComponent();
            idSubject = subjectModel._id;
            Application.Current.Properties["nameSubject"] = subjectModel.name;
            LabelNombreMateria.Text = subjectModel.name;
        }
        void ContenidoProgramaticoButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageListContenidoProgramatico(idSubject);
        }

        void BibliografiaButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageDetallesBibliografia(idSubject);
        }

        void CibergrafiaButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageDetallesCibergrafia(idSubject);
        }

        void EvaluacionButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageDetallesEvaluacion(idSubject);
        }
        void CalificacionButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageDetallesCalificacion(idSubject);
        }
        public void OnAtrasClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            Application.Current.MainPage = new PageListMaterias();

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