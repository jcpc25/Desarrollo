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
    /// Clase de acceso a datos de la tabla ME_ORIGENLECTURA
    /// </summary>
    public class MeOrigenlecturaRepository: RepositoryBase, IMeOrigenlecturaRepository
    {
        public MeOrigenlecturaRepository(string strConn): base(strConn)
        {
        }

        MeOrigenlecturaHelper helper = new MeOrigenlecturaHelper();

        public void Save(MeOrigenlecturaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Origlectnombre, DbType.String, entity.Origlectnombre);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, entity.Origlectcodi);
            dbProvider.AddInParameter(command, helper.Origlectnombre, DbType.String, entity.Origlectnombre);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, entity.Origlectcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MeOrigenlecturaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Origlectnombre, DbType.String, entity.Origlectnombre);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, entity.Origlectcodi);
            dbProvider.AddInParameter(command, helper.Origlectnombre, DbType.String, entity.Origlectnombre);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, entity.Origlectcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int origlectcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, origlectcodi);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, origlectcodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public MeOrigenlecturaDTO GetById(int origlectcodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, origlectcodi);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, origlectcodi);
            MeOrigenlecturaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MeOrigenlecturaDTO> List()
        {
            List<MeOrigenlecturaDTO> entitys = new List<MeOrigenlecturaDTO>();
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

        public List<MeOrigenlecturaDTO> GetByCriteria()
        {
            List<MeOrigenlecturaDTO> entitys = new List<MeOrigenlecturaDTO>();
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
