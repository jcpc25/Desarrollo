using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_RELACION
    /// </summary>
    public class EqRelacionDTO : EntityBase
    {
        public int Relacioncodi { get; set; } 
        public int? Equicodi { get; set; } 
        public int? Codincp { get; set; } 
        public string Nombrencp { get; set; } 
        public string Codbarra { get; set; } 
        public string Idgener { get; set; } 
        public string Descripcion { get; set; } 
        public string Nombarra { get; set; } 
        public string Estado { get; set; } 
    }
}
