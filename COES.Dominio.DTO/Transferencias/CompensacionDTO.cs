using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
   public class CompensacionDTO
    {
        public System.Int32 Cabecompcodi { get; set; }
        public System.String Cabecompnombre { get; set; }
        public System.String Cabecompver { get; set; }
        public System.String Cabecompestado { get; set; }
        public System.String Cabecompusername { get; set; }
        public System.DateTime Cabecompfecins { get; set; }
        public System.DateTime Cabecompfecact { get; set; }
        public System.Int32 Cabecomppericodi { get; set; }
    }
}
