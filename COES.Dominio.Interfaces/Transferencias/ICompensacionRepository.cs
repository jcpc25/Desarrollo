using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ICompensacionRepository
    {
        int Save(CompensacionDTO entity);
        void Update(CompensacionDTO entity);
        void Delete(System.Int32 id);
        CompensacionDTO GetById(System.Int32 id);
        CompensacionDTO GetByCodigo(string nombre, int pericodi);
        List<CompensacionDTO> List(int id);
        List<CompensacionDTO> GetByCriteria(string nombre);
    }
}
