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
    /// Clase de acceso a datos de la tabla EVE_MANTTO
    /// </summary>
    public class EveManttoRepository: RepositoryBase, IEveManttoRepository
    {
        public EveManttoRepository(string strConn): base(strConn)
        {
        }

        EveManttoHelper helper = new EveManttoHelper();

        public void Save(EveManttoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Manttocodi, DbType.Int32, entity.Manttocodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Evenclasecodi, DbType.Int32, entity.Evenclasecodi);
            dbProvider.AddInParameter(command, helper.Tipoevencodi, DbType.Int32, entity.Tipoevencodi);
            dbProvider.AddInParameter(command, helper.Compcode, DbType.Int32, entity.Compcode);
            dbProvider.AddInParameter(command, helper.Evenini, DbType.DateTime, entity.Evenini);
            dbProvider.AddInParameter(command, helper.Evenpreini, DbType.DateTime, entity.Evenpreini);
            dbProvider.AddInParameter(command, helper.Evenfin, DbType.DateTime, entity.Evenfin);
            dbProvider.AddInParameter(command, helper.Subcausacodi, DbType.Int32, entity.Subcausacodi);
            dbProvider.AddInParameter(command, helper.Evenprefin, DbType.DateTime, entity.Evenprefin);
            dbProvider.AddInParameter(command, helper.Evenmwindisp, DbType.Decimal, entity.Evenmwindisp);
            dbProvider.AddInParameter(command, helper.Evenpadre, DbType.Int32, entity.Evenpadre);
            dbProvider.AddInParameter(command, helper.Evenindispo, DbType.String, entity.Evenindispo);
            dbProvider.AddInParameter(command, helper.Eveninterrup, DbType.String, entity.Eveninterrup);
            dbProvider.AddInParameter(command, helper.Eventipoprog, DbType.String, entity.Eventipoprog);
            dbProvider.AddInParameter(command, helper.Evendescrip, DbType.String, entity.Evendescrip);
            dbProvider.AddInParameter(command, helper.Evenobsrv, DbType.String, entity.Evenobsrv);
            dbProvider.AddInParameter(command, helper.Evenestado, DbType.String, entity.Evenestado);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Evenrelevante, DbType.Int32, entity.Evenrelevante);
            dbProvider.AddInParameter(command, helper.Deleted, DbType.Int32, entity.Deleted);
            dbProvider.AddInParameter(command, helper.Mancodi, DbType.Int32, entity.Mancodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(EveManttoDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);

            dbProvider.AddInParameter(command, helper.Manttocodi, DbType.Int32, entity.Manttocodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Evenclasecodi, DbType.Int32, entity.Evenclasecodi);
            dbProvider.AddInParameter(command, helper.Tipoevencodi, DbType.Int32, entity.Tipoevencodi);
            dbProvider.AddInParameter(command, helper.Compcode, DbType.Int32, entity.Compcode);
            dbProvider.AddInParameter(command, helper.Evenini, DbType.DateTime, entity.Evenini);
            dbProvider.AddInParameter(command, helper.Evenpreini, DbType.DateTime, entity.Evenpreini);
            dbProvider.AddInParameter(command, helper.Evenfin, DbType.DateTime, entity.Evenfin);
            dbProvider.AddInParameter(command, helper.Subcausacodi, DbType.Int32, entity.Subcausacodi);
            dbProvider.AddInParameter(command, helper.Evenprefin, DbType.DateTime, entity.Evenprefin);
            dbProvider.AddInParameter(command, helper.Evenmwindisp, DbType.Decimal, entity.Evenmwindisp);
            dbProvider.AddInParameter(command, helper.Evenpadre, DbType.Int32, entity.Evenpadre);
            dbProvider.AddInParameter(command, helper.Evenindispo, DbType.String, entity.Evenindispo);
            dbProvider.AddInParameter(command, helper.Eveninterrup, DbType.String, entity.Eveninterrup);
            dbProvider.AddInParameter(command, helper.Eventipoprog, DbType.String, entity.Eventipoprog);
            dbProvider.AddInParameter(command, helper.Evendescrip, DbType.String, entity.Evendescrip);
            dbProvider.AddInParameter(command, helper.Evenobsrv, DbType.String, entity.Evenobsrv);
            dbProvider.AddInParameter(command, helper.Evenestado, DbType.String, entity.Evenestado);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Evenrelevante, DbType.Int32, entity.Evenrelevante);
            dbProvider.AddInParameter(command, helper.Deleted, DbType.Int32, entity.Deleted);
            dbProvider.AddInParameter(command, helper.Mancodi, DbType.Int32, entity.Mancodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int manttocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);

            dbProvider.AddInParameter(command, helper.Manttocodi, DbType.Int32, manttocodi);
            dbProvider.AddInParameter(command, helper.Manttocodi, DbType.Int32, manttocodi);

            dbProvider.ExecuteNonQuery(command);
        }

        public EveManttoDTO GetById(int manttocodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Manttocodi, DbType.Int32, manttocodi);
            dbProvider.AddInParameter(command, helper.Manttocodi, DbType.Int32, manttocodi);
            EveManttoDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                }
            }

            return entity;
        }

        public List<EveManttoDTO> List()
        {
            List<EveManttoDTO> entitys = new List<EveManttoDTO>();
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

        public List<EveManttoDTO> GetByCriteria()
        {
            List<EveManttoDTO> entitys = new List<EveManttoDTO>();
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

        public List<EveManttoDTO> BuscarMantenimientos(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
            string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string indInterrupcion, string idstipoMantto, 
            string idsEquipos,int nroPagina, int nroFilas)
        {

            String query = String.Format(helper.SqlGetByCriteria, idsTipoMantenimiento, idsEmpresa, idsTipoEquipo,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), nroPagina,
                nroFilas, idsTipoEmpresa, indInterrupcion, idstipoMantto, idsEquipos);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            List<EveManttoDTO> entitys = new List<EveManttoDTO>();

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public int ObtenerNroRegistros(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
           string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string idsEquipos, string indInterrupcion, string idstipoMantto)
        {

            String query = String.Format(helper.SqlTotalRecords, idsTipoMantenimiento, idsEmpresa, idsTipoEquipo,
                    fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha),
                     idsTipoEmpresa, indInterrupcion, idstipoMantto, idsEquipos);

            DbCommand command = dbProvider.GetSqlStringCommand(query);
            object count = dbProvider.ExecuteScalar(command);

            if (count != null) return Convert.ToInt32(count);

            return 0;
        }

        public List<ReporteManttoDTO> ObtenerTotalManttoEmpresa(DateTime fechaInicio, DateTime fechaFin,
            string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string indInterrupcion, string idstipoMantto)
        {
            List<ReporteManttoDTO> entitys = new List<ReporteManttoDTO>();
            string query = String.Format(helper.SqlMantEmpresas, idsEmpresa, idsTipoEmpresa, idsTipoEquipo, indInterrupcion,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), idstipoMantto);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            ReporteManttoDTO entity = null;
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                
                int iEmprcodi = dr.GetOrdinal("emprcodi");
                int iEmprnomb = dr.GetOrdinal("emprnomb");
                int iTotalmantto = dr.GetOrdinal("totalmantto");
                while (dr.Read())
                {
                    entity = new ReporteManttoDTO();
                    if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));
                    if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

                    entitys.Add(entity);
                }
            }
            return entitys;
        }

        public List<EveManttoDTO> ObtenerReporteMantenimientos(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
            string idsTipoEmpresa, string idsEmpresa, string  idsTipoEquipo, string indInterrupcion,string idstipoMantto,string idsEquipo)
        {
            String query = String.Format(helper.SqlReporteMantto, idsTipoMantenimiento, idsEmpresa, idsTipoEquipo,
               fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha),
               idsTipoEmpresa, indInterrupcion, idstipoMantto,idsEquipo);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            List<EveManttoDTO> entitys = new List<EveManttoDTO>();

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
