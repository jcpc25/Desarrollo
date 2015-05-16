using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COES.Dominio.DTO.Transferencias;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class RecalculoModel
    {
        public bool bEditar { get; set; }
        public bool bNuevo { get; set; }
        public bool bEliminar { get; set; }
        public bool bGrabar { get; set; }
        public List<RecalculoDTO> ListaRecalculo { get; set; }
        public RecalculoDTO Entidad { get; set; }
        public int IdRecalculo { get; set; }

        public string Recafecini { get; set; }
        public string Recafecfin { get; set; }
        public string sError { get; set; }
    }
}