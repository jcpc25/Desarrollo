﻿using COES.Dominio.DTO.Sic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Hidrologia.Models
{
    public class HidrologiaModel
    {
        public List<SiEmpresaDTO> ListaEmpresas { get; set; }
        public int empresa { get; set; }
        //public List<string> ListaSemanas { get; set; }
        //public int NroSemana { get; set; }
        public string Fecha { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Anho { get; set; }
        public string SemanaIni { get; set; }
        public string SemanaFin { get; set; }
        public string FechaPlazo { get; set; }
        public int HoraPlazo { get; set; }
        public string Resultado { get; set; }
        public List<MeHojaptomedDTO> ListaHojaPto { get; set; }
        public MeFormatoDTO Formato { get; set; }
        public List<MeHeadcolumnDTO> ListaHeadColumn { get; set; }
        public List<MePtomedicionDTO> ListaMedicion { get; set; }
        public List<PtoMedida> ListaPtoMedida { get; set; }
        public List<EqEquipoDTO> ListaCuenca { get; set; }
        public List<EqEquipoDTO> ListaRecursosCuenca { get; set; }
        public List<MeFormatoDTO> ListaTipoInformacion { get; set; }
        public List<TipoInformacion> ListaTipoInformacionEnvio { get; set; }
        public List<TipoInformacion> ListaTipoFormato { get; set; }
        public List<TipoInformacion> ListaFrecuencia { get; set; }
        public List<TipoInformacion> ListaSemanas { get; set; }
        public List<String> ListaCategoriaGrafico { get; set; }
        public List<String> ListaSerieName { get; set; }
        public decimal?[][] ListaSerieData { get; set; }
        public string TituloReporte { get; set; }
        public string TitlexAxis { get; set; }
        public int TipoReporte { get; set; }
        public List<MeMedicion1DTO> ListaMedicion1 { get; set; }
        public List<MeMedicion24DTO> ListaMedicion24 { get; set; }

        public bool IndicadorPagina { get; set; }
        public int NroPaginas { get; set; }
        public int NroMostrar { get; set; }
    }
    public class PtoMedida
    {
        public int IdMedida { get; set; }
        public string NombreMedida { get; set; }
    }

    public class TipoInformacion
    {
        public int IdTipoInfo { get; set; }
        public string NombreTipoInfo { get; set; }
    }
    
}