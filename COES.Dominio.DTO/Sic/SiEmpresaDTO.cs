using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla SI_EMPRESA
    /// </summary>
    public class SiEmpresaDTO : EntityBase
    {
        public int Emprcodi { get; set; } 
        public string Emprnomb { get; set; } 
        public int Tipoemprcodi { get; set; } 
        public string Emprdire { get; set; } 
        public string Emprtele { get; set; } 
        public string Emprnumedocu { get; set; } 
        public string Tipodocucodi { get; set; } 
        public string Emprruc { get; set; } 
        public string Emprabrev { get; set; } 
        public int? Emprorden { get; set; } 
        public string Emprdom { get; set; } 
        public string Emprsein { get; set; } 
        public string Emprrazsocial { get; set; } 
        public string Emprcoes { get; set; } 
        public string Lastuser { get; set; } 
        public DateTime? Lastdate { get; set; } 
        public int? Compcode { get; set; } 
        public string Inddemanda { get; set; } 
    }
}
