using COES.MVC.Intranet.Areas.Hidrologia.Models;
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
            elemento = new PtoMedida() { IdMedida = 4, NombreMedida = "Cuenca" };
            lista.Add(elemento);

            return lista;
        }             

        public static List<TipoInformacion> ObtenerListaTipoInfo()
        {
            List<TipoInformacion> lista = new List<TipoInformacion>();
            var elemento = new TipoInformacion() { IdTipoInfo = 1, NombreTipoInfo = "HISTORICO" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 2, NombreTipoInfo = "PROYECTADO" };
            lista.Add(elemento);           
            return lista;
        }

        public static List<TipoInformacion> ObtenerListaFrecuencia()
        {
            List<TipoInformacion> lista = new List<TipoInformacion>();
            var elemento = new TipoInformacion() { IdTipoInfo = 1, NombreTipoInfo = "DIARIA" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 2, NombreTipoInfo = "CADA (3) HORAS" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 3, NombreTipoInfo = "SEMANAL" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 4, NombreTipoInfo = "MENSUAL" };
            lista.Add(elemento);
            return lista;
        }

        public static List<TipoInformacion> ObtenerListaTipoFormato()
        {
            List<TipoInformacion> lista = new List<TipoInformacion>();
            var elemento = new TipoInformacion() { IdTipoInfo = 1, NombreTipoInfo = "EJECUTADO" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 2, NombreTipoInfo = "PROGRAMADO DIARIO" };
            lista.Add(elemento);
            elemento = new TipoInformacion() { IdTipoInfo = 3, NombreTipoInfo = "PROGRAMADO SEMANAL" };
            lista.Add(elemento);            
            return lista;

        }
    }
}