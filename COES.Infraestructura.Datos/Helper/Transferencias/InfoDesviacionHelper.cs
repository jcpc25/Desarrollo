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
    public class InfoDesviacionHelper:HelperBase
    {
        public InfoDesviacionHelper() : base(Consultas.InfoDesviacionSql)
        {
        }

        public InfoDesviacionDTO Create(IDataReader dr)
        {
            InfoDesviacionDTO entity = new InfoDesviacionDTO();

            int iEmpresa = dr.GetOrdinal(this.Empresa);
            if (!dr.IsDBNull(iEmpresa)) entity.Empresa = dr.GetString(iEmpresa);

            int iBarra = dr.GetOrdinal(this.Barra);
            if (!dr.IsDBNull(iBarra)) entity.Barra = dr.GetString(iBarra);

            int iCliente = dr.GetOrdinal(this.Cliente);
            if (!dr.IsDBNull(iCliente)) entity.Cliente = dr.GetString(iCliente);

            int iCodigo = dr.GetOrdinal(this.Codigo);
            if (!dr.IsDBNull(iCodigo)) entity.Codigo = dr.GetString(iCodigo);

            int iDesviacion = dr.GetOrdinal(this.Desviacion);
            if (!dr.IsDBNull(iDesviacion)) entity.Desviacion = dr.GetDecimal(iDesviacion);

            return entity;
        }

        #region Mapeo de Campos

        public string AnioMes = "AnioMes";
        public string AnioMes1 = "AnioMes1";
        public string AnioMes2 = "AnioMes2";
        public string Dias = "Dias";
        public string DiasMeses = "DiasMeses";
        public string Desviacion = "Desviacion";
        public string Empresa = "Empresa";
        public string Barra = "Barra";
        public string Cliente = "Cliente";        
        public string Codigo = "Codigo";


        #endregion

    }
}
