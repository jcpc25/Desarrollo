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
    /// Clase de acceso a datos de la tabla EQ_PROPEQUI
    /// </summary>
    public class EqPropequiRepository: RepositoryBase, IEqPropequiRepository
    {
        public EqPropequiRepository(string strConn): base(strConn)
        {
        }

        EqPropequiHelper helper = new EqPropequiHelper();

        public void Save(EqPropequiDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, entity.Propcodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Fechapropequi, DbType.DateTime, entity.Fechapropequi);
            dbProvider.AddInParameter(command, helper.Valor, DbType.String, entity.Valor);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(EqPropequiDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, entity.Propcodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Fechapropequi, DbType.DateTime, entity.Fechapropequi);
            dbProvider.AddInParameter(command, helper.Valor, DbType.String, entity.Valor);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int propcodi, int equicodi, DateTime fechapropequi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, propcodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, equicodi);
            dbProvider.AddInParameter(command, helper.Fechapropequi, DbType.DateTime, fechapropequi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EqPropequiDTO GetById(int propcodi, int equicodi, DateTime fechapropequi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Propcodi, DbType.Int32, propcodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, equicodi);
            dbProvider.AddInParameter(command, helper.Fechapropequi, DbType.DateTime, fechapropequi);
            EqPropequiDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EqPropequiDTO> List()
        {
            List<EqPropequiDTO> entitys = new List<EqPropequiDTO>();
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

        public List<EqPropequiDTO> GetByCriteria()
        {
            List<EqPropequiDTO> entitys = new List<EqPropequiDTO>();
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

        /// <summary>
        /// Método que retorna los valores de las propiedades marcadas como parte de Ficha Técnica
        /// </summary>
        /// <param name="iEquipo">Código de Equipo</param>
        /// <param name="iFamilia">Código de Familia</param>
        /// <returns></returns>
        public List<PropiedadEquipoHistDTO> ListarDatosPropiedadesFichaTecnicaVigentesxEquipo(int iEquipo, int iFamilia)
        {
            var entities = new List<PropiedadEquipoHistDTO>();
            string strCommand = string.Format(helper.SqlPropiedadesFichaTecnicaVigentesxEquipo, iEquipo, iFamilia);
            DbCommand command = dbProvider.GetSqlStringCommand(strCommand);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oPropEquipo = new PropiedadEquipoHistDTO();
                    oPropEquipo.PROPCODI = dr.IsDBNull(dr.GetOrdinal("PROPCODI")) ? -1 : dr.GetInt32(dr.GetOrdinal("PROPCODI"));
                    oPropEquipo.PROPFILE = dr.IsDBNull(dr.GetOrdinal("PROPFILE")) ? "" : dr.GetString(dr.GetOrdinal("PROPFILE"));
                    oPropEquipo.PROPUNIDAD = dr.IsDBNull(dr.GetOrdinal("PROPUNIDAD")) ? "" : dr.GetString(dr.GetOrdinal("PROPUNIDAD"));
                    oPropEquipo.VALOR = dr.IsDBNull(dr.GetOrdinal("VALOR")) ? "" : dr.GetString(dr.GetOrdinal("VALOR"));
                    entities.Add(oPropEquipo);
                }
            }
            return entities;
        }
    }
}
