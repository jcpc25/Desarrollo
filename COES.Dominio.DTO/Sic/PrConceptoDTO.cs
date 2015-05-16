using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla PR_CONCEPTO
    /// </summary>
    public class PrConceptoDTO : EntityBase
    {
        public int? Catecodi { get; set; } 
        public int Concepcodi { get; set; } 
        public string Concepabrev { get; set; } 
        public string Concepdesc { get; set; } 
        public string Concepunid { get; set; } 
        public string Conceptipo { get; set; } 
        public int? Conceporden { get; set; } 
    }
}
