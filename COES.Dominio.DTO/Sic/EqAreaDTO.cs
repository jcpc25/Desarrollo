using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_AREA
    /// </summary>
    public class EqAreaDTO : EntityBase
    {
        public int Areacodi { get; set; } 
        public int? Tareacodi { get; set; } 
        public string Areaabrev { get; set; } 
        public string Areanomb { get; set; } 
        public int Areapadre { get; set; } 

        //TIPO AREA
        public string Tareanomb { get; set; }
    }
}
