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
    /// Clase de acceso a datos de la tabla PR_GRUPODAT
    /// </summary>
    public class PrGrupodatRepository: RepositoryBase, IPrGrupodatRepository
    {
        public PrGrupodatRepository(string strConn): base(strConn)
        {
        }

        PrGrupodatHelper helper = new PrGrupodatHelper();

        public void Save(PrGrupodatDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Fechadat, DbType.DateTime, entity.Fechadat);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, entity.Concepcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Formuladat, DbType.String, entity.Formuladat);
            dbProvider.AddInParameter(command, helper.Deleted, DbType.Int32, entity.Deleted);
            dbProvider.AddInParameter(command, helper.Fechaact, DbType.DateTime, entity.Fechaact);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(PrGrupodatDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Fechadat, DbType.DateTime, entity.Fechadat);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, entity.Concepcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Formuladat, DbType.String, entity.Formuladat);
            dbProvider.AddInParameter(command, helper.Deleted, DbType.Int32, entity.Deleted);
            dbProvider.AddInParameter(command, helper.Fechaact, DbType.DateTime, entity.Fechaact);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(DateTime fechadat, int concepcodi, int grupocodi, int deleted)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Fechadat, DbType.DateTime, fechadat);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, grupocodi);
            dbProvider.AddInParameter(command, helper.Deleted, DbType.Int32, deleted);

            dbProvider.ExecuteNonQuery(command);
        }

        public PrGrupodatDTO GetById(DateTime fechadat, int concepcodi, int grupocodi, int deleted)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Fechadat, DbType.DateTime, fechadat);
            dbProvider.AddInParameter(command, helper.Concepcodi, DbType.Int32, concepcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, grupocodi);
            dbProvider.AddInParameter(command, helper.Deleted, DbType.Int32, deleted);
            PrGrupodatDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<PrGrupodatDTO> List()
        {
            List<PrGrupodatDTO> entitys = new List<PrGrupodatDTO>();
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

        public List<PrGrupodatDTO> GetByCriteria()
        {
            List<PrGrupodatDTO> entitys = new List<PrGrupodatDTO>();
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


        public List<ConceptoDatoDTO> ListarDatosConceptoGrupoDat(int iGrupoCodi)
        {
            var resultado = new List<ConceptoDatoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlValoresModoOperacionGrupoDat);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, iGrupoCodi);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oDatoConc = new ConceptoDatoDTO();
                    oDatoConc.CONCEPCODI = dr.IsDBNull(dr.GetOrdinal("CONCEPCODI")) ? -1 : dr.GetInt32(dr.GetOrdinal("CONCEPCODI"));
                    oDatoConc.CONCEPUNID = dr.IsDBNull(dr.GetOrdinal("CONCEPUNID")) ? "" : dr.GetString(dr.GetOrdinal("CONCEPUNID"));
                    oDatoConc.VALOR = dr.IsDBNull(dr.GetOrdinal("VALOR")) ? "" : dr.GetString(dr.GetOrdinal("VALOR"));
                    resultado.Add(oDatoConc);
                }
            }

            return resultado;
        }
    }
}
