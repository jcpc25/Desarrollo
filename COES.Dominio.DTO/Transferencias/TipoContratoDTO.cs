using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class TipoContratoDTO   {

        public System.Int32 Tipocontcodi { get; set; }
        public System.String Tipocontnombre { get; set; }
        public System.String Tipocontestado { get; set; }
        public System.String Tipocontusername { get; set; }
        public System.DateTime Tipocontfecins { get; set; }
        public System.DateTime Tipocontfecact { get; set; }

        public bool bGrabar { get; set; }
    }
}
