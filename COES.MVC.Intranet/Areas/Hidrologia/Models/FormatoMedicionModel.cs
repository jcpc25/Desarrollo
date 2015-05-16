using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Hidrologia.Models
{
    public class BusquedaFormatoMedicionModel
    {
        public List<MeOrigenlecturaDTO> ListaOrigenLectura { get; set; }
        public List<MeLecturaDTO> ListaLectura { get; set; }
        public List<FwAreaDTO> ListaAreasCoes { get; set; }
    }

    public class FormatoMedicionModel
    {
        public List<MeFormatoDTO> ListaFormato { get; set; }
        public List<MeFormatohojaDTO> ListaFormatoHojas { get; set; }
        public MeFormatoDTO Formato { get; set; }
        public List<MeLecturaDTO> ListaLectura { get; set; }
        public List<FwAreaDTO> ListaAreasCoes { get; set; }
        public List<MeHojaptomedDTO> ListaHojaPto { get; set; }
        public MeHojaptomedDTO HojaPto { get; set; }
        public List<EmpresaDTO> ListaEmpresa { get; set; }
        public List<SiTipoinformacionDTO> ListaMedidas { get; set; }
        public List<EqFamiliaDTO> ListaFamilia { get; set; }
        public List<EqEquipoDTO> ListaEquipo { get; set; }
        public List<MePtomedicionDTO> ListaPtos { get; set; }
        public List<MeHeadcolumnDTO> ListaHeadColumn { get; set; }
        public int FormatoCodigo { get; set; }
        public int HojaNumero { get; set; }
        public int EmpresaCodigo { get; set; }
        public string HeadColFormato { get; set; }
        public int HeadColAncho { get; set; }
        public int HeadColPos { get; set; }
        public int HeadColActivo { get; set; }
        public decimal HeadColLimsup { get; set; }
        public int Resultado { get; set; }
    }

}