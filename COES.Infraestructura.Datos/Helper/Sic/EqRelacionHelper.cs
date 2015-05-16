using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla EQ_RELACION
    /// </summary>
    public class EqRelacionHelper : HelperBase
    {
        public EqRelacionHelper(): base(Consultas.EqRelacionSql)
        {
        }

        public EqRelacionDTO Create(IDataReader dr)
        {
            EqRelacionDTO entity = new EqRelacionDTO();

            int iRelacioncodi = dr.GetOrdinal(this.Relacioncodi);
            if (!dr.IsDBNull(iRelacioncodi)) entity.Relacioncodi = Convert.ToInt32(dr.GetValue(iRelacioncodi));

            int iEquicodi = dr.GetOrdinal(this.Equicodi);
            if (!dr.IsDBNull(iEquicodi)) entity.Equicodi = Convert.ToInt32(dr.GetValue(iEquicodi));

            int iCodincp = dr.GetOrdinal(this.Codincp);
            if (!dr.IsDBNull(iCodincp)) entity.Codincp = Convert.ToInt32(dr.GetValue(iCodincp));

            int iNombrencp = dr.GetOrdinal(this.Nombrencp);
            if (!dr.IsDBNull(iNombrencp)) entity.Nombrencp = dr.GetString(iNombrencp);

            int iCodbarra = dr.GetOrdinal(this.Codbarra);
            if (!dr.IsDBNull(iCodbarra)) entity.Codbarra = dr.GetString(iCodbarra);

            int iIdgener = dr.GetOrdinal(this.Idgener);
            if (!dr.IsDBNull(iIdgener)) entity.Idgener = dr.GetString(iIdgener);

            int iDescripcion = dr.GetOrdinal(this.Descripcion);
            if (!dr.IsDBNull(iDescripcion)) entity.Descripcion = dr.GetString(iDescripcion);

            int iNombarra = dr.GetOrdinal(this.Nombarra);
            if (!dr.IsDBNull(iNombarra)) entity.Nombarra = dr.GetString(iNombarra);

            int iEstado = dr.GetOrdinal(this.Estado);
            if (!dr.IsDBNull(iEstado)) entity.Estado = dr.GetString(iEstado);

            return entity;
        }


        #region Mapeo de Campos

        public string Relacioncodi = "RELACIONCODI";
        public string Equicodi = "EQUICODI";
        public string Codincp = "CODINCP";
        public string Nombrencp = "NOMBRENCP";
        public string Codbarra = "CODBARRA";
        public string Idgener = "IDGENER";
        public string Descripcion = "DESCRIPCION";
        public string Nombarra = "NOMBARRA";
        public string Estado = "ESTADO";

        #endregion
    }
}
