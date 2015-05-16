using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ITransferenciaEntregaRepository
    {

        int Save(TransferenciaEntregaDTO entity);
        void Update(TransferenciaEntregaDTO entity);
        void Delete(int emprcodi,int pericodi, int version);
        TransferenciaEntregaDTO GetById(System.Int32 id);
        List<TransferenciaEntregaDTO> List(int emprcodi, int pericodi, int version);
        List<TransferenciaEntregaDTO> GetByCriteria(string nombre);
    }
}
