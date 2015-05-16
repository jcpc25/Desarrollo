using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EVE_MANTTO
    /// </summary>
    public class EveManttoDTO : EntityBase
    {
        public int Manttocodi { get; set; } 
        public int? Equicodi { get; set; } 
        public int? Evenclasecodi { get; set; } 
        public int? Tipoevencodi { get; set; }
        public int? Compcode { get; set; } 
        public DateTime? Evenini { get; set; } 
        public DateTime? Evenpreini { get; set; } 
        public DateTime? Evenfin { get; set; } 
        public int? Subcausacodi { get; set; } 
        public DateTime? Evenprefin { get; set; } 
        public decimal? Evenmwindisp { get; set; } 
        public int? Evenpadre { get; set; } 
        public string Evenindispo { get; set; } 
        public string Eveninterrup { get; set; } 
        public string Eventipoprog { get; set; } 
        public string Evendescrip { get; set; } 
        public string Evenobsrv { get; set; } 
        public string Evenestado { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public int? Evenrelevante { get; set; } 
        public int? Deleted { get; set; } 
        public int? Mancodi { get; set; }

        public int Emprcodi { get; set; }
        public string Emprnomb { get; set; }
        public string Emprabrev { get; set; }
        public string Evenclasedesc { get; set; }
        public string Areanomb { get; set; }
        public int Famcodi { get; set; }
        public string Famnomb { get; set; }
        public string Equiabrev { get; set; }
        public string Causaevenabrev { get; set; }
        public Nullable<decimal> Equitension { get; set; }
        public string Tipoevenabrev { get; set; }
        public string Tipoevendesc { get; set; }
        public string Tipoemprdesc { get; set; }
        public string Osigrupocodi { get; set; }
    }

    public class ReporteManttoDTO : EntityBase
    {
        public int Equicodi { get; set; }
        public string Equiabrev { get; set; }
        public int Emprcodi { get; set; }
        public string Emprnomb { get; set; }
        public string Emprabrev { get; set; }
        public int Famcodi { get; set; }
        public string Famnomb { get; set; }
        public int Tipoevencodi { get; set; }
        public string Tipoevendesc { get; set; }
        public string Tipoemprdesc { get; set; }
        public int Subtotal { get; set; }
        public int? Evenclasecodi { get; set; }
        public string Evenclasedesc { get; set; }
        public decimal Porcentajemantto { get; set; }
        public string Osigrupocodi { get; set; }
    }
}

