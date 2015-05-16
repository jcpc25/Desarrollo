using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Sic
{
    public class ConsolidadoEnvioDTO
    {
        public string Empresa { get; set; }
        public string Central { get; set; }
        public short idCentral { get; set; }
        public string GrupSSAA { get; set; }
        public decimal Total { get; set; }
        public DateTime fecha { get; set; }
        public short tipoGeneracion { get; set; }
    }
}
