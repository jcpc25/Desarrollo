using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IInfoDesviacionRepository: IRepositoryBase
    {
        List<InfoDesviacionDTO> GetByCriteria(Int32 AnioMes, Int32 AnioMes1, Int32 AnioMes2, Int32 Dias, Int32 DiasMeses, Decimal Desviacion);
    }
}
