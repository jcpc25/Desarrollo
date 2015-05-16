using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EN_ESTFORMATO
    /// </summary>
    public class EnEstformatoDTO : EntityBase
    {
        public int? Ensayocodi { get; set; } 
        public int? Formatocodi { get; set; } 
        public int? Estadocodi { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public string Lastuser { get; set; } 
        public string Estformatdescrip { get; set; }

        /// <summary>
        /// Campos adicionales no inluidos en BD
        /// </summary>
        public string estadoNombre { get; set; }
        public string estadoColor { get; set; }
        public string formatodesc { get; set; }
    }
}
