using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
   public interface IIngresoRetiroSCRepository
    {
        int Save(IngresoRetiroSCDTO entity);
        void Delete(System.Int32 PeriCodi, System.Int32 Ingrscversion);
        List<IngresoRetiroSCDTO> GetByCodigo(int? pericodi);
        List<IngresoRetiroSCDTO> GetByCriteria(int pericodi, int version);
    }
}
