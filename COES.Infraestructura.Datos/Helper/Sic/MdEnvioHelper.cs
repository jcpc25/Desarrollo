using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla MD_ENVIO
    /// </summary>
    public class MdEnvioHelper : HelperBase
    {
        public MdEnvioHelper(): base(Consultas.MdEnvioSql)
        {
        }

        public MdEnvioDTO Create(IDataReader dr)
        {
            MdEnvioDTO entity = new MdEnvioDTO();

            int iEnvioarchnomb = dr.GetOrdinal(this.Envioarchnomb);
            if (!dr.IsDBNull(iEnvioarchnomb)) entity.Envioarchnomb = dr.GetString(iEnvioarchnomb);

            int iEstenvcodi = dr.GetOrdinal(this.Estenvcodi);
            if (!dr.IsDBNull(iEstenvcodi)) entity.Estenvcodi = Convert.ToInt32(dr.GetValue(iEstenvcodi));

            int iEnviomes = dr.GetOrdinal(this.Enviomes);
            if (!dr.IsDBNull(iEnviomes)) entity.Enviomes = dr.GetDateTime(iEnviomes);

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = Convert.ToInt32(dr.GetValue(iEmprcodi));

            int iUsercodi = dr.GetOrdinal(this.Usercodi);
            if (!dr.IsDBNull(iUsercodi)) entity.Usercodi = dr.GetString(iUsercodi);

            int iEnviocodi = dr.GetOrdinal(this.Enviocodi);
            if (!dr.IsDBNull(iEnviocodi)) entity.Enviocodi = Convert.ToInt32(dr.GetValue(iEnviocodi));

            int iEnviofecha = dr.GetOrdinal(this.Enviofecha);
            if (!dr.IsDBNull(iEnviofecha)) entity.Enviofecha = dr.GetDateTime(iEnviofecha);

            return entity;
        }


        #region Mapeo de Campos

        public string Envioarchnomb = "ENVIOARCHNOMB";
        public string Estenvcodi = "ESTENVCODI";
        public string Enviomes = "ENVIOMES";
        public string Emprcodi = "EMPRCODI";
        public string Usercodi = "USERCODI";
        public string Enviocodi = "ENVIOCODI";
        public string Enviofecha = "ENVIOFECHA";

        #endregion
    }
}
