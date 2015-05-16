using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EN_FORMATO
    /// </summary>
    public class EnFormatoDTO : EntityBase
    {
        public int Formatocodi { get; set; } 
        public string Formatodesc { get; set; } 
        public int Tipoarchivo { get; set; } 
    }
}
