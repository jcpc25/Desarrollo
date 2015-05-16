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
    /// Clase de acceso a datos de la tabla CB_COMBUSTIBLEDATOS
    /// </summary>
    public class CbCombustibledatosRepository: RepositoryBase, ICbCombustibledatosRepository
    {
        public CbCombustibledatosRepository(string strConn): base(strConn)
        {
        }

        CbCombustibledatosHelper helper = new CbCombustibledatosHelper();

        public void Save(CbCombustibledatosDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Combdatosfecha, DbType.DateTime, entity.Combdatosfecha);
            dbProvider.AddInParameter(command, helper.Combdatosvalor, DbType.String, entity.Combdatosvalor);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, entity.Concepcodi);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, entity.Enviocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(CbCombustibledatosDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Combdatosfecha, DbType.DateTime, entity.Combdatosfecha);
            dbProvider.AddInParameter(command, helper.Combdatosvalor, DbType.String, entity.Combdatosvalor);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, entity.Concepcodi);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, entity.Enviocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(DateTime combdatosfecha, int concepcodi, int enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Combdatosfecha, DbType.DateTime, combdatosfecha);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, enviocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public CbCombustibledatosDTO GetById(DateTime combdatosfecha, int concepcodi, int enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Combdatosfecha, DbType.DateTime, combdatosfecha);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, enviocodi);
            CbCombustibledatosDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<CbCombustibledatosDTO> List()
        {
            List<CbCombustibledatosDTO> entitys = new List<CbCombustibledatosDTO>();
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

        public List<CbCombustibledatosDTO> GetByCriteria(int concepcodi, int enviocodi)
        {
            List<CbCombustibledatosDTO> entitys = new List<CbCombustibledatosDTO>();
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

        public List<CbCombustibledatosDTO> GetListPropValor(int idEnvio)
        {
            string query = string.Format(helper.SqlGetListPropValor, idEnvio);
            List<CbCombustibledatosDTO> entitys = new List<CbCombustibledatosDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            CbCombustibledatosDTO entity = new CbCombustibledatosDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iCONCEPORDEN = dr.GetOrdinal("CONCEPORDEN");
                    if (!dr.IsDBNull(iCONCEPORDEN)) entity.Conceporden = dr.GetInt32(iCONCEPORDEN);
                    int iCONCEPNOMB = dr.GetOrdinal("CONCEPNOMB");
                    if (!dr.IsDBNull(iCONCEPNOMB)) entity.Concepnomb = dr.GetString(iCONCEPNOMB);
                    int iCONCEPUNIDAD = dr.GetOrdinal("CONCEPUNIDAD");
                    if (!dr.IsDBNull(iCONCEPUNIDAD)) entity.Concepunidad = dr.GetString(iCONCEPUNIDAD);
                    entitys.Add(entity);

                }
            }

            return entitys;
        }

    }
}
