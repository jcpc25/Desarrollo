using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_EQUIPO
    /// </summary>
    public class EqEquipoDTO : EntityBase
    {
        public int Equicodi { get; set; } 
        public int? Emprcodi { get; set; } 
        public int? Grupocodi { get; set; } 
        public int? Elecodi { get; set; } 
        public int? Areacodi { get; set; } 
        public int? Famcodi { get; set; } 
        public string Equiabrev { get; set; } 
        public string Equinomb { get; set; } 
        public string Equiabrev2 { get; set; } 
        public decimal? Equitension { get; set; } 
        public int? Equipadre { get; set; } 
        public decimal? Equipot { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public string Ecodigo { get; set; } 
        public string Equiestado { get; set; } 
        public string Osigrupocodi { get; set; } 
        public int? Lastcodi { get; set; } 
        public DateTime? Equifechiniopcom { get; set; } 
        public DateTime? Equifechfinopcom { get; set; }

        //DATOS EMPRESA
        public string EMPRNOMB { get; set; }

        //DATOS AREA
        public string AREANOMB { get; set; }
        public string TAREAABREV { get; set; }
        //DATOS FAMILIA
        public string Famnomb { get; set; }
        public string FAMABREV { get; set; }
    }
}
