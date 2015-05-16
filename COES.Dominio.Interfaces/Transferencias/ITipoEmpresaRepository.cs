using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
   public interface ITipoEmpresaRepository
    {
        List<TipoEmpresaDTO > List();
    }
}
