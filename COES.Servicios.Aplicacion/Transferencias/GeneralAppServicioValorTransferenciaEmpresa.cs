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
    public class GeneralAppServicioValorTransferenciaEmpresa : AppServicioBase
    {
        /// <summary>
        ///Graba un ValorTransferenciaEmpresa
        /// </summary>
        /// <param name="entity"></param>
      

        public int SaveValorTransferenciaEmpresa(ValorTransferenciaEmpresaDTO entity)
        {
            try
            {
                int id = 0;
                if (entity.Valtranempcodi == 0)
                {
                    id = FactoryTransferencia.GetValorTransferenciaEmpresaRepository().Save(entity);
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




            /// <summary>
            ///Elimina los  ValorTransferenciaEmpresa por PeriCodi,Version
            /// </summary>
            /// <param name="PeriCodi"></param>
            /// <param name="Version"></param>
        public int DeleteValorTransferenciaEmpresa(int PeriCodi, int Version)
        {
            try
            {
                FactoryTransferencia.GetValorTransferenciaEmpresaRepository().Delete(PeriCodi, Version);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return PeriCodi;
        }

    }
}
