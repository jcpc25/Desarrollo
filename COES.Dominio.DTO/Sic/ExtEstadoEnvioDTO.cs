using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    public class ExtEstadoEnvioDTO : EntityBase
    {
        public int? Estenvcodi { get; set; }
        public string Estenvabrev { get; set; }
        public string Estenvnomb { get; set; }
        public string Estenvactivo { get; set; } 
    }
}
