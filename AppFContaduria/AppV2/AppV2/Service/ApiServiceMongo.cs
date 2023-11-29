using AppV2.Models;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppV2.Service
{
    public class ApiServiceMongo
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static string globalToken = Application.Current.Properties["token"].ToString();
        public async Task<List<SubjectModel>> ListSubjectForEstudent()
        {
            try
            {
                Dictionary<string, SubjectModel> oObject = new Dictionary<string, SubjectModel>();
                List<SubjectModel> oListaCurso = new List<SubjectModel>();
                //  URL completa concatenando 
                string apiUrl = AppSettings.ApiServiceMongo + "get-Student/"+ Application.Current.Properties["codeUsr"].ToString();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalToken);

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        oListaCurso = JsonConvert.DeserializeObject<List<SubjectModel>>(jsonstring);
                    }
                }
                return oListaCurso;
                

            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren.
                return null;
            }
            
        }

        #region (Contenido Programatico (Thematic))
        public async Task<List<ThematicModel>> ListThematicForSubject(string idSubject)
        {
            try
            {
                Dictionary<string, ThematicModel> oObject = new Dictionary<string, ThematicModel>();
                List<ThematicModel> oListaThematic = new List<ThematicModel>();
                //  URL completa concatenando 
                string apiUrl = AppSettings.ApiServiceMongo + "Get-Thematics-By-Subject/" + idSubject;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalToken);

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        oListaThematic = JsonConvert.DeserializeObject<List<ThematicModel>>(jsonstring);
                    }
                }
                return oListaThematic;
            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren.
                return null;
            }
        }
        #endregion

        #region(Bibliography)
        public async Task<List<BibliographyModel>> ListBibliographyForSubject(string idSubject)
        {
            try
            {
                Dictionary<string, BibliographyModel> oObject = new Dictionary<string, BibliographyModel>();
                List<BibliographyModel> oListaBibliography = new List<BibliographyModel>();
                //  URL completa concatenando 
                string apiUrl = AppSettings.ApiServiceMongo + "Get-Bibliography-By-Subject/" + idSubject;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalToken);

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        oListaBibliography = JsonConvert.DeserializeObject<List<BibliographyModel>>(jsonstring);
                    }
                }
                return oListaBibliography;
            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren.
                return null;
            }
        }
        #endregion

        #region(Cybergraphy)
        public async Task<List<CybergraphyModel>> ListCybergraphyForSubject(string idSubject)
        {
            try
            {
                Dictionary<string, CybergraphyModel> oObject = new Dictionary<string, CybergraphyModel>();
                List<CybergraphyModel> oListaCybergraphy = new List<CybergraphyModel>();
                //  URL completa concatenando 
                string apiUrl = AppSettings.ApiServiceMongo + "Get-cybergraphy-By-Subject/" + idSubject;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalToken);

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        oListaCybergraphy = JsonConvert.DeserializeObject<List<CybergraphyModel>>(jsonstring);
                    }
                }
                return oListaCybergraphy;
            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren.
                return null;
            }
        }
        #endregion

        #region(Qualification)
        public async Task<bool> SaveQualification(QualificationModel dataToSave)
        {
            try
            {
                // URL completa para guardar los datos
                string apiUrl = AppSettings.ApiServiceMongo + "Create-Qualification";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalToken);

                // Serializar el objeto a JSON
                var jsonContent = JsonConvert.SerializeObject(dataToSave);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    // La operación de guardado fue exitosa
                    return true;
                }
                else
                {
                    // La operación de guardado falló
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren.
                return false;
            }
        }

        #endregion

        #region(Semi_annual_cut_off)
        public async Task<List<Semi_annual_cut_offModels>> ListSemi_annual_cut_offForSubject(string idSubject)
        {
            try
            {
                Dictionary<string, Semi_annual_cut_offModels> oObject = new Dictionary<string, Semi_annual_cut_offModels>();
                List<Semi_annual_cut_offModels> oListaSemi_annual_cut_offModels = new List<Semi_annual_cut_offModels>();
                //  URL completa concatenando 
                string apiUrl = AppSettings.ApiServiceMongo + "Get-Semi_annual_cut_off-By-Subject/" + idSubject;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalToken);

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        oListaSemi_annual_cut_offModels = JsonConvert.DeserializeObject<List<Semi_annual_cut_offModels>>(jsonstring);
                    }
                }
                return oListaSemi_annual_cut_offModels;
            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren.
                return null;
            }
        }
        #endregion

    }
}
