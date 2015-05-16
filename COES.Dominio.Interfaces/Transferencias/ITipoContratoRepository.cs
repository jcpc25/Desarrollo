using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ITipoContratoRepository : IRepositoryBase
    {
        int Save(TipoContratoDTO entity);
        void Update(TipoContratoDTO entity);
        void Delete(System.Int32 id);
        TipoContratoDTO GetById(System.Int32 id);
        List<TipoContratoDTO> List();
        List<TipoContratoDTO> GetByCriteria(string nombre);
      
        
    }
}
