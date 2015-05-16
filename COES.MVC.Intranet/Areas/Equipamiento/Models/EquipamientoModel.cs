using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COES.Dominio.DTO.Sic;
namespace COES.MVC.Intranet.Areas.Equipamiento.Models
{
    public class EquipamientoModel
    {
    }

    /// <summary>
    /// Model del Index de área
    /// </summary>
    public class AreaModel
    {
        public List<EqTipoareaDTO> ListaTipoArea { get; set; }
        public int idTipoArea { get; set; }
        public string NombreArea { get; set; }
        public List<EqAreaDTO> ListaArea { get; set; }
        //Paginado
        public int NroPagina { get; set; }
        public int NroPaginas { get; set; }
        public int NroMostrar { get; set; }
        public bool IndicadorPagina { get; set; }
    }

    public class AreaDetalleModel
    {
        public int Areacodi { get; set; }
        public int? Tareacodi { get; set; }
        public string Areaabrev { get; set; }
        public string Areanomb { get; set; }
        public int Areapadre { get; set; }
        public string AreaUsuIns { get; set; }
        public string AreaUsuUpd { get; set; }
    }
}