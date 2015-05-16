using COES.Base.Core;
using COES.Dominio.DTO.Sic;
using COES.Servicios.Aplicacion.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.Mantto
{
    public class ManttoAppServicio : AppServicioBase
    {
        /// <summary>
        /// Permite buscar equipos segun los criterios especificados
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        public List<ManRegistroDTO> BuscarManRegistroEvento(int idEvento, int nroPagina, int nroFilas)
        {
            return FactorySic.GetManRegistroRepository().BuscarManRegistro(idEvento, nroPagina, nroFilas);
        }

        /// <summary>
        /// Permite obtener el nro de items del resultado de la busqueda de equipos
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        public int ObtenerNroFilasBusquedaEquipo(int? idEvento)
        {
            return FactorySic.GetManRegistroRepository().ObtenerNroFilasManRegistroxTipo(idEvento);
        }
    }
}
