using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class TransferenciaEntregaDTO
    {

        public System.Int32 Tranentrcodi { get; set; }
        
             public System.Int32 Codentcodi { get; set; }

        public System.Int32 Emprcodi { get; set; }
        public System.Int32 Barrcodi { get; set; }
        public System.String Codientrcodigo { get; set; }
        public System.Int32 Centgenecodi { get; set; }
        public System.Int32 Pericodi { get; set; }
        public System.Int32 Tranentrversion { get; set; }
        public System.String Tranentripoinformacion { get; set; }
        public System.String Tranentrestado { get; set; }
        public System.DateTime Tranentrfecins { get; set; }
        public System.DateTime Tranentrfecact { get; set; }

         public System.String Tentusername { get; set; }
        
        public System.String Emprnombre { get; set; }
        public System.String Centgenenombre { get; set; }
        public System.String Barrnombre { get; set; }
        public System.Decimal Total { get; set; }


    }
}
