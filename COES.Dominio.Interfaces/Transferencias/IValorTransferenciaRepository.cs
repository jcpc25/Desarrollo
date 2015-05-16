using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IValorTransferenciaRepository
    {
        int Save(ValorTransferenciaDTO entity);

        void Delete(System.Int32 PeriCodi, System.Int32 ValoTranVersion);

        List<ValorTransferenciaDTO> List(int pericodi, int version);

        List<ValorTransferenciaDTO> GetByCriteria(int? empcodi,int? barrcodi,int? pericodi); //int pericodi, string barrcodi

    
        List<ValorTransferenciaDTO> GetTotalByTipoFlag(int pericodi, int version);

        List<ValorTransferenciaDTO> GetValorEmpresa(int pericodi, int version);

        List<ValorTransferenciaDTO> GetBalance(int pericodi);
        
    }
}
