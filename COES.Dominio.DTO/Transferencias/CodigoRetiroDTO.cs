using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class CodigoRetiroDTO
    {
            public System.Int32 Solicodireticodi { get; set; }
            public System.Int32 Emprcodi { get; set; }
            public System.Int32 Barrcodi { get; set; }
            public System.String Usuacodi { get; set; }
            public System.Int32 Tipocontcodi { get; set; }
            public System.Int32 Tipousuacodi{ get; set; }
            public System.Int32 Clicodi  { get; set; }
            public System.String Solicodireticodigo { get; set; }
            public System.DateTime Solicodiretifecharegistro { get; set; }
            public System.String Solicodiretidescripcion { get; set; }
            public System.String Solicodiretidetalleamplio { get; set; }
            public System.DateTime?  Solicodiretifechainicio { get; set; }
            public System.DateTime? Solicodiretifechafin { get; set; }          
            public System.String Solicodiretiobservacion { get; set; }
            public System.String Solicodiretiestado { get; set; }
            public System.String Coesusername { get; set; }
            //public System.String Seinusername { get; set; }
            public System.DateTime Solicodiretifecins { get; set; }
            public System.DateTime Solicodiretifecact { get; set; }
            public System.DateTime Solicodiretifechasolbaja { get; set; }
            public System.DateTime Solicodiretifechadebaja { get; set; }

            public System.String Emprnombre { get; set; }
            public System.String Barrnombbarrtran { get; set; }
            public System.String Tipocontnombre { get; set; }
            public System.String Tipousuanombre { get; set; }
            public System.String Clinombre { get; set; }

            //Para la vista
            public System.String Trettabla { get; set; }
            public System.String FechaInicio { get; set; }
            public System.String FechaFin { get; set; }
    }
}
