using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Transferencias
{
    public  class CodigoRetiroSinContratoDTO
    {
           public System.Int32 Codretisinconcodi { get; set; }
           public System.Int32 Clicodi { get; set; }
           public System.Int32 Barrcodi { get; set; }
           public System.String Codretisinconcodigo { get; set; }          
           public System.DateTime Codretisinconfechainicio { get; set; }
           public System.DateTime? Codretisinconfechafin { get; set; }   
           public System.String Codretisinconestado { get; set; }
           public System.String Codretisinconusername { get; set; }
           public System.DateTime Codretisinconfecins { get; set; }
           public System.DateTime Codretisinconfecact { get; set; }
           public System.Int32 Genemprcodi { get; set; }
        
           public System.String Clinombre { get; set; }
           public System.String Barrnombbarrtran { get; set; }
    }
}
