using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_AMPLIACIONFECHA
    /// </summary>
    public class MeAmpliacionfechaDTO : EntityBase
    {
        public DateTime Amplifecha { get; set; } 
        public int Emprcodi { get; set; } 
        public int Formatcodi { get; set; } 
        public DateTime Amplifechaplazo { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; }

        public string Emprnomb { get; set; }
        public string Formatnombre { get; set; }
    }
}
