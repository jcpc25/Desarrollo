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
    public class InfoDesbalanceHelper : HelperBase
    {
        public InfoDesbalanceHelper() : base(Consultas.InfoDesbalanceSql)
        {
        }

        public InfoDesbalanceDTO Create(IDataReader dr)
        {
            InfoDesbalanceDTO entity = new InfoDesbalanceDTO();

            int iBarrcodi = dr.GetOrdinal(this.Barrcodi);
            if (!dr.IsDBNull(iBarrcodi)) entity.BARRCODI = dr.GetInt32(iBarrcodi);

            int iTotal = dr.GetOrdinal(this.Total);
            if (!dr.IsDBNull(iTotal)) entity.TOTAL = Math.Round(Math.Abs(dr.GetDecimal(iTotal)),2);


            int iBarrnombre = dr.GetOrdinal(this.Barrnombre);
            if (!dr.IsDBNull(iBarrnombre)) entity.BARRNOMBRE = dr.GetString(iBarrnombre);

            return entity;
        }


        #region Mapeo de Campos

        public string Barrcodi = "BARRCODI";
        public string Barrnombre = "BARRNOMBRE";
        public string Total = "TOTAL";

        public string Pericodi = "PERICODI";
        #endregion

    }
}
