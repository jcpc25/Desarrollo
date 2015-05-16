using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class EnvioInformacionModel
    {
        public List<ExportExcelDTO> ListaEntregReti{ get; set; }
        public ExportExcelDTO Entidad { get; set; }
    }
}