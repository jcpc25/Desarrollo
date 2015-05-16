﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Scada;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class IeodCuadroRepository: RepositoryBase
    {
        IeodCuadroHelper helper = new IeodCuadroHelper();

        public IeodCuadroRepository(string strConn)
            : base(strConn)
        {
        }

        public void GrabarDatos(List<IeodCuadroDTO> entitys, DateTime fecha)
        {


            if (entitys.Count > 0)
            {
                string query = String.Format(helper.SqlDelete, fecha.ToString(ConstantesBase.FormatoFecha));
                DbCommand command = dbProvider.GetSqlStringCommand(query);
                dbProvider.ExecuteNonQuery(command);

                command = dbProvider.GetSqlStringCommand(helper.SqlGetMaxId);
                object result = dbProvider.ExecuteScalar(command);
                int id = 1;

                if (result != null)
                    id = Convert.ToInt32(result);

                foreach (IeodCuadroDTO entity in entitys)
                {
                    command.Parameters.Clear();
                    command = dbProvider.GetSqlStringCommand(helper.SqlSave);

                    dbProvider.AddInParameter(command, helper.ICCODI, DbType.Int32, id);
                    dbProvider.AddInParameter(command, helper.EQUICODI, DbType.Int32, entity.EQUICODI);
                    dbProvider.AddInParameter(command, helper.SUBCAUSACODI, DbType.Int32, entity.SUBCAUSACODI);
                    dbProvider.AddInParameter(command, helper.ICHORINI, DbType.DateTime, entity.ICHORINI);
                    dbProvider.AddInParameter(command, helper.ICHORFIN, DbType.DateTime, entity.ICHORFIN);
                    dbProvider.AddInParameter(command, helper.ICCHECK1, DbType.String, entity.ICCHECK1);
                    dbProvider.AddInParameter(command, helper.ICVALOR1, DbType.Decimal, entity.ICVALOR1);
                    dbProvider.AddInParameter(command, helper.LASTUSER, DbType.String, entity.LASTUSER);
                    dbProvider.AddInParameter(command, helper.LASTDATE, DbType.DateTime, entity.LASTDATE);
                    dbProvider.AddInParameter(command, helper.EVENCLASECODI, DbType.Int32, entity.EVENCLASECODI);
                    dbProvider.AddInParameter(command, helper.ICCHECK2, DbType.String, entity.ICCHECK2);

                    dbProvider.ExecuteNonQuery(command);

                    id++;
                }

                command.Parameters.Clear();
                command = dbProvider.GetSqlStringCommand(helper.SqlUpdateCounter);
                dbProvider.AddInParameter(command, helper.MAXCOUNT, DbType.Int32, id);

                dbProvider.ExecuteNonQuery(command);

            }

        }

        public List<IeodCuadroDTO> GetByCriteria(DateTime fechaInicio, DateTime fechaFin)
        {
            List<IeodCuadroDTO> entitys = new List<IeodCuadroDTO>();

            string query = String.Format(helper.SqlGetByCriteria,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    IeodCuadroDTO entity = this.helper.Create(dr);
                   

                    int iEmprNomb = dr.GetOrdinal(helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEmprNomb)) entity.EMPRENOMB = dr.GetString(iEmprNomb);

                    int iAreaNomb = dr.GetOrdinal(helper.AREANOMB);
                    if (!dr.IsDBNull(iAreaNomb)) entity.AREANOMB = dr.GetString(iAreaNomb);

                    int iFamAbrev = dr.GetOrdinal(helper.FAMABREV);
                    if (!dr.IsDBNull(iFamAbrev)) entity.FAMABREV = dr.GetString(iFamAbrev);

                    int iEquiAbrev = dr.GetOrdinal(helper.EQUIABREV);
                    if (!dr.IsDBNull(iEquiAbrev)) entity.EQUIABREV = dr.GetString(iEquiAbrev);

                    int iTareaAbrev = dr.GetOrdinal(helper.TAREAABREV);
                    if (!dr.IsDBNull(iTareaAbrev)) entity.TAREAABREV = dr.GetString(iTareaAbrev);                  

                    int iEmprCodi = dr.GetOrdinal(helper.EMPRCODI);
                    if (!dr.IsDBNull(iEmprCodi)) entity.EMPRCODI = Convert.ToInt16(dr.GetValue(iEmprCodi));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<IeodCuadroDTO> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin)
        {
            List<IeodCuadroDTO> entitys = new List<IeodCuadroDTO>();

            string query = String.Format(helper.SqlObtenerReporte,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha));

            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {

                    IeodCuadroDTO entity = new IeodCuadroDTO();

                    int iRUS = dr.GetOrdinal(this.helper.RUS);
                    int iSUBCAUSACODI = dr.GetOrdinal(this.helper.SUBCAUSACODI);
                    int iICHORINI = dr.GetOrdinal(this.helper.ICHORINI);
                    int iICHORFIN = dr.GetOrdinal(this.helper.ICHORFIN);
                    int iICVALOR1 = dr.GetOrdinal(this.helper.ICVALOR1);
                    int iHORA = dr.GetOrdinal(this.helper.HORA);                    

                    if (!dr.IsDBNull(iRUS)) entity.RUS = dr.GetString(iRUS);                   
                    if (!dr.IsDBNull(iSUBCAUSACODI)) entity.SUBCAUSACODI = Convert.ToInt32(dr.GetValue(iSUBCAUSACODI));
                    if (!dr.IsDBNull(iICHORINI)) entity.ICHORINI = dr.GetDateTime(iICHORINI);
                    if (!dr.IsDBNull(iICHORFIN)) entity.ICHORFIN = dr.GetDateTime(iICHORFIN);                   
                    if (!dr.IsDBNull(iICVALOR1)) entity.ICVALOR1 = dr.GetDecimal(iICVALOR1);
                    if (!dr.IsDBNull(iHORA)) entity.HORA = dr.GetString(iHORA);

                    if (entity.SUBCAUSACODI == 318)
                    {
                        entity.TIPO = "MANUAL";
                    }

                    if (entity.SUBCAUSACODI == 319)
                    {
                        entity.TIPO = "AUTOMÁTICO";
                    }
                   
                    entitys.Add(entity);
                }
            }

            return entitys;
        }
        
        public List<IeodCuadroDTO> GetConfiguracionEmpresa()
        {
            List<IeodCuadroDTO> entitys = new List<IeodCuadroDTO>();            

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlConfiguracionEquipo);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    IeodCuadroDTO entity = new IeodCuadroDTO();

                    int iEmprNomb = dr.GetOrdinal(helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEmprNomb)) entity.EMPRENOMB = dr.GetString(iEmprNomb);

                    int iAreaNomb = dr.GetOrdinal(helper.AREANOMB);
                    if (!dr.IsDBNull(iAreaNomb)) entity.AREANOMB = dr.GetString(iAreaNomb);

                    int iFamAbrev = dr.GetOrdinal(helper.FAMABREV);
                    if (!dr.IsDBNull(iFamAbrev)) entity.FAMABREV = dr.GetString(iFamAbrev);

                    int iEquiCodi = dr.GetOrdinal(helper.EQUICODI);
                    if (!dr.IsDBNull(iEquiCodi)) entity.EQUICODI = Convert.ToInt32(dr.GetValue(iEquiCodi));

                    int iEquiAbrev = dr.GetOrdinal(helper.EQUIABREV);
                    if (!dr.IsDBNull(iEquiAbrev)) entity.EQUIABREV = dr.GetString(iEquiAbrev);

                    int iTareaAbrev = dr.GetOrdinal(helper.TAREAABREV);
                    if (!dr.IsDBNull(iTareaAbrev)) entity.TAREAABREV = dr.GetString(iTareaAbrev);

                    int iEmprCodi = dr.GetOrdinal(helper.EMPRCODI);
                    if (!dr.IsDBNull(iEmprCodi)) entity.EMPRCODI = Convert.ToInt16(dr.GetValue(iEmprCodi));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<IeodCuadroDTO> ValidarExistenciaRegistro(int equiCodi, DateTime horaInicio, DateTime horaFin)
        {
            List<IeodCuadroDTO> entitys = new List<IeodCuadroDTO>();

            string query = String.Format(helper.SqlValidarExistencia, equiCodi, horaInicio.ToString(ConstantesBase.FormatoFechaExtendido),
                horaFin.ToString(ConstantesBase.FormatoFechaExtendido));
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    IeodCuadroDTO entity = new IeodCuadroDTO();                                      

                    int iEquiCodi = dr.GetOrdinal(helper.EQUICODI);
                    if (!dr.IsDBNull(iEquiCodi)) entity.EQUICODI = Convert.ToInt32(dr.GetValue(iEquiCodi));                                      

                    entitys.Add(entity);
                }
            }

            return entitys;
        }
    }
}