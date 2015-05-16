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
    /// Clase de acceso a datos de la tabla EQ_TIPOREL
    /// </summary>
    public class EqTiporelRepository: RepositoryBase, IEqTiporelRepository
    {
        public EqTiporelRepository(string strConn): base(strConn)
        {
        }

        EqTiporelHelper helper = new EqTiporelHelper();

        public int Save(EqTiporelDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Tiporelnomb, DbType.String, entity.Tiporelnomb);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(EqTiporelDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, entity.Tiporelcodi);
            dbProvider.AddInParameter(command, helper.Tiporelnomb, DbType.String, entity.Tiporelnomb);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int tiporelcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, tiporelcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqTiporelDTO GetById(int tiporelcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, tiporelcodi);
            EqTiporelDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqTiporelDTO> List()
        {
            List<EqTiporelDTO> entitys = new List<EqTiporelDTO>();
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

        public List<EqTiporelDTO> GetByCriteria()
        {
            List<EqTiporelDTO> entitys = new List<EqTiporelDTO>();
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
    }
}
