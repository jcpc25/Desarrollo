using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class EmpresaPagoDTO
    {
            public System.Int32 EMPPAGOCODI { get; set; }

            public System.Int32 VALTOTAEMPCODI { get; set; }
            public System.Int32 EMPCODI { get; set; }
            public System.Int32 VALTOTAEMPVERSION { get; set; }
            public System.Int32 PERICODI { get; set; }



            public System.Int32 EMPPAGOCODEMPPAGO { get; set; }
            public System.Decimal EMPPAGOMONTO { get; set; }
          public System.String EMPPAGUSERNAME { get; set; }
  
            public System.DateTime EMPPAGOFECINS { get; set; }

            //para reporte
            public System.String EMPRNOMB { get; set; }
            public System.String EMPRNOMBPAGO { get; set; }
        

    }
}
