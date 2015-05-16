using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla MD_CAMBIOENVIO
    /// </summary>
    public class MdCambioenvioHelper : HelperBase
    {
        public MdCambioenvioHelper(): base(Consultas.MdCambioenvioSql)
        {
        }

        public MdCambioenvioDTO Create(IDataReader dr)
        {
            MdCambioenvioDTO entity = new MdCambioenvioDTO();

            int iTipoinfocodi = dr.GetOrdinal(this.Tipoinfocodi);
            if (!dr.IsDBNull(iTipoinfocodi)) entity.Tipoinfocodi = Convert.ToInt32(dr.GetValue(iTipoinfocodi));

            int iEnviocodiold = dr.GetOrdinal(this.Enviocodiold);
            if (!dr.IsDBNull(iEnviocodiold)) entity.Enviocodiold = Convert.ToInt32(dr.GetValue(iEnviocodiold));

            int iMedifecha = dr.GetOrdinal(this.Medifecha);
            if (!dr.IsDBNull(iMedifecha)) entity.Medifecha = dr.GetDateTime(iMedifecha);

            int iPtomedicodi = dr.GetOrdinal(this.Ptomedicodi);
            if (!dr.IsDBNull(iPtomedicodi)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(iPtomedicodi));

            int iEnviocodinew = dr.GetOrdinal(this.Enviocodinew);
            if (!dr.IsDBNull(iEnviocodinew)) entity.Enviocodinew = Convert.ToInt32(dr.GetValue(iEnviocodinew));

            int iCmbvalorold = dr.GetOrdinal(this.Cmbvalorold);
            if (!dr.IsDBNull(iCmbvalorold)) entity.Cmbvalorold = dr.GetDecimal(iCmbvalorold);

            int iCmbvalornew = dr.GetOrdinal(this.Cmbvalornew);
            if (!dr.IsDBNull(iCmbvalornew)) entity.Cmbvalornew = dr.GetDecimal(iCmbvalornew);

            return entity;
        }


        #region Mapeo de Campos

        public string Tipoinfocodi = "TIPOINFOCODI";
        public string Enviocodiold = "ENVIOCODIOLD";
        public string Medifecha = "MEDIFECHA";
        public string Ptomedicodi = "PTOMEDICODI";
        public string Enviocodinew = "ENVIOCODINEW";
        public string Cmbvalorold = "CMBVALOROLD";
        public string Cmbvalornew = "CMBVALORNEW";

        #endregion
    }
}
