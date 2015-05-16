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
    /// Clase de acceso a datos de la tabla ME_PERIODOMEDIDOR
    /// </summary>
    public class MePeriodomedidorRepository: RepositoryBase, IMePeriodomedidorRepository
    {
        public MePeriodomedidorRepository(string strConn): base(strConn)
        {
        }

        MePeriodomedidorHelper helper = new MePeriodomedidorHelper();

        public void Update(MePeriodomedidorDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Medicodi, DbType.Int32, entity.Medicodi);
            dbProvider.AddInParameter(command, helper.Earcodi, DbType.Int32, entity.Earcodi);
            dbProvider.AddInParameter(command, helper.Permedifechaini, DbType.DateTime, entity.Permedifechaini);
            dbProvider.AddInParameter(command, helper.Permedifechafin, DbType.DateTime, entity.Permedifechafin);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Save(MePeriodomedidorDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Medicodi, DbType.Int32, entity.Medicodi);
            dbProvider.AddInParameter(command, helper.Earcodi, DbType.Int32, entity.Earcodi);
            dbProvider.AddInParameter(command, helper.Permedifechaini, DbType.DateTime, entity.Permedifechaini);
            dbProvider.AddInParameter(command, helper.Permedifechafin, DbType.DateTime, entity.Permedifechafin);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.ExecuteNonQuery(command);
        }

        public MePeriodomedidorDTO GetById()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            MePeriodomedidorDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MePeriodomedidorDTO> List()
        {
            List<MePeriodomedidorDTO> entitys = new List<MePeriodomedidorDTO>();
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

        public List<MePeriodomedidorDTO> GetByCriteria()
        {
            List<MePeriodomedidorDTO> entitys = new List<MePeriodomedidorDTO>();
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
