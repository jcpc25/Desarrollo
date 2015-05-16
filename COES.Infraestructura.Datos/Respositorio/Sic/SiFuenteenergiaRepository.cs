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
    /// Clase de acceso a datos de la tabla SI_FUENTEENERGIA
    /// </summary>
    public class SiFuenteenergiaRepository: RepositoryBase, ISiFuenteenergiaRepository
    {
        public SiFuenteenergiaRepository(string strConn): base(strConn)
        {
        }

        SiFuenteenergiaHelper helper = new SiFuenteenergiaHelper();

        public int Save(SiFuenteenergiaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Fenergcodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Fenergabrev, DbType.String, entity.Fenergabrev);
            dbProvider.AddInParameter(command, helper.Fenergnomb, DbType.String, entity.Fenergnomb);
            dbProvider.AddInParameter(command, helper.Tgenercodi, DbType.Int32, entity.Tgenercodi);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(SiFuenteenergiaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Fenergcodi, DbType.Int32, entity.Fenergcodi);
            dbProvider.AddInParameter(command, helper.Fenergabrev, DbType.String, entity.Fenergabrev);
            dbProvider.AddInParameter(command, helper.Fenergnomb, DbType.String, entity.Fenergnomb);
            dbProvider.AddInParameter(command, helper.Tgenercodi, DbType.Int32, entity.Tgenercodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int fenergcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Fenergcodi, DbType.Int32, fenergcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public SiFuenteenergiaDTO GetById(int fenergcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Fenergcodi, DbType.Int32, fenergcodi);
            SiFuenteenergiaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<SiFuenteenergiaDTO> List()
        {
            List<SiFuenteenergiaDTO> entitys = new List<SiFuenteenergiaDTO>();
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

        public List<SiFuenteenergiaDTO> GetByCriteria()
        {
            List<SiFuenteenergiaDTO> entitys = new List<SiFuenteenergiaDTO>();
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
