using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
  public  class RatioCumplimientoDTO
    {
        public System.Int32 Emprcodi { get; set; }
        public System.String Emprnomb { get; set; }
        public System.Int32 Tipoemprcodi { get; set; }
        public System.Int32 Pericodi { get; set; }
        public System.Decimal Requerido { get; set; }
        public System.Decimal Informado { get; set; }
        //public System.Decimal Infofinal { get; set; }
        //public System.Decimal Cumplimiento { get; set; }
    }
}
