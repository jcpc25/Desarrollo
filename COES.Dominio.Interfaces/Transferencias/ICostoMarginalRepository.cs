using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Transferencias
{
    /// <summary>
    /// Interface de acceso a datos de la tabla TRN_COSTO_MARGINAL
    /// </summary>
    public interface ICostoMarginalRepository : IRepositoryBase
    {
        int Save(CostoMarginalDTO entity);
        void Delete(System.Int32 PeriCodi, System.Int32 CostMargVersion);
        List<CostoMarginalDTO> List(int PeriCodi);
        List<CostoMarginalDTO> GetByCriteria(int PeriCodi, string BarrCodi);
        List<CostoMarginalDTO> ListByBarrPeriodoVersion(int BarrCodi, int PeriCodi, int CostMargVersion);
        List<CostoMarginalDTO> GetByCodigo(int? pericodi);
        List<CostoMarginalDTO> GetByBarraTransferencia(int pericodi, int iVersion);
    }
}
