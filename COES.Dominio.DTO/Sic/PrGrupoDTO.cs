using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla PR_GRUPO
    /// </summary>
    public class PrGrupoDTO : EntityBase
    {
        public int? Fenergcodi { get; set; } 
        public int Barracodi { get; set; } 
        public int Grupocodi { get; set; } 
        public string Gruponomb { get; set; } 
        public string Grupoabrev { get; set; } 
        public decimal? Grupovmax { get; set; } 
        public decimal? Grupovmin { get; set; } 
        public int? Grupoorden { get; set; } 
        public int? Emprcodi { get; set; } 
        public string Grupotipo { get; set; } 
        public int? Catecodi { get; set; } 
        public int? Grupotipoc { get; set; } 
        public int? Grupopadre { get; set; } 
        public string Grupoactivo { get; set; } 
        public string Grupocomb { get; set; } 
        public string Osicodi { get; set; } 
        public int? Grupocodi2 { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public string Gruposub { get; set; } 
        public int Barracodi2 { get; set; } 
        public decimal Barramw1 { get; set; } 
        public decimal Barramw2 { get; set; } 
        public string Gruponombncp { get; set; } 
        public int Tipogrupocodi { get; set; }
        public string DesTipoGrupo { get; set; }
        public string EmprNomb { get; set; }
    }
}
