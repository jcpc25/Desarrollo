using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ISaldoEmpresaRepository
    {

        int Save(SaldoEmpresaDTO entity);
        void Update(SaldoEmpresaDTO entity);
        void Delete(int pericodi, int version);
        //SaldoEmpresaDTO GetById(System.Int32 id);
        //List<SaldoEmpresaDTO> List();
        //List<SaldoEmpresaDTO> GetByCriteria(string nombre);
    }
}
