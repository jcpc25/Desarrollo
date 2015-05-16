using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_EQUIPO
    /// </summary>
    public class EqEquipoHelper : HelperBase
    {
        public EqEquipoHelper(): base(Consultas.EqEquipoSql)
        {
        }

        public EqEquipoDTO Create(IDataReader dr)
        {
            EqEquipoDTO entity = new EqEquipoDTO();

            int iEquicodi = dr.GetOrdinal(this.Equicodi);
            if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iGrupocodi = dr.GetOrdinal(this.Grupocodi);
            if (!dr.IsDBNull(iGrupocodi)) entity.Grupocodi = Convert.ToInt32(dr.GetValue(iGrupocodi));

            int iElecodi = dr.GetOrdinal(this.Elecodi);
            if (!dr.IsDBNull(iElecodi)) entity.Elecodi = Convert.ToInt32(dr.GetValue(iElecodi));

            int iAreacodi = dr.GetOrdinal(this.Areacodi);
            if (!dr.IsDBNull(iAreacodi)) entity.Areacodi = Convert.ToInt32(dr.GetValue(iAreacodi));

            int iFamcodi = dr.GetOrdinal(this.Famcodi);
            if (!dr.IsDBNull(iFamcodi)) entity.Famcodi = Convert.ToInt32(dr.GetValue(iFamcodi));

            int iEquiabrev = dr.GetOrdinal(this.Equiabrev);
            if (!dr.IsDBNull(iEquiabrev)) entity.Equiabrev = dr.GetString(iEquiabrev);

            int iEquinomb = dr.GetOrdinal(this.Equinomb);
            if (!dr.IsDBNull(iEquinomb)) entity.Equinomb = dr.GetString(iEquinomb);

            int iEquiabrev2 = dr.GetOrdinal(this.Equiabrev2);
            if (!dr.IsDBNull(iEquiabrev2)) entity.Equiabrev2 = dr.GetString(iEquiabrev2);

            int iEquitension = dr.GetOrdinal(this.Equitension);
            if (!dr.IsDBNull(iEquitension)) entity.Equitension = dr.GetDecimal(iEquitension);

            int iEquipadre = dr.GetOrdinal(this.Equipadre);
            if (!dr.IsDBNull(iEquipadre)) entity.Equipadre = Convert.ToInt32(dr.GetValue(iEquipadre));

            int iEquipot = dr.GetOrdinal(this.Equipot);
            if (!dr.IsDBNull(iEquipot)) entity.Equipot = dr.GetDecimal(iEquipot);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iEcodigo = dr.GetOrdinal(this.Ecodigo);
            if (!dr.IsDBNull(iEcodigo)) entity.Ecodigo = dr.GetString(iEcodigo);

            int iEquiestado = dr.GetOrdinal(this.Equiestado);
            if (!dr.IsDBNull(iEquiestado)) entity.Equiestado = dr.GetString(iEquiestado);

            int iOsigrupocodi = dr.GetOrdinal(this.Osigrupocodi);
            if (!dr.IsDBNull(iOsigrupocodi)) entity.Osigrupocodi = dr.GetString(iOsigrupocodi);

            int iLastcodi = dr.GetOrdinal(this.Lastcodi);
            if (!dr.IsDBNull(iLastcodi)) entity.Lastcodi = Convert.ToInt32(dr.GetValue(iLastcodi));

            int iEquifechiniopcom = dr.GetOrdinal(this.Equifechiniopcom);
            if (!dr.IsDBNull(iEquifechiniopcom)) entity.Equifechiniopcom = dr.GetDateTime(iEquifechiniopcom);

            int iEquifechfinopcom = dr.GetOrdinal(this.Equifechfinopcom);
            if (!dr.IsDBNull(iEquifechfinopcom)) entity.Equifechfinopcom = dr.GetDateTime(iEquifechfinopcom);

            return entity;
        }


        #region Mapeo de Campos

        public string Equicodi = "EQUICODI";
        public string Emprcodi = "EMPRCODI";
        public string Grupocodi = "GRUPOCODI";
        public string Elecodi = "ELECODI";
        public string Areacodi = "AREACODI";
        public string Famcodi = "FAMCODI";
        public string Equiabrev = "EQUIABREV";
        public string Equinomb = "EQUINOMB";
        public string Equiabrev2 = "EQUIABREV2";
        public string Equitension = "EQUITENSION";
        public string Equipadre = "EQUIPADRE";
        public string Equipot = "EQUIPOT";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";
        public string Ecodigo = "ECODIGO";
        public string Equiestado = "EQUIESTADO";
        public string Osigrupocodi = "OSIGRUPOCODI";
        public string Lastcodi = "LASTCODI";
        public string Equifechiniopcom = "EQUIFECHINIOPCOM";
        public string Equifechfinopcom = "EQUIFECHFINOPCOM";

        public string EMPRNOMB = "EMPRNOMB";
        public string AREANOMB = "AREANOMB";
        public string Famnomb = "FAMNOMB";

        #endregion
        public string SqlListadoCentralesOsinergmin
        {
            get { return base.GetSqlXml("ListadoCentralesOsinergmin"); }
        }
        public string SQLListarEquiposxFiltro
        {
            get { return base.GetSqlXml("SQLListarEquiposxFiltro"); }
        }
        public string SqlBuscarEquipoPorNombrePaginado
        {
            get { return base.GetSqlXml("SqlBuscarEquipoPorNombrePaginado"); }
        }
        public string SqlEquiposxFamilias
        {
            get { return base.GetSqlXml("EquiposxFamilias"); }
        }

        public string SqlGetByEmprFam
        {
            get { return base.GetSqlXml("GetByEmprFam"); }
        }

        public string SqlCentralesXCombustible
        {
            get { return base.GetSqlXml("CentralesXCombustible"); }
        }

        public string SqlEquiposxFamilias2
        {
            get { return base.GetSqlXml("EquiposxFamilias2"); }
        }

        public string SqlCentralesXEmpresaGEN
        {
            get { return base.GetSqlXml("CentralesXEmpresaGEN"); }
        }
        public string SqlListaEquiposEnsayo
        {
            get { return base.GetSqlXml("ListaEquiposEnsayo"); }
        }
    }
}
