using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IIngresoCompensacionRepository
    {
        int Save(IngresoCompensacionDTO entity);
        void Delete(System.Int32 PeriCodi, System.Int32 IngrCompVersion);
        List<IngresoCompensacionDTO> GetByCodigo(int? pericodi);
    }
}
