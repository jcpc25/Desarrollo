using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
   public class IngresoRetiroSCDTO
    {
        public System.Int32 Ingrsccodi { get; set; }
        public System.Int32 PeriCodi { get; set; }
        public System.Int32 EmprCodi { get; set; }
        public System.Int32 Ingrscversion { get; set; }
        public System.Decimal Ingrscimporte { get; set; }
        public System.String Ingrscusername { get; set; }
        public System.DateTime Ingrscfecins { get; set; }
        public System.DateTime Ingrscfecact { get; set; }

        public System.String EmprNombre { get; set; }
        public System.String PeriNombre { get; set; }

        public System.Decimal Total { get; set; }
    }
}
