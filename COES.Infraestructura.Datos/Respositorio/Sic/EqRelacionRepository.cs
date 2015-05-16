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
    /// Clase de acceso a datos de la tabla EQ_RELACION
    /// </summary>
    public class EqRelacionRepository: RepositoryBase, IEqRelacionRepository
    {
        public EqRelacionRepository(string strConn): base(strConn)
        {
        }

        EqRelacionHelper helper = new EqRelacionHelper();

        public int Save(EqRelacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Relacioncodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Codincp, DbType.Int32, entity.Codincp);
            dbProvider.AddInParameter(command, helper.Nombrencp, DbType.String, entity.Nombrencp);
            dbProvider.AddInParameter(command, helper.Codbarra, DbType.String, entity.Codbarra);
            dbProvider.AddInParameter(command, helper.Idgener, DbType.String, entity.Idgener);
            dbProvider.AddInParameter(command, helper.Descripcion, DbType.String, entity.Descripcion);
            dbProvider.AddInParameter(command, helper.Nombarra, DbType.String, entity.Nombarra);
            dbProvider.AddInParameter(command, helper.Estado, DbType.String, entity.Estado);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(EqRelacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Relacioncodi, DbType.Int32, entity.Relacioncodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Codincp, DbType.Int32, entity.Codincp);
            dbProvider.AddInParameter(command, helper.Nombrencp, DbType.String, entity.Nombrencp);
            dbProvider.AddInParameter(command, helper.Codbarra, DbType.String, entity.Codbarra);
            dbProvider.AddInParameter(command, helper.Idgener, DbType.String, entity.Idgener);
            dbProvider.AddInParameter(command, helper.Descripcion, DbType.String, entity.Descripcion);
            dbProvider.AddInParameter(command, helper.Nombarra, DbType.String, entity.Nombarra);
            dbProvider.AddInParameter(command, helper.Estado, DbType.String, entity.Estado);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int relacioncodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Relacioncodi, DbType.Int32, relacioncodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqRelacionDTO GetById(int relacioncodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Relacioncodi, DbType.Int32, relacioncodi);
            EqRelacionDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqRelacionDTO> List()
        {
            List<EqRelacionDTO> entitys = new List<EqRelacionDTO>();
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

        public List<EqRelacionDTO> GetByCriteria()
        {
            List<EqRelacionDTO> entitys = new List<EqRelacionDTO>();
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
