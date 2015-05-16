using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IValorTotalEmpresaRepository
    {

        int Save(ValorTotalEmpresaDTO entity);
        void Update(ValorTotalEmpresaDTO entity);
        void Delete(int pericodi, int version);
        ValorTotalEmpresaDTO GetById(System.Int32 id);
        List<ValorTotalEmpresaDTO> List();
        List<ValorTotalEmpresaDTO> GetByCriteria(string nombre);



        List<ValorTotalEmpresaDTO> GetEmpresaPositivaByCriteria(int pericodi, int version);

        List<ValorTotalEmpresaDTO> GetEmpresaNegativaByCriteria(int pericodi, int version);
      
    }
}
