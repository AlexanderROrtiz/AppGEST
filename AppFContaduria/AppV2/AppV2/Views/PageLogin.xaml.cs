using Acr.UserDialogs;
using AppV2.Models;
using AppV2.Service;
using AppV2.ViewModels;
using AppV2.Views.Materia;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : ContentPage
    {
        private ApiServiceAuthentication apiService;
        private ValidateConnection validateConn;
        private bool sesionGuardada = false;
        private bool isCheckedEventHandled = false;
        public PageLogin()
        {
            InitializeComponent();
            apiService = new ApiServiceAuthentication();
            validateConn = new ValidateConnection();
            ValidarConx();
        }
        private async void ValidarConx()
        {
            bool validacionCon = validateConn.IsInternetConnected();
            if (!validacionCon) await DisplayAlert("Mensaje", "No tienes conexión a internet", "OK");

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // Patrón de expresión regular para validar un correo electrónico
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                Regex regex = new Regex(pattern);

                // Verificar si el correo electrónico coincide con el patrón
                return regex.IsMatch(email);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                await DisplayAlert("Información", "Debes ingresar un Usuario y Contraseña para inciar la sesión", "Aceptar");
                return;
            }

            // Validar el formato del correo electrónico
            if (!IsValidEmail(txtEmail.Text))
            {
                await DisplayAlert("Información", "Ingrese un correo electrónico válido", "Aceptar");
                return;
            }

            UserAuthentication oUser = new UserAuthentication { email = txtEmail.Text, password = txtContrasena.Text };

            try
            {
                UserDialogs.Instance.ShowLoading("Cargando Por favor espere...");
                // Llama al método SignInAsync de ApiServiceMongo
                string responseContent = await apiService.Login(oUser);

                // Modificación para manejar casos de correo o contraseña incorrectos
                if (responseContent.Contains("Error de autenticación"))
                {
                    await DisplayAlert("Información", "Usuario o Contraseña incorrecta", "OK");
                    return;
                }

                // Deserializa la respuesta JSON en un objeto User
                ApiResponseUser user = JsonConvert.DeserializeObject<ApiResponseUser>(responseContent);

                if (!string.IsNullOrEmpty(user.Token))
                {
                    if (user.Role == "Estudiante")
                    {
                        Application.Current.Properties["token"] = user.Token.Trim();
                        Application.Current.Properties["IsLoggedIn"] = true;
                        Application.Current.Properties["codeUsr"] = user.code_User;
                        Application.Current.MainPage = new PageListMaterias();


                    }
                    else
                    {
                        await DisplayAlert("Mensaje", "El usuario no es estudiante", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Oops", "Usuario no encontrado", "OK");

                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones, por ejemplo, falta de conexión
                await DisplayAlert("Error", "Ocurrió un error durante la autenticación. Verifica tu conexión a Internet.", "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void mantenerSesionIniciada(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                // Desvincula temporalmente el evento CheckedChanged
                keepSessionCheckBox.CheckedChanged -= mantenerSesionIniciada;

                string usuario = txtEmail.Text;
                string contrasena = txtContrasena.Text;

                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contrasena))
                {
                    string userToken = Application.Current.Properties["token"] as string;

                    if (e.Value) // CheckBox está marcado
                    {
                        Application.Current.Properties["AuthToken"] = userToken;
                        sesionGuardada = true;
                        await DisplayAlert("Información", "Sesión guardada con éxito", "OK");
                    }
                    else
                    {
                        if (sesionGuardada)
                        {
                            Application.Current.Properties.Remove("AuthToken");
                            sesionGuardada = false;
                            await DisplayAlert("Información", "Sesión eliminada con éxito", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Información", "No se encontró ninguna sesión para eliminar", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Información", "Debes ingresar un Usuario y Contraseña para guardar la sesión", "OK");
                    keepSessionCheckBox.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Información", "Inconvenientes técnicos en el proceso, un momento...", "OK");
            }
            finally
            {
                // Vuelve a vincular el evento CheckedChanged
                keepSessionCheckBox.CheckedChanged += mantenerSesionIniciada;
            }
        }

        private async void recuperarContraseña(object sender, EventArgs e)
        {
            string url = "https://fup.edu.co/"; // Reemplaza con la URL
            await Launcher.OpenAsync(new Uri(url));
            await DisplayAlert("Información", "Comunicate con el area de administración para actualizar contraseña ", "OK");
        }


    }
}