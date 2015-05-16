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
    /// Clase de acceso a datos de la tabla MD_ENVIO
    /// </summary>
    public class MdEnvioRepository: RepositoryBase, IMdEnvioRepository
    {
        public MdEnvioRepository(string strConn): base(strConn)
        {
        }

        MdEnvioHelper helper = new MdEnvioHelper();

        public void Save(MdEnvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);
           
            dbProvider.AddInParameter(command, helper.Envioarchnomb, DbType.String, entity.Envioarchnomb);
            dbProvider.AddInParameter(command, helper.Estenvcodi, DbType.Int32, entity.Estenvcodi);
            dbProvider.AddInParameter(command, helper.Enviomes, DbType.DateTime, entity.Enviomes);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Usercodi, DbType.String, entity.Usercodi);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, entity.Enviocodi);
            dbProvider.AddInParameter(command, helper.Enviofecha, DbType.DateTime, entity.Enviofecha);

            dbProvider.ExecuteNonQuery(command);
            
        }

        public void Update(MdEnvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Envioarchnomb, DbType.String, entity.Envioarchnomb);
            dbProvider.AddInParameter(command, helper.Estenvcodi, DbType.Int32, entity.Estenvcodi);
            dbProvider.AddInParameter(command, helper.Enviomes, DbType.DateTime, entity.Enviomes);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Usercodi, DbType.String, entity.Usercodi);
            dbProvider.AddInParameter(command, helper.Enviofecha, DbType.DateTime, entity.Enviofecha);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, entity.Enviocodi);
            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, enviocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public MdEnvioDTO GetById(int enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, enviocodi);
            MdEnvioDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MdEnvioDTO> List()
        {
            List<MdEnvioDTO> entitys = new List<MdEnvioDTO>();
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

        public List<MdEnvioDTO> GetByCriteria(int emprcodi,DateTime enviomes)
        {
            List<MdEnvioDTO> entitys = new List<MdEnvioDTO>();
            string query = string.Format(helper.SqlGetByCriteria, emprcodi, enviomes.ToString("yyyy-MM-dd"));
            DbCommand command = dbProvider.GetSqlStringCommand(query);

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
