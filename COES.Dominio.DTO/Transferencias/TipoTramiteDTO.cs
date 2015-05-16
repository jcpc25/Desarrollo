using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
   public class TipoTramiteDTO
    {
       public System.Int32 Tipotramcodi { get; set; }
       public System.String Tipotramnombre { get; set; }
       public System.String Tipotramestado { get; set; }
       public System.String Tipotramusername { get; set; }
       public System.DateTime Tipotramfecins { get; set; }
       public System.DateTime Tipotramfecact { get; set; }
    }
}
