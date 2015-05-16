﻿using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class CodigoRetiroSinContratoModel
    {
        public bool bEditar { get; set; }
        public bool bNuevo { get; set; }
        public bool bEliminar { get; set; }
        public bool bGrabar { get; set; }

        public List<CodigoRetiroSinContratoDTO> ListaCodigoRetiroSinContrato { get; set; }
        public CodigoRetiroSinContratoDTO Entidad { get; set; }
        public int IdCodigoRetirosinContrato { get; set; }

        public string Codretisinconfechainicio { get; set; }
        public string Codretisinconfechafin { get; set; }
        public string sError { get; set; }
    }
}