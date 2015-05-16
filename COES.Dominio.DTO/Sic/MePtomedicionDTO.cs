using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_PTOMEDICION
    /// </summary>
    public class MePtomedicionDTO : EntityBase
    {
        public int Ptomedicodi { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public string Lastuser { get; set; } 
        public int? Emprcodi { get; set; } 
        public int? Grupocodi { get; set; } 
        public int? Tipoinfocodi { get; set; } 
        public string Osicodi { get; set; } 
        public int? Equicodi { get; set; } 
        public int? Codref { get; set; } 
        public string Ptomedidesc { get; set; } 
        public int? Orden { get; set; } 
        public string Ptomedielenomb { get; set; } 
        public string Ptomedibarranomb { get; set; }
        public int? Origlectcodi { get; set; }
        public short Tipoptomedicodi { get; set; }
        public string Ptomediestado { get; set; } 

        public short famcodi { get; set; }
        public string CENTRALNOMB { get; set; }
        public string GRUPONOMB { get; set; }

        public string Emprnomb { get; set; }
        public string Equinomb { get; set; }
        public string Famnomb { get; set; }
        public string Tipoptomedinomb { get; set; }
        public string Origlectnombre { get; set; }

        public int ColFormato { get; set; }
        public double LimiteUp { get; set; }
        
    }
}
