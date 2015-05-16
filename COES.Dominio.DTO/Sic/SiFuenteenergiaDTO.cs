using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla SI_FUENTEENERGIA
    /// </summary>
    public class SiFuenteenergiaDTO : EntityBase
    {
        public int Fenergcodi { get; set; } 
        public string Fenergabrev { get; set; } 
        public string Fenergnomb { get; set; } 
        public int? Tgenercodi { get; set; } 
    }
}
