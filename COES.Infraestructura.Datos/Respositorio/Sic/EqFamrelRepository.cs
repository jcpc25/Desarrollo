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
    /// Clase de acceso a datos de la tabla EQ_FAMREL
    /// </summary>
    public class EqFamrelRepository: RepositoryBase, IEqFamrelRepository
    {
        public EqFamrelRepository(string strConn): base(strConn)
        {
        }

        EqFamrelHelper helper = new EqFamrelHelper();

        public void Save(EqFamrelDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, entity.Tiporelcodi);
            dbProvider.AddInParameter(command, helper.Famcodi1, DbType.Int32, entity.Famcodi1);
            dbProvider.AddInParameter(command, helper.Famcodi2, DbType.Int32, entity.Famcodi2);
            dbProvider.AddInParameter(command, helper.Famnumconec, DbType.Int32, entity.Famnumconec);
            dbProvider.AddInParameter(command, helper.Famreltension, DbType.String, entity.Famreltension);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(EqFamrelDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, entity.Tiporelcodi);
            dbProvider.AddInParameter(command, helper.Famcodi1, DbType.Int32, entity.Famcodi1);
            dbProvider.AddInParameter(command, helper.Famcodi2, DbType.Int32, entity.Famcodi2);
            dbProvider.AddInParameter(command, helper.Famnumconec, DbType.Int32, entity.Famnumconec);
            dbProvider.AddInParameter(command, helper.Famreltension, DbType.String, entity.Famreltension);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int tiporelcodi, int famcodi1, int famcodi2)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, tiporelcodi);
            dbProvider.AddInParameter(command, helper.Famcodi1, DbType.Int32, famcodi1);
            dbProvider.AddInParameter(command, helper.Famcodi2, DbType.Int32, famcodi2);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqFamrelDTO GetById(int tiporelcodi, int famcodi1, int famcodi2)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, tiporelcodi);
            dbProvider.AddInParameter(command, helper.Famcodi1, DbType.Int32, famcodi1);
            dbProvider.AddInParameter(command, helper.Famcodi2, DbType.Int32, famcodi2);
            EqFamrelDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqFamrelDTO> List()
        {
            List<EqFamrelDTO> entitys = new List<EqFamrelDTO>();
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

        public List<EqFamrelDTO> GetByCriteria()
        {
            List<EqFamrelDTO> entitys = new List<EqFamrelDTO>();
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
