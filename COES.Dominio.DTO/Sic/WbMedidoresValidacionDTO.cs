using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla WB_MEDIDORES_VALIDACION
    /// </summary>
    public class WbMedidoresValidacionDTO : EntityBase
    {
        public int Medivalcodi { get; set; } 
        public int? Ptomedicodimed { get; set; } 
        public int? Ptomedicodidesp { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public string Indestado { get; set; }
        public string EmprNomb { get; set; }
        public string GrupoNomb { get; set; }
        public string GrupoAbrev { get; set; }
    }
}
