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
    /// Clase de acceso a datos de la tabla ME_PTOMEDICION
    /// </summary>
    public class MePtomedicionRepository: RepositoryBase, IMePtomedicionRepository
    {
        public MePtomedicionRepository(string strConn): base(strConn)
        {
        }

        MePtomedicionHelper helper = new MePtomedicionHelper();

        public void Save(MePtomedicionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlSave);

            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Osicodi, DbType.String, entity.Osicodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Codref, DbType.Int32, entity.Codref);
            dbProvider.AddInParameter(command, helper.Ptomedidesc, DbType.String, entity.Ptomedidesc);
            dbProvider.AddInParameter(command, helper.Orden, DbType.Int32, entity.Orden);
            dbProvider.AddInParameter(command, helper.Ptomedielenomb, DbType.String, entity.Ptomedielenomb);
            dbProvider.AddInParameter(command, helper.Ptomedibarranomb, DbType.String, entity.Ptomedibarranomb);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, entity.Origlectcodi);
            dbProvider.AddInParameter(command, helper.Tipoptomedicodi, DbType.Int16, entity.Tipoptomedicodi);
            dbProvider.AddInParameter(command, helper.Ptomediestado, DbType.String, entity.Ptomediestado);


            dbProvider.ExecuteNonQuery(command);
        }

        public void Update(MePtomedicionDTO entity)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlUpdate);
            dbProvider.AddInParameter(command, helper.Lastdate, DbType.DateTime, entity.Lastdate);
            dbProvider.AddInParameter(command, helper.Lastuser, DbType.String, entity.Lastuser);
            dbProvider.AddInParameter(command, helper.Emprcodi, DbType.Int32, entity.Emprcodi);
            dbProvider.AddInParameter(command, helper.Grupocodi, DbType.Int32, entity.Grupocodi);
            dbProvider.AddInParameter(command, helper.Tipoinfocodi, DbType.Int32, entity.Tipoinfocodi);
            dbProvider.AddInParameter(command, helper.Osicodi, DbType.String, entity.Osicodi);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, entity.Equicodi);
            dbProvider.AddInParameter(command, helper.Codref, DbType.Int32, entity.Codref);
            dbProvider.AddInParameter(command, helper.Ptomedidesc, DbType.String, entity.Ptomedidesc);
            dbProvider.AddInParameter(command, helper.Orden, DbType.Int32, entity.Orden);
            dbProvider.AddInParameter(command, helper.Ptomedielenomb, DbType.String, entity.Ptomedielenomb);
            dbProvider.AddInParameter(command, helper.Ptomedibarranomb, DbType.String, entity.Ptomedibarranomb);
            dbProvider.AddInParameter(command, helper.Origlectcodi, DbType.Int32, entity.Origlectcodi);
            dbProvider.AddInParameter(command, helper.Tipoptomedicodi, DbType.Int16, entity.Tipoptomedicodi);
            dbProvider.AddInParameter(command, helper.Ptomediestado, DbType.String, entity.Ptomediestado);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, entity.Ptomedicodi);
            dbProvider.ExecuteNonQuery(command);
        }

        public void Delete(int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlDelete);
            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);
            dbProvider.ExecuteNonQuery(command);
        }

        public MePtomedicionDTO GetById(int ptomedicodi)
        {
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetById);

            dbProvider.AddInParameter(command, helper.Ptomedicodi, DbType.Int32, ptomedicodi);

            MePtomedicionDTO entity = null;

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                if (dr.Read())
                {
                    entity = helper.Create(dr);
                    int iFAMCODI = dr.GetOrdinal("famcodi");
                    if (!dr.IsDBNull(iFAMCODI)) entity.famcodi = Convert.ToInt16(dr.GetValue(iFAMCODI));
                }
            }

            return entity;
        }

        public List<MePtomedicionDTO> List()
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
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

        public List<MePtomedicionDTO> GetByIdEquipo(int equicodi)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            DbCommand command = dbProvider.GetSqlStringCommand(helper.SqlGetByIdEquipo);
            dbProvider.AddInParameter(command, helper.Equicodi, DbType.Int32, equicodi);
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }
            return entitys;
        }

        public List<MePtomedicionDTO> GetByCriteria(string empresas, string idsOriglectura, string idsTipoptomedicion)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            string query = string.Format(helper.SqlGetByCriteria, empresas, idsOriglectura, idsTipoptomedicion);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            MePtomedicionDTO entity;
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = new MePtomedicionDTO();
                    entity = helper.Create(dr);
                    int iEmprenomb = dr.GetOrdinal("emprnomb");
                    if (!dr.IsDBNull(iEmprenomb)) entity.Emprnomb = dr.GetString(iEmprenomb);
                    int iOriglectnombre = dr.GetOrdinal("Origlectnombre");
                    if (!dr.IsDBNull(iOriglectnombre)) entity.Origlectnombre = dr.GetString(iOriglectnombre);
                    int iEquinomb = dr.GetOrdinal("Equinomb");
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);
                    int iFamnomb = dr.GetOrdinal("Famnomb");
                    if (!dr.IsDBNull(iFamnomb)) entity.Famnomb = dr.GetString(iFamnomb);
                    int iTipoptomedinomb = dr.GetOrdinal("Tipoptomedinomb");
                    if (!dr.IsDBNull(iTipoptomedinomb)) entity.Tipoptomedinomb = dr.GetString(iTipoptomedinomb);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MePtomedicionDTO> ListarDetallePtoMedicionFiltro(string empresas, string idsOriglectura, string idsTipoptomedicion, int nroPaginas, int pageSize)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            string query = string.Format(helper.SqlListarDetallePtoMedicionFiltro, empresas, idsOriglectura, idsTipoptomedicion, nroPaginas, pageSize);
            DbCommand command = dbProvider.GetSqlStringCommand(query);

            MePtomedicionDTO entity;
            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    entity = new MePtomedicionDTO();
                    entity = helper.Create(dr);
                    int iEmprenomb = dr.GetOrdinal("emprnomb");
                    if (!dr.IsDBNull(iEmprenomb)) entity.Emprnomb = dr.GetString(iEmprenomb);
                    int iOriglectnombre = dr.GetOrdinal("Origlectnombre");
                    if (!dr.IsDBNull(iOriglectnombre)) entity.Origlectnombre = dr.GetString(iOriglectnombre);
                    int iEquinomb = dr.GetOrdinal("Equinomb");
                    if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);
                    int iFamnomb = dr.GetOrdinal("Famnomb");
                    if (!dr.IsDBNull(iFamnomb)) entity.Famnomb = dr.GetString(iFamnomb);
                    int iTipoptomedinomb = dr.GetOrdinal("Tipoptomedinomb");
                    if (!dr.IsDBNull(iTipoptomedinomb)) entity.Tipoptomedinomb = dr.GetString(iTipoptomedinomb);
                    entitys.Add(entity);
                }
            }

            return entitys;
        }

        public List<MePtomedicionDTO> ListarPtoMedicion(string listapto)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            string sqlQuery = string.Format(helper.SqlListarPtoMedicion, listapto);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);
            MePtomedicionDTO entity;


            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {
                
                while (dr.Read())
                {
                    entity = new MePtomedicionDTO();
                    entity = helper.Create(dr);
                    int iFAMCODI = dr.GetOrdinal("famcodi");
                    if (!dr.IsDBNull(iFAMCODI)) entity.famcodi = Convert.ToInt16(dr.GetValue(iFAMCODI));
                    int iGRUPONOMB = dr.GetOrdinal("GRUPONOMB");
                    if (!dr.IsDBNull(iGRUPONOMB)) entity.GRUPONOMB = dr.GetString(iGRUPONOMB);
                    int iCENTRALNOMB = dr.GetOrdinal("CENTRALNOMB");
                    if (!dr.IsDBNull(iCENTRALNOMB)) entity.CENTRALNOMB = dr.GetString(iCENTRALNOMB);
                    entitys.Add(entity);
                }
            }

            return entitys;       
        }

        public List<MePtomedicionDTO> ListarPtoDuplicado(int equipo,int origen,int tipopto)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            string sqlQuery = string.Format(helper.SqlGetPtoDuplicado, equipo,origen,tipopto);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlQuery);

            using (IDataReader dr = dbProvider.ExecuteReader(command))
            {

                while (dr.Read())
                {
                    entitys.Add(helper.Create(dr));
                }
            }

            return entitys;        
        }

        public int ObtenerTotalPtomedicion(string empresas, string idsOriglectura, string idsTipoptomedicion)
        {
            string sqlTotal = string.Format(helper.SqlTotalListaPtoMedicion, empresas, idsOriglectura, idsTipoptomedicion);
            DbCommand command = dbProvider.GetSqlStringCommand(sqlTotal);
            object result = dbProvider.ExecuteScalar(command);
            int total = 0;
            if (result != null) total = Convert.ToInt32(result);
            return total;
        }

    }
}
