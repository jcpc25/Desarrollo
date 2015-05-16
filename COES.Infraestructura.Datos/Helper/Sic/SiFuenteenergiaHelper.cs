using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla SI_FUENTEENERGIA
    /// </summary>
    public class SiFuenteenergiaHelper : HelperBase
    {
        public SiFuenteenergiaHelper(): base(Consultas.SiFuenteenergiaSql)
        {
        }

        public SiFuenteenergiaDTO Create(IDataReader dr)
        {
            SiFuenteenergiaDTO entity = new SiFuenteenergiaDTO();

            int iFenergcodi = dr.GetOrdinal(this.Fenergcodi);
            if (!dr.IsDBNull(iFenergcodi)) entity.Fenergcodi = Convert.ToInt32(dr.GetValue(iFenergcodi));

            int iFenergabrev = dr.GetOrdinal(this.Fenergabrev);
            if (!dr.IsDBNull(iFenergabrev)) entity.Fenergabrev = dr.GetString(iFenergabrev);

            int iFenergnomb = dr.GetOrdinal(this.Fenergnomb);
            if (!dr.IsDBNull(iFenergnomb)) entity.Fenergnomb = dr.GetString(iFenergnomb);

            int iTgenercodi = dr.GetOrdinal(this.Tgenercodi);
            if (!dr.IsDBNull(iTgenercodi)) entity.Tgenercodi = Convert.ToInt32(dr.GetValue(iTgenercodi));

            return entity;
        }


        #region Mapeo de Campos

        public string Fenergcodi = "FENERGCODI";
        public string Fenergabrev = "FENERGABREV";
        public string Fenergnomb = "FENERGNOMB";
        public string Tgenercodi = "TGENERCODI";

        #endregion
    }
}
