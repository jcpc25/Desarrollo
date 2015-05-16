using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla MD_ENVIO
    /// </summary>
    public class MdEnvioDTO : EntityBase
    {
        public string Envioarchnomb { get; set; } 
        public int? Estenvcodi { get; set; } 
        public DateTime? Enviomes { get; set; } 
        public int? Emprcodi { get; set; } 
        public string Usercodi { get; set; } 
        public int Enviocodi { get; set; } 
        public DateTime Enviofecha { get; set; } 
    }
}
