using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ITransferenciaRetiroRepository
    {

        int Save(TransferenciaRetiroDTO entity);
        void Update(TransferenciaRetiroDTO entity);
        void Delete(int emprcodi, int pericodi, int version);
        TransferenciaRetiroDTO GetById(System.Int32 id);
        List<TransferenciaRetiroDTO> List(int emprcodi, int pericodi,int version);
        List<TransferenciaRetiroDTO> GetByCriteria(string nombre);

    }
     
}
