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
   public class GeneralAppServicioIngresoPotencia: AppServicioBase
    {
        public int SaveIngresoPotencia(IngresoPotenciaDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.IngrPoteCodi == 0)
                {
                    id = FactoryTransferencia.GetIngresoPotenciaRepository().Save(entity);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public int DeleteListaIngresoPotencia(int PeriCodi, int IngrPoteVersion)
        {
            try
            {
                FactoryTransferencia.GetIngresoPotenciaRepository().Delete(PeriCodi, IngrPoteVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }


        public List<IngresoPotenciaDTO> ListImportesByPeriVer(int pericodi, int version)
        {
            return FactoryTransferencia.GetIngresoPotenciaRepository().GetByCriteria(pericodi, version);
        }

        public List<IngresoPotenciaDTO> BuscarIngresoPotencia(int? idPeriodo)
        {
            return FactoryTransferencia.GetIngresoPotenciaRepository().GetByCodigo( idPeriodo);
        }
    }
}
