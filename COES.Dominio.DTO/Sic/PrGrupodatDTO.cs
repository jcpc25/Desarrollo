using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla PR_GRUPODAT
    /// </summary>
    public class PrGrupodatDTO : EntityBase
    {
        public DateTime Fechadat { get; set; } 
        public int Concepcodi { get; set; } 
        public int Grupocodi { get; set; } 
        public string Lastuser { get; set; } 
        public string Formuladat { get; set; } 
        public int Deleted { get; set; } 
        public DateTime? Fechaact { get; set; } 
    }
}
