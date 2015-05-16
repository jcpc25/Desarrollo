using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COES.Dominio.DTO.Transferencias;

namespace COES.MVC.Intranet.Areas.Transferencias.Models
{
    public class IngresoCompensacionModel
    {
        public List<IngresoCompensacionDTO> ListaIngresoCompensacion { get; set; }
        public IngresoCompensacionDTO Entidad { get; set; }
        public int IdIngresoCompensacion { get; set; }
    }
}