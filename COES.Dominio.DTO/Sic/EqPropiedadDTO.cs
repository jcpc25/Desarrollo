using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_PROPIEDAD
    /// </summary>
    public class EqPropiedadDTO : EntityBase
    {
        public string Proptabla { get; set; } 
        public string Propcampo { get; set; } 
        public string Propfiltro { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public int? Propmaxelem { get; set; } 
        public string Propfichaoficial { get; set; } 
        public string Propvisible { get; set; } 
        public int Propcodi { get; set; } 
        public int? Famcodi { get; set; } 
        public string Propabrev { get; set; } 
        public string Propnomb { get; set; } 
        public string Propunidad { get; set; } 
        public int? Orden { get; set; } 
        public string Propmask { get; set; } 
        public string Proptipo { get; set; } 
        public string Prophisto { get; set; } 
        public string Propdefinicion { get; set; } 
        public string Propprincipal { get; set; } 
        public string Propfile { get; set; } 
        public int? Propcodipadre { get; set; } 
    }
}
