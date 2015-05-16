using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_PROPEQUI
    /// </summary>
    public class EqPropequiDTO : EntityBase
    {
        public int Propcodi { get; set; } 
        public int Equicodi { get; set; } 
        public DateTime Fechapropequi { get; set; } 
        public string Valor { get; set; } 
        public string Lastuser { get; set; } 
    }
}
