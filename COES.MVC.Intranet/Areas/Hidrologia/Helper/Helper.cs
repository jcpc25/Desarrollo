﻿using COES.MVC.Intranet.Areas.Hidrologia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.Hidrologia.Helper
{
    public class Helper
    {
    }
    public class Tools
    {
        public static List<PtoMedida> ObtenerListaMedida()
        {
            List<PtoMedida> lista = new List<PtoMedida>();
            var elemento = new PtoMedida() { IdMedida = 1, NombreMedida = "Central" };
            lista.Add(elemento);
            elemento = new PtoMedida() { IdMedida = 2, NombreMedida = "Embalse" };
            lista.Add(elemento);
            elemento = new PtoMedida() { IdMedida = 3, NombreMedida = "Estación Hidrológica" };
            lista.Add(elemento);

            return lista;
        }
       
        public static List<TipoInformacion> ObtenerListaFormato()
        {
            List<TipoInformacion> lista = new List<TipoInformacion>();
            var elemento = new TipoInformacion() { IdTipoInfo = 3, NombreTipoInfo = "PROGRAMA DIARIO - QN" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 4, NombreTipoInfo = "PROGRAMA SEMANAL - QN" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 5, NombreTipoInfo = "EJECUTADO DIARIO - Q TURB. VERT." };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 6, NombreTipoInfo = "EJECUTADO DIARIO - EMBALSES" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 7, NombreTipoInfo = "PROGRAMADO MENSUAL - QN" };
            lista.Add(elemento);

            return lista;
        }
    }
}