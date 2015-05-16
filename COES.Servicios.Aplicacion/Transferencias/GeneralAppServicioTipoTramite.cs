using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using COES.Servicios.Aplicacion.Factory;

namespace COES.Servicios.Aplicacion.Transferencias
{
    public class GeneralAppServicioTipoTramite: AppServicioBase
    {
        public List<TipoTramiteDTO> ListTipoTramite()
        {
            return FactoryTransferencia.GetTipoTramiteRepository().List();
        }

        public TipoTramiteDTO GetByIdTipoTramite(System.Int32? TipTrmCodi)
        {
            return FactoryTransferencia.GetTipoTramiteRepository().GetById(TipTrmCodi);
        }
    }
}
