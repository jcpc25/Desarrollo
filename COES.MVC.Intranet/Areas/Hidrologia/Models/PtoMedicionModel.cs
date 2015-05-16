using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Hidrologia.Models
{
    public class PtoMedicionModel
    {
        public List<MePtomedicionDTO> ListaPtoMedicion { get; set; }
        public List<EmpresaDTO> ListaEmpresas { get; set; }
        public List<EqFamiliaDTO> ListaFamilia { get; set; }
        public List<EqEquipoDTO> ListaEquipo{ get; set; }
        public List<MeTipopuntomedicionDTO> ListaTipoPuntoMedicion { get; set; }
        public List<MeOrigenlecturaDTO> ListaOrigenLectura { get; set; }
        public MePtomedicionDTO ptomedicion { get; set; }
        public int idPtomedicodi { get; set; }
        public int idEquipo { get; set; }
        public int idEmpresa { get; set; }
        public int idOrigenLectura { get; set; }
        public short idTipoPtoMedicion { get; set; }
        public string idOsicodi { get; set; }
        public int idOrden { get; set; }
        public string idPtomedibarranomb { get; set; }
        public string idPtomedielenomb { get; set; }
        public bool IndicadorPagina { get; set; }
        public int NroPaginas { get; set; }
        public int NroMostrar { get; set; }
    }

    public class BusquedaPtoMedicionModel
    {
        public List<EmpresaDTO> ListaEmpresas { get; set; }
        public List<MeTipopuntomedicionDTO> ListaTipoPuntoMedicion { get; set; }
        public List<SiTipoinformacionDTO> ListaTipoInformacion { get; set; }
        public List<MeOrigenlecturaDTO> ListaOrigenLectura { get; set; }
    }
}