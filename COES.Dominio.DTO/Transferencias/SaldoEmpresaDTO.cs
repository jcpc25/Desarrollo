using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class SaldoEmpresaDTO
    {
        public System.Int32 SALEMPCODI { get; set; }
        public System.Int32 EMPCODI { get; set; }
        public System.Int32 SALEMPVERSION { get; set; }
        public System.Decimal SALEMPSALDO { get; set; }
        public System.Int32 PERICODI { get; set; }
        public System.DateTime SALEMPFECINS { get; set; }

        public System.String SALEMPUSERNAME { get; set; }

  
    }
}
