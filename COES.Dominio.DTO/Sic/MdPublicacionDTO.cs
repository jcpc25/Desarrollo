using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla MD_PUBLICACION
    /// </summary>
    public class MdPublicacionDTO : EntityBase
    {
        public string Publiarchivo { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public DateTime? Publiplazofecha { get; set; } 
        public int Emprcodi { get; set; } 
        public string Usercodi { get; set; } 
        public DateTime Publimes { get; set; } 
        public DateTime Publifecha { get; set; } 
        public string Publipin { get; set; } 
    }
}
