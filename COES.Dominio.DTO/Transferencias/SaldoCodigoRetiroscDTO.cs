using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class SaldoCodigoRetiroscDTO
    {

        public System.Int32 SALRSCCODI { get; set; }
        public System.Int32 EMPRCODI { get; set; }
        public System.Int32 SALRSCVERSION { get; set; }
        public System.Decimal SALRSCSALDO { get; set; }
        public System.Int32 PERICODI { get; set; }
        public System.DateTime SALRSCFECINS { get; set; }

        public System.String SALRSCUSERNAME { get; set; }
    }
}
