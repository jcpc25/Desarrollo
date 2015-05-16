using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class PeriodoDTO
    {
        public System.Int32 Pericodi { get; set; }
        public System.String Perinombre { get; set; }
        public System.Int32 Aniocodi { get; set; }
        public System.Int32 Mescodi { get; set; }
        public System.DateTime Perifechavalorizacion { get; set; }
        public System.DateTime Perifechalimite { get; set; }
        public System.DateTime Perifechaobservacion { get; set; }
        public System.String Periestado { get; set; }
        public System.String Periusername { get; set; }
        public System.DateTime Perifecins { get; set; }
        public System.DateTime Perifecact { get; set; }

        public System.Int32 Perianiomes { get; set; }
        public System.String Perihoralimite { get; set; }

    }
}
