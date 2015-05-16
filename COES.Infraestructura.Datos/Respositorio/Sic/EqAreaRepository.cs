using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    /// <summary>
    /// Clase de acceso a datos de la tabla EQ_AREA
    /// </summary>
    public class EqAreaRepository: RepositoryBase, IEqAreaRepository
    {
        public EqAreaRepository(string strConn): base(strConn)
        {
        }

        EqAreaHelper helper = new EqAreaHelper();

        public int Save(EqAreaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, entity.Tareacodi);
            dbProvider.AddInParameter(command, helper.Areaabrev, DbType.String, entity.Areaabrev);
            dbProvider.AddInParameter(command, helper.Areanomb, DbType.String, entity.Areanomb);
            dbProvider.AddInParameter(command, helper.Areapadre, DbType.Int32, entity.Areapadre);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(EqAreaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, entity.Areacodi);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, entity.Tareacodi);
            dbProvider.AddInParameter(command, helper.Areaabrev, DbType.String, entity.Areaabrev);
            dbProvider.AddInParameter(command, helper.Areanomb, DbType.String, entity.Areanomb);
            dbProvider.AddInParameter(command, helper.Areapadre, DbType.Int32, entity.Areapadre);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int areacodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, areacodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqAreaDTO GetById(int areacodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Areacodi, DbType.Int32, areacodi);
            EqAreaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqAreaDTO> List()
        {
            List<EqAreaDTO> entitys = new List<EqAreaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public List<EqAreaDTO> GetByCriteria()
        {
            List<EqAreaDTO> entitys = new List<EqAreaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        /// <summary>
        /// Listado de áreas filtradas por tipo de área y nombre de área
        /// </summary>
        /// <param name="idTipoArea">Id de Tipo de Área, para evitar este filtro usar -99</param>
        /// <param name="strNombreArea">Nombre de Área</param>
        /// <param name="nroPagina">Cantidad de Página</param>
        /// <param name="nroFilas">Cantidad de Registros por Página</param>
        /// <returns></returns>
        public List<EqAreaDTO> ListarxFiltro(int idTipoArea, string strNombreArea, int nroPagina, int nroFilas)
        {
            if (string.IsNullOrEmpty(strNombreArea)) strNombreArea = string.Empty;
            List<EqAreaDTO> entitys = new List<EqAreaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlAreasPorFiltro);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, idTipoArea);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, idTipoArea);
            dbProvider.AddInParameter(command, helper.Areanomb, DbType.String, strNombreArea);
            dbProvider.AddInParameter(command, "nropaginas", DbType.Int32, nroPagina);
            dbProvider.AddInParameter(command, "nroFilas", DbType.Int32, nroFilas);
            dbProvider.AddInParameter(command, "nropaginas", DbType.Int32, nroPagina);
            dbProvider.AddInParameter(command, "nroFilas", DbType.Int32, nroFilas);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var entidad = new EqAreaDTO();
                    entidad = helper.Create(dr);
                    entidad.Tareanomb = dr.GetString(dr.GetOrdinal("TAREANOMB"));
                    entitys.Add(entidad);
                }
            }
            return entitys;
        }

        /// <summary>
        /// Obtiene la cantidad total de resultados de la Consulta ListarxFiltro
        /// </summary>
        /// <param name="idTipoArea">Id de Tipo de Área, para evitar este filtro usar -99</param>
        /// <param name="strNombreArea">Nombre de Área</param>
        /// <returns></returns>
        public int CantidadListarxFiltro(int idTipoArea, string strNombreArea)
        {
            if (string.IsNullOrEmpty(strNombreArea)) strNombreArea = string.Empty;

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCantidadAreasPorFiltro);
            
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, idTipoArea);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, idTipoArea);
            dbProvider.AddInParameter(command, helper.Areanomb, DbType.String, strNombreArea);
            object count = dbProvider.ExecuteScalar(command);
            if (count != null) return Convert.ToInt32(count);
            return 0;
        }
    }
}
