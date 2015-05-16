using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    public class TipoContratoHelper : HelperBase
    {
        public TipoContratoHelper() : base(Consultas.TipoContratoSql)
        {
        }

        public TipoContratoDTO Create(IDataReader dr)
        {
            TipoContratoDTO entity = new TipoContratoDTO();

            int iTIPOCONTCODI = dr.GetOrdinal(this.TIPOCONTCODI);
            if (!dr.IsDBNull(iTIPOCONTCODI)) entity.Tipocontcodi = dr.GetInt32(iTIPOCONTCODI);

            int iTIPOCONTNOMBRE = dr.GetOrdinal(this.TIPOCONTNOMBRE);
            if (!dr.IsDBNull(iTIPOCONTNOMBRE)) entity.Tipocontnombre = dr.GetString(iTIPOCONTNOMBRE);

            int iTIPOCONTESTADO = dr.GetOrdinal(this.TIPOCONTESTADO);
            if (!dr.IsDBNull(iTIPOCONTESTADO)) entity.Tipocontestado = dr.GetString(iTIPOCONTESTADO);

            int iTIPOCONTUSERNAME = dr.GetOrdinal(this.TIPOCONTUSERNAME);
            if (!dr.IsDBNull(iTIPOCONTUSERNAME)) entity.Tipocontusername = dr.GetString(iTIPOCONTUSERNAME);

            int iTIPOCONTFECINS = dr.GetOrdinal(this.TIPOCONTFECINS);
            if (!dr.IsDBNull(iTIPOCONTFECINS)) entity.Tipocontfecins = dr.GetDateTime(iTIPOCONTFECINS);

            int iTIPOCONTFECACT = dr.GetOrdinal(this.TIPOCONTFECACT);
            if (!dr.IsDBNull(iTIPOCONTFECACT)) entity.Tipocontfecact = dr.GetDateTime(iTIPOCONTFECACT);

            return entity;
        }

        #region Mapeo de Campos

        public string TIPOCONTCODI = "TIPCONCODI";
        public string TIPOCONTNOMBRE = "TIPCONNOMBRE";
        public string TIPOCONTESTADO = "TIPCONESTADO";
        public string TIPOCONTUSERNAME = "TIPCONUSERNAME";
        public string TIPOCONTFECINS = "TIPCONFECINS";
        public string TIPOCONTFECACT = "TIPCONFECACT";

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }

    }
}
