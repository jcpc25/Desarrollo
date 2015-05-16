using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla CB_ARCHIVOENVIO
    /// </summary>
    class CbArchivoEnvioHelper : HelperBase
    {
        public CbArchivoEnvioHelper(): base(Consultas.CbArchivoEnvioSql)
        {
        }
        public CbArchivoEnvioDTO Create(IDataReader dr)
        {
            CbArchivoEnvioDTO entity = new CbArchivoEnvioDTO();

            int iconcepcodi = dr.GetOrdinal(this.concepcodi);
            if (!dr.IsDBNull(iconcepcodi)) entity.concepcodi = Convert.ToInt32(dr.GetValue(iconcepcodi));
            
            int ienviocodi = dr.GetOrdinal(this.enviocodi);
            if (!dr.IsDBNull(ienviocodi)) entity.enviocodi = Convert.ToInt32(dr.GetValue(ienviocodi));

            int iarchivnombreenvio = dr.GetOrdinal(this.archivnombreenvio);
            if (!dr.IsDBNull(iarchivnombreenvio)) entity.archivnombreenvio = dr.GetString(iarchivnombreenvio);

            int iarchivnombrefisico = dr.GetOrdinal(this.archivnombrefisico);
            if (!dr.IsDBNull(iarchivnombrefisico)) entity.archivnombrefisico = dr.GetString(iarchivnombrefisico);

            int iarchivoestado = dr.GetOrdinal(this.archivoestado);
            if (!dr.IsDBNull(iarchivoestado)) entity.archivoestado = Convert.ToInt32(dr.GetValue(iarchivoestado));

            int ilastdate = dr.GetOrdinal(this.lastdate);
            if (!dr.IsDBNull(ilastdate)) entity.lastdate = dr.GetDateTime(ilastdate); 

            int ilastuser = dr.GetOrdinal(this.lastuser);
            if (!dr.IsDBNull(ilastuser)) entity.lastuser = dr.GetString(ilastuser);

            int iarchienvioorden = dr.GetOrdinal(this.archienvioorden);
            if (!dr.IsDBNull(iarchienvioorden)) entity.archienvioorden = Convert.ToInt32(dr.GetValue(iarchienvioorden));

            return entity;
        }


        #region Mapeo de Campos

        public string concepcodi = "CONCEPCODI";
        public string enviocodi = "ENVIOCODI";
        public string archivnombreenvio = "ARCHIVNOMBREENVIO";
        public string archivnombrefisico = "ARCHIVNOMBREFISICO";
        public string archivoestado = "ARCHIVOESTADO";
        public string lastdate = "LASTDATE";
        public string lastuser = "LASTUSER";
        public string archienvioorden = "ARCHIENVIOORDEN";
        

        #endregion

        public string SqlUpdateEstado
        {
            get { return GetSqlXml("UpdateEstado"); }
        }
        public string SqlGetMaxIdOrden
        {
            get { return GetSqlXml("GetMaxIdOrden"); }
        }
    }
}
