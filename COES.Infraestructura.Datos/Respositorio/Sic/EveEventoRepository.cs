using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using COES.Dominio.DTO.Sic;
using COES.Dominio.Interfaces.Scada;
using COES.Base.Core;
using COES.Infraestructura.Datos.Helper.Sic;

namespace COES.Infraestructura.Datos.Respositorio.Sic
{
    public class EveEventoRepository: RepositoryBase
    {

        public EveEventoRepository(string strConn)
            : base(strConn)
        {
        }

        EventoHelper helper = new EventoHelper();

        public List<EventoDTO> BuscarEventos(int? idTipoEvento, DateTime fechaInicio, DateTime fechaFin,
           string version, string turno, int? idTipoEmpresa, int? idEmpresa, int? idTipoEquipo, string informe, 
            string indInterrupcion, int nroPagina, int nroFilas)
        {
                        
            String query = String.Format(helper.SqlGetByCriteria, idTipoEquipo, idEmpresa, idTipoEquipo, version,
                fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha), nroPagina, 
                nroFilas, turno, informe, idTipoEmpresa, indInterrupcion);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            List<EventoDTO> entitys = new List<EventoDTO>();

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;
        }

        public int ObtenerNroRegistros(int? idTipoEvento, DateTime fechaInicio, DateTime fechaFin,
           string version, string turno, int? idTipoEmpresa, int? idEmpresa, int? idTipoEquipo, string informe, string indInterrupcion)
        {         

            String query = String.Format(helper.SqlTotalRecords, idTipoEquipo, idEmpresa, idTipoEquipo, version,
                    fechaInicio.ToString(ConstantesBase.FormatoFecha), fechaFin.ToString(ConstantesBase.FormatoFecha),
                    turno, informe, idTipoEmpresa, indInterrupcion);

            DbCommand command = dbProvider.GetSqlStringCommand(query);       
            object count = dbProvider.ExecuteScalar(command);

            if (count != null) return Convert.ToInt32(count);

            return 0;            
        }

        public EventoDTO ObtenerEvento(int idEvento)
        {
            EventoDTO entity = null;

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlObtenerEvento);
            dbProvider.AddInParameter(command, helper.EVENCODI, DbType.Int32, idEvento);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = new EventoDTO();

                    int iEVENCODI = dr.GetOrdinal(helper.EVENCODI);
                    int iEMPRCODIRESPON = dr.GetOrdinal(helper.EMPRCODIRESPON);
                    int iEQUICODI = dr.GetOrdinal(helper.EQUICODI);
                    int iEVENCLASECODI = dr.GetOrdinal(helper.EVENCLASECODI);
                    int iEMPRCODI = dr.GetOrdinal(helper.EMPRCODI);
                    int iTIPOEVENCODI = dr.GetOrdinal(helper.TIPOEVENCODI);
                    int iEVENINI = dr.GetOrdinal(helper.EVENINI);
                    int iEVENMWINDISP = dr.GetOrdinal(helper.EVENMWINDISP);
                    int iEVENFIN = dr.GetOrdinal(helper.EVENFIN);
                    int iSUBCAUSACODI = dr.GetOrdinal(helper.SUBCAUSACODI);
                    int iEVENASUNTO = dr.GetOrdinal(helper.EVENASUNTO);
                    int iEVENPADRE = dr.GetOrdinal(helper.EVENPADRE);
                    int iEVENINTERRUP = dr.GetOrdinal(helper.EVENINTERRUP);
                    int iLASTUSER = dr.GetOrdinal(helper.LASTUSER);
                    int iLASTDATE = dr.GetOrdinal(helper.LASTDATE);
                    int iEVENPREINI = dr.GetOrdinal(helper.EVENPREINI);
                    int iEVENPOSTFIN = dr.GetOrdinal(helper.EVENPOSTFIN);
                    int iEVENDESC = dr.GetOrdinal(helper.EVENDESC);
                    int iEVENTENSION = dr.GetOrdinal(helper.EVENTENSION);
                    int iEVENAOPERA = dr.GetOrdinal(helper.EVENAOPERA);
                    int iEVENPRELIMINAR = dr.GetOrdinal(helper.EVENPRELIMINAR);
                    int iEVENRELEVANTE = dr.GetOrdinal(helper.EVENRELEVANTE);
                    int iEVENCTAF = dr.GetOrdinal(helper.EVENCTAF);
                    int iEVENINFFALLA = dr.GetOrdinal(helper.EVENINFFALLA);
                    int iEVENINFFALLAN2 = dr.GetOrdinal(helper.EVENINFFALLAN2);
                    int iDELETED = dr.GetOrdinal(helper.DELETED);
                    int iEVENTIPOFALLA = dr.GetOrdinal(helper.EVENTIPOFALLA);
                    int iEVENTIPOFALLAFASE = dr.GetOrdinal(helper.EVENTIPOFALLAFASE);
                    int iSMSENVIADO = dr.GetOrdinal(helper.SMSENVIADO);
                    int iSMSENVIAR = dr.GetOrdinal(helper.SMSENVIAR);
                    int iEVENACTUACION = dr.GetOrdinal(helper.EVENACTUACION);
                    int iEQUINOMB = dr.GetOrdinal(helper.EQUINOMB);
                    int iEVENCOMENTARIOS = dr.GetOrdinal(helper.EVENCOMENTARIOS);
                    int iEVENPERTURBACION = dr.GetOrdinal(helper.EVENPERTURBACION);

