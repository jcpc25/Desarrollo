using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class InformePreliminarDTO
    {

        public System.String NombEmp { get; set; }
        public System.Decimal Valorizacion { get; set; }
        public System.Decimal Compensacion { get; set; }
        public System.Decimal IngresoPotencia { get; set; }
        public System.Decimal SaldoTransmision { get; set; }
        public System.Decimal ValorTotalEmp { get; set; }
    }
}
