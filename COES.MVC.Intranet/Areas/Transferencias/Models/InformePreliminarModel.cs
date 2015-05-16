using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class InformePreliminarModel
    {

        public List<InformePreliminarDTO> ListaInformePreliminar { get; set; }
        public InformePreliminarDTO Entidad { get; set; }
       
    }
}