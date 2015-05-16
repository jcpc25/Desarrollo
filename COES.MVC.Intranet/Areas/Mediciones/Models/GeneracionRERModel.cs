using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Mediciones.Models
{
    public class GeneracionRERModel
    {
        public List<WbGeneracionrerDTO> ListaEmpresas { get; set; }
        public List<string> ListaSemanas { get; set; }
        public int NroSemana { get; set; }
        public string Fecha { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Resultado { get; set; }
        public List<int> ListaAnios { get; set; }
        public int Anio { get; set; }
        public List<ExtLogenvioDTO> ListaReporte { get; set; }
    }
}