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
    /// Clase de acceso a datos de la tabla MD_PUBLICACION
    /// </summary>
    public class MdPublicacionRepository: RepositoryBase, IMdPublicacionRepository
    {
        public MdPublicacionRepository(string strConn): base(strConn)
        {
        }

        MdPublicacionHelper helper = new MdPublicacionHelper();

        public void Save(MdPublicacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Publiarchivo, DbType.String, entity.Publiarchivo);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Publiplazofecha, DbType.DateTime, entity.Publiplazofecha);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Usercodi, DbType.String, entity.Usercodi);
            dbProvider.AddInParameter(command, helper.Publimes, DbType.DateTime, entity.Publimes);
            dbProvider.AddInParameter(command, helper.Publifecha, DbType.DateTime, entity.Publifecha);
            dbProvider.AddInParameter(command, helper.Publipin, DbType.String, entity.Publipin);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MdPublicacionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Publiarchivo, DbType.String, entity.Publiarchivo);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Publiplazofecha, DbType.DateTime, entity.Publiplazofecha);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Usercodi, DbType.String, entity.Usercodi);
            dbProvider.AddInParameter(command, helper.Publimes, DbType.DateTime, entity.Publimes);
            dbProvider.AddInParameter(command, helper.Publifecha, DbType.DateTime, entity.Publifecha);
            dbProvider.AddInParameter(command, helper.Publipin, DbType.String, entity.Publipin);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int emprcodi, DateTime publimes)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.Publimes, DbType.DateTime, publimes);

            dbProvider.ExecuteNonQuery(command);
        }

        public MdPublicacionDTO GetById(int emprcodi, DateTime publimes)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.Publimes, DbType.DateTime, publimes);
            MdPublicacionDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MdPublicacionDTO> List()
        {
            List<MdPublicacionDTO> entitys = new List<MdPublicacionDTO>();
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

        public List<MdPublicacionDTO> GetByCriteria()
        {
            List<MdPublicacionDTO> entitys = new List<MdPublicacionDTO>();
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

        public MdPublicacionDTO GetLastPubEmpresa(DateTime publimes,int emprcodi)
        {
            MdPublicacionDTO entity;
            DateTime fechames = new DateTime(publimes.Year, publimes.Month, 1);
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetLastPubEmpresa);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, emprcodi);
            dbProvider.AddInParameter(command, helper.Publimes, DbType.DateTime, fechames);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = new MdPublicacionDTO();
                    entity = helper.Create(dr);
                    return entity;
                }
                
            }

            return null;
        }
    }
}
