using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Transferencias;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;

namespace COES.Servicios.Aplicacion.Transferencias
{
    /// <summary>
    /// Clases con métodos del módulo Empresa
    /// </summary>
    public class GeneralAppServicioEmpresa : AppServicioBase
    {
        /// <summary>
        /// Permite obtener la empresa en base al id
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public EmpresaDTO GetByIdEmpresa(int idEmpresa)
        {
            return FactoryTransferencia.GetEmpresaRepository().GetById(idEmpresa);
        }

        /// <summary>
        /// Permite encontrar a una empresa
        /// </summary>
        /// <returns></returns>
        /// 
        public EmpresaDTO GetByCodigo(string nombre)
        {
            return FactoryTransferencia.GetEmpresaRepository().GetByCodigo(nombre);
        }

        public List<EmpresaDTO> ListEmpresas()
        {
            return FactoryTransferencia.GetEmpresaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas de empresas en base al nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<EmpresaDTO> BuscarEmpresas(string nombre)
        {
            return FactoryTransferencia.GetEmpresaRepository().GetByCriteria(nombre);
        }

    }
}
