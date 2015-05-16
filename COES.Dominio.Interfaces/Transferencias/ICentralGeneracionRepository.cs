using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    /// <summary>
    /// Interface de acceso a datos de la vista VW_EQ_CENTRAL_GENERACION
    /// </summary>
    public interface ICentralGeneracionRepository : IRepositoryBase
    {
        List<CentralGeneracionDTO> List();
    }
}
