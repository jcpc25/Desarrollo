using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    /// <summary>
    /// Interface de acceso a datos de la tabla TRN_FACTOR_PERDIDA
    /// </summary>
    public interface IFactorPerdidaRepository
    {
        int Save(FactorPerdidaDTO entity);
        void Delete(System.Int32 PeriCodi, System.Int32 FactPerdVersion);
        List<FactorPerdidaDTO> ListByPeriodoVersion(System.Int32 PeriCodi, System.Int32 FactPerdVersion);
    }
}
