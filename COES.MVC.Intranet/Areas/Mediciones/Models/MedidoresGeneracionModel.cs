﻿using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Mediciones.Models
{
    /// <summary>
    /// Maneja los datos del reporte de medidores
    /// </summary>
    public class MedidoresGeneracionModel
    {
        public List<SiEmpresaDTO> ListaEmpresas { get; set; }
        public List<SiTipogeneracionDTO> ListaTipoGeneracion { get; set; }
        public List<SiFuenteenergiaDTO> ListaFuenteEnergia { get; set; }
        public List<SiTipoempresaDTO> ListaTipoEmpresas { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public List<MeMedicion96DTO> ListaDatos { get; set; }
        public List<MeMedicion96DTO> EntidadTotal {get; set;}
        public string TextoCabecera { get; set; }
        public bool IndicadorPagina { get; set; }
        public int NroPaginas { get; set; }
        public int NroMostrar { get; set; }
        public int NroPagina { get; set; }
        public string IndicadorPublico { get; set; }
    }

    /// <summary>
    /// Maneja los datos del reporte de medidores
    /// </summary>
    public class ReporteMedidoresModel
    {
        public List<SiEmpresaDTO> ListaEmpresas { get; set; }
        public List<SiTipogeneracionDTO> ListaTipoGeneracion { get; set; }
        public List<SiFuenteenergiaDTO> ListaFuenteEnergia { get; set; }
        public List<SiTipoempresaDTO> ListaTipoEmpresas { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string FechaConsulta { get; set; }
        public List<MedicionReporteDTO> ListaCuadros { get; set; }
        public MedicionReporteDTO DatosReporte { get; set; }
        public List<MedicionReporteDTO> ReporteFuenteEnergia { get; set; }
    }
}