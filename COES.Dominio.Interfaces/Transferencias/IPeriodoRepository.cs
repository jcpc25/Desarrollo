using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IPeriodoRepository
    {
        int Save(PeriodoDTO entity);
        void Update(PeriodoDTO entity);
        void Delete(System.Int32 id);
        PeriodoDTO GetById(System.Int32? id);
        List<PeriodoDTO> List();
        List<PeriodoDTO> GetByCriteria(string nombre);
    }
}
