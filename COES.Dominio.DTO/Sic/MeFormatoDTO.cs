using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla ME_FORMATO
    /// </summary>
    public class MeFormatoDTO : EntityBase
    {
        public DateTime? Lastdate { get; set; } 
        public string Lastuser { get; set; } 
        public int? Areacode { get; set; } 
        public int? Formatresolucion { get; set; } 
        public string Formatextension { get; set; } 
        public int? Formatperiodo { get; set; } 
        public string Formatnombre { get; set; } 
        public int Formatcodi { get; set; }
        public int Formathorizonte { get; set; }
        public int? Formatversion { get; set; }
        public string Areaname { get; set; }
        public int? Modcodi { get; set; }

        public string Periodo { get; set; }
        public string Resolucion { get; set; }
        public string Horizonte { get; set; }
        public List<MeFormatohojaDTO> ListaHoja { get; set; }
    }
}
