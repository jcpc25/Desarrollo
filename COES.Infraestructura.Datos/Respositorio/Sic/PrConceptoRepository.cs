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
    /// Clase de acceso a datos de la tabla PR_CONCEPTO
    /// </summary>
    public class PrConceptoRepository: RepositoryBase, IPrConceptoRepository
    {
        public PrConceptoRepository(string strConn): base(strConn)
        {
        }

        PrConceptoHelper helper = new PrConceptoHelper();

        public int Save(PrConceptoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Catecodi, DbType.Int32, entity.Catecodi);
            dbProvider.AddInParameter(command, helper.Concepabrev, DbType.String, entity.Concepabrev);
            dbProvider.AddInParameter(command, helper.Concepdesc, DbType.String, entity.Concepdesc);
            dbProvider.AddInParameter(command, helper.Concepunid, DbType.String, entity.Concepunid);
            dbProvider.AddInParameter(command, helper.Conceptipo, DbType.String, entity.Conceptipo);
            dbProvider.AddInParameter(command, helper.Conceporden, DbType.Int32, entity.Conceporden);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(PrConceptoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Catecodi, DbType.Int32, entity.Catecodi);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, entity.Concepcodi);
            dbProvider.AddInParameter(command, helper.Concepabrev, DbType.String, entity.Concepabrev);
            dbProvider.AddInParameter(command, helper.Concepdesc, DbType.String, entity.Concepdesc);
            dbProvider.AddInParameter(command, helper.Concepunid, DbType.String, entity.Concepunid);
            dbProvider.AddInParameter(command, helper.Conceptipo, DbType.String, entity.Conceptipo);
            dbProvider.AddInParameter(command, helper.Conceporden, DbType.Int32, entity.Conceporden);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int concepcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public PrConceptoDTO GetById(int concepcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);
            PrConceptoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<PrConceptoDTO> List()
        {
            List<PrConceptoDTO> entitys = new List<PrConceptoDTO>();
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

        public List<PrConceptoDTO> GetByCriteria()
        {
            List<PrConceptoDTO> entitys = new List<PrConceptoDTO>();
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
