using COES.Base.Core;
using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Infraestructura.Datos.Helper.Sic
{
    public class DesviacionHelper : HelperBase
    {
        public DesviacionHelper()
            : base(Consultas.DatosDesviacionSql)
        {
        }

        public DesviacionDTO Create(IDataReader dr)
        {
            DesviacionDTO entity = new DesviacionDTO();



            if (!dr.IsDBNull(1)) entity.Lectcodi = 4;
            if (!dr.IsDBNull(2)) entity.Desvfecha = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (!dr.IsDBNull(0)) entity.Ptomedicodi = Convert.ToInt32(dr.GetValue(0));
            if (!dr.IsDBNull(3)) entity.Medorigdesv = Convert.ToInt32(dr.GetValue(3));
            

            return entity;



        }


        #region Mapeo de Campos



        public string Lectcodi = "LECTCODI";
        public string Desvfecha = "DESVFECHA";
        public string Ptomedicodi = "PTOMEDICODI";
        public string Medorigdesv = "MEDORIGDESV";
        public string Lastuser = "LASTUSER";
        public string Lastdate = "LASTDATE";


        #endregion
    }
}
