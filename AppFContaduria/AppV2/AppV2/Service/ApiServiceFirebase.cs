using AppV2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppV2.Service
{
    //public class ApiServiceFirebase
    //{
    //    #region[Cursos]
        
    //    public static async Task<List< CursosModels>> ObtenerCurso()
    //    {
    //        Dictionary<string, CursosModels> oObject = new Dictionary<string, CursosModels>();
    //        List<CursosModels> oListaCurso = new List<CursosModels>();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            string apiurlformat = string.Concat(AppSettings.ApiFirebase, "Curso.json?auth={0}");
    //            var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                var jsonstring = await response.Content.ReadAsStringAsync();

    //                if (jsonstring != "null")
    //                {

    //                    oObject = JsonConvert.DeserializeObject<Dictionary< string, CursosModels >>(jsonstring);
    //                    foreach (KeyValuePair<string, CursosModels> item in oObject)
    //                    {
    //                        oListaCurso.Add(new CursosModels()
    //                        {
    //                            nombre = item.Value.nombre,
    //                            descripcion = item.Value.descripcion
                               
    //                        });
    //                    }
    //                }
    //                return oListaCurso;
    //            }
    //            else
    //            {
    //                oListaCurso = null;
    //                return oListaCurso;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            oListaCurso = null;
    //            return oListaCurso;
    //        }

    //    }

    //    public static async Task<List<CursosModels>> ObtenerCursoXProfesor(string profesor)
    //    {
    //        Dictionary<string, CursosModels> oObject = new Dictionary<string, CursosModels>();
    //        List<CursosModels> oListaCurso = new List<CursosModels>();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            string apiurlformat = string.Concat(AppSettings.ApiFirebase, "Curso.json?auth={0}");
    //            var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                var jsonstring = await response.Content.ReadAsStringAsync();

    //                if (jsonstring != "null")
    //                {

    //                    oObject = JsonConvert.DeserializeObject<Dictionary<string, CursosModels>>(jsonstring);
    //                    foreach (KeyValuePair<string, CursosModels> item in oObject)
    //                    {
    //                        if(profesor == item.Value.descripcion)
    //                        {
    //                            oListaCurso.Add(new CursosModels()
    //                            {
    //                                nombre = item.Value.nombre,
    //                                descripcion = item.Value.descripcion

    //                            });
    //                        }

                            
    //                    }
    //                }
    //                return oListaCurso;
    //            }
    //            else
    //            {
    //                oListaCurso = null;
    //                return oListaCurso;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            oListaCurso = null;
    //            return oListaCurso;
    //        }

    //    }

    //    public static async Task<bool> AgregarenCurso(CursosModels oCurso)
    //    {
    //        UserAuthentication oObject = new UserAuthentication();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            var body = JsonConvert.SerializeObject(oCurso);
    //            var content = new StringContent(body, Encoding.UTF8, "application/json");


    //            string apiformat = string.Concat(AppSettings.ApiFirebase, "Curso.json?auth={1}");
    //            var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            return false;
    //        }

    //    }
    //    #endregion

    //    #region[Estudiantes]
    //    public static async Task<List<EstudianteModels>> ObtenerEstudiantes()
    //    {
    //        Dictionary<string, EstudianteModels> oObject = new Dictionary<string, EstudianteModels>();
    //        List<EstudianteModels> oListaCurso = new List<EstudianteModels>();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            string apiurlformat = string.Concat(AppSettings.ApiFirebase, "Estudiante.json?auth={0}");
    //            var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                var jsonstring = await response.Content.ReadAsStringAsync();

    //                if (jsonstring != "null")
    //                {

    //                    oObject = JsonConvert.DeserializeObject<Dictionary<string, EstudianteModels>>(jsonstring);
    //                    foreach (KeyValuePair<string, EstudianteModels> item in oObject)
    //                    {
    //                        oListaCurso.Add(new EstudianteModels()
    //                        {
    //                            nombre = item.Value.nombre,
    //                            curso = item.Value.curso

    //                        });
    //                    }
    //                }
    //                return oListaCurso;
    //            }
    //            else
    //            {
    //                oListaCurso = null;
    //                return oListaCurso;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            oListaCurso = null;
    //            return oListaCurso;
    //        }

    //    }
    //    public static async Task<bool> AgregarEstudiante(EstudianteModels oCurso)
    //    {
    //        UserAuthentication oObject = new UserAuthentication();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            var body = JsonConvert.SerializeObject(oCurso);
    //            var content = new StringContent(body, Encoding.UTF8, "application/json");


    //            string apiformat = string.Concat(AppSettings.ApiFirebase, "Estudiante.json?auth={1}");
    //            var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            return false;
    //        }

    //    }
    //    #endregion

    //    #region[Profesor]
    //    public static async Task<List<ProfesorModels>> ObtenerProfesores()
    //    {
    //        Dictionary<string, ProfesorModels> oObject = new Dictionary<string, ProfesorModels>();
    //        List<ProfesorModels> oListaCurso = new List<ProfesorModels>();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            string apiurlformat = string.Concat(AppSettings.ApiFirebase, "Estudiante.json?auth={0}");
    //            var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                var jsonstring = await response.Content.ReadAsStringAsync();

    //                if (jsonstring != "null")
    //                {

    //                    oObject = JsonConvert.DeserializeObject<Dictionary<string, ProfesorModels>>(jsonstring);
    //                    foreach (KeyValuePair<string, ProfesorModels> item in oObject)
    //                    {
    //                        oListaCurso.Add(new ProfesorModels()
    //                        {
    //                            nombre = item.Value.nombre,
    //                            materia = item.Value.materia

    //                        });
    //                    }
    //                }
    //                return oListaCurso;
    //            }
    //            else
    //            {
    //                oListaCurso = null;
    //                return oListaCurso;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            oListaCurso = null;
    //            return oListaCurso;
    //        }

    //    }
    //    public static async Task<bool> AgregarProfesor(ProfesorModels oCurso)
    //    {
    //        UserAuthentication oObject = new UserAuthentication();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            var body = JsonConvert.SerializeObject(oCurso);
    //            var content = new StringContent(body, Encoding.UTF8, "application/json");


    //            string apiformat = string.Concat(AppSettings.ApiFirebase, "Profesor.json?auth={1}");
    //            var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            return false;
    //        }

    //    }
    //    #endregion

    //    #region[Clase]
    //    public static async Task<List<ClaseModels>> ObtenerClases()
    //    {
    //        Dictionary<string, ClaseModels> oObject = new Dictionary<string, ClaseModels>();
    //        List<ClaseModels> oListaClase = new List<ClaseModels>();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            string apiurlformat = string.Concat(AppSettings.ApiFirebase, "Clase.json?auth={0}");
    //            var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                var jsonstring = await response.Content.ReadAsStringAsync();

    //                if (jsonstring != "null")
    //                {

    //                    oObject = JsonConvert.DeserializeObject<Dictionary<string, ClaseModels>>(jsonstring);
    //                    foreach (KeyValuePair<string, ClaseModels> item in oObject)
    //                    {
    //                        oListaClase.Add(new ClaseModels()
    //                        {
    //                            nombre = item.Value.nombre,
    //                            dia = item.Value.dia,
    //                            hora = item.Value.hora

    //                        });
    //                    }
    //                }
    //                return oListaClase;
    //            }
    //            else
    //            {
    //                oListaClase = null;
    //                return oListaClase;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            oListaClase = null;
    //            return oListaClase;
    //        }

    //    }

    //    public static async Task<bool> AgregaClase(ClaseModels oCurso)
    //    {
    //        UserAuthentication oObject = new UserAuthentication();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            var body = JsonConvert.SerializeObject(oCurso);
    //            var content = new StringContent(body, Encoding.UTF8, "application/json");


    //            string apiformat = string.Concat(AppSettings.ApiFirebase, "Clase.json?auth={1}");
    //            var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            return false;
    //        }

    //    }
    //    #endregion

    //    #region[Calificacion Clase]
    //    public static async Task<bool> AgregaCalificacionClase(CalificarClase oCurso)
    //    {
    //        UserAuthentication oObject = new UserAuthentication();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            var body = JsonConvert.SerializeObject(oCurso);
    //            var content = new StringContent(body, Encoding.UTF8, "application/json");


    //            string apiformat = string.Concat(AppSettings.ApiFirebase, "CalificacionClase.json?auth={1}");
    //            var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            return false;
    //        }

    //    }
    //    public static async Task<List<CalificarClase>> ObtenerCalificacionClases(string estudiante, string clase)
    //    {
    //        Dictionary<string, CalificarClase> oObject = new Dictionary<string, CalificarClase>();
    //        List<CalificarClase> oListaClase = new List<CalificarClase>();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            string apiurlformat = string.Concat(AppSettings.ApiFirebase, "CalificacionClase.json?auth={0}");
    //            var response = await client.GetAsync(string.Format(apiurlformat, AppSettings.oAuthentication.IdToken));
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                var jsonstring = await response.Content.ReadAsStringAsync();

    //                if (jsonstring != "null")
    //                {

    //                    oObject = JsonConvert.DeserializeObject<Dictionary<string, CalificarClase>>(jsonstring);
    //                    foreach (KeyValuePair<string, CalificarClase> item in oObject)
    //                    {
    //                        if(estudiante == item.Value.estudiante && clase == item.Value.nombreClase)
    //                        {
    //                            oListaClase.Add(new CalificarClase()
    //                            {
    //                                nombreClase = item.Value.nombreClase,
    //                                estudiante = item.Value.estudiante,
    //                                calificacion = item.Value.calificacion

    //                            });
    //                        }
                            
    //                    }
    //                }
    //                return oListaClase;
    //            }
    //            else
    //            {
    //                oListaClase = null;
    //                return oListaClase;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            oListaClase = null;
    //            return oListaClase;
    //        }

    //    }

    //    #endregion

    //    #region[Tema]
    //    public static async Task<bool> AgregarTema(TemaModels oTema)
    //    {
    //        UserAuthentication oObject = new UserAuthentication();
    //        try
    //        {
    //            HttpClient client = new HttpClient();
    //            var body = JsonConvert.SerializeObject(oTema);
    //            var content = new StringContent(body, Encoding.UTF8, "application/json");


    //            string apiformat = string.Concat(AppSettings.ApiFirebase, "Subirinformacion.json?auth={1}");
    //            var response = await client.PostAsync(string.Format(apiformat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), content);
    //            if (response.StatusCode.Equals(HttpStatusCode.OK))
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string t = ex.Message;
    //            return false;
    //        }

    //    }
    //    #endregion
    //}
}
