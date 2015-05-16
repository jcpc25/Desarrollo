using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_FAMREL
    /// </summary>
    public class EqFamrelDTO : EntityBase
    {
        public int Tiporelcodi { get; set; } 
        public int Famcodi1 { get; set; } 
        public int Famcodi2 { get; set; } 
        public int? Famnumconec { get; set; } 
        public string Famreltension { get; set; } 
    }
}
