using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class ExportExcelDTO
    {
        public System.Int32 Codientrereticodi { get; set; }
        public System.String Emprnomb { get; set; }        
        public System.String Barrnombbarrtran{ get; set; }
        public System.String Codientrereticodigo { get; set; }
        public System.String Tipo { get; set; }
        public System.String CentgeneClinombre { get; set; }
        public System.Int32 EMPRCODI { get; set; }


        //CUADRO
        public System.Decimal ValorizacionTransferencia { get; set; }
        public System.Decimal SaldoTransmision { get; set; }
        public System.Decimal Compensacion { get; set; }
        public System.Decimal TotalEmp { get; set; }
        public System.Int32 Pericodi { get; set; }
        public System.Int32 Vtranversion { get; set; }

        //Cuadro-compensacion
        public System.Int32 IngComversion { get; set; }
        public System.Decimal IngComImporte { get; set; }
        public System.String CabComnombre { get; set; }
    }
}
