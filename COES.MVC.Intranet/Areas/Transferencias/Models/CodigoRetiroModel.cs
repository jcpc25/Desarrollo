using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class CodigoRetiroModel
    {
        public bool bEditar { get; set; }
        public bool bNuevo { get; set; }
        public bool bEliminar { get; set; }
        public bool bGrabar { get; set; }

        public List<CodigoRetiroDTO> ListaCodigoRetiro { get; set; }
        public CodigoRetiroDTO Entidad { get; set; }
        public int IdcodRetiro { get; set; }


        public string sError { get; set; }
    }
}