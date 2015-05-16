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
    /// Clase de acceso a datos de la tabla EQ_FAMILIA
    /// </summary>
    public class EqFamiliaRepository: RepositoryBase, IEqFamiliaRepository
    {
        public EqFamiliaRepository(string strConn): base(strConn)
        {
        }

        EqFamiliaHelper helper = new EqFamiliaHelper();

        public int Save(EqFamiliaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Famabrev, DbType.String, entity.Famabrev);
            dbProvider.AddInParameter(command, helper.Tipoecodi, DbType.Int32, entity.Tipoecodi);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, entity.Tareacodi);
            dbProvider.AddInParameter(command, helper.Famnomb, DbType.String, entity.Famnomb);
            dbProvider.AddInParameter(command, helper.Famnumconec, DbType.Int32, entity.Famnumconec);
            dbProvider.AddInParameter(command, helper.Famnombgraf, DbType.String, entity.Famnombgraf);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(EqFamiliaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, entity.Famcodi);
            dbProvider.AddInParameter(command, helper.Famabrev, DbType.String, entity.Famabrev);
            dbProvider.AddInParameter(command, helper.Tipoecodi, DbType.Int32, entity.Tipoecodi);
            dbProvider.AddInParameter(command, helper.Tareacodi, DbType.Int32, entity.Tareacodi);
            dbProvider.AddInParameter(command, helper.Famnomb, DbType.String, entity.Famnomb);
            dbProvider.AddInParameter(command, helper.Famnumconec, DbType.Int32, entity.Famnumconec);
            dbProvider.AddInParameter(command, helper.Famnombgraf, DbType.String, entity.Famnombgraf);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int famcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, famcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqFamiliaDTO GetById(int famcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Famcodi, DbType.Int32, famcodi);
            EqFamiliaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqFamiliaDTO> List()
        {
            List<EqFamiliaDTO> entitys = new List<EqFamiliaDTO>();
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

        public List<EqFamiliaDTO> GetByCriteria()
        {
            List<EqFamiliaDTO> entitys = new List<EqFamiliaDTO>();
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
