using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class CodigoEntregaDTO
    {

        public System.Int32 Codientrcodi { get; set; }
        public System.Int32 Emprcodi { get; set; }
        public System.Int32 Barrcodi { get; set; }
        public System.Int32 Centgenecodi { get; set; }
        public System.String Codientrcodigo { get; set; }
        public System.DateTime Codientrfechainicio { get; set; }
        public System.DateTime? Codientrfechafin { get; set; }
        public System.String Codientrestado { get; set; }
        public System.String Codientrusername { get; set; }
        public System.DateTime Codientrfecins { get; set; }
        public System.DateTime Codientrfecact { get; set; }

        public System.String Centgenenombre { get; set; }
        public System.String Barrnombbarrtran { get; set; }
        public System.String Emprnomb { get; set; }
    }
}
