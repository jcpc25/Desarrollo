using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.Transferencias
{
    public class GeneralAppServicioInfoDesbalance : AppServicioBase
    {
        /// <summary>
        /// Permite realizar búsquedas de InfoDesbalance en base al periodo
        /// </summary>
        /// <param name="pericodi"></param>
        /// <returns></returns>
        public List<InfoDesbalanceDTO> BuscarInfoDesbalance(string pericodi)
        {
            return FactoryTransferencia.GetInfoDesbalanceRepository().GetByCriteria(pericodi);
        }

    }
}
