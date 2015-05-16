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
    /// Clase de acceso a datos de la tabla ME_AMPLIACIONFECHA
    /// </summary>
    public class MeAmpliacionfechaRepository: RepositoryBase, IMeAmpliacionfechaRepository
    {
        public MeAmpliacionfechaRepository(string strConn): base(strConn)
        {
        }

        MeAmpliacionfechaHelper helper = new MeAmpliacionfechaHelper();

        public void Update(MeAmpliacionfechaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Amplifecha, DbType.DateTime, entity.Amplifecha);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, entity.Formatcodi);
            dbProvider.AddInParameter(command, helper.Amplifechaplazo, DbType.DateTime, entity.Amplifechaplazo);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Save(MeAmpliacionfechaDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Amplifecha, DbType.DateTime, entity.Amplifecha);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Formatcodi, DbType.Int32, entity.Formatcodi);
            dbProvider.AddInParameter(command, helper.Amplifechaplazo, DbType.DateTime, entity.Amplifechaplazo);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete()
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);


            dbProvider.ExecuteNonQuery(command);
        }

        public MeAmpliacionfechaDTO GetById(DateTime fecha,int empresa,int formato)
        {
            string queryString = string.Format(helper.SqlGetById, fecha.ToString(ConstantesBase.FormatoFecha), empresa, formato);
            DbCommand command = dbProvider.GetSqlStringCommand(queryString);

            MeAmpliacionfechaDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<MeAmpliacionfechaDTO> List()
        {
            List<MeAmpliacionfechaDTO> entitys = new List<MeAmpliacionfechaDTO>();
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

        public List<MeAmpliacionfechaDTO> GetByCriteria()
        {
            List<MeAmpliacionfechaDTO> entitys = new List<MeAmpliacionfechaDTO>();
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

        public List<MeAmpliacionfechaDTO> GetListaAmpliacion(DateTime fechaIni, DateTime fechaFin, int empresa, int formato)
        {
            List<MeAmpliacionfechaDTO> entitys = new List<MeAmpliacionfechaDTO>();
            string queryString = string.Format(helper.SqlListaAmpliacion, fechaIni.ToString(ConstantesBase.FormatoFecha),
                fechaFin.ToString(ConstantesBase.FormatoFecha), empresa, formato);
            DbCommand command = dbProvider.GetSqlStringCommand(queryString);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    MeAmpliacionfechaDTO entity = helper.Create(dr);
                    int iEmprnomb = dr.GetOrdinal("emprnomb");
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                    int iFormatnomb = dr.GetOrdinal("formatnombre");
                    if (!dr.IsDBNull(iFormatnomb)) entity.Formatnombre = dr.GetString(iFormatnomb);
                    entitys.Add(entity);
                }
            }
            return entitys;
        }
    }
}
