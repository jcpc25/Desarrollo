﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Eventos.Models
{
    public class MatrizModel
    {
        public List<RsfModel> ListaElementos { get; set; }
        public string Fecha { get; set; }
    }

    public class RsfModel
    {
        public string Empresa { get; set; }
        public string Central { get; set; }
        public string Equipo { get; set; }
        public Decimal Potencia { get; set; }
        public int IdEmpresa { get; set; }
        public int IdEquipo { get; set; }
        public string DesURS { get; set; }
        public string Order { get; set; }
        private List<RsfItemModel> listItems = new List<RsfItemModel>();
        public List<RsfItemModel> ListItems
        {
            get { return listItems; }
            set { listItems = value; }
        }
    }

    public class RsfItemModel
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public Decimal Manual { get; set; }
        public Decimal Automatico { get; set; }
        public string IndManual { get; set; }
        public string IndAutomatico { get; set; }
        public string CheckDelete { get; set; }
    }

    public class HoraModel
    {
        public string TxtInicio { get; set; }
        public string TxtFin { get; set; }
        public string IndicadorEdicion { get; set; }
        public int Indice { get; set; }
    }
}