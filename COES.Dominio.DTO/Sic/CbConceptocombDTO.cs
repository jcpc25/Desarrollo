using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla CB_CONCEPTOCOMB
    /// </summary>
    public class CbConceptocombDTO : EntityBase
    {
        public string Conceptipo { get; set; } 
        public string Concepabrev { get; set; } 
        public int? Conceporden { get; set; } 
        public string Concepunidad { get; set; } 
        public int? Tipocombcodi { get; set; } 
        public string Concepnomb { get; set; } 
        public int Concepcodi { get; set; } 
    }
}