                    if (!dr.IsDBNull(iEVENCODI)) entity.EVENCODI = Convert.ToInt32(dr.GetValue(iEVENCODI));
                    if (!dr.IsDBNull(iEMPRCODIRESPON)) entity.EMPRCODIRESPON = Convert.ToInt16(dr.GetValue(iEMPRCODIRESPON));
                    if (!dr.IsDBNull(iEQUICODI)) entity.EQUICODI = Convert.ToInt32(dr.GetValue(iEQUICODI));
                    if (!dr.IsDBNull(iEVENCLASECODI)) entity.EVENCLASECODI = Convert.ToInt16(dr.GetValue(iEVENCLASECODI));
                    if (!dr.IsDBNull(iEMPRCODI)) entity.EMPRCODI = Convert.ToInt32(dr.GetValue(iEMPRCODI));
                    if (!dr.IsDBNull(iTIPOEVENCODI)) entity.TIPOEVENCODI = Convert.ToInt32(dr.GetValue(iTIPOEVENCODI));
                    if (!dr.IsDBNull(iEVENINI)) entity.EVENINI = dr.GetDateTime(iEVENINI);
                    if (!dr.IsDBNull(iEVENMWINDISP)) entity.EVENMWINDISP = dr.GetDecimal(iEVENMWINDISP);
                    if (!dr.IsDBNull(iEVENFIN)) entity.EVENFIN = dr.GetDateTime(iEVENFIN);
                    if (!dr.IsDBNull(iSUBCAUSACODI)) entity.SUBCAUSACODI = Convert.ToInt32(dr.GetValue(iSUBCAUSACODI));
                    if (!dr.IsDBNull(iEVENASUNTO)) entity.EVENASUNTO = dr.GetString(iEVENASUNTO);
                    if (!dr.IsDBNull(iEVENPADRE)) entity.EVENPADRE = Convert.ToInt32(dr.GetValue(iEVENPADRE));
                    if (!dr.IsDBNull(iEVENINTERRUP)) entity.EVENINTERRUP = dr.GetString(iEVENINTERRUP);
                    if (!dr.IsDBNull(iLASTUSER)) entity.LASTUSER = dr.GetString(iLASTUSER);
                    if (!dr.IsDBNull(iLASTDATE)) entity.LASTDATE = dr.GetDateTime(iLASTDATE);
                    if (!dr.IsDBNull(iEVENPREINI)) entity.EVENPREINI = dr.GetDateTime(iEVENPREINI);
                    if (!dr.IsDBNull(iEVENPOSTFIN)) entity.EVENPOSTFIN = dr.GetDateTime(iEVENPOSTFIN);
                    if (!dr.IsDBNull(iEVENDESC)) entity.EVENDESC = dr.GetString(iEVENDESC);
                    if (!dr.IsDBNull(iEVENTENSION)) entity.EVENTENSION = dr.GetDecimal(iEVENTENSION);
                    if (!dr.IsDBNull(iEVENAOPERA)) entity.EVENAOPERA = dr.GetString(iEVENAOPERA);
                    if (!dr.IsDBNull(iEVENPRELIMINAR)) entity.EVENPRELIMINAR = dr.GetString(iEVENPRELIMINAR);
                    if (!dr.IsDBNull(iEVENRELEVANTE)) entity.EVENRELEVANTE = Convert.ToInt32(dr.GetValue(iEVENRELEVANTE));
                    if (!dr.IsDBNull(iEVENCTAF)) entity.EVENCTAF = dr.GetString(iEVENCTAF);
                    if (!dr.IsDBNull(iEVENINFFALLA)) entity.EVENINFFALLA = dr.GetString(iEVENINFFALLA);
                    if (!dr.IsDBNull(iEVENINFFALLAN2)) entity.EVENINFFALLAN2 = dr.GetString(iEVENINFFALLAN2);
                    if (!dr.IsDBNull(iDELETED)) entity.DELETED = dr.GetString(iDELETED);
                    if (!dr.IsDBNull(iEVENTIPOFALLA)) entity.EVENTIPOFALLA = dr.GetString(iEVENTIPOFALLA);
                    if (!dr.IsDBNull(iEVENTIPOFALLAFASE)) entity.EVENTIPOFALLAFASE = dr.GetString(iEVENTIPOFALLAFASE);
                    if (!dr.IsDBNull(iSMSENVIADO)) entity.SMSENVIADO = dr.GetString(iSMSENVIADO);
                    if (!dr.IsDBNull(iSMSENVIAR)) entity.SMSENVIAR = dr.GetString(iSMSENVIAR);
                    if (!dr.IsDBNull(iEVENACTUACION)) entity.EVENACTUACION = dr.GetString(iEVENACTUACION);
                    if (!dr.IsDBNull(iEQUINOMB)) entity.EQUIABREV = dr.GetString(iEQUINOMB);
                    if (!dr.IsDBNull(iEVENCOMENTARIOS)) entity.EVENCOMENTARIOS = dr.GetString(iEVENCOMENTARIOS);
                    if (!dr.IsDBNull(iEVENPERTURBACION)) entity.EVENPERTURBACION = dr.GetString(iEVENPERTURBACION);
                }
            }

            return entity;
        }

        public EventoDTO ObtenerResumenEvento(int idEvento)
        {
            EventoDTO entity = null;

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlObtenerResumenEvento);
            dbProvider.AddInParameter(command, helper.EVENCODI, DbType.Int32, idEvento);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = new EventoDTO();

                    int iEVENCODI = dr.GetOrdinal(helper.EVENCODI);
                    int iEVENINI = dr.GetOrdinal(helper.EVENINI);
                    int iEMPRNOMB = dr.GetOrdinal(helper.EMPRNOMB);
                    int iEQUIABREV = dr.GetOrdinal(helper.EQUINOMB);
                    int iEVENASUNTO = dr.GetOrdinal(helper.EVENASUNTO);
                    int iEVENDESC = dr.GetOrdinal(helper.EVENDESC);
                    int iTIPOEVENCODI = dr.GetOrdinal(helper.TIPOEVENCODI);
                    int iEVENPERTURBACION = dr.GetOrdinal(helper.EVENPERTURBACION);

                    if (!dr.IsDBNull(iEVENCODI)) entity.EVENCODI = Convert.ToInt32(dr.GetValue(iEVENCODI));
                    if (!dr.IsDBNull(iEVENINI)) entity.EVENINI = dr.GetDateTime(iEVENINI);
                    if (!dr.IsDBNull(iEMPRNOMB)) entity.EMPRNOMB = dr.GetString(iEMPRNOMB);
                    if (!dr.IsDBNull(iEQUIABREV)) entity.EQUIABREV = dr.GetString(iEQUIABREV);
                    if (!dr.IsDBNull(iEVENASUNTO)) entity.EVENASUNTO = dr.GetString(iEVENASUNTO);
                    if (!dr.IsDBNull(iEVENDESC)) entity.EVENDESC = dr.GetString(iEVENDESC);
                    if (!dr.IsDBNull(iTIPOEVENCODI)) entity.TIPOEVENCODI = Convert.ToInt32(dr.GetValue(iTIPOEVENCODI));
                    if (!dr.IsDBNull(iEVENPERTURBACION)) entity.EVENPERTURBACION = dr.GetString(iEVENPERTURBACION);
                }
            }

            return entity;                   
        }

        public List<AreaDTO> ObtenerAreaPorEmpresa(int? idEmpresa)
        {
            List<AreaDTO> entitys = new List<AreaDTO>();

            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlObtenerAreaPorEmpresa);
            dbProvider.AddInParameter(command, helper.EMPRCODI, DbType.Int32, idEmpresa);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    AreaDTO entity = new AreaDTO();

                    int iAREACODI = dr.GetOrdinal(helper.AREACODI);
                    int iAREANOMB = dr.GetOrdinal(helper.AREANOMB);
                    int iTAREAABREV = dr.GetOrdinal(helper.TAREAABREV);

                    if (!dr.IsDBNull(iAREACODI)) entity.AREACODI = Convert.ToInt16(dr.GetValue(iAREACODI));
                    if (!dr.IsDBNull(iAREANOMB)) entity.AREANOMB = dr.GetString(iAREANOMB);
                    if (!dr.IsDBNull(iTAREAABREV)) entity.TAREAABREV = dr.GetString(iTAREAABREV);

                    entitys.Add(entity);
                }
            }     

            return entitys;
        }

        public List<EquipoDTO> BuscarEquipoEvento(int? idEmpresa, int? idArea, int? idFamilia, string filtro, int nroPagina, int nroFilas)
        {         
            String query = String.Format(helper.SqlBusquedaEquipoEvento, idEmpresa, idFamilia, idArea, filtro, nroPagina, nroFilas);
            DbCommand command = dbProvider.GetSqlStringCommand(query);
            List<EquipoDTO> entitys = new List<EquipoDTO>();

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    EquipoDTO entity = new EquipoDTO();

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

                    int iEquiCodi = dr.GetOrdinal(helper.EQUICODI);
                    if (!dr.IsDBNull(iEquiCodi)) entity.EQUICODI = Convert.ToInt16(dr.GetValue(iEquiCodi));

                    int iEmprCodi = dr.GetOrdinal(helper.EMPRCODI);
                    if (!dr.IsDBNull(iEmprCodi)) entity.EMPRCODI = Convert.ToInt16(dr.GetValue(iEmprCodi));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public int ObtenerNroFilasBusquedaEquipo(int? idEmpresa, int? idArea, int? idFamilia, string filtro)
        {           
            String query = String.Format(helper.SqlTotalRecordsEquipo, idEmpresa, idFamilia, idArea, filtro);

            DbCommand command = dbProvider.GetSqlStringCommand(query);
            object count = dbProvider.ExecuteScalar(command);

            if (count != null) return Convert.ToInt32(count);

            return 0;
        }

        public List<EmpresaDTO> ListarEmpresas()
        {           
            List<EmpresaDTO> entitys = new List<EmpresaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListarEmpresas);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    EmpresaDTO entity = new EmpresaDTO();

                    int iEmprNomb = dr.GetOrdinal(helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEmprNomb)) entity.EMPRNOMB = dr.GetString(iEmprNomb);                    

                    int iEmprCodi = dr.GetOrdinal(helper.EMPRCODI);
                    if (!dr.IsDBNull(iEmprCodi)) entity.EMPRCODI = Convert.ToInt16(dr.GetValue(iEmprCodi));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<EmpresaDTO> ListarEmpresasPorTipo(int idTipoEmpresa)
        {
            List<EmpresaDTO> entitys = new List<EmpresaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListarEmpresasPorTipo);
            dbProvider.AddInParameter(command, helper.TIPOEMPRCODI, DbType.Int32, idTipoEmpresa);


            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    EmpresaDTO entity = new EmpresaDTO();

                    int iEmprNomb = dr.GetOrdinal(helper.EMPRNOMB);
                    if (!dr.IsDBNull(iEmprNomb)) entity.EMPRNOMB = dr.GetString(iEmprNomb);

                    int iEmprCodi = dr.GetOrdinal(helper.EMPRCODI);
                    if (!dr.IsDBNull(iEmprCodi)) entity.EMPRCODI = Convert.ToInt16(dr.GetValue(iEmprCodi));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<FamiliaDTO> ListarFamilias()
        {           
            List<FamiliaDTO> entitys = new List<FamiliaDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlListarFamilias);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    FamiliaDTO entity = new FamiliaDTO();

                    int iFamNomb = dr.GetOrdinal(helper.FAMNOMB);
                    if (!dr.IsDBNull(iFamNomb)) entity.FAMNOMB = dr.GetString(iFamNomb);

                    int iFamCodi = dr.GetOrdinal(helper.FAMCODI);
                    if (!dr.IsDBNull(iFamCodi)) entity.FAMCODI = Convert.ToInt16(dr.GetValue(iFamCodi));

                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public void ActualizarInformePerturbacion(string estado, int idEvento)
        {
            try
            {  
                string query = string.Format(helper.SqlActualizarInformePerturbacion, estado, idEvento);
                DbCommand command = dbProvider.GetSqlStringCommand(query);
                dbProvider.ExecuteNonQuery(command);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }            
        }
       
    }
}

