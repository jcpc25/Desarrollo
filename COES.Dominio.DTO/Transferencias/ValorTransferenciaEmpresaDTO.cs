using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class ValorTransferenciaEmpresaDTO 
    {

        public System.Int32 Valtranempcodi { get; set; }
        public System.Int32 Empcodi { get; set; }
        public System.Int32 Valtranempversion { get; set; }
        public System.Decimal Valtranemptotal { get; set; }
        public System.Int32 Pericodi { get; set; }
        public System.DateTime Valtranempfrecins { get; set; }

        public System.String Vtraneusername { get; set; }


    }
}
