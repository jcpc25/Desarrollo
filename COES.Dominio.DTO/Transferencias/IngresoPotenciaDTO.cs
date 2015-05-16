using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
   public class IngresoPotenciaDTO
    {
        public System.Int32 IngrPoteCodi { get; set; }
        public System.Int32 PeriCodi { get; set; }
        public System.Int32 EmprCodi { get; set; }
        public System.Int32 IngrPoteVersion { get; set; }
        public System.Decimal IngrPoteImporte { get; set; }
        public System.String IngrPoteUsername { get; set; }
        public System.DateTime IngrPoteFecins { get; set; }
        public System.DateTime IngrPoteFecact { get; set; }

        public System.String EmprNombre { get; set; }
        public System.String PeriNombre { get; set; }

        public System.Decimal Total { get; set; }
        
       
    }
}
