using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    /// <summary>
    /// Entidad que mapea la tabla WB_PARAMETORPF
    /// </summary>
    public class ParametroRpfDTO : EntityBase
    {
        public int PARAMRPFCODI { get; set; }
        public string PARAMTIPO { get; set; }
        public string PARAMVALUE { get; set; }
        public string PARAMMODULO { get; set; }
    }
}
