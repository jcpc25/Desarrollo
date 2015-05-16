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
    /// Clase de acceso a datos de la tabla ME_FORMATO
    /// </summary>
    public class MeFormatoRepository: RepositoryBase, IMeFormatoRepository
    {
        public MeFormatoRepository(string strConn): base(strConn)
        {
        }

        MeFormatoHelper helper = new MeFormatoHelper();

        public int Save(MeFormatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Areacode, DbType.Int32, entity.Areacode);
            dbProvider.AddInParameter(command, helper.Formatresolucion, DbType.Int32, entity.Formatresolucion);
            dbProvider.AddInParameter(command, helper.Formatextension, DbType.String, entity.Formatextension);
            dbProvider.AddInParameter(command, helper.Formatperiodo, DbType.Int32, entity.Formatperiodo);
            dbProvider.AddInParameter(command, helper.Formatnombre, DbType.String, entity.Formatnombre);
            dbProvider.AddInParameter(command, helper.Formathorizonte, DbType.Int32, entity.Formathorizonte);
            dbProvider.AddInParameter(command, helper.Formatversion, DbType.Int32, entity.Formatversion);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(MeFormatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Areacode, DbType.Int32, entity.Areacode);
            dbProvider.AddInParameter(command, helper.Formatresolucion, DbType.Int32, entity.Formatresolucion);
            dbProvider.AddInParameter(command, helper.Formatextension, DbType.String, entity.Formatextension);
            dbProvider.AddInParameter(command, helper.Formatperiodo, DbType.Int32, entity.Formatperiodo);
            dbProvider.AddInParameter(command, helper.Formatnombre, DbType.String, entity.Formatnombre);
            dbProvider.AddInParameter(command, helper.Formathorizonte, DbType.Int32, entity.Formathorizonte);
            //dbProvider.AddInParameter(command, helper.Formatversion, DbType.Int32, entity.Formatversion);
            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, entity.Formatcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int formatcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, formatcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public MeFormatoDTO GetById(int formatcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, formatcodi);
            MeFormatoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MeFormatoDTO> List()
        {
            List<MeFormatoDTO> entitys = new List<MeFormatoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlList);
            MeFormatoDTO entity;
            
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                int iAreaname = dr.GetOrdinal("areaname");
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    if (!dr.IsDBNull(iAreaname)) entity.Areaname = dr.GetString(iAreaname);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MeFormatoDTO> GetByCriteria(int areaUsuario)
        {
            string sqlQuery = string.Format(helper.SqlGetByCriteria, areaUsuario);
            List<MeFormatoDTO> entitys = new List<MeFormatoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);
            MeFormatoDTO entity;
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                int iAreaname = dr.GetOrdinal("areaname");
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    if (!dr.IsDBNull(iAreaname)) entity.Areaname = dr.GetString(iAreaname).Trim();
                    entitys.Add(entity);
                }
            }

            return entitys;
        }
    }
}
