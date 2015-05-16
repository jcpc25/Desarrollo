using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public class IngresoCompensacionDTO
    {
        public System.Int32 IngrCompCodi { get; set; }
        public System.Int32 PeriCodi { get; set; }
        public System.Int32 EmprCodi { get; set; }
        public System.Int32 CompCodi { get; set; }
        public System.Int32 IngrCompVersion { get; set; }
        public System.Decimal IngrCompImporte { get; set; }
        public System.String IngrCompusername { get; set; }
        public System.DateTime IngrCompfecins { get; set; }
        //public System.DateTime IngrCompfecact { get; set; }

        public System.String EmprNombre { get; set; }
        public System.String PeriNombre { get; set; }
        public System.String CabeCompNombre { get; set; }

    }

}
