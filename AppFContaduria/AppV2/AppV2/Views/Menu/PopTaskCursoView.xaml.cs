using AppV2.Models;
using AppV2.Service;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace AppV2.Views.Cursos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopTaskCursoView 
    {
        public PopTaskCursoView()
        {
            InitializeComponent();

        }

        private async void BtnCrearCurso(object sender, EventArgs e)
        {
            if (txtNombreCurso.Text.Trim().Equals("") || txtDesc.Text.Trim().Equals(""))
            {
                await DisplayAlert("Oops", "Ingrese todos los datos", "Aceptar");
                return;
            }
            CursosModels oCursos =new CursosModels()
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
        
        //private async void btnPick_Clicked(object sender, EventArgs e)
        //{
        //    await CrossMedia.Current.Initialize();
        //    try
        //    {
        //        file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
        //        {
        //            PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
        //        });
                
        //        if (file == null)
        //            return;
        //        imgChoosed.Source = ImageSource.FromStream(() =>
        //        {
        //            var imageStram = file.GetStream();
        //            return imageStram;
        //        });
        //        //await StoreImages(file.GetStream(), txtNombreCurso.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}
        //private async void btnStore_Clicked(object sender, EventArgs e)
        //{
        //    if (!CrossMedia.Current.IsPickPhotoSupported)
        //    {
        //        // El acceso a la galería no es compatible en el dispositivo
        //        return;
        //    }

        //    var opciones = new PickMediaOptions
        //    {
        //        PhotoSize = PhotoSize.Medium
        //    };

        //    var archivo = await CrossMedia.Current.PickPhotoAsync(opciones);

        //    if (archivo == null)
        //    {
        //        // No se seleccionó ninguna imagen
        //        return;
        //    }

        //    string urlImagen = await SubirImagenAsync(archivo);

        //    // Aquí puedes hacer algo con la URL de descarga de la imagen,
        //    // como mostrarla en una vista de imagen.

        //    archivo.Dispose();
        //}

        //public async Task<string> SubirImagenAsync(MediaFile archivo)
        //{
        //    var firebaseStorage = new FirebaseStorage("appfcontaduria-31160.appspot.com");

        //    // Genera un nombre de archivo único
        //    string nombreArchivo = Guid.NewGuid().ToString("N") + ".jpg";

        //    // Ruta dentro de Firebase Storage donde se almacenará la imagen
        //    string rutaImagen = "Cursos/" + nombreArchivo;
        //    // Sube el archivo a Firebase Storage
        //    var tareaSubida = firebaseStorage
        //        .Child(rutaImagen)
        //        .PutAsync(archivo.GetStream());

        //    // Espera a que la tarea de subida se complete
        //    string urlDescarga = await tareaSubida;

        //    return urlDescarga;

        //}
    }
}