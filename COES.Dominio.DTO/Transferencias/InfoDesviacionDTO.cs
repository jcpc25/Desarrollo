using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class InfoDesviacionDTO
    {
        public System.String Empresa { get; set; }
        public System.String Barra { get; set; }
        public System.String Cliente { get; set; }
        public System.String Codigo { get; set; }
        public System.Decimal Desviacion { get; set; }   
    }
}
