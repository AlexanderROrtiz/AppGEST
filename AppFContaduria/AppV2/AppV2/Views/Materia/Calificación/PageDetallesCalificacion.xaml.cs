using Acr.UserDialogs;
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
    public partial class PageDetallesCalificacion : ContentPage
    {
        private ApiServiceMongo apiService;
        public QualificationModel oQualificationModel;
        private SubjectModel oSubject;
        public PageDetallesCalificacion(string idSubj)
        {
            InitializeComponent();
            apiService = new ApiServiceMongo();
            //LabelNombreTematica.Text = nombreTematica;
            oSubject = new SubjectModel {_id= idSubj, name= Application.Current.Properties["nameSubject"].ToString() };
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
            //await Navigation.PopAsync();
            Application.Current.MainPage = new PageDetallesMateria(oSubject);


        }
        public async void BtnGuardarCalificacion(object sender, EventArgs e)
        {
            try
            {
                // Obtén el comentario del editor
                string comentario = EditorComentario.Text;
                //  lógica de guardado
                UserDialogs.Instance.ShowLoading("Cargando Por favor espere...");

                UserAuthentication oUser = new UserAuthentication { editor = comentario };

                oQualificationModel = new QualificationModel
                {
                    commit_Qualification = EditorComentario.Text,
                    Day = Convert.ToString((int)DateTime.Now.DayOfWeek),
                    Qualification = ratingbarFron.SelectedStarValue.ToString(),
                    Time = DateTime.Now.ToString("hh:mm:ss tt"),
                    id_Subject = oSubject._id

                };
                bool respuestaApi = await apiService.SaveQualification(oQualificationModel);

                // Oculta el indicador de carga
                UserDialogs.Instance.HideLoading();

                if (respuestaApi)
                {
                    await DisplayAlert("Mensaje", "Calificación recibida", "OK");
                    Application.Current.MainPage = new PageDetallesMateria(oSubject);

                }
                else
                {
                    await DisplayAlert("Mensaje", "La Calificación no se guardo correctamente", "OK");
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                // Manejar la excepción de falta de conexión
                await DisplayAlert("Error", "No se pudo establecer conexión con el servidor. Verifica tu conexión a Internet.", "OK");
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones (puede ser lentitud del servidor u otros errores)
                await DisplayAlert("Error", "Ocurrió un error al intentar guardar la calificación.", "OK");
            }
        }

    }
}