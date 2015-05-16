using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla CB_ARCHIVOENVIO
    /// </summary>
    public class CbArchivoEnvioDTO : EntityBase
    {
        public int concepcodi { get; set; }
        public int enviocodi { get; set; }
        public string archivnombreenvio { get; set; }
        public string archivnombrefisico { get; set; }
        public int archivoestado { get; set; }
        public DateTime lastdate { get; set; }
        public string lastuser { get; set; }
        public int archienvioorden{ get; set; }

        public string backgroundcolor { get; set; }
        public string imageextension { get; set; }
    }
}
