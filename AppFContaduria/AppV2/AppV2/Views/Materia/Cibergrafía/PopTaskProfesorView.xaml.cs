using AppV2.Models;
using AppV2.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.Profesores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopTaskProfesorView
    {
        public List<CursosModels> oListaCurso;
        public PopTaskProfesorView()
        {
            InitializeComponent();
            obtenerCurso();
        }
        private async void BtnCrearCurso(object sender, EventArgs e)
        {
            if (txtNombreCurso.Text.Trim().Equals("") || txtDesc.Text.Trim().Equals(""))
            {
                await DisplayAlert("Oops", "Ingrese todos los datos", "Aceptar");
                return;
            }
            CursosModels oCursos = new CursosModels()
            {
                nombre = txtNombreCurso.Text,
                descripcion = txtDesc.Text,
            };

            //bool resulta = await ApiServiceFirebase.AgregarenCurso(oCursos);
            //if (resulta)
            //{
            //    await DisplayAlert("Mensaje", "Curso agregado", "Ok");
            //}
            //else
            //{
            //    await DisplayAlert("Mensaje", "No se pudo agregar el curso", "Ok");
            //}
        }
        private async void obtenerCurso()
        {
            //oListaCurso = await ApiServiceFirebase.ObtenerCurso();
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