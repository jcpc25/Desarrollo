using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla ME_FORMATO
    /// </summary>
    public class MeFormatoHelper : HelperBase
    {
        public MeFormatoHelper(): base(Consultas.MeFormatoSql)
        {
        }

        public MeFormatoDTO Create(IDataReader dr)
        {
            MeFormatoDTO entity = new MeFormatoDTO();

            int iLastdate = dr.GetOrdinal(this.Lastdate);
            if (!dr.IsDBNull(iLastdate)) entity.Lastdate = dr.GetDateTime(iLastdate);

            int iLastuser = dr.GetOrdinal(this.Lastuser);
            if (!dr.IsDBNull(iLastuser)) entity.Lastuser = dr.GetString(iLastuser);

            int iAreacode = dr.GetOrdinal(this.Areacode);
            if (!dr.IsDBNull(iAreacode)) entity.Areacode = Convert.ToInt32(dr.GetValue(iAreacode));

            int iFormatresolucion = dr.GetOrdinal(this.Formatresolucion);
            if (!dr.IsDBNull(iFormatresolucion)) entity.Formatresolucion = Convert.ToInt32(dr.GetValue(iFormatresolucion));

            int iFormatextension = dr.GetOrdinal(this.Formatextension);
            if (!dr.IsDBNull(iFormatextension)) entity.Formatextension = dr.GetString(iFormatextension);

            int iFormatperiodo = dr.GetOrdinal(this.Formatperiodo);
            if (!dr.IsDBNull(iFormatperiodo)) entity.Formatperiodo = Convert.ToInt32(dr.GetValue(iFormatperiodo));

            int iFormatnombre = dr.GetOrdinal(this.Formatnombre);
            if (!dr.IsDBNull(iFormatnombre)) entity.Formatnombre = dr.GetString(iFormatnombre);

            int iFormatcodi = dr.GetOrdinal(this.Formatcodi);
            if (!dr.IsDBNull(iFormatcodi)) entity.Formatcodi = Convert.ToInt32(dr.GetValue(iFormatcodi));

            int iFormathorizonte = dr.GetOrdinal(this.Formathorizonte);
            if (!dr.IsDBNull(iFormathorizonte)) entity.Formathorizonte = Convert.ToInt32(dr.GetValue(iFormathorizonte));

            int iFormatversion = dr.GetOrdinal(this.Formatversion);
            if (!dr.IsDBNull(iFormatversion)) entity.Formatversion = Convert.ToInt32(dr.GetValue(iFormatversion));

            switch (entity.Formatperiodo)
            { 
                case 1:
                    entity.Periodo = "Diario";
                    break;
                case 2:
                    entity.Periodo = "Semanal";
                    break;
                case 3:
                    entity.Periodo = "Mensual";
                    break;
                case 4:
                    entity.Periodo = "Anual";
                    break;
                default:
                    entity.Periodo = "No Definido";
                    break;
            }
            switch (entity.Formatresolucion)
            {
                case 15:
                    entity.Resolucion = "15 Minutos";
                    break;
                case 30:
                    entity.Resolucion = "30 Minutos";
                    break;
                case 60:
                    entity.Resolucion = "1 Hora";
                    break;
                default:
                    entity.Resolucion = "No Definido";
                    break;
            }
            switch (entity.Formathorizonte)
            {
                case 1:
                    entity.Horizonte = "1 Día";
                    break;
                case 3:
                    entity.Horizonte = "3 Días";
                    break;
                case 7:
                    entity.Horizonte = "7 Días";
                    break;
                case 30:
                    entity.Horizonte = "30 Días";
                    break;
                default:
                    entity.Horizonte = "No Definido";
                    break;
            }
            return entity;
        }


        #region Mapeo de Campos

        public string Lastdate = "LASTDATE";
        public string Lastuser = "LASTUSER";
        public string Areacode = "AREACODE";
        public string Formatresolucion = "FORMATRESOLUCION";
        public string Formatextension = "FORMATEXTENSION";
        public string Formatperiodo = "FORMATPERIODO";
        public string Formatnombre = "FORMATNOMBRE";
        public string Formatcodi = "FORMATCODI";
        public string Formathorizonte = "FORMATHORIZONTE";
        public string Formatversion = "FORMATVERSION";

        #endregion
    }
}
