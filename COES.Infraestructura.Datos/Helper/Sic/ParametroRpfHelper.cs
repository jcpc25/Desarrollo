using System;
using System.Collections.Generic;
using System.Data;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    public class ParametroRpfHelper : HelperBase
    {
        public ParametroRpfHelper()
            : base(Consultas.ParametroRpfSql)
        {

        }

        public ParametroRpfDTO Create(IDataReader dr)
        {
            ParametroRpfDTO entity = new ParametroRpfDTO();

            int iPARAMRPFCODI = dr.GetOrdinal(this.PARAMRPFCODI);
            if (!dr.IsDBNull(iPARAMRPFCODI)) entity.PARAMRPFCODI = Convert.ToInt32(dr.GetValue(iPARAMRPFCODI));

            int iPARAMTIPO = dr.GetOrdinal(this.PARAMTIPO);
            if (!dr.IsDBNull(iPARAMTIPO)) entity.PARAMTIPO = dr.GetString(iPARAMTIPO);

            int iPARAMVALUE = dr.GetOrdinal(this.PARAMVALUE);
            if (!dr.IsDBNull(iPARAMVALUE)) entity.PARAMVALUE = dr.GetString(iPARAMVALUE);

            int iPARAMMODULO = dr.GetOrdinal(this.PARAMMODULO);
            if (!dr.IsDBNull(iPARAMMODULO)) entity.PARAMMODULO = dr.GetString(iPARAMMODULO);

            return entity;
        }

        public string PARAMRPFCODI = "PARAMRPFCODI";
        public string PARAMTIPO = "PARAMTIPO";
        public string PARAMVALUE = "PARAMVALUE";
        public string PARAMMODULO = "PARAMMODULO";


        //public string SqlObtenerPuntosExcluir
        //{
        //    get { return base.GetSqlXml("ObtenerPuntosExcluir"); }
        //}


    }
}
