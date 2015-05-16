using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;
namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class CbArchivoEnvioRepository : RepositoryBase, ICbArchivoEnvioRepository
    {
         /// <summary>
    /// Clase de acceso a datos de la tabla CB_ARCHIVOENVIO
    /// </summary>
        public CbArchivoEnvioRepository(string strConn) : base(strConn)
        {
        }
        CbArchivoEnvioHelper helper = new CbArchivoEnvioHelper();
        
        public void Save(CbArchivoEnvioDTO entity)
        {
            string insertQuery = string.Format(helper.SqlSave, entity.concepcodi, entity.enviocodi, entity.archivnombreenvio,
                entity.archivnombrefisico, entity.archivoestado, ((DateTime)entity.lastdate).ToString(ConstantesBase.FormatoFechaExtendido), 
                entity.lastuser, entity.archienvioorden);

            DbCommand command = dbProvider.GetSqlStringCommand(insertQuery);

            dbProvider.ExecuteNonQuery(command);
          
        }
        public void UpdateEstado(int iEstado, int concepcodi, int enviocodi, int archienvioorden)
        {
            string updateEstadoStr = string.Format(helper.SqlUpdateEstado, iEstado, concepcodi, enviocodi, archienvioorden);
            DbCommand command = dbProvider.GetSqlStringCommand(updateEstadoStr);

            dbProvider.ExecuteNonQuery(command);

        }
        public void Update(CbArchivoEnvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);
            dbProvider.AddInParameter(command, helper.concepcodi, DbType.Int32, entity.concepcodi);
            dbProvider.AddInParameter(command, helper.enviocodi, DbType.Int32, entity.enviocodi);
            dbProvider.AddInParameter(command, helper.archivnombreenvio, DbType.String, entity.archivnombreenvio);
            dbProvider.AddInParameter(command, helper.archivnombrefisico, DbType.String, entity.archivnombrefisico);
            dbProvider.AddInParameter(command, helper.archivoestado, DbType.Int32, entity.archivoestado);
            dbProvider.AddInParameter(command, helper.lastdate, DbType.DateTime, entity.lastdate);
            dbProvider.AddInParameter(command, helper.lastuser, DbType.String, entity.lastuser);
            dbProvider.AddInParameter(command, helper.lastuser, DbType.Int32, entity.archienvioorden);
            dbProvider.ExecuteNonQuery(command);
        }


        public void Delete(int concepcodi, int enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.concepcodi, DbType.Int32, concepcodi);
            dbProvider.AddInParameter(command, helper.concepcodi, DbType.Int32, enviocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public List<CbArchivoEnvioDTO> GetById(int enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            
            dbProvider.AddInParameter(command, helper.enviocodi, DbType.Int32, enviocodi);


            List<CbArchivoEnvioDTO> entitys = new List<CbArchivoEnvioDTO>();

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }
        public List<CbArchivoEnvioDTO> List()
        {
            List<CbArchivoEnvioDTO> entitys = new List<CbArchivoEnvioDTO>();
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
        public int GetMaxIdOrden(int concepcodi, int enviocodi)
        {
            string GetMaxIdOrdenStr = string.Format(helper.SqlGetMaxIdOrden, concepcodi, enviocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(GetMaxIdOrdenStr);

            object result = dbProvider.ExecuteScalar(command);
            int maxOrden = 1;
            if (result != null) maxOrden = Convert.ToInt32(result);
            return maxOrden;

        }
    }
}
