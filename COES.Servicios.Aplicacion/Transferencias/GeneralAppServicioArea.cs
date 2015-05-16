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
    public class GeneralAppServicioArea : AppServicioBase
    {

        /// <summary>
        /// Permite obtener el área en base al id
        /// </summary>
        /// <param name="idBarra"></param>
        /// <returns></returns>
        public AreaDTO GetByIdArea(int idArea)
        {
            return FactoryTransferencia.GetAreaRepository().GetById(idArea);
        }

        /// <summary>
        /// Permite listar todas las áreas
        /// </summary>
        /// <returns></returns>
        public List<AreaDTO> ListAreas()
        {
            return FactoryTransferencia.GetAreaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de áreas en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<AreaDTO> BuscarArea(string nombre)
        {
            return FactoryTransferencia.GetAreaRepository().GetByCriteria(nombre);
        }

    }
}
