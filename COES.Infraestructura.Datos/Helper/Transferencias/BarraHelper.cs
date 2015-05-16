using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System.Data;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    /// <summary>
    /// Clase que contiene el mapeo de la tabla TRN_BARRA
    /// </summary>
    public class BarraHelper : HelperBase
    {
        public BarraHelper() : base(Consultas.BarraSql)
        {
        }

        public BarraDTO Create(IDataReader dr)
        {
            BarraDTO entity = new BarraDTO();

            int iBarrcodi = dr.GetOrdinal(this.Barrcodi);
            if (!dr.IsDBNull(iBarrcodi)) entity.Barrcodi = dr.GetInt32(iBarrcodi);

            int iBarrnombre = dr.GetOrdinal(this.Barrnombre);
            if (!dr.IsDBNull(iBarrnombre)) entity.Barrnombre = dr.GetString(iBarrnombre);

            int iBarrtension = dr.GetOrdinal(this.Barrtension);
            if (!dr.IsDBNull(iBarrtension)) entity.Barrtension = dr.GetString(iBarrtension);

            int iBarrpuntosumirer = dr.GetOrdinal(this.Barrpuntosumirer);
            if (!dr.IsDBNull(iBarrpuntosumirer)) entity.Barrpuntosumirer = dr.GetString(iBarrpuntosumirer);

            int iBarrbarrabgr = dr.GetOrdinal(this.Barrbarrabgr);
            if (!dr.IsDBNull(iBarrbarrabgr)) entity.Barrbarrabgr = dr.GetString(iBarrbarrabgr);

            int iBarrestado = dr.GetOrdinal(this.Barrestado);
            if (!dr.IsDBNull(iBarrestado)) entity.Barrestado = dr.GetString(iBarrestado);

            int iBarrflagbarrtran = dr.GetOrdinal(this.Barrflagbarrtran);
            if (!dr.IsDBNull(iBarrflagbarrtran)) entity.Barrflagbarrtran = dr.GetString(iBarrflagbarrtran);

            int iAreacodi = dr.GetOrdinal(this.Areacodi);
            if (!dr.IsDBNull(iAreacodi)) entity.Areacodi = dr.GetInt32(iAreacodi);

            int iBarrnombbarrtran = dr.GetOrdinal(this.Barrnombbarrtran);
            if (!dr.IsDBNull(iBarrnombbarrtran)) entity.Barrnombbarrtran = dr.GetString(iBarrnombbarrtran);

            int iBarrusername = dr.GetOrdinal(this.Barrusername);
            if (!dr.IsDBNull(iBarrusername)) entity.Barrusername = dr.GetString(iBarrusername);

            int iBarrfecins = dr.GetOrdinal(this.Barrfecins);
            if (!dr.IsDBNull(iBarrfecins)) entity.Barrfecins = dr.GetDateTime(iBarrfecins);

            int iBarrfecact = dr.GetOrdinal(this.Barrfecact);
            if (!dr.IsDBNull(iBarrfecact)) entity.Barrfecact = dr.GetDateTime(iBarrfecact);

            return entity;
        }

        #region Mapeo de Campos

        public string Barrcodi = "BARRCODI";
        public string Barrnombre = "BARRNOMBRE";
        public string Barrtension = "BARRTENSION";
        public string Barrpuntosumirer = "BARRPUNTOSUMINISTRORER";
        public string Barrbarrabgr = "BARRBARRABGR";
        public string Barrestado = "BARRESTADO";
        public string Barrflagbarrtran = "BARRFLAGBARRATRANSFERENCIA";
        public string Areacodi = "AREACODI";
        public string Barrnombbarrtran = "BARRBARRATRANSFERENCIA";
        public string Barrusername = "BARRUSERNAME";
        public string Barrfecins = "BARRFECINS";
        public string Barrfecact = "BARRFECACT";

        #endregion

        public string SqlCodigoGenerado
        {
            get { return base.GetSqlXml("GetMaxId"); }
        }
    }
}
