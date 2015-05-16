using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class ValorTotalEmpresaDTO
    {

        public System.Int32 VALTOTAEMPCODI { get; set; }
        public System.Int32 EMPCODI { get; set; }
        public System.Int32 VALTOTAEMPVERSION { get; set; }
        public System.Decimal VALTOTAEMPTOTAL { get; set; }
        public System.Int32 PERICODI { get; set; }
        public System.DateTime VALTOTAEMPFECINS { get; set; }

        public System.Decimal TOTAL { get; set; }

        public System.String VOTEMUSERNAME { get; set; }
 


    
    }
}
