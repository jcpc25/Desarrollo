using COES.Dominio.DTO.Sic;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace COES.MVC.Intranet.Areas.SupervisionPlanificacion.Helpers
{
    public class RpdHelper
    {
        /// <summary>
        /// Permite obtener la configuracion del RPF
        /// </summary>
        //ConfiguracionRPD configuracion = new ConfiguracionRPD();

        /// <summary>
        /// Lee los artículos desde el formato excel cargado
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public List<DesviacionDTO> LeerDesdeFormato(string file)
        {
            try
            {
                List<DesviacionDTO> list = new List<DesviacionDTO>();

                int cantidad = 60;
                //Debug.WriteLine("LeerFormato");
                FileInfo fileInfo = new FileInfo(file);

                using (ExcelPackage xlPackage = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet ws = xlPackage.Workbook.Worksheets["DESV-SUB-SOB"];

                    for (int i = 6; i <= cantidad; i++)
                    {

                        for (int j = 1; j <= 3; j++)
                        {
                            if (ws.Cells[i, j * 4 + 1].Value != null && ws.Cells[i, j * 4 + 1].Value != string.Empty)
                            {
                                DesviacionDTO item = new DesviacionDTO();

                                item.Lectcodi = 4;
                                item.Medorigdesv = (ws.Cells[i, j * 4 + 1] != null) ? int.Parse(ws.Cells[i, j * 4 + 1].ToString()) : 0;
                                item.Desvfecha = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                item.Ptomedicodi = int.Parse(ws.Cells[i, j * 4 + 4].ToString());

                                list.Add(item);
                            }
                            else
                            {

                                //break;

                            }

                        }


                    }




                }
                //Debug.WriteLine("Fin leer");
                return list;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Error" + ex.ToString());
                throw new Exception(ex.Message, ex);
            }
        }
    }
}