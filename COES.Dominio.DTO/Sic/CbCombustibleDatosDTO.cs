using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla CB_COMBUSTIBLEDATOS
    /// </summary>
    public class CbCombustibledatosDTO : EntityBase
    {
        public DateTime Combdatosfecha { get; set; } 
        public string Combdatosvalor { get; set; } 
        public int Concepcodi { get; set; } 
        public int Enviocodi { get; set; }
        public int Conceporden { get; set; }
        public string Lastuser { get; set; }

        public string Concepnomb { get; set; }
        public string Concepunidad { get; set; }
    }
}
