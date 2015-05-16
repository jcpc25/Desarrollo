using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IEmpresaPagoRepository
    {

        int Save(EmpresaPagoDTO entity);
        void Delete(int PeriCodi, int Version);
        List<EmpresaPagoDTO> GetByCriteria(int pericodi, int version);

        List<EmpresaPagoDTO> GetEmpresaPositivaByCriteria(int pericodi, int version);

        List<EmpresaPagoDTO> GetEmpresaNegativaByCriteria(int pericodi, int version);

    }
}
