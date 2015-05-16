﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Base.Core;
using COES.Dominio.DTO.Transferencias;
using System.Data;

namespace COES.Infraestructura.Datos.Helper.Transferencias
{
    public class RatioCumplimientoHelper: HelperBase
    {
        public RatioCumplimientoHelper() : base(Consultas.RatioCumplimientoSql)
        {
        }

        public RatioCumplimientoDTO Create(IDataReader dr)
        {
            RatioCumplimientoDTO entity = new RatioCumplimientoDTO();

            int iEmprcodi = dr.GetOrdinal(this.Emprcodi);
            if (!dr.IsDBNull(iEmprcodi)) entity.Emprcodi = dr.GetInt32(iEmprcodi);

            int iEmprnomb = dr.GetOrdinal(this.Emprnomb);
            if (!dr.IsDBNull(iEmprnomb)) entity.Emprnomb = dr.GetString(iEmprnomb);

            int iTipoemprcodi = dr.GetOrdinal(this.Tipoemprcodi);
            if (!dr.IsDBNull(iTipoemprcodi)) entity.Tipoemprcodi = dr.GetInt32(iTipoemprcodi);

            int iPericodi = dr.GetOrdinal(this.Pericodi);
            if (!dr.IsDBNull(iPericodi)) entity.Pericodi = dr.GetInt32(iPericodi);

            int iRequerido = dr.GetOrdinal(this.Requerido);
            if (!dr.IsDBNull(iRequerido)) entity.Requerido = dr.GetDecimal(iRequerido);

            int iInformado = dr.GetOrdinal(this.Informado);
            if (!dr.IsDBNull(iInformado)) entity.Informado= dr.GetDecimal(iInformado);

            //int iInfofinal = dr.GetOrdinal(this.Infofinal);
            //if (!dr.IsDBNull(iInfofinal)) entity.Infofinal = dr.GetInt32(iInfofinal);

                      return entity;
        }
        #region Mapeo de Campos

        public string Emprcodi = "EMPRCODI";
        public string Emprnomb = "EMPRNOMB";
        public string Tipoemprcodi = "TIPOEMPRCODI";
        public string Pericodi = "PERICODI";
        public string Requerido = "REQUERIDO";
        public string Informado = "INFORMADO";
        //public string Infofinal = "INFOFINAL";

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
