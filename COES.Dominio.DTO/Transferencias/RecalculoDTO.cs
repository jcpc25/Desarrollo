using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
  public class RecalculoDTO
    {
        public System.Int32 Recacodi { get; set; }
        public System.Int32 Recapericodi { get; set; }
        public System.DateTime Recafecini { get; set; }
        public System.DateTime Recafecfin { get; set; }
        public System.String Recadesc { get; set; }
        public System.String Recausername { get; set; }
        public System.DateTime Recafecins { get; set; }
        public System.DateTime Recafecact { get; set; }
    }
}
