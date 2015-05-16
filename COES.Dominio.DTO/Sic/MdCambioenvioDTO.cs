using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla MD_CAMBIOENVIO
    /// </summary>
    public class MdCambioenvioDTO : EntityBase
    {
        public int Tipoinfocodi { get; set; } 
        public int Enviocodiold { get; set; } 
        public DateTime Medifecha { get; set; } 
        public int Ptomedicodi { get; set; } 
        public int? Enviocodinew { get; set; } 
        public decimal? Cmbvalorold { get; set; } 
        public decimal? Cmbvalornew { get; set; } 
    }
}
