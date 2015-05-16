using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_PROPIEDAD
    /// </summary>
    public class EqPropiedadHelper : HelperBase
    {
        public EqPropiedadHelper(): base(Consultas.EqPropiedadSql)
        {
        }

        public EqPropiedadDTO Create(IDataReader dr)
        {
            EqPropiedadDTO entity = new EqPropiedadDTO();

            int iProptabla = dr.GetOrdinal(this.Proptabla);
            if (!dr.IsDBNull(iProptabla)) entity.Proptabla = dr.GetString(iProptabla);

            int iPropcampo = dr.GetOrdinal(this.Propcampo);
            if (!dr.IsDBNull(iPropcampo)) entity.Propcampo = dr.GetString(iPropcampo);

            int iPropfiltro = dr.GetOrdinal(this.Propfiltro);
            if (!dr.IsDBNull(iPropfiltro)) entity.Propfiltro = dr.GetString(iPropfiltro);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iPropmaxelem = dr.GetOrdinal(this.Propmaxelem);
            if (!dr.IsDBNull(iPropmaxelem)) entity.Propmaxelem = Convert.ToInt32(dr.GetValue(iPropmaxelem));

            int iPropfichaoficial = dr.GetOrdinal(this.Propfichaoficial);
            if (!dr.IsDBNull(iPropfichaoficial)) entity.Propfichaoficial = dr.GetString(iPropfichaoficial);

            int iPropvisible = dr.GetOrdinal(this.Propvisible);
            if (!dr.IsDBNull(iPropvisible)) entity.Propvisible = dr.GetString(iPropvisible);

            int iPropcodi = dr.GetOrdinal(this.Propcodi);
            if (!dr.IsDBNull(iPropcodi)) entity.Propcodi = Convert.ToInt32(dr.GetValue(iPropcodi));

            int iFamcodi = dr.GetOrdinal(this.Famcodi);
            if (!dr.IsDBNull(iFamcodi)) entity.Famcodi = Convert.ToInt32(dr.GetValue(iFamcodi));

            int iPropabrev = dr.GetOrdinal(this.Propabrev);
            if (!dr.IsDBNull(iPropabrev)) entity.Propabrev = dr.GetString(iPropabrev);

            int iPropnomb = dr.GetOrdinal(this.Propnomb);
            if (!dr.IsDBNull(iPropnomb)) entity.Propnomb = dr.GetString(iPropnomb);

            int iPropunidad = dr.GetOrdinal(this.Propunidad);
            if (!dr.IsDBNull(iPropunidad)) entity.Propunidad = dr.GetString(iPropunidad);

            int iOrden = dr.GetOrdinal(this.Orden);
            if (!dr.IsDBNull(iOrden)) entity.Orden = Convert.ToInt32(dr.GetValue(iOrden));

            int iPropmask = dr.GetOrdinal(this.Propmask);
            if (!dr.IsDBNull(iPropmask)) entity.Propmask = dr.GetString(iPropmask);

            int iProptipo = dr.GetOrdinal(this.Proptipo);
            if (!dr.IsDBNull(iProptipo)) entity.Proptipo = dr.GetString(iProptipo);

            int iProphisto = dr.GetOrdinal(this.Prophisto);
            if (!dr.IsDBNull(iProphisto)) entity.Prophisto = dr.GetString(iProphisto);

            int iPropdefinicion = dr.GetOrdinal(this.Propdefinicion);
            if (!dr.IsDBNull(iPropdefinicion)) entity.Propdefinicion = dr.GetString(iPropdefinicion);

            int iPropprincipal = dr.GetOrdinal(this.Propprincipal);
            if (!dr.IsDBNull(iPropprincipal)) entity.Propprincipal = dr.GetString(iPropprincipal);

            int iPropfile = dr.GetOrdinal(this.Propfile);
            if (!dr.IsDBNull(iPropfile)) entity.Propfile = dr.GetString(iPropfile);

            int iPropcodipadre = dr.GetOrdinal(this.Propcodipadre);
            if (!dr.IsDBNull(iPropcodipadre)) entity.Propcodipadre = Convert.ToInt32(dr.GetValue(iPropcodipadre));

            return entity;
        }


        #region Mapeo de Campos

        public string Proptabla = "PROPTABLA";
        public string Propcampo = "PROPCAMPO";
        public string Propfiltro = "PROPFILTRO";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";
        public string Propmaxelem = "PROPMAXELEM";
        public string Propfichaoficial = "PROPFICHAOFICIAL";
        public string Propvisible = "PROPVISIBLE";
        public string Propcodi = "PROPCODI";
        public string Famcodi = "FAMCODI";
        public string Propabrev = "PROPABREV";
        public string Propnomb = "PROPNOMB";
        public string Propunidad = "PROPUNIDAD";
        public string Orden = "ORDEN";
        public string Propmask = "PROPMASK";
        public string Proptipo = "PROPTIPO";
        public string Prophisto = "PROPHISTO";
        public string Propdefinicion = "PROPDEFINICION";
        public string Propprincipal = "PROPPRINCIPAL";
        public string Propfile = "PROPFILE";
        public string Propcodipadre = "PROPCODIPADRE";

        #endregion
    }
}
