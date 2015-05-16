using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    /// <summary>
    /// Interface de acceso a datos de la tabla TRN_BARRA
    /// </summary>
    public interface IBarraRepository : IRepositoryBase
    {
        int Save(BarraDTO entity);
        void Update(BarraDTO entity);
        void Delete(System.Int32 id);
        BarraDTO GetById(System.Int32 id);
        List<BarraDTO> List();
        List<BarraDTO> GetByCriteria(string nombre);
    }
}
