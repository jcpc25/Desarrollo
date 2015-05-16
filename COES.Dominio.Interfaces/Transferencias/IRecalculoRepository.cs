using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IRecalculoRepository
    {
        int Save(RecalculoDTO entity);
        void Update(RecalculoDTO entity);
        void Delete(System.Int32 id);
        RecalculoDTO GetById(System.Int32 id);
        List<RecalculoDTO> List(int id);
        List<RecalculoDTO> GetByCriteria(string nombre);

        int GetUltimaVersion(int pericodi);
    }
}
