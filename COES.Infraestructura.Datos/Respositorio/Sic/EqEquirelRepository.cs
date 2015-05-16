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
    /// Clase de acceso a datos de la tabla EQ_EQUIREL
    /// </summary>
    public class EqEquirelRepository: RepositoryBase, IEqEquirelRepository
    {
        public EqEquirelRepository(string strConn): base(strConn)
        {
        }

        EqEquirelHelper helper = new EqEquirelHelper();

        public void Save(EqEquirelDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Equicodi1, DbType.Int32, entity.Equicodi1);
            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, entity.Tiporelcodi);
            dbProvider.AddInParameter(command, helper.Equicodi2, DbType.Int32, entity.Equicodi2);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(EqEquirelDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Equicodi1, DbType.Int32, entity.Equicodi1);
            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, entity.Tiporelcodi);
            dbProvider.AddInParameter(command, helper.Equicodi2, DbType.Int32, entity.Equicodi2);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int equicodi1, int tiporelcodi, int equicodi2)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Equicodi1, DbType.Int32, equicodi1);
            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, tiporelcodi);
            dbProvider.AddInParameter(command, helper.Equicodi2, DbType.Int32, equicodi2);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqEquirelDTO GetById(int equicodi1, int tiporelcodi, int equicodi2)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Equicodi1, DbType.Int32, equicodi1);
            dbProvider.AddInParameter(command, helper.Tiporelcodi, DbType.Int32, tiporelcodi);
            dbProvider.AddInParameter(command, helper.Equicodi2, DbType.Int32, equicodi2);
            EqEquirelDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqEquirelDTO> List()
        {
            List<EqEquirelDTO> entitys = new List<EqEquirelDTO>();
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

        public List<EqEquirelDTO> GetByCriteria()
        {
            List<EqEquirelDTO> entitys = new List<EqEquirelDTO>();
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
