using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_EQUIREL
    /// </summary>
    public class EqEquirelDTO : EntityBase
    {
        public int Equicodi1 { get; set; } 
        public int Tiporelcodi { get; set; } 
        public int Equicodi2 { get; set; } 
    }
}
