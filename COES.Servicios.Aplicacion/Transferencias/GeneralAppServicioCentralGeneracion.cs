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
    public class GeneralAppServicioCentralGeneracion : AppServicioBase
    {
        public List<CentralGeneracionDTO> ListCentralGeneracion()
        {
            return FactoryTransferencia.GetCentralGeneracionRepository().List();
        }
    }
}
