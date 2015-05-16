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
    /// Clase de acceso a datos de la tabla CB_CONCEPTOCOMB
    /// </summary>
    public class CbConceptocombRepository: RepositoryBase, ICbConceptocombRepository
    {
        public CbConceptocombRepository(string strConn): base(strConn)
        {
        }

        CbConceptocombHelper helper = new CbConceptocombHelper();

        public int Save(CbConceptocombDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Conceptipo, DbType.String, entity.Conceptipo);
            dbProvider.AddInParameter(command, helper.Concepabrev, DbType.String, entity.Concepabrev);
            dbProvider.AddInParameter(command, helper.Conceporden, DbType.Int32, entity.Conceporden);
            dbProvider.AddInParameter(command, helper.Concepunidad, DbType.String, entity.Concepunidad);
            dbProvider.AddInParameter(command, helper.Tipocombcodi, DbType.Int32, entity.Tipocombcodi);
            dbProvider.AddInParameter(command, helper.Concepnomb, DbType.String, entity.Concepnomb);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(CbConceptocombDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Conceptipo, DbType.String, entity.Conceptipo);
            dbProvider.AddInParameter(command, helper.Concepabrev, DbType.String, entity.Concepabrev);
            dbProvider.AddInParameter(command, helper.Conceporden, DbType.Int32, entity.Conceporden);
            dbProvider.AddInParameter(command, helper.Concepunidad, DbType.String, entity.Concepunidad);
            dbProvider.AddInParameter(command, helper.Tipocombcodi, DbType.Int32, entity.Tipocombcodi);
            dbProvider.AddInParameter(command, helper.Concepnomb, DbType.String, entity.Concepnomb);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, entity.Concepcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int concepcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public CbConceptocombDTO GetById(int concepcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);
            CbConceptocombDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<CbConceptocombDTO> List()
        {
            List<CbConceptocombDTO> entitys = new List<CbConceptocombDTO>();
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

        public int GetByCriteria(int orden,int tipocomb)
        {
            List<CbConceptocombDTO> entitys = new List<CbConceptocombDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Conceporden, DbType.Int32, orden);
            dbProvider.AddInParameter(command, helper.Tipocombcodi, DbType.Int32, tipocomb);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null) id = Convert.ToInt32(result);

            return id;
        }
    }
}
