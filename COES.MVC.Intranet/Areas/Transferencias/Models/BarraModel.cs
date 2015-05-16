﻿using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class BarraModel
    {
        public bool bEditar { get; set; }
        public bool bNuevo { get; set; }
        public bool bEliminar { get; set; }
        public List<BarraDTO> ListaBarras { get; set; }
        public BarraDTO Entidad { get; set; }
        public int IdBarra { get; set; }
    }
}