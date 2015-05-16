using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla WB_GENERACIONRER
    /// </summary>
    public class WbGeneracionrerDTO : EntityBase
    {
        public int Ptomedicodi { get; set; } 
        public string Estado { get; set; } 
        public string Userupdate { get; set; } 
        public string Usercreate { get; set; } 
        public DateTime? Fecupdate { get; set; } 
        public DateTime? Feccreate { get; set; }
        public string EmprNomb { get; set; }
        public string EquiNomb { get; set; }
        public string Central { get; set; }
        public string IndPorCentral { get; set; }
        public int EmprCodi { get; set; }
        public int GrupoCodi { get; set; }
        public int EquiCodi { get; set; }
        public int CentralCodi { get; set; }
    }
}
