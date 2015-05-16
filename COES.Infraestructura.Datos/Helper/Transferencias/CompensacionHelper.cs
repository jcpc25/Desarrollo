using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System.Data;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla TRN_CAB_COPENSACION
    /// </summary>
    public class CompensacionHelper: HelperBase
    {
        public CompensacionHelper() : base(Consultas.CompensacionSql)
        {
        }

        public CompensacionDTO Create(IDataReader dr)
        {
            CompensacionDTO entity = new CompensacionDTO();

            int iCabecompcodi = dr.GetOrdinal(this.Cabecompcodi);
            if (!dr.IsDBNull(iCabecompcodi)) entity.Cabecompcodi = dr.GetInt32(iCabecompcodi);

            int iCabecompnombre = dr.GetOrdinal(this.Cabecompnombre);
            if (!dr.IsDBNull(iCabecompnombre)) entity.Cabecompnombre = dr.GetString(iCabecompnombre);

            int iCabecompver = dr.GetOrdinal(this.Cabecompver);
            if (!dr.IsDBNull(iCabecompver)) entity.Cabecompver = dr.GetString(iCabecompver);

            int iCabecompestado = dr.GetOrdinal(this.Cabecompestado);
            if (!dr.IsDBNull(iCabecompestado)) entity.Cabecompestado = dr.GetString(iCabecompestado);

            int iCabecompusername = dr.GetOrdinal(this.Cabecompusername);
            if (!dr.IsDBNull(iCabecompusername)) entity.Cabecompusername = dr.GetString(iCabecompusername);

            int iCabecompfecins = dr.GetOrdinal(this.Cabecompfecins);
            if (!dr.IsDBNull(iCabecompfecins)) entity.Cabecompfecins = dr.GetDateTime(iCabecompfecins);

            int iCabecompfecact = dr.GetOrdinal(this.Cabecompfecact);
            if (!dr.IsDBNull(iCabecompfecact)) entity.Cabecompfecact = dr.GetDateTime(iCabecompfecact);

            int iCabecomppericodi = dr.GetOrdinal(this.Cabecomppericodi);
            if (!dr.IsDBNull(iCabecomppericodi)) entity.Cabecomppericodi = dr.GetInt32(iCabecomppericodi);

          


            return entity;
        }

        #region Mapeo de Campos

        public string Cabecompcodi = "CABCOMCODI";
        public string Cabecompnombre = "CABCOMNOMBRE";
        public string Cabecompver = "CABCOMVISUALIZAR";
        public string Cabecompestado = "CABCOMESTADO";
        public string Cabecompusername = "CABCOMUSERNAME";
        public string Cabecompfecins = "CABCOMFECINS";
        public string Cabecompfecact = "CABCOMFECACT";
        public string Cabecomppericodi = "PERICODI";
      
      

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

        public string SqlGetByCodigo
        {
            get { return base.GetSqlXml("GetByCodigo"); }

        }
    }
    }

