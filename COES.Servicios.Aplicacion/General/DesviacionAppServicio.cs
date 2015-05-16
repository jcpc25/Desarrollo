using COES.Base.Core;
using COES.Dominio.DTO.Sic;
using COES.Servicios.Aplicacion.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.General
{
    public class DesviacionAppServicio : AppServicioBase
    {

        /// <summary>
        /// Inserta o actualiza un registro de desviaciones
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveDesviacion(DesviacionDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Lectcodi != 0)
                {
                    id = FactorySic.GetDesviacionRepositoryOracle().Save(entity);
                }


                return id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error app servicio");
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina una desviacion en base a la fecha
        /// </summary>
        /// <param name="idEmpresa"></param>
        public void DeleteDesviacion(DesviacionDTO entity)
        {
            try
            {
                FactorySic.GetDesviacionRepositoryOracle().Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public List<DesviacionDTO> ListaDesviaciones(String version)
        //{
        //    return FactorySic.GetDesviacionRepositoryExcel(version).List();
        //}


    }
}
