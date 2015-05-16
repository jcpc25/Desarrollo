﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

namespace WSIC2010
{
    /// <summary>
    /// Summary description for WebServiceCloud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCloud : System.Web.Services.WebService
    {
        public string CadenaConexion = "Provider=OraOLEDB.Oracle.1;Persist Security Info=False;User ID=sic;Password=47896;Data Source=SICCOESR";

        [WebMethod]
        public List<PtoMedicionExtranet> ObtenerPuntosMedicion(int idEmpresa)
        {
            List<PtoMedicionExtranet> entitys = new List<PtoMedicionExtranet>();

            try
            {
                string sql = @"select pto.ptomedicodi, eq.equinomb, eq.equiabrev from me_ptomedicion pto inner join eq_equipo eq
                               on pto.equicodi = eq.equicodi
                               where pto.origlectcodi = 1 and pto.emprcodi = {0} and eq.famcodi in (2,3,4,5, 36, 37, 38, 39)";

                string query = String.Format(sql, idEmpresa);

                IDbConnection conn = new OleDbConnection(this.CadenaConexion);
                OleDbCommand command = new OleDbCommand(query, (OleDbConnection)conn);
                conn.Open();

                OleDbDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    PtoMedicionExtranet entity = new PtoMedicionExtranet();

                    int iPtoMediCodi = dr.GetOrdinal("ptomedicodi");
                    if (!dr.IsDBNull(iPtoMediCodi)) entity.PtoMediCodi = Convert.ToInt32(dr.GetValue(iPtoMediCodi));

                    int iEquiNomb = dr.GetOrdinal("equinomb");
                    if (!dr.IsDBNull(iEquiNomb)) entity.PtoMediNomb = dr.GetString(iEquiNomb);

                    int iEquiAbrev = dr.GetOrdinal("equiabrev");
                    if (!dr.IsDBNull(iEquiAbrev)) entity.PtoMediAbrev = dr.GetString(iEquiAbrev);

                    entity.PtoMediNomb = entity.PtoMediCodi.ToString().PadLeft(5, ' ') + " - " + entity.PtoMediNomb + " - " + entity.PtoMediAbrev;

                    entitys.Add(entity);
                }

                conn.Close();
            }
            catch
            {
                throw;
            }

            return entitys;
        }


        [WebMethod]
        public List<PtoMedicionExtranet> ObtenerPuntoMedicionExtranet(int idEquipo)
        {
            List<PtoMedicionExtranet> entitys = new List<PtoMedicionExtranet>();

            try
            {
                string sql = @"select pto.ptomedicodi, eq.equinomb, eq.equiabrev from me_ptomedicion pto inner join eq_equipo eq
                               on pto.equicodi = eq.equicodi
                               where pto.origlectcodi = 1 and (eq.equicodi = {0} or eq.equipadre = {0}) and eq.famcodi in (2,3,4,5, 36, 37, 38, 39)";

                string query = String.Format(sql, idEquipo);

                IDbConnection conn = new OleDbConnection(this.CadenaConexion);
                OleDbCommand command = new OleDbCommand(query, (OleDbConnection)conn);
                conn.Open();

                OleDbDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    PtoMedicionExtranet entity = new PtoMedicionExtranet();

                    int iPtoMediCodi = dr.GetOrdinal("ptomedicodi");
                    if (!dr.IsDBNull(iPtoMediCodi)) entity.PtoMediCodi = Convert.ToInt32(dr.GetValue(iPtoMediCodi));

                    int iEquiNomb = dr.GetOrdinal("equinomb");
                    if (!dr.IsDBNull(iEquiNomb)) entity.PtoMediNomb = dr.GetString(iEquiNomb);

                    int iEquiAbrev = dr.GetOrdinal("equiabrev");
                    if (!dr.IsDBNull(iEquiAbrev)) entity.PtoMediAbrev = dr.GetString(iEquiAbrev);

                    entity.PtoMediNomb = entity.PtoMediCodi.ToString().PadLeft(5, ' ') + " - " + entity.PtoMediNomb + " - " + entity.PtoMediAbrev;

                    entitys.Add(entity);
                }

                conn.Close();
            }
            catch
            {
                throw;
            }

            return entitys;
        }

        [WebMethod]
        public List<CentralExtranet> ObtenerCentralExtranet(int idEmpresa)
        {
            List<CentralExtranet> entitys = new List<CentralExtranet>();

            try
            {
                string query = String.Format("select equinomb, equicodi from eq_equipo where emprcodi = {0} and famcodi in (4,5,37,39) and equiestado = 'A'", idEmpresa);

                IDbConnection conn = new OleDbConnection(this.CadenaConexion);
                OleDbCommand command = new OleDbCommand(query, (OleDbConnection)conn);

                conn.Open();

                OleDbDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    CentralExtranet entity = new CentralExtranet();

                    int iEquiCodi = dr.GetOrdinal("equicodi");
                    if (!dr.IsDBNull(iEquiCodi)) entity.EquiCodi = Convert.ToInt32(dr.GetValue(iEquiCodi));

                    int iEquiNomb = dr.GetOrdinal("equinomb");
                    if (!dr.IsDBNull(iEquiNomb)) entity.EquiNomb = dr.GetString(iEquiNomb);

                    entitys.Add(entity);
                }

                conn.Close();
            }
            catch
            {
                throw;
            }

            return entitys;
        }


        [WebMethod]
        public List<EmpresaExtranet> ObtenerEmpresasExtranet()
        {
            List<EmpresaExtranet> entitys = new List<EmpresaExtranet>();

            try
            {
                string query = "select emprcodi, emprnomb from si_empresa where EMPRCOES = 'S' and emprsein ='S' and EMPRCODI > 0 order by emprnomb asc";

                IDbConnection conn = new OleDbConnection(this.CadenaConexion);
                OleDbCommand command = new OleDbCommand(query, (OleDbConnection)conn);

                conn.Open();

                OleDbDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    EmpresaExtranet entity = new EmpresaExtranet();

                    int iEmprCodi = dr.GetOrdinal("emprcodi");
                    if (!dr.IsDBNull(iEmprCodi)) entity.EmprCodi = Convert.ToInt32(dr.GetValue(iEmprCodi));

                    int iEmprNomb = dr.GetOrdinal("emprnomb");
                    if (!dr.IsDBNull(iEmprNomb)) entity.EmprNomb = dr.GetString(iEmprNomb);

                    entitys.Add(entity);
                }

                conn.Close();
            }
            catch
            {
                throw;
            }

            return entitys;
        }

    }

    public class PtoMedicionExtranet
    {
        private int ptoMediCodi;
        private string ptoMediNomb;
        private string ptoMediAbrev;

        public int PtoMediCodi
        {
            get { return ptoMediCodi; }
            set { ptoMediCodi = value; }
        }

        public string PtoMediNomb
        {
            get { return ptoMediNomb; }
            set { ptoMediNomb = value; }
        }

        public string PtoMediAbrev
        {
            get { return ptoMediAbrev; }
            set { ptoMediAbrev = value; }
        }
    }

    public class CentralExtranet
    {
        private int equiCodi;
        private string equiNomb;

        public int EquiCodi
        {
            get { return equiCodi; }
            set { equiCodi = value; }
        }

        public string EquiNomb
        {
            get { return equiNomb; }
            set { equiNomb = value; }
        }
    }

    public class EmpresaExtranet
    {
        private int emprCodi;
        private string emprNomb;

        public int EmprCodi
        {
            get { return emprCodi; }
            set { emprCodi = value; }
        }

        public string EmprNomb
        {
            get { return emprNomb; }
            set { emprNomb = value; }
        }

    }
}
