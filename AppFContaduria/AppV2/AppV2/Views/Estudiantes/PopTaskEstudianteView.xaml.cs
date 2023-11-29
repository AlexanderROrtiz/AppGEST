using AppV2.Models;
using AppV2.Service;
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
    public partial class PopTaskEstudianteView
    {
        private List<CursosModels> oListaCurso;
        public PopTaskEstudianteView()
        {
            InitializeComponent();
            obtenerCursoE();
        }
        private async void BtnCrearEstudiante(object sender, EventArgs e)
        {
            //if (txtNombreEstudiante.Text.Trim().Equals("") || miPicker.SelectedItem.ToString().Trim().Equals(""))
            //{
            //    await DisplayAlert("Oops", "Ingrese todos los datos", "Aceptar");
            //    return;
            //}
            //EstudianteModels oEstudiante =new EstudianteModels()
            //{
            //    nombre = txtNombreEstudiante.Text,
            //    curso = miPicker.SelectedItem.ToString(),
            //};

            //bool resulta = await ApiServiceFirebase.AgregarEstudiante(oEstudiante);
            //if (resulta)
            //{
            //    await DisplayAlert("Mensaje", "Estudiante agregado", "Ok");
            //}
            //else
            //{
            //    await DisplayAlert("Mensaje", "No se pudo agregar el estudiante", "Ok");
            //}
        }
        private async void obtenerCursoE()
        {
            //if(AppSettings.oAuthentication.Email.Contains("docente"))
            //{
            //    oListaCurso = await ApiServiceFirebase.ObtenerCursoXProfesor(AppSettings.oAuthentication.Email.ToString());
            //}
            //else 
            //{
            //    oListaCurso = await ApiServiceFirebase.ObtenerCurso();                
            //}
            //foreach (var item in oListaCurso)
            //{
            //    miPicker.Items.Add(item.nombre);
            //}

        }
        private void Picker_SelectedIndexChangedE(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            bool focused = picker.IsFocused;
            picker.ItemsSource = oListaCurso;

        }
    }
}