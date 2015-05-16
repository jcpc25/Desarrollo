using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Clase que mapea la tabla EQ_FAMILIA
    /// </summary>
    public class EqFamiliaDTO : EntityBase
    {
        public int Famcodi { get; set; }
        public string Famabrev { get; set; }
        public int? Tipoecodi { get; set; }
        public int? Tareacodi { get; set; }
        public string Famnomb { get; set; }
        public int? Famnumconec { get; set; }
        public string Famnombgraf { get; set; }
    }
}
