using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_MEDICION24
    /// </summary>
    public class MeMedicion24DTO : EntityBase
    {
        public int Lectcodi { get; set; } 
        public DateTime Medifecha { get; set; } 
        public int Tipoinfocodi { get; set; } 
        public int Ptomedicodi { get; set; } 
        public decimal? Meditotal { get; set; } 
        public string Mediestado { get; set; } 
        public decimal? H1 { get; set; } 
        public decimal? H2 { get; set; } 
        public decimal? H3 { get; set; } 
        public decimal? H4 { get; set; } 
        public decimal? H5 { get; set; } 
        public decimal? H6 { get; set; } 
        public decimal? H7 { get; set; } 
        public decimal? H8 { get; set; } 
        public decimal? H9 { get; set; } 
        public decimal? H10 { get; set; } 
        public decimal? H11 { get; set; } 
        public decimal? H12 { get; set; } 
        public decimal? H13 { get; set; } 
        public decimal? H14 { get; set; } 
        public decimal? H15 { get; set; } 
        public decimal? H16 { get; set; } 
        public decimal? H17 { get; set; } 
        public decimal? H18 { get; set; } 
        public decimal? H19 { get; set; } 
        public decimal? H20 { get; set; } 
        public decimal? H21 { get; set; } 
        public decimal? H22 { get; set; } 
        public decimal? H23 { get; set; } 
        public decimal? H24 { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; }

        public int Equicodi { get; set; }
        public string Equinomb { get; set; }
        public int Emprcodi { get; set; }
        public string Emprnomb { get; set; }
        public string Tipoinfoabrev { get; set; }
        public int Tipoptomedicodi { get; set; }
        public string Tipoptomedinomb { get; set; }
        public string Ptomedinomb { get; set; }

    }
}
