using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
  public  class TramiteDTO
    {
        public System.Int32 Tramcodi { get; set; }
        public System.String Usuacoescodi { get; set; }
        public System.String Usuaseincodi { get; set; }
        public System.Int32? Emprcodi { get; set; }
        public System.Int32? Pericodi  { get; set; }
        public System.Int32 Tipotramcodi { get; set; }
        public System.String Tramcorrinf { get; set; }
        public System.String Tramdescripcion { get; set; }
        public System.String Tramrespuesta { get; set; }
        public System.DateTime Tramfecreg { get; set; }
        public System.DateTime? Tramfecres { get; set; }
        public System.DateTime? Tramfecins { get; set; }
        public System.DateTime? Tramfecact { get; set; }

        public System.String Tipotramnombre { get; set; }
        public System.String Emprnombre { get; set; }
        public bool bGrabar { get; set; }
    }
}
