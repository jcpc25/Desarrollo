using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    /// <summary>
    /// Clase de acceso a datos de la tabla PR_GRUPO
    /// </summary>
    public class PrGrupoRepository: RepositoryBase, IPrGrupoRepository
    {
        public PrGrupoRepository(string strConn): base(strConn)
        {
        }

        PrGrupoHelper helper = new PrGrupoHelper();

        public int Save(PrGrupoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null)id = Convert.ToInt32(result);

            command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, id);
            dbProvider.AddInParameter(command, helper.Fenergcodi, DbType.Int32, entity.Fenergcodi);
            dbProvider.AddInParameter(command, helper.Barracodi, DbType.Int32, entity.Barracodi);
            dbProvider.AddInParameter(command, helper.Gruponomb, DbType.String, entity.Gruponomb);
            dbProvider.AddInParameter(command, helper.Grupoabrev, DbType.String, entity.Grupoabrev);
            dbProvider.AddInParameter(command, helper.Grupovmax, DbType.Decimal, entity.Grupovmax);
            dbProvider.AddInParameter(command, helper.Grupovmin, DbType.Decimal, entity.Grupovmin);
            dbProvider.AddInParameter(command, helper.Grupoorden, DbType.Int32, entity.Grupoorden);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Grupotipo, DbType.String, entity.Grupotipo);
            dbProvider.AddInParameter(command, helper.Catecodi, DbType.Int32, entity.Catecodi);
            dbProvider.AddInParameter(command, helper.Grupotipoc, DbType.Int32, entity.Grupotipoc);
            dbProvider.AddInParameter(command, helper.Grupopadre, DbType.Int32, entity.Grupopadre);
            dbProvider.AddInParameter(command, helper.Grupoactivo, DbType.String, entity.Grupoactivo);
            dbProvider.AddInParameter(command, helper.Grupocomb, DbType.String, entity.Grupocomb);
            dbProvider.AddInParameter(command, helper.Osicodi, DbType.String, entity.Osicodi);
            dbProvider.AddInParameter(command, helper.Grupocodi2, DbType.Int32, entity.Grupocodi2);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Gruposub, DbType.String, entity.Gruposub);
            dbProvider.AddInParameter(command, helper.Barracodi2, DbType.Int32, entity.Barracodi2);
            dbProvider.AddInParameter(command, helper.Barramw1, DbType.Decimal, entity.Barramw1);
            dbProvider.AddInParameter(command, helper.Barramw2, DbType.Decimal, entity.Barramw2);
            dbProvider.AddInParameter(command, helper.Gruponombncp, DbType.String, entity.Gruponombncp);
            dbProvider.AddInParameter(command, helper.Tipogrupocodi, DbType.Int32, entity.Tipogrupocodi);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }

        public void Update(PrGrupoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Fenergcodi, DbType.Int32, entity.Fenergcodi);
            dbProvider.AddInParameter(command, helper.Barracodi, DbType.Int32, entity.Barracodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Gruponomb, DbType.String, entity.Gruponomb);
            dbProvider.AddInParameter(command, helper.Grupoabrev, DbType.String, entity.Grupoabrev);
            dbProvider.AddInParameter(command, helper.Grupovmax, DbType.Decimal, entity.Grupovmax);
            dbProvider.AddInParameter(command, helper.Grupovmin, DbType.Decimal, entity.Grupovmin);
            dbProvider.AddInParameter(command, helper.Grupoorden, DbType.Int32, entity.Grupoorden);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Grupotipo, DbType.String, entity.Grupotipo);
            dbProvider.AddInParameter(command, helper.Catecodi, DbType.Int32, entity.Catecodi);
            dbProvider.AddInParameter(command, helper.Grupotipoc, DbType.Int32, entity.Grupotipoc);
            dbProvider.AddInParameter(command, helper.Grupopadre, DbType.Int32, entity.Grupopadre);
            dbProvider.AddInParameter(command, helper.Grupoactivo, DbType.String, entity.Grupoactivo);
            dbProvider.AddInParameter(command, helper.Grupocomb, DbType.String, entity.Grupocomb);
            dbProvider.AddInParameter(command, helper.Osicodi, DbType.String, entity.Osicodi);
            dbProvider.AddInParameter(command, helper.Grupocodi2, DbType.Int32, entity.Grupocodi2);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Gruposub, DbType.String, entity.Gruposub);
            dbProvider.AddInParameter(command, helper.Barracodi2, DbType.Int32, entity.Barracodi2);
            dbProvider.AddInParameter(command, helper.Barramw1, DbType.Decimal, entity.Barramw1);
            dbProvider.AddInParameter(command, helper.Barramw2, DbType.Decimal, entity.Barramw2);
            dbProvider.AddInParameter(command, helper.Gruponombncp, DbType.String, entity.Gruponombncp);
            dbProvider.AddInParameter(command, helper.Tipogrupocodi, DbType.Int32, entity.Tipogrupocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int grupocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, grupocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public PrGrupoDTO GetById(int grupocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, grupocodi);
            PrGrupoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<PrGrupoDTO> List()
        {
            List<PrGrupoDTO> entitys = new List<PrGrupoDTO>();
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

        public List<PrGrupoDTO> ListCentrales(string tipocombustible, string emprcodi)
        {
            List<PrGrupoDTO> entitys = new List<PrGrupoDTO>();
            string query = string.Format(helper.sqlListCentrales, tipocombustible, emprcodi);
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


        public List<PrGrupoDTO> GetByCriteria(int idTipoGrupo)
        {
            List<PrGrupoDTO> entitys = new List<PrGrupoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByCriteria);
            dbProvider.AddInParameter(command, helper.Tipogrupocodi, DbType.Int32, idTipoGrupo);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    PrGrupoDTO entity = helper.Create(dr);

                    int iDesTipoGrupo = dr.GetOrdinal(this.helper.DesTipoGrupo);
                    if (!dr.IsDBNull(iDesTipoGrupo)) entity.DesTipoGrupo = dr.GetString(iDesTipoGrupo);

                    int iEmprNomb = dr.GetOrdinal(this.helper.EmprNomb);
                    if (!dr.IsDBNull(iEmprNomb)) entity.EmprNomb = dr.GetString(iEmprNomb);

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<GrupoGeneracionDTO> ListarGeneradoresDespachoOsinergmin()
        {
            var entitys = new List<GrupoGeneracionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListarGeneradoresDespachoOsinergmin);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oGenerador = new GrupoGeneracionDTO();
                    oGenerador.Equifechfinopcom = dr.IsDBNull(dr.GetOrdinal("EQUIFECHFINOPCOM")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("EQUIFECHFINOPCOM"));
                    oGenerador.Equifechiniopcom = dr.IsDBNull(dr.GetOrdinal("EQUIFECHINIOPCOM")) ? (DateTime?)null : dr.GetDateTime(dr.GetOrdinal("EQUIFECHINIOPCOM"));
                    oGenerador.Gruponomb = dr.GetString(dr.GetOrdinal("GRUPONOMB"));
                    oGenerador.Grupopadre = dr.IsDBNull(dr.GetOrdinal("GRUPOPADRE")) ? -1 : dr.GetInt32(dr.GetOrdinal("GRUPOPADRE"));
                    oGenerador.Grupocodi = dr.IsDBNull(dr.GetOrdinal("GRUPOCODI")) ? -1 : dr.GetInt32(dr.GetOrdinal("GRUPOCODI"));
                    entitys.Add(oGenerador);
                }
            }
            return entitys;
        }


        public List<PrGrupoDTO> ListaModosOperacionActivos()
        {
            List<PrGrupoDTO> entitys = new List<PrGrupoDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListaModosOperacionActivos);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public void CambiarTipoGrupo(int idGrupo, int idTipoGrupo, string userName, DateTime fecha)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlCambiarTipoGrupo);
                       
            dbProvider.AddInParameter(command, helper.Tipogrupocodi, DbType.Int32, idTipoGrupo);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, userName);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, fecha);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, idGrupo);

            dbProvider.ExecuteNonQuery(command);
        }


        public List<ModoOperacionDTO> ModoOperacionCentral1(int iCentral)
        {
            List<ModoOperacionDTO> lsResultado= new List<ModoOperacionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlModosOperacionCentral1);
            dbProvider.AddInParameter(command, "idCentral", DbType.Int32, iCentral);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oModo = new ModoOperacionDTO();
                    oModo.EQUICODI = dr.IsDBNull(dr.GetOrdinal("EQUICODI")) ? 0 : dr.GetInt32(dr.GetOrdinal("EQUICODI"));
                    oModo.GRUPOABREV = dr.IsDBNull(dr.GetOrdinal("GRUPOABREV")) ? "" : dr.GetString(dr.GetOrdinal("GRUPOABREV"));
                    oModo.GRUPOCODI = dr.IsDBNull(dr.GetOrdinal("GRUPOABREV"))? 0 : dr.GetInt32(dr.GetOrdinal("GRUPOCODI"));
                    oModo.GRUPONOM = dr.IsDBNull(dr.GetOrdinal("GRUPONOM")) ? "" : dr.GetString(dr.GetOrdinal("GRUPONOM"));
                    oModo.IDCENTRAL = dr.IsDBNull(dr.GetOrdinal("IDCENTRAL")) ? "" : dr.GetString(dr.GetOrdinal("IDCENTRAL"));
                    oModo.MODONOM = dr.IsDBNull(dr.GetOrdinal("MODONOM")) ? "" : dr.GetString(dr.GetOrdinal("MODONOM"));
                    lsResultado.Add(oModo);
                }
            }

            return lsResultado;
        }
        public List<ModoOperacionDTO> ModoOperacionCentral2(int iCentral)
        {
            List<ModoOperacionDTO> lsResultado = new List<ModoOperacionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlModosOperacionCentral2);
            dbProvider.AddInParameter(command, "idCentral", DbType.Int32, iCentral);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    var oModo = new ModoOperacionDTO();
                    oModo.EQUICODI = dr.IsDBNull(dr.GetOrdinal("EQUICODI")) ? 0 : dr.GetInt32(dr.GetOrdinal("EQUICODI"));
                    oModo.GRUPOABREV = dr.IsDBNull(dr.GetOrdinal("GRUPOABREV")) ? "" : dr.GetString(dr.GetOrdinal("GRUPOABREV"));
                    oModo.GRUPOCODI = dr.IsDBNull(dr.GetOrdinal("GRUPOABREV")) ? 0 : dr.GetInt32(dr.GetOrdinal("GRUPOCODI"));
                    oModo.GRUPONOM = dr.IsDBNull(dr.GetOrdinal("GRUPONOM")) ? "" : dr.GetString(dr.GetOrdinal("GRUPONOM"));
                    oModo.IDCENTRAL = dr.IsDBNull(dr.GetOrdinal("IDCENTRAL")) ? "" : dr.GetString(dr.GetOrdinal("IDCENTRAL"));
                    oModo.MODONOM = dr.IsDBNull(dr.GetOrdinal("MODONOM")) ? "" : dr.GetString(dr.GetOrdinal("MODONOM"));
                    lsResultado.Add(oModo);
                }
            }

            return lsResultado;
        }


        public int ObtenerCodigoModoOperacionPadre(int iPrGrupo)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlObtenerCodigoModoOperacionPadre);
            dbProvider.AddInParameter(command, "grupocodi", DbType.Int32, iPrGrupo);
            object result = dbProvider.ExecuteScalar(command);
            int id = -1;
            if (result != null) id = Convert.ToInt32(result);
            return id;
        }
    }
}
