using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
   public class TipoUsuarioDTO
    {
     
        public System.Int32 Tipousuacodi { get; set; }
        public System.String Tipousuanombre { get; set; }
        public System.String Tipousuaestado { get; set; }
        public System.String Tipousuausername { get; set; }
        public System.DateTime Tipousuafecins { get; set; }
        public System.DateTime Tipousuafecact { get; set; }

        public bool bGrabar { get; set; }
    }
}
