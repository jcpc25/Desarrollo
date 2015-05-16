using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ITransferenciaRetiroDetalleRepository
    {
        int Save(TransferenciaRetiroDetalleDTO entity);
        void Update(TransferenciaRetiroDetalleDTO entity);
        void Delete(int emprcodi, int pericodi, int version);
        TransferenciaRetiroDetalleDTO GetById(System.Int32 id);
        List<TransferenciaRetiroDetalleDTO> List(int emprcodi, int pericodi);
        List<TransferenciaRetiroDetalleDTO> GetByCriteria(int emprcodi,int pericodi,string solicodireticodigo,int version);

        List<TransferenciaRetiroDetalleDTO> GetByPeriodoVersion(int pericodi, int version);
    }
}
