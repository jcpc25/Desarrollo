using COES.MVC.Intranet.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COES.MVC.Intranet.Areas.Transferencias.Helper
{
    public class Funcion
    {
        //CONSTANTES
        public const int iGrabar = 1;
        public const int iEditar = 2;
        public const int iNuevo = 3;
        public const int iEliminar = 5;
        public const decimal dValorMax = 0.3135M;


        public const int CODIEMPR_SINCONTRATO = -1;
        
        public const string RutaReporte = "Areas/Transferencias/Reporte/";
        public const string HojaReporteExcel = "REPORTE";
        public const string NombreReporteAreaExcel = "ReporteArea.xlsx";
        public const string NombreReporteBarraExcel = "ReporteBarra.xlsx";
        public const string NombreReporteClienteExcel = "ReporteCliente.xlsx";
        public const string NombreReporteTipoContratoExcel = "ReporteTipoContrato.xlsx";
        public const string NombreReporteTipoUsuarioExcel = "ReporteTipoUsuario.xlsx";
        public const string NombreReporteCompensacionExcel = "ReporteCompensacion.xlsx";
        public const string NombreReporteCodigoEntregaExcel = "ReporteCodigoEntrega.xlsx";
        public const string NombreReporteCodigoRetiroExcel = "ReporteCodigoRetiro.xlsx";
        public const string NombreReporteCodigoRetiroSinConExcel = "ReporteCodigoRetiroSinCon.xlsx";
        public const string NombreReporteCostoMarginalExcel = "ReporteCostoMarginal.xlsx";
        public const string NombreReporteCostoMarginalBarraExcel = "ReporteCostoMarginalBarra.xlsx";
        public const string NombreReporteBalanceEnergiaExcel = "ReporteBalanceEnergia.xlsx";
        public const string NombreReporteBalanceEnergiaActivaExcel = "ReporteBalanceEnergiaActiva.xlsx";
        public const string NombreReporteEnvioExcel = "Reporte.xlsx";
        public const string NombreReporteInformePreliminarExcel = "InformePreliminar.xlsx";
        public const string NombreReporteCuadro = "Cuadro.xlsx";
        public const string NombreReporteMatriz = "Matriz.xlsx";


        public const string NombrePlantillaInformePreliminarExcel = "PlantillaInformePreliminar.xlsx";
        public const string NombrePlantillaCuadroExcel = "PlantillaCuadro.xlsx";
        public const string NombrePlantillaMatriz = "PlantillaMatriz.xlsx";
        public const string NombrePlantillaEnvioExcel = "plantilla.xlsx";
        public const string NombrePlantillaAreaExcel = "plantillaarea.xlsx";
        public const string NombrePlantillaBarraExcel = "plantillabarra.xlsx";
        public const string NombrePlantillaClienteExcel = "plantillacliente.xlsx";
        public const string NombrePlantillaTipoContratoExcel = "plantillatipocontrato.xlsx";
        public const string NombrePlantillaTipoUsuarioExcel = "plantillatipousuario.xlsx";
        public const string NombrePlantillaCompensacionExcel = "plantillacompensacion.xlsx";
        public const string NombrePlantillaCodigoEntregaExcel = "plantillacodigoentrega.xlsx";
        public const string NombrePlantillaCodigoRetiroExcel = "plantillacodigoretiro.xlsx";
        public const string NombrePlantillaCodigoRetiroSinConExcel = "plantillacodigoretirosincon.xlsx";
        public const string NombrePlantillaCostoMarginalExcel = "plantillacostomarginal.xlsx";
        public const string NombrePlantillaCostoMarginalBarraExcel = "plantillacostomarginalbarra.xlsx";
        public const string NombrePlantillaBalanceEnergiaExcel = "plantillabalanceenergia.xlsx";
        public const string NombrePlantillaBalanceEnergiaActivaExcel = "plantillabalanceenergiaactiva.xlsx";

        public const string AppExcel = "application/vnd.ms-excel";
        public const string AppWord = "application/vnd.ms-word";
        public const string AppPdf = "application/pdf";
        public const string AppCSV = "application/CSV";
        public const string AppTxt = "application/txt";


        SeguridadServicio.SeguridadServicioClient seguridad = new SeguridadServicio.SeguridadServicioClient();

        public bool ValidarPermnisoGrabar(object IdOpcion, string sUsuario)
        {
            int id = (IdOpcion != null) ? Convert.ToInt32(IdOpcion) : 0;
            //return this.seguridad.ValidarPermisoOpcion(Constantes.IdAplicacion, id, iGrabar, sUsuario);
            return true;
        }

        public bool ValidarPermnisoEditar(object IdOpcion, string sUsuario)
        {
            int id = (IdOpcion != null) ? Convert.ToInt32(IdOpcion) : 0;
            //return this.seguridad.ValidarPermisoOpcion(Constantes.IdAplicacion, id, iEditar, sUsuario);
            return true;
        }

        public bool ValidarPermnisoNuevo(object IdOpcion, string sUsuario)
        {
            int id = (IdOpcion != null) ? Convert.ToInt32(IdOpcion) : 0;
            //return this.seguridad.ValidarPermisoOpcion(Constantes.IdAplicacion, id, iNuevo, sUsuario);
            return true;
        }

        public bool ValidarPermnisoEliminar(object IdOpcion, string sUsuario)
        {
            int id = (IdOpcion != null) ? Convert.ToInt32(IdOpcion) : 0;
            //return this.seguridad.ValidarPermisoOpcion(Constantes.IdAplicacion, id, iEliminar, sUsuario);
            return true;
        }

        public IEnumerable<SelectListItem> ObtenerAnio()
        {
            var ListaAnio = new List<SelectListItem>();
            int iAnioFinal = DateTime.Today.Year + 6;
            for (int i = 2014; i <= iAnioFinal; i++)
            {
                var list = new SelectListItem();
                list.Text = list.Value = i.ToString();
                ListaAnio.Add(list);
            }
            return ListaAnio;
        }

        public IEnumerable<SelectListItem> ObtenerMes()
                
        {
            var ListaMes = new List<SelectListItem>();
            var list1 = new SelectListItem();
            list1.Text = "Enero"; list1.Value = "1"; ListaMes.Add(list1);
            var list2 = new SelectListItem();
            list2.Text = "Febrero"; list2.Value = "2"; ListaMes.Add(list2);
            var list3 = new SelectListItem();
            list3.Text = "Marzo"; list3.Value = "3"; ListaMes.Add(list3);
            var list4 = new SelectListItem();
            list4.Text = "Abril"; list4.Value = "4"; ListaMes.Add(list4);
            var list5 = new SelectListItem();
            list5.Text = "Mayo"; list5.Value = "5"; ListaMes.Add(list5);
            var list6 = new SelectListItem();
            list6.Text = "Junio"; list6.Value = "6"; ListaMes.Add(list6);
            var list7 = new SelectListItem();
            list7.Text = "Julio"; list7.Value = "7"; ListaMes.Add(list7);
            var list8 = new SelectListItem();
            list8.Text = "Agosto"; list8.Value = "8"; ListaMes.Add(list8);
            var list9 = new SelectListItem();
            list9.Text = "Setiembre"; list9.Value = "9"; ListaMes.Add(list9);
            var list10 = new SelectListItem();
            list10.Text = "Octubre"; list10.Value = "10"; ListaMes.Add(list10);
            var list11 = new SelectListItem();
            list11.Text = "Noviembre"; list11.Value = "11"; ListaMes.Add(list11);
            var list12 = new SelectListItem();
            list12.Text = "Diciembre"; list12.Value = "12"; ListaMes.Add(list12);
            return ListaMes;
        }


        public DataSet GeneraDataset(string RutaArchivo, int hoja)
        {
            FileInfo archivo = new FileInfo(RutaArchivo);
            ExcelPackage xlPackage = new ExcelPackage(archivo);
            ExcelWorksheet ws = xlPackage.Workbook.Worksheets[hoja];

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            for (int j = 1; j <= ws.Dimension.End.Column; j = j + 1)
            {
                string Columna = "";
                if (ws.Cells[1, j].Value != null) Columna = ws.Cells[1, j].Value.ToString();
                dt.Columns.Add(Columna);
            }

            for (int i = 2; i <= ws.Dimension.End.Row; i = i + 1)
            {
                //Array Fila = ws.Cells[i, 1, i, ws.Dimension.End.Column].ToArray();
                //dt.Rows.Add(Fila);
                DataRow row = dt.NewRow();
                for (int j = 1; j <= ws.Dimension.End.Column; j = j + 1)
                    row[j - 1] = ws.Cells[i, j].Value.ToString();
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            xlPackage.Dispose();

            return ds;
        }

    }
}
