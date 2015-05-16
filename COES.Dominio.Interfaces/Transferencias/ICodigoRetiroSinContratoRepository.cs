using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
   public  interface ICodigoRetiroSinContratoRepository :IRepositoryBase
    {
        int Save(CodigoRetiroSinContratoDTO entity);
        void Update(CodigoRetiroSinContratoDTO entity);
        void Delete(System.Int32 id);
        CodigoRetiroSinContratoDTO GetById(System.Int32 id);
        List<CodigoRetiroSinContratoDTO> List();
        List<CodigoRetiroSinContratoDTO> GetByCriteria(string nombreCli, string nombreBarra, DateTime? fechaini, DateTime? fechafin, string estado);
        CodigoRetiroSinContratoDTO GetByCodigoRetiroSinContratoCodigo(string Codretisinconcodigo);
    }
}
