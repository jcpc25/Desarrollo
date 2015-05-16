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
    /// <summary>
    /// Clase de acceso a datos de la tabla EN_ENSAYOUNIDAD
    /// </summary>
    public class EnEnsayounidadRepository: RepositoryBase, IEnEnsayounidadRepository
    {
        public EnEnsayounidadRepository(string strConn): base(strConn)
        {
        }

        EnEnsayounidadHelper helper = new EnEnsayounidadHelper();  

        public void Update(EnEnsayounidadDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Ensayocodi, DbType.Int32, entity.Ensayocodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Unidadfecha, DbType.DateTime, entity.Unidadfecha);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Save(EnEnsayounidadDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Ensayocodi, DbType.Int32, entity.Ensayocodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Unidadfecha, DbType.DateTime, entity.Unidadfecha);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int ensayocodi)
        {
            string sqlQuery = string.Format(helper.SqlDelete, ensayocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);
            dbProvider.ExecuteNonQuery(command);
        }
        public EnEnsayounidadDTO GetById()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            EnEnsayounidadDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EnEnsayounidadDTO> List()
        {
            List<EnEnsayounidadDTO> entitys = new List<EnEnsayounidadDTO>();
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
        public List<EnEnsayounidadDTO> ListarUnidadxEnsayo(int ensayocodi)
        {
            List<EnEnsayounidadDTO> entitys = new List<EnEnsayounidadDTO>();
            string query = string.Format(helper.SqlListUnidadxEnsayo, ensayocodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            EnEnsayounidadDTO entity = new EnEnsayounidadDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iequinomb = dr.GetOrdinal("equinomb");
                    if (!dr.IsDBNull(iequinomb)) entity.equinomb = dr.GetString(iequinomb);                   
                    entitys.Add(entity);
                }
            }
            return entitys;
        }
        public List<EnEnsayounidadDTO> GetByCriteria()
        {
            List<EnEnsayounidadDTO> entitys = new List<EnEnsayounidadDTO>();
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
