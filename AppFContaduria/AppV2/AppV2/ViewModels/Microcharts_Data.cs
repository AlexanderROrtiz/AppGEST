using Microcharts;
using SkiaSharp;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;
using AppV2.Models;
using AppV2.Service;

namespace AppV2.ViewModels
{
    public class Microcharts_Data
    {
               
        public List<Entry> GetChart( List<CursosModels> oListaCurso, List<EstudianteModels> oListaEstudiante, List<ProfesorModels> oListaProfesor)
        {
            List<Entry> data = new List<Entry>
        {
            new Entry(oListaCurso.Count())
            {
                Label = "Cursos",
                ValueLabel =Convert.ToString(oListaCurso.Count()),
                Color = SKColor.Parse("#3399FF"),
                TextColor = SKColor.Parse("#DF013A"),
            },
            new Entry(oListaEstudiante.Count())
            {
                Label = "Estudiantes",
                ValueLabel =Convert.ToString(oListaEstudiante.Count()),
                Color = SKColor.Parse("#F3FB75"),
                TextColor = SKColor.Parse("#DF013A"),
            },
            new Entry(oListaProfesor.Count())
            {
                Label = "Profesores",
                ValueLabel =Convert.ToString(oListaProfesor.Count()),
                Color = SKColor.Parse("#EE6A08"),
                TextColor = SKColor.Parse("#DF013A"),
            },
            
            };
            return data;
        }
    }
}
