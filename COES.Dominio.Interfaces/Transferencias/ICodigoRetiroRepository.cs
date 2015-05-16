using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ICodigoRetiroRepository : IRepositoryBase
    {

        int Save(CodigoRetiroDTO entity);
        void Update(CodigoRetiroDTO entity);
        void Delete(System.Int32 id);
        CodigoRetiroDTO GetById(System.Int32 id);
        List<CodigoRetiroDTO> List(string estado);
        List<CodigoRetiroDTO> GetByCriteria(string nombreEmp, string tipousu, string tipocont, string bartran, string clinomb, DateTime? fechaIni, DateTime? fechaFin, string Solicodiretiobservacion, string estado);

        CodigoRetiroDTO GetByCodigoRetiCodigo(System.String CodiReticodigo);
    }
}
