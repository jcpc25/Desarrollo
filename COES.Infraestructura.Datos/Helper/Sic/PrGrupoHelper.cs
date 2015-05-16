using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla PR_GRUPO
    /// </summary>
    public class PrGrupoHelper : HelperBase
    {
        public PrGrupoHelper(): base(Consultas.PrGrupoSql)
        {
        }

        public PrGrupoDTO Create(IDataReader dr)
        {
            PrGrupoDTO entity = new PrGrupoDTO();

            int iFenergcodi = dr.GetOrdinal(this.Fenergcodi);
            if (!dr.IsDBNull(iFenergcodi)) entity.Fenergcodi = Convert.ToInt32(dr.GetValue(iFenergcodi));

            int iBarracodi = dr.GetOrdinal(this.Barracodi);
            if (!dr.IsDBNull(iBarracodi)) entity.Barracodi = Convert.ToInt32(dr.GetValue(iBarracodi));

            int iGrupocodi = dr.GetOrdinal(this.Grupocodi);
            if (!dr.IsDBNull(iGrupocodi)) entity.Grupocodi = Convert.ToInt32(dr.GetValue(iGrupocodi));

            int iGruponomb = dr.GetOrdinal(this.Gruponomb);
            if (!dr.IsDBNull(iGruponomb)) entity.Gruponomb = dr.GetString(iGruponomb);

            int iGrupoabrev = dr.GetOrdinal(this.Grupoabrev);
            if (!dr.IsDBNull(iGrupoabrev)) entity.Grupoabrev = dr.GetString(iGrupoabrev);

            int iGrupovmax = dr.GetOrdinal(this.Grupovmax);
            if (!dr.IsDBNull(iGrupovmax)) entity.Grupovmax = dr.GetDecimal(iGrupovmax);

            int iGrupovmin = dr.GetOrdinal(this.Grupovmin);
            if (!dr.IsDBNull(iGrupovmin)) entity.Grupovmin = dr.GetDecimal(iGrupovmin);

            int iGrupoorden = dr.GetOrdinal(this.Grupoorden);
            if (!dr.IsDBNull(iGrupoorden)) entity.Grupoorden = Convert.ToInt32(dr.GetValue(iGrupoorden));

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iGrupotipo = dr.GetOrdinal(this.Grupotipo);
            if (!dr.IsDBNull(iGrupotipo)) entity.Grupotipo = dr.GetString(iGrupotipo);

            int iCatecodi = dr.GetOrdinal(this.Catecodi);
            if (!dr.IsDBNull(iCatecodi)) entity.Catecodi = Convert.ToInt32(dr.GetValue(iCatecodi));

            int iGrupotipoc = dr.GetOrdinal(this.Grupotipoc);
            if (!dr.IsDBNull(iGrupotipoc)) entity.Grupotipoc = Convert.ToInt32(dr.GetValue(iGrupotipoc));

            int iGrupopadre = dr.GetOrdinal(this.Grupopadre);
            if (!dr.IsDBNull(iGrupopadre)) entity.Grupopadre = Convert.ToInt32(dr.GetValue(iGrupopadre));

            int iGrupoactivo = dr.GetOrdinal(this.Grupoactivo);
            if (!dr.IsDBNull(iGrupoactivo)) entity.Grupoactivo = dr.GetString(iGrupoactivo);

            int iGrupocomb = dr.GetOrdinal(this.Grupocomb);
            if (!dr.IsDBNull(iGrupocomb)) entity.Grupocomb = dr.GetString(iGrupocomb);

            int iOsicodi = dr.GetOrdinal(this.Osicodi);
            if (!dr.IsDBNull(iOsicodi)) entity.Osicodi = dr.GetString(iOsicodi);

            int iGrupocodi2 = dr.GetOrdinal(this.Grupocodi2);
            if (!dr.IsDBNull(iGrupocodi2)) entity.Grupocodi2 = Convert.ToInt32(dr.GetValue(iGrupocodi2));

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iGruposub = dr.GetOrdinal(this.Gruposub);
            if (!dr.IsDBNull(iGruposub)) entity.Gruposub = dr.GetString(iGruposub);

            int iBarracodi2 = dr.GetOrdinal(this.Barracodi2);
            if (!dr.IsDBNull(iBarracodi2)) entity.Barracodi2 = Convert.ToInt32(dr.GetValue(iBarracodi2));

            int iBarramw1 = dr.GetOrdinal(this.Barramw1);
            if (!dr.IsDBNull(iBarramw1)) entity.Barramw1 = dr.GetDecimal(iBarramw1);

            int iBarramw2 = dr.GetOrdinal(this.Barramw2);
            if (!dr.IsDBNull(iBarramw2)) entity.Barramw2 = dr.GetDecimal(iBarramw2);

            int iGruponombncp = dr.GetOrdinal(this.Gruponombncp);
            if (!dr.IsDBNull(iGruponombncp)) entity.Gruponombncp = dr.GetString(iGruponombncp);

            int iTipogrupocodi = dr.GetOrdinal(this.Tipogrupocodi);
            if (!dr.IsDBNull(iTipogrupocodi)) entity.Tipogrupocodi = Convert.ToInt32(dr.GetValue(iTipogrupocodi));

            return entity;
        }


        #region Mapeo de Campos

        public string Fenergcodi = "FENERGCODI";
        public string Barracodi = "BARRACODI";
        public string Grupocodi = "GRUPOCODI";
        public string Gruponomb = "GRUPONOMB";
        public string Grupoabrev = "GRUPOABREV";
        public string Grupovmax = "GRUPOVMAX";
        public string Grupovmin = "GRUPOVMIN";
        public string Grupoorden = "GRUPOORDEN";
        public string Emprcodi = "EMPRCODI";
        public string Grupotipo = "GRUPOTIPO";
        public string Catecodi = "CATECODI";
        public string Grupotipoc = "GRUPOTIPOC";
        public string Grupopadre = "GRUPOPADRE";
        public string Grupoactivo = "GRUPOACTIVO";
        public string Grupocomb = "GRUPOCOMB";
        public string Osicodi = "OSICODI";
        public string Grupocodi2 = "GRUPOCODI2";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";
        public string Gruposub = "GRUPOSUB";
        public string Barracodi2 = "BARRACODI2";
        public string Barramw1 = "BARRAMW1";
        public string Barramw2 = "BARRAMW2";
        public string Gruponombncp = "GRUPONOMBNCP";
        public string Tipogrupocodi = "TIPOGRUPOCODI";
        public string DesTipoGrupo = "TIPOGRUPONOMB";
        public string EmprNomb = "EMPRNOMB";

        #endregion

        public string SqlListarGeneradoresDespachoOsinergmin
        {
            get { return base.GetSqlXml("ListarGeneradoresDespachoOsinergmin"); }
        }
        public string SqlListaModosOperacionActivos
        {
            get { return base.GetSqlXml("ListaModosOperacionActivos"); }
        }

        public string SqlCambiarTipoGrupo
        {
            get { return base.GetSqlXml("CambiarTipoGrupo"); }
        }
        public string SqlModosOperacionCentral1
        {
            get { return base.GetSqlXml("ModosOperacionPorCentral1"); }
        }
        public string SqlModosOperacionCentral2
        {
            get { return base.GetSqlXml("ModosOperacionPorCentral2"); }
        }
        public string SqlObtenerCodigoModoOperacionPadre
        {
            get { return base.GetSqlXml("ObtenerCodigoModoOperacionPadre"); }
        }
        public string sqlListCentrales
        {
            get { return base.GetSqlXml("ListCentrales"); }
        }
    }
}
