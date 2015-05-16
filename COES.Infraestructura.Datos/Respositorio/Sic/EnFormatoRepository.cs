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
    /// Clase de acceso a datos de la tabla EN_FORMATO
    /// </summary>
    public class EnFormatoRepository: RepositoryBase, IEnFormatoRepository
    {
        public EnFormatoRepository(string strConn): base(strConn)
        {
        }

        EnFormatoHelper helper = new EnFormatoHelper();


        public void Update(EnFormatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Formatocodi, DbType.Int32, entity.Formatocodi);
            dbProvider.AddInParameter(command, helper.Formatodesc, DbType.String, entity.Formatodesc);
            dbProvider.AddInParameter(command, helper.Tipoarchivo, DbType.Int32, entity.Tipoarchivo);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Save(EnFormatoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Formatocodi, DbType.Int32, entity.Formatocodi);
            dbProvider.AddInParameter(command, helper.Formatodesc, DbType.String, entity.Formatodesc);
            dbProvider.AddInParameter(command, helper.Tipoarchivo, DbType.Int32, entity.Tipoarchivo);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.ExecuteNonQuery(command);
        }

        public EnFormatoDTO GetById()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            EnFormatoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EnFormatoDTO> List()
        {
            List<EnFormatoDTO> entitys = new List<EnFormatoDTO>();
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

        public List<EnFormatoDTO> GetByCriteria()
        {
            List<EnFormatoDTO> entitys = new List<EnFormatoDTO>();
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
