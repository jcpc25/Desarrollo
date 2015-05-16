using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ICodigoEntregaRepository : IRepositoryBase
    {
        int Save(CodigoEntregaDTO entity);
        void Update(CodigoEntregaDTO entity);
        void Delete(System.Int32 id);
        CodigoEntregaDTO GetById(System.Int32 id);
        List<CodigoEntregaDTO> List();
        List<CodigoEntregaDTO> GetByCriteria(string nombreEmp, string barrTrans, string centralgene, DateTime? fechini, DateTime? fechafin, string estado);

        CodigoEntregaDTO GetByCodiEntrCodigo(System.String codientrCodigo);
    }
}
