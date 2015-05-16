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
    public class GeneralAppServicioInformePreliminar : AppServicioBase
    {

        public List<InformePreliminarDTO> ListInformeByPeriVer(int periodo, int version)
        {
            return FactoryTransferencia.GetInformePreliminarRepository().GetByCriteria(periodo, version);
        }
    }
}
