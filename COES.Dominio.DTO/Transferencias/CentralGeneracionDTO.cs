using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class CentralGeneracionDTO
    {
        public System.Int32 Centgenecodi { get; set; }
        public System.String Centgenenombre { get; set; }
        public System.String Centgeneestado { get; set; }
        public System.DateTime Centgenefecins { get; set; }
        public System.DateTime Centgenefecact { get; set; }  
    }
}
