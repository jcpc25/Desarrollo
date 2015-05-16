using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class BarraDTO
    {
        public System.Int32 Barrcodi { get; set; }
        public System.String Barrnombre { get; set; }
        public System.String Barrtension { get; set; }
        public System.String Barrpuntosumirer { get; set; }
        public System.String Barrbarrabgr { get; set; }
        public System.String Barrestado { get; set; }
        public System.String Barrflagbarrtran { get; set; }
        public System.Int32 Areacodi { get; set; }
        public System.String Barrnombbarrtran { get; set; }
        public System.String Barrusername { get; set; }
        public System.DateTime Barrfecins { get; set; }
        public System.DateTime Barrfecact { get; set; }

        //public System.String Areanombre { get; set; }
        public bool bGrabar { get; set; }
    }
}
