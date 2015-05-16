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
    public class GeneralAppServicioTipoUsuario : AppServicioBase
    {
        /// <summary>
        /// Inserta o actualiza un registro de barras
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveOrUpdateTipoUsuario(TipoUsuarioDTO entity)
        {
            try
            {
                int id = 0;

                if (entity.Tipousuacodi == 0)
                {
                    id = FactoryTransferencia.GetTipoUsuarioRepository().Save(entity);
                }
                else
                {
                    FactoryTransferencia.GetTipoUsuarioRepository().Update(entity);
                    id = entity.Tipousuacodi;
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina una TipoUsuario en base al id
        /// </summary>
        /// <param name="idTipoUsuario"></param>
        public int DeleteTipoUsuario(int idTipoUsuario)
        {
            try
            {
                FactoryTransferencia.GetTipoUsuarioRepository().Delete(idTipoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return idTipoUsuario;
        }

        /// <summary>
        /// Permite obtenerTipoUsuario en base al id
        /// </summary>
        /// <param name="idTipoUsuario"></param>
        /// <returns></returns>
        public TipoUsuarioDTO GetByTipoUsuario(int idTipoUsuario)
        {
            return FactoryTransferencia.GetTipoUsuarioRepository().GetById(idTipoUsuario);
        }

        /// <summary>
        /// Permite listar todas TipoUsuario
        /// </summary>
        /// <returns></returns>
        public List<TipoUsuarioDTO> ListTipoUsuario()
        {
            return FactoryTransferencia.GetTipoUsuarioRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de TipoUsuario en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<TipoUsuarioDTO> BuscarTipoUsuario(string nombre)
        {
            return FactoryTransferencia.GetTipoUsuarioRepository().GetByCriteria(nombre);
        }

    }
}
