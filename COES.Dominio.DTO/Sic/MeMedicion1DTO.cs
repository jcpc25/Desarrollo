using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_MEDICION1
    /// </summary>
    public class MeMedicion1DTO : EntityBase
    {
        public int Lectcodi { get; set; } 
        public DateTime Medifecha { get; set; } 
        public int Tipoinfocodi { get; set; } 
        public int Ptomedicodi { get; set; } 
        public decimal? H1 { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; }

        public int Equicodi { get; set; }
        public string Equinomb { get; set; }
        public int Emprcodi { get; set; }
        public string Emprnomb { get; set; }
        public string Tipoinfoabrev { get; set; }
        public int Tipoptomedicodi { get; set; }
        public string Tipoptomedinomb { get; set; }

    }
}
