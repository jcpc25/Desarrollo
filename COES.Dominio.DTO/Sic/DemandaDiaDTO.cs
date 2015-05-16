using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COES.Dominio.DTO.Sic
{
    public class DemandadiaDTO
    {
      
        public string Empresanomb { get; set; }
        public string Centralnomb { get; set; }
        public string Gruponomb { get; set; }
        public string Tipogeneracion { get; set; } 
        public DateTime Medifecha { get; set; }
        public decimal? Valor { get; set; }
        public int HMax { get; set; }
        public string MedifechaHFP { get; set; }
        public string MedifechaHP { get; set; }
        public decimal ValorHFP { get; set; }
        public decimal ValorHP { get; set; }
        public decimal ValorMD { get; set; }
        public string HoraMD { get; set; }
        public string FechaMD { get; set; }
        public string StrMediFecha { get; set; }
        public int IndexHoraMD { get; set; }
        public int IndiceMDHP { get; set; }
        public int IndiceMDHFP { get; set; }
        public int DestinoPotencia { get; set; } // 0=> Generacion Peru, 1 => Exportacion Ecuador, 2 => Importacion Ecuador
    }
}
