using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Sic;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    /// <summary>
    /// Clase de acceso a datos de la tabla CB_ENVIO
    /// </summary>
    public class CbEnvioRepository : RepositoryBase, ICbEnvioRepository
    {
        public CbEnvioRepository(string strConn) : base(strConn)
        {
        }
        CbEnvioHelper helper = new CbEnvioHelper();
        public int Save(CbEnvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
            object result = dbProvider.ExecuteScalar(command);
            int id = 1;
            if (result != null) id = Convert.ToInt32(result);
            string insertQuery = string.Format(helper.SqlSave, id, ((DateTime)entity.Enviofecha).ToString(ConstantesBase.FormatoFechaExtendido),
                entity.Usercodi, entity.Grupocodi, entity.Estenvcodi, entity.Tipocombcodi, entity.Emprcodi, entity.Envioobservacion,
                entity.Lastdate.ToString(ConstantesBase.FormatoFechaExtendido),entity.Lastuser,entity.Envioestado,entity.Envioplazo);

            command = dbProvider.GetSqlStringCommand(insertQuery);

            dbProvider.ExecuteNonQuery(command);
            return id;
        }
        public void Update(CbEnvioDTO entity)
        {
            string updateQuery = string.Format(helper.SqlUpdate,((DateTime)entity.Enviofecha).ToString(ConstantesBase.FormatoFechaExtendido), entity.Usercodi,
                 entity.Grupocodi, entity.Estenvcodi, entity.Tipocombcodi, entity.Emprcodi, entity.Envioobservacion,
                 entity.Lastdate.ToString(ConstantesBase.FormatoFechaExtendido),entity.Lastuser,entity.Enviocodi,entity.Envioestado,entity.Envioplazo);
            DbCommand command = dbProvider.GetSqlStringCommand(updateQuery);
            
            dbProvider.ExecuteNonQuery(command);
        }
        public void UpdateObs(CbEnvioDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdateObs);
            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, entity.Enviocodi);
            dbProvider.AddInParameter(command, helper.Estenvcodi, DbType.Int32, entity.Estenvcodi);
            dbProvider.AddInParameter(command, helper.Envioobservacion, DbType.String, entity.Envioobservacion);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.ExecuteNonQuery(command);
        }
        public void Delete(int Enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, Enviocodi);

            dbProvider.ExecuteNonQuery(command);
        }
        public CbEnvioDTO GetById(int Enviocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Enviocodi, DbType.Int32, Enviocodi);
            CbEnvioDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }
        public List<CbEnvioDTO> List()
        {
            List<CbEnvioDTO> entitys = new List<CbEnvioDTO>();
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
        public List<CbEnvioDTO> ListaDetalle(int tipocombcodi)
        {
            List<CbEnvioDTO> entitys = new List<CbEnvioDTO>();
            string query = string.Format(helper.SqlListaDetalle, tipocombcodi);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            //DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListaDetalle); 
            CbEnvioDTO entity = new CbEnvioDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iEmprnomb = dr.GetOrdinal("Emprnomb");
                    int iGruponomb = dr.GetOrdinal("Gruponomb");
                    int iEstenvnomb = dr.GetOrdinal("Estenvnomb");
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                    if (!dr.IsDBNull(iGruponomb)) entity.Gruponomb = dr.GetString(iGruponomb);
                    if (!dr.IsDBNull(iEstenvnomb)) entity.Estenvnomb = dr.GetString(iEstenvnomb);
                    entitys.Add(entity);

                }
            }

            return entitys;
        }
        public List<CbEnvioDTO> ListaDetalleFiltro(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles, int nroPaginas,int pageSize)
        {
            List<CbEnvioDTO> entitys = new List<CbEnvioDTO>();
            string query = string.Format(helper.SqlListaDetalleFiltro, emprcodi, grupocodi, estenvcodi, fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), tipocombustibles,nroPaginas,pageSize);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            CbEnvioDTO entity = new CbEnvioDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iEmprnomb = dr.GetOrdinal("Emprnomb");
                    int iGruponomb = dr.GetOrdinal("Gruponomb");
                    int iEstenvnomb = dr.GetOrdinal("Estenvnomb");
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                    if (!dr.IsDBNull(iGruponomb)) entity.Gruponomb = dr.GetString(iGruponomb);
                    if (!dr.IsDBNull(iEstenvnomb)) entity.Estenvnomb = dr.GetString(iEstenvnomb);
                    entitys.Add(entity);

                }
            }

            return entitys;
        }
        public List<CbEnvioDTO> ListaDetalleFiltroXls(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles)
        {
            List<CbEnvioDTO> entitys = new List<CbEnvioDTO>();
            string query = string.Format(helper.SqlTotalListaEnvioXls, emprcodi, grupocodi, estenvcodi, fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), tipocombustibles);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            CbEnvioDTO entity = new CbEnvioDTO();
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iEmprnomb = dr.GetOrdinal("Emprnomb");
                    int iGruponomb = dr.GetOrdinal("Gruponomb");
                    int iEstenvnomb = dr.GetOrdinal("Estenvnomb");
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);
                    if (!dr.IsDBNull(iGruponomb)) entity.Gruponomb = dr.GetString(iGruponomb);
                    if (!dr.IsDBNull(iEstenvnomb)) entity.Estenvnomb = dr.GetString(iEstenvnomb);
                    entitys.Add(entity);

                }
            }

            return entitys;
        }
        public int ObtenerTotalListaEnvio(string emprcodi, string grupocodi, string estenvcodi, DateTime fechaInicio, DateTime fechaFin, int tipocombustibles)
        {
            string sqlTotal = string.Format(helper.SqlTotalListaEnvio,emprcodi,grupocodi,estenvcodi,
               fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), tipocombustibles);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlTotal);
            object result = dbProvider.ExecuteScalar(command);
            int total = 0;
            if (result != null) total = Convert.ToInt32(result);
            return total;
        }

        public List<DateTime> ObtenerDiasFeriados(DateTime fIni,DateTime fFin)
        {
            string getSql = string.Format(helper.SqlGetDiasFeriados, fIni.ToString(ConstantesBase.FormatoFecha),
                fFin.ToString(ConstantesBase.FormatoFecha));
            List<DateTime> entitys = new List<DateTime>();
            DateTime fecha = DateTime.MinValue;
            DbCommand command = dbProvider.GetSqlStringCommand(getSql);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    int iDiafecha = dr.GetOrdinal("Diafecha");
                    if (!dr.IsDBNull(iDiafecha)) fecha = dr.GetDateTime(iDiafecha);
                    entitys.Add(fecha);
                }
            }

            return entitys;
        }
    }
}
