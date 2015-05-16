using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_HOJAPTOMED
    /// </summary>
    public class MeHojaptomedDTO : EntityBase
    {
        public int? Hojaptoactivo { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public string Lastuser { get; set; } 
        public decimal? Hojaptoliminf { get; set; } 
        public int Hojanumero { get; set; } 
        public int Formatcodi { get; set; } 
        public int Tipoinfocodi { get; set; } 
        public decimal? Hojaptolimsup { get; set; } 
        public int Ptomedicodi { get; set; }
        public int Hojaptoorden { get; set; }
        public int Hojaptosigno { get; set; }

        public string Tipoinfoabrev { get; set; }
        public string Equinomb { get; set; }
        public string Emprabrev { get; set; }
        public int Tipoptomedicodi { get; set; }
        public string  Tipoptomedinomb { get; set; }
    }
}
