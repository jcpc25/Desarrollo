using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface ITransferenciaEntregaDetalleRepository
    {
        int Save(TransferenciaEntregaDetalleDTO entity);
        void Update(TransferenciaEntregaDetalleDTO entity);
        void Delete(int emprcodi, int pericodi, int version);
        TransferenciaEntregaDetalleDTO GetById(System.Int32 id);
        List<TransferenciaEntregaDetalleDTO> List(int emprcodi, int pericodi);
        List<TransferenciaEntregaDetalleDTO> GetByCriteria(int emprcodi, int pericodi, string codientrcodi,int version);

        List<TransferenciaEntregaDetalleDTO> GetByPeriodoVersion( int pericodi, int version );

        List<TransferenciaEntregaDetalleDTO> BalanceEnergiaActiva(int pericodi);

    }
}
