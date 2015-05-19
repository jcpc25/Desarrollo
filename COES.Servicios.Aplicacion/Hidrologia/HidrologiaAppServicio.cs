using System;
using System.Linq;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;
using System.Globalization;
using System.Text;

namespace COES.Servicios.Aplicacion.Hidrologia
{
    /// <summary>
    /// Clases con métodos del módulo Hidrologia
    /// </summary>
    public class HidrologiaAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HidrologiaAppServicio));

        #region Métodos Tabla ME_ORIGENLECTURA

        /// <summary>
        /// Inserta un registro de la tabla ME_ORIGENLECTURA
        /// </summary>
        public void SaveMeOrigenlectura(MeOrigenlecturaDTO entity)
        {
            try
            {
                FactorySic.GetMeOrigenlecturaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_ORIGENLECTURA
        /// </summary>
        public void UpdateMeOrigenlectura(MeOrigenlecturaDTO entity)
        {
            try
            {
                FactorySic.GetMeOrigenlecturaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_ORIGENLECTURA
        /// </summary>
        public void DeleteMeOrigenlectura(int origlectcodi)
        {
            try
            {
                FactorySic.GetMeOrigenlecturaRepository().Delete(origlectcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_ORIGENLECTURA
        /// </summary>
        public MeOrigenlecturaDTO GetByIdMeOrigenlectura(int origlectcodi)
        {
            return FactorySic.GetMeOrigenlecturaRepository().GetById(origlectcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_ORIGENLECTURA
        /// </summary>
        public List<MeOrigenlecturaDTO> ListMeOrigenlecturas()
        {
            return FactorySic.GetMeOrigenlecturaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeOrigenlectura
        /// </summary>
        public List<MeOrigenlecturaDTO> GetByCriteriaMeOrigenlecturas()
        {
            return FactorySic.GetMeOrigenlecturaRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla ME_LECTURA

        /// <summary>
        /// Inserta un registro de la tabla ME_LECTURA
        /// </summary>
        public void SaveMeLectura(MeLecturaDTO entity)
        {
            try
            {
                FactorySic.GetMeLecturaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_LECTURA
        /// </summary>
        public void UpdateMeLectura(MeLecturaDTO entity)
        {
            try
            {
                FactorySic.GetMeLecturaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_LECTURA
        /// </summary>
        public void DeleteMeLectura(int lectcodi)
        {
            try
            {
                FactorySic.GetMeLecturaRepository().Delete(lectcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_LECTURA
        /// </summary>
        public MeLecturaDTO GetByIdMeLectura(int lectcodi)
        {
            return FactorySic.GetMeLecturaRepository().GetById(lectcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_LECTURA
        /// </summary>
        public List<MeLecturaDTO> ListMeLecturas()
        {
            return FactorySic.GetMeLecturaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeLectura
        /// </summary>
        public List<MeLecturaDTO> GetByCriteriaMeLecturas()
        {
            return FactorySic.GetMeLecturaRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla SI_TIPOINFORMACION

        /// <summary>
        /// Inserta un registro de la tabla SI_TIPOINFORMACION
        /// </summary>
        public void SaveSiTipoinformacion(SiTipoinformacionDTO entity)
        {
            try
            {
                FactorySic.GetSiTipoinformacionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla SI_TIPOINFORMACION
        /// </summary>
        public void UpdateSiTipoinformacion(SiTipoinformacionDTO entity)
        {
            try
            {
                FactorySic.GetSiTipoinformacionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla SI_TIPOINFORMACION
        /// </summary>
        public void DeleteSiTipoinformacion(int tipoinfocodi)
        {
            try
            {
                FactorySic.GetSiTipoinformacionRepository().Delete(tipoinfocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla SI_TIPOINFORMACION
        /// </summary>
        public SiTipoinformacionDTO GetByIdSiTipoinformacion(int tipoinfocodi)
        {
            return FactorySic.GetSiTipoinformacionRepository().GetById(tipoinfocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla SI_TIPOINFORMACION
        /// </summary>
        public List<SiTipoinformacionDTO> ListSiTipoinformacions()
        {
            return FactorySic.GetSiTipoinformacionRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla SiTipoinformacion
        /// </summary>
        public List<SiTipoinformacionDTO> GetByCriteriaSiTipoinformacions()
        {
            return FactorySic.GetSiTipoinformacionRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla SI_EMPRESA
        /// <summary>
        /// Permite listar las empresas
        /// </summary>
        /// <returns></returns>
        public List<EmpresaDTO> ListarEmpresas()
        {
            return FactorySic.ObtenerEventoDao().ListarEmpresas();
        }

        public List<SiEmpresaDTO> ObtenerEmpresasPorUsuario(string userlogin)
        {
            return FactorySic.GetSiEmpresaRepository().GetByUser(userlogin);
        }

        public List<SiEmpresaDTO> ObtenerEmpresasSEIN()
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasSEIN();
        }

        public List<SiEmpresaDTO> ListarEmpresasPorTipo(string tiposEmpresa)
        {
            return FactorySic.GetSiEmpresaRepository().GetByCriteria(tiposEmpresa);
        }

        #endregion

        #region Métodos Tabla EQ_equipo

        public List<EqEquipoDTO> GetByCriteriaEqequipo(int emprcodi,int famcodi)
        {
            return FactorySic.GetEqEquipoRepository().GetByEmprFam(emprcodi, famcodi);
        }

        public EqEquipoDTO GetByIdEqequipo(int equicodi)
        {
            EqEquipoDTO equipo = new EqEquipoDTO();
            equipo = FactorySic.GetEqEquipoRepository().GetById(equicodi);
            return equipo;
        }

        public List<EqEquipoDTO> ListarEquiposXFamilia(int idFamilia)
        { 
            List<int> idsFamilia = new List<int>();
            idsFamilia.Add(idFamilia);
            return FactorySic.GetEqEquipoRepository().ListarEquipoxFamilias(idsFamilia.ToArray());
        }

        public List<EqEquipoDTO> ListarRecursosxCuenca(int idEquipo)
        {
            return FactorySic.GetEqEquipoRepository().ListaRecursosxCuenca(idEquipo);
        }
        #endregion

        #region Métodos Tabla Me_PuntosdeMedicion

        public List<MePtomedicionDTO> ListarPtoMedicion(string empresas, string idsOriglectura, string idsTipoptomedicion)
        {
            if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsOriglectura)) idsOriglectura = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsTipoptomedicion)) idsTipoptomedicion = Constantes.ParametroDefecto;
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            try
            {
                entitys = FactorySic.GetMePtomedicionRepository().GetByCriteria(empresas, idsOriglectura, idsTipoptomedicion);
            }
            catch (Exception ex)
            {
                var result = ex.Message;
            }
            return entitys;
        }

        public List<MePtomedicionDTO> ListarDetallePtoMedicion(string empresas, string idsOriglectura, string idsTipoptomedicion, int nroPaginas, int pageSize)
        {
            if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsOriglectura)) idsOriglectura = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsTipoptomedicion)) idsTipoptomedicion = Constantes.ParametroDefecto;
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            try
            {
                entitys = FactorySic.GetMePtomedicionRepository().ListarDetallePtoMedicionFiltro(empresas, idsOriglectura, idsTipoptomedicion, nroPaginas, pageSize);
            }
            catch (Exception ex)
            {
                var result = ex.Message;
            }
            return entitys;
        }

        public void SavePtoMedicion(MePtomedicionDTO ptoMedicion, FwCounterDTO counter)
        {
            try
            {
                FactorySic.GetMePtomedicionRepository().Save(ptoMedicion);
                UpdateFwCounter(counter);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public MePtomedicionDTO GetByIdMePtomedicion(int ptomedicodi)
        {
            return FactorySic.GetMePtomedicionRepository().GetById(ptomedicodi);
        }

        public void UpdatePtoMedicion(MePtomedicionDTO entity)
        {
            try
            {
                FactorySic.GetMePtomedicionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MePtomedicionDTO> GetByIdEquipoMePtomedicion(int equipo)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            try
            {
                entitys = FactorySic.GetMePtomedicionRepository().GetByIdEquipo(equipo);
            }
            catch (Exception ex)
            {
                var result = ex.Message;
            }
            return entitys;            
        }

        public List<MePtomedicionDTO> ListarPtoMedicionDuplicados(int equipo, int origen, int tipopto)
        {
            List<MePtomedicionDTO> entitys = new List<MePtomedicionDTO>();
            try
            {
                entitys = FactorySic.GetMePtomedicionRepository().ListarPtoDuplicado(equipo, origen, tipopto);
            }
            catch (Exception ex)
            {
                var result = ex.Message;
            }
            return entitys;             
        }

        /// <summary>
        /// permite contar la cantidad de untos de medicion
        /// </summary>       
        public int GetTotalPtomedicion(string empresas, string idsOriglectura, string idsTipoptomedicion)
        {
            return FactorySic.GetMePtomedicionRepository().ObtenerTotalPtomedicion(empresas, idsOriglectura, idsTipoptomedicion);
        }

        #endregion

        #region Métodos Tabla ME_MEDICION96

        public void SaveMeMedicion96(MeMedicion96DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion96Repository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        ///  Actualiza la columna total 
        /// </summary>
        public void ActualizarListaEnvio96(List<MeMedicion96DTO> listaMedicion)
        {
            decimal totalDia = 0;
            decimal valorH = 0;
            try
            {
                for (var i = 0; i < listaMedicion.Count; i++)
                {
                    totalDia = 0;
                    //listaMedicion[i].ENVIOCODI = codigoEnvio;
                    for (var j = 1; j <= 96; j++)
                    {
                        valorH = (decimal)listaMedicion[i].GetType().GetProperty("H" + j.ToString()).GetValue(listaMedicion[i], null);
                        totalDia += valorH;
                    }
                    listaMedicion[i].Meditotal = totalDia;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Permite eliminar los valores previos cargados
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void EliminarValoresCargados96(int idLectura,int idFormato,int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                FactorySic.GetMeMedicion96Repository().DeleteEnvioArchivo(idLectura, fechaInicio, fechaFin, idFormato, idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite grabar los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        public void GrabarValoresCargados96(List<MeMedicion96DTO> entitys)
        {
            try
            {
                foreach (MeMedicion96DTO entity in entitys)
                {
                    FactorySic.GetMeMedicion96Repository().Save(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// Permite obtener el reporte  html de los datos cargados por el agente
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public string ObtenerResumenCargaDatos(int idEmpresa, DateTime fechaInicio, DateTime fechaFin, MeFormatoDTO formato,List<MeHojaptomedDTO> puntos,List<MeHeadcolumnDTO> cabeceras)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            List<Object> listaGenerica = new List<Object>();
            switch (formato.Formatresolucion)
            {
                case 60 * 24:
                    List<MeMedicion1DTO> lista1 = FactorySic.GetMeMedicion1Repository().GetEnvioArchivo(formato.Formatcodi, idEmpresa, fechaInicio, fechaFin);
                    foreach (var reg in lista1)
                    {
                        listaGenerica.Add(reg);
                    }
                    break;

                case 60:
                    List<MeMedicion24DTO> lista24 = FactorySic.GetMeMedicion24Repository().GetEnvioArchivo(formato.Formatcodi, idEmpresa, fechaInicio, fechaFin);
                    foreach (var reg in lista24)
                    {
                        listaGenerica.Add(reg);
                    }
                    break;
                case 30:
                    List<MeMedicion48DTO> lista48 = FactorySic.GetMeMedicion48Repository().GetEnvioArchivo(formato.Formatcodi, idEmpresa, fechaInicio, fechaFin);
                    foreach (var reg in lista48)
                    {
                        listaGenerica.Add(reg);
                    }
                    break;
                case 15:
                    List<MeMedicion96DTO> lista96 = FactorySic.GetMeMedicion96Repository().GetEnvioArchivo(formato.Formatcodi, idEmpresa, fechaInicio, fechaFin);
                    foreach (var reg in lista96)
                    {
                        listaGenerica.Add(reg);
                    }
                    break;
            }
            StringBuilder strHtml = new StringBuilder();

            strHtml.Append("<table border='1' class='pretty tabla-adicional cell-border' cellspacing='0' width='100%' id='tabla'>");
            strHtml.Append("<thead>");
            strHtml.Append("<tr><th></th>");
            foreach(var reg in cabeceras)
                strHtml.Append("<th colspan='" + reg.Headlen + "'>" + reg.Headnombre +"</th>");
            strHtml.Append("</tr>");
            strHtml.Append("<tr>");
            strHtml.Append("<th>FECHA HORA</th>");
            foreach(var reg in puntos)
                strHtml.Append("<th>" + reg.Tipoptomedinomb + " (" + reg.Tipoinfoabrev + ")" + "</th>");
            strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            int horizonte = formato.Formathorizonte * 60 * 24;
            int resolucion = (int)formato.Formatresolucion;
            int nBloques = 60 * 24 / resolucion;
            if (formato.Formatresolucion == 60 * 24)
                fechaInicio = fechaInicio.AddDays(-1);
            if (listaGenerica.Count > 0)
            {
                for (int i = 0; i < formato.Formathorizonte;i++ )
                    for (int k = 1; k <= nBloques; k++)
                    {
                        var fechaMin = ((fechaInicio.AddMinutes(k * resolucion + i * 60*24))).ToString(ConstantesBase.FormatoFechaHora);
                        strHtml.Append("<tr>");
                        strHtml.Append(string.Format("<td>{0}</td>", fechaMin));
                        foreach (var p in listaGenerica)
                        {
                            decimal valor = (decimal)p.GetType().GetProperty("H" + k).GetValue(p, null);

                            strHtml.Append(string.Format("<td>{0}</td>", valor.ToString("N", nfi)));
                        }

                        strHtml.Append("</tr>");
                    }

            }
            else
            {
                strHtml.Append("<td  style='text-align:center'>No existen registros.</td>");
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");

            return strHtml.ToString();
        }

/// <summary>
/// Obtiene Reporte en codigo HTLM de Historico de Hidrologia
/// </summary>
/// <param name="idsEmpresa"></param>
/// <param name="fechaInicio"></param>
/// <param name="fechaFin"></param>
/// <param name="formato"></param>
/// <returns></returns>
        public string ObtenerReporteHidrologia(string idsEmpresa, string idsCuenca, DateTime fechaInicio, DateTime fechaFin, MeFormatoDTO formato)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            string strHtml= string.Empty;
            if (string.IsNullOrEmpty(idsEmpresa)) idsEmpresa = Constantes.ParametroNoExiste;
            List<Object> listaGenerica = new List<Object>();
            switch (formato.Formatresolucion)
            {
                case 60 * 24 * 30: //rpte MES
                    List<MeMedicion1DTO> listaMes = FactorySic.GetMeMedicion1Repository().GetHidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, fechaInicio, fechaFin);
                    List<MeMedicion1DTO> listaCabecera = listaMes.GroupBy(x => new {x.Ptomedicodi, x.Ptomedinomb,x.Tipoinfoabrev})
                        .Select(y => new MeMedicion1DTO()
                        {
                            Ptomedicodi = y.Key.Ptomedicodi,
                            Ptomedinomb = y.Key.Ptomedinomb,
                            Tipoinfoabrev = y.Key.Tipoinfoabrev
                        }
                        ).ToList();
                    strHtml = GeneraViewHidromensual(listaMes, listaCabecera, formato, fechaInicio, fechaFin);
                    break;

                case 60 * 24: // semanal (lectcodi = 12)
                    
                    List<MeMedicion1DTO> lista1 = FactorySic.GetMeMedicion1Repository().GetHidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, fechaInicio, fechaFin);
                    List<MeMedicion1DTO> listaCabecera1 = lista1.GroupBy(x => new { x.Ptomedicodi, x.Ptomedinomb, x.Tipoinfoabrev })
                     .Select(y => new MeMedicion1DTO()
                     {
                         Ptomedicodi = y.Key.Ptomedicodi,
                         Ptomedinomb = y.Key.Ptomedinomb,
                         Tipoinfoabrev = y.Key.Tipoinfoabrev
                     }
                     ).ToList();
                    strHtml = GeneraViewHidroSemanal(lista1,listaCabecera1, formato, fechaInicio, fechaFin);
                    break;

                case 60: //Rpte Diario (lectcodi=63)
                    List<MeMedicion24DTO> lista24 = FactorySic.GetMeMedicion24Repository().GetHidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, idsCuenca, fechaInicio, fechaFin);
                    foreach (var reg in lista24)
                    {
                        listaGenerica.Add(reg);
                    }
                    strHtml = GeneraViewHidrologia(listaGenerica, formato, fechaInicio);
                    break;
                case 30: // Rpte 1/2 horas
                    List<MeMedicion48DTO> lista48 = FactorySic.GetMeMedicion48Repository().GetHidrologia((int)formato.ListaHoja[0].Lectcodi, 5,idsEmpresa,idsCuenca, fechaInicio, fechaFin);
                    foreach (var reg in lista48)
                    {
                        listaGenerica.Add(reg);
                    }
                    strHtml = GeneraViewHidrologia(listaGenerica, formato, fechaInicio);
                    break;
                case 15: // Rpte 15 minnutos
                    List<MeMedicion96DTO> lista96 = FactorySic.GetMeMedicion96Repository().GetHidrologia((int)formato.ListaHoja[0].Lectcodi, 5, idsEmpresa, fechaInicio, fechaFin);
                    foreach (var reg in lista96)
                    {
                        listaGenerica.Add(reg);
                    }
                    strHtml = GeneraViewHidrologia(listaGenerica, formato, fechaInicio);
                    break;
            }
            

            return strHtml;
        }


        public string GeneraViewHidrologia(List<Object> listaGenerica, MeFormatoDTO formato, DateTime fechaInicio)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<table border='1' style='width:auto' class='pretty tabla-adicional ' cellspacing='0' width='100%' id='tabla'>");
            strHtml.Append("<thead>");


            strHtml.Append("<tr><th style='width:160px;'>RECURSO</th>");
            foreach (var p in listaGenerica)
            {
                string valor = (string)p.GetType().GetProperty("Equinomb").GetValue(p, null);
                strHtml.Append("<th style='width:100px;'>" + valor + "</th>");
            }
            strHtml.Append("</tr>");

            strHtml.Append("<tr><td rowspan='2' style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>FECHA</td>");
            foreach (var p in listaGenerica)
            {
                string valor3 = (string)p.GetType().GetProperty("Tipoptomedinomb").GetValue(p, null);
                strHtml.Append("<td colspan='" + 1 + "' style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>" + valor3 + "</td>");
            }
            strHtml.Append("</tr>");

            foreach (var p in listaGenerica)
            {
                string valor = (string)p.GetType().GetProperty("Tipoinfoabrev").GetValue(p, null);
                strHtml.Append("<td style='background-color:#87CEFA;border:1px solid #9AC9E9;text-align: center'>" + valor + "</td>");
            }
            strHtml.Append("</tr>");

            //strHtml.Append("<tr>");
            //strHtml.Append("<th>FECHA HORA</th>");
            //foreach (var reg in puntos)
            //    strHtml.Append("<th>" + reg.Tipoptomedinomb + " (" + reg.Tipoinfoabrev + ")" + "</th>");
            //strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            int horizonte = formato.Formathorizonte * 60 * 24;
            int resolucion = (int)formato.Formatresolucion;
            int nBloques = 60 * 24 / resolucion;
            if (formato.Formatresolucion == 60 * 24)
                fechaInicio = fechaInicio.AddDays(-1);
            if (listaGenerica.Count > 0)
            {
                for (int i = 0; i < formato.Formathorizonte; i++)
                    for (int k = 1; k <= nBloques; k++)
                    {
                        var fechaMin = ((fechaInicio.AddMinutes(k * resolucion + i * 60 * 24))).ToString(ConstantesBase.FormatoFechaHora);
                        strHtml.Append("<tr>");
                        strHtml.Append(string.Format("<td>{0}</td>", fechaMin));
                        foreach (var p in listaGenerica)
                        {
                            decimal valor = (decimal)p.GetType().GetProperty("H" + k).GetValue(p, null);

                            strHtml.Append(string.Format("<td>{0}</td>", valor.ToString("N", nfi)));
                        }

                        strHtml.Append("</tr>");
                    }

            }
            else
            {
                strHtml.Append("<td  style='text-align:center'>No existen registros.</td>");
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");


            return strHtml.ToString();
        }

        public string GeneraViewHidromensual(List<MeMedicion1DTO> listaGenerica,List<MeMedicion1DTO> listaCabecera, MeFormatoDTO formato, DateTime fechaInicio,DateTime fechaFin)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<table border='1' style='width:auto' class='pretty tabla-adicional ' cellspacing='0' width='100%' id='tabla'>");
            strHtml.Append("<thead>");

            strHtml.Append("<tr><th  style='width:160px;'>AFLUENTES</th>");

            foreach (var p in listaCabecera)
            {
                strHtml.Append("<th style='width:100px;'>" + p.Ptomedinomb + "</th>");
            }
            strHtml.Append("</tr>");

            strHtml.Append("<tr><td  style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>AÑO - MES</td>");
            //strHtml.Append("<td style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>MESES</td>");
            foreach (var p in listaCabecera)
            {
                strHtml.Append("<td style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>" + p.Tipoinfoabrev + "</td>");
            }
            strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            if (formato.Formatresolucion == 60 * 24)
                fechaInicio = fechaInicio.AddDays(-1);
            if (listaGenerica.Count > 0)
            {
                //for (var f = fechaInicio; f <= fechaFin; f = f.AddMonths(1))
                var f = fechaInicio;
                foreach (var lst in listaGenerica)
                {
                    
                    strHtml.Append("<tr>");
                    var anho = f.Year.ToString();
                    var mes = f.Month;
                    strHtml.Append(string.Format("<td>{0} &nbsp;&nbsp;{1}</td>", anho, COES.Base.Tools.Util.ObtenerNombreMes(mes)));
                    foreach (var p in listaCabecera)
                    {
                        var reg = listaGenerica.Find(x => x.Medifecha == f && x.Ptomedicodi == p.Ptomedicodi);
                        if (reg != null)
                        {
                            decimal valor = (decimal)reg.H1;
                            strHtml.Append(string.Format("<td>{0}</td>", valor.ToString("N", nfi)));
                        }
                        else
                            strHtml.Append("<td></td>");
                    }
                    strHtml.Append("</tr>");
                    f = f.AddMonths(1);
                }
            }
            else
            {
                strHtml.Append("<td  style='text-align:center'>No existen registros.</td>");
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");          
            return strHtml.ToString();
        }

        public string GeneraViewHidroSemanal(List<MeMedicion1DTO> listaGenerica, List<MeMedicion1DTO> listaCabecera, MeFormatoDTO formato, DateTime fechaInicio, DateTime fechaFin)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<table border='1' style='width:auto' class='pretty tabla-adicional ' cellspacing='0' width='100%' id='tabla'>");
            strHtml.Append("<thead>");

            strHtml.Append("<tr><th colspan ='2' style='width:160px;'>AFLUENTES</th>");

            foreach (var p in listaCabecera)
            {
                strHtml.Append("<th style='width:100px;'>" + p.Ptomedinomb + "</th>");
            }
            strHtml.Append("</tr>");

            strHtml.Append("<tr><td  style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>AÑO</td>");
            strHtml.Append("<td style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>Semana</td>");
            foreach (var p in listaCabecera)
            {
                strHtml.Append("<td style='background-color:#2980B9;border:1px solid #9AC9E9;color:#87CEEB;text-align: center'>" + p.Tipoinfoabrev + "</td>");
            }
            strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            if (formato.Formatresolucion == 60 * 24)
                fechaInicio = fechaInicio.AddDays(-1);
            if (listaGenerica.Count > 0)
            {
                //for (var f = fechaInicio; f <= fechaFin; f = f.AddMonths(1))
                var f = fechaInicio;
                int i = 1;
                var anho = "2001";
                foreach (var lst in listaGenerica)
                {

                    strHtml.Append("<tr>");
                    var anho1 = f.Year.ToString();
                    if (anho1 != anho)
                    {
                        strHtml.Append(string.Format("<td>{0}</td>", anho1));
                        anho = anho1;
                        i = 1;
                    }
                    strHtml.Append(string.Format("<td>{0}</td>", i));
                    foreach (var p in listaCabecera)
                    {
                        var reg = listaGenerica.Find(x => x.Medifecha == f && x.Ptomedicodi == p.Ptomedicodi);
                        if (reg != null)
                        {
                            decimal valor = (decimal)reg.H1;
                           
                            strHtml.Append(string.Format("<td>{0}</td>", valor.ToString("N", nfi)));                       
                        }
                        else
                            strHtml.Append("<td></td>");
                    }
                    strHtml.Append("</tr>");
                    i++;
                    f = f.AddDays(7);
                }
            }
            else
            {
                strHtml.Append("<td  style='text-align:center'>No existen registros.</td>");
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");
            return strHtml.ToString();
        }

        #endregion

        #region Metodos Tabla ME_MEDICION48
        /// <summary>
        /// Inserta un registro de la tabla ME_MEDICION48
        /// </summary>
        public void SaveMeMedicion48(MeMedicion48DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion48Repository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite eliminar los valores previos cargados
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void EliminarValoresCargados48(int idLectura, int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                FactorySic.GetMeMedicion48Repository().DeleteEnvioArchivo(idLectura, fechaInicio, fechaFin, idFormato, idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite grabar los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        public void GrabarValoresCargados48(List<MeMedicion48DTO> entitys)
        {
            try
            {
                foreach (MeMedicion48DTO entity in entitys)
                {
                    FactorySic.GetMeMedicion48Repository().Save(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region Métodos Tabla ME_MEDICION24

        /// <summary>
        /// Inserta un registro de la tabla ME_MEDICION24
        /// </summary>
        public void SaveMeMedicion24(MeMedicion24DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion24Repository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_MEDICION24
        /// </summary>
        public void UpdateMeMedicion24(MeMedicion24DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion24Repository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_MEDICION24
        /// </summary>
        public void DeleteMeMedicion24()
        {
            try
            {
                FactorySic.GetMeMedicion24Repository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_MEDICION24
        /// </summary>
        public MeMedicion24DTO GetByIdMeMedicion24()
        {
            return FactorySic.GetMeMedicion24Repository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_MEDICION24
        /// </summary>
        public List<MeMedicion24DTO> ListMeMedicion24s()
        {
            return FactorySic.GetMeMedicion24Repository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeMedicion24
        /// </summary>
        public List<MeMedicion24DTO> GetByCriteriaMeMedicion24s()
        {
            return FactorySic.GetMeMedicion24Repository().GetByCriteria();
        }

        /// <summary>
        /// Permite eliminar los valores previos cargados
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void EliminarValoresCargados24(int idLectura, int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                FactorySic.GetMeMedicion24Repository().DeleteEnvioArchivo(idLectura, fechaInicio, fechaFin, idFormato, idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite grabar los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        public void GrabarValoresCargados24(List<MeMedicion24DTO> entitys)
        {
            try
            {
                foreach (MeMedicion24DTO entity in entitys)
                {
                    FactorySic.GetMeMedicion24Repository().Save(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region Métodos Tabla ME_MEDICION1

        /// <summary>
        /// Inserta un registro de la tabla ME_MEDICION1
        /// </summary>
        public void SaveMeMedicion1(MeMedicion1DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion1Repository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_MEDICION1
        /// </summary>
        public void UpdateMeMedicion1(MeMedicion1DTO entity)
        {
            try
            {
                FactorySic.GetMeMedicion1Repository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_MEDICION1
        /// </summary>
        public void DeleteMeMedicion1(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi)
        {
            try
            {
                FactorySic.GetMeMedicion1Repository().Delete(lectcodi, medifecha, tipoinfocodi, ptomedicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_MEDICION1
        /// </summary>
        public MeMedicion1DTO GetByIdMeMedicion1(int lectcodi, DateTime medifecha, int tipoinfocodi, int ptomedicodi)
        {
            return FactorySic.GetMeMedicion1Repository().GetById(lectcodi, medifecha, tipoinfocodi, ptomedicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_MEDICION1
        /// </summary>
        public List<MeMedicion1DTO> ListMeMedicion1s()
        {
            return FactorySic.GetMeMedicion1Repository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeMedicion1
        /// </summary>
        public List<MeMedicion1DTO> GetByCriteriaMeMedicion1s()
        {
            return FactorySic.GetMeMedicion1Repository().GetByCriteria();
        }

        /// <summary>
        /// Permite eliminar los valores previos cargados
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void EliminarValoresCargados1(int idLectura, int idFormato, int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                FactorySic.GetMeMedicion1Repository().DeleteEnvioArchivo(idLectura, fechaInicio, fechaFin, idFormato, idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite grabar los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        public void GrabarValoresCargados1(List<MeMedicion1DTO> entitys)
        {
            try
            {
                foreach (MeMedicion1DTO entity in entitys)
                {
                    FactorySic.GetMeMedicion1Repository().Save(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region Métodos Tabla ME_TIPOPUNTOMEDICION

        /// <summary>
        /// Inserta un registro de la tabla ME_TIPOPUNTOMEDICION
        /// </summary>
        public void SaveMeTipopuntomedicion(MeTipopuntomedicionDTO entity)
        {
            try
            {
                FactorySic.GetMeTipopuntomedicionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_TIPOPUNTOMEDICION
        /// </summary>
        public void UpdateMeTipopuntomedicion(MeTipopuntomedicionDTO entity)
        {
            try
            {
                FactorySic.GetMeTipopuntomedicionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_TIPOPUNTOMEDICION
        /// </summary>
        public void DeleteMeTipopuntomedicion(int tipoptomedicodi)
        {
            try
            {
                FactorySic.GetMeTipopuntomedicionRepository().Delete(tipoptomedicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_TIPOPUNTOMEDICION
        /// </summary>
        public MeTipopuntomedicionDTO GetByIdMeTipopuntomedicion(int tipoptomedicodi)
        {
            return FactorySic.GetMeTipopuntomedicionRepository().GetById(tipoptomedicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_TIPOPUNTOMEDICION
        /// </summary>
        public List<MeTipopuntomedicionDTO> ListMeTipopuntomedicions(string origlectcodi)
        {
            if (string.IsNullOrEmpty(origlectcodi)) origlectcodi = Constantes.ParametroDefecto;
            return FactorySic.GetMeTipopuntomedicionRepository().List(origlectcodi);
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeTipopuntomedicion
        /// </summary>
        public List<MeTipopuntomedicionDTO> GetByCriteriaMeTipopuntomedicions()
        {
            List<MeTipopuntomedicionDTO> entitys = new List<MeTipopuntomedicionDTO>();
            try
            {
                entitys = FactorySic.GetMeTipopuntomedicionRepository().GetByCriteria();
            }
            catch (Exception ex)
            {
                var result = ex.Message;
            }
            return entitys;
        }

        #endregion

        #region Métodos Tabla Familia

        public List<EqFamiliaDTO> ListarFamilia()
        {
            return FactorySic.GetEqFamiliaRepository().List();
        }

        #endregion

        #region Métodos Tabla Fw_counter

        public void UpdateFwCounter(FwCounterDTO entity)
        {
            try
            {
                FactorySic.GetFwCounterRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla FW_COUNTER
        /// </summary>
        public FwCounterDTO GetByIdFwCounter(string tablename)
        {
            return FactorySic.GetFwCounterRepository().GetById(tablename);
        }

        #endregion

        #region Métodos Tabla ME_FORMATO

        /// <summary>
        /// Inserta un registro de la tabla ME_FORMATO
        /// </summary>
        public int SaveMeFormato(MeFormatoDTO entity)
        {
            int id = 0;
            try
            {
                id = FactorySic.GetMeFormatoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
            return id;
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_FORMATO
        /// </summary>
        public void UpdateMeFormato(MeFormatoDTO entity)
        {
            try
            {
                FactorySic.GetMeFormatoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_FORMATO
        /// </summary>
        public void DeleteMeFormato(int formatcodi)
        {
            try
            {
                FactorySic.GetMeFormatoRepository().Delete(formatcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_FORMATO
        /// </summary>
        public MeFormatoDTO GetByIdMeFormato(int formatcodi)
        {
            return FactorySic.GetMeFormatoRepository().GetById(formatcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_FORMATO
        /// </summary>
        public List<MeFormatoDTO> ListMeFormatos()
        {
            return FactorySic.GetMeFormatoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeFormato
        /// </summary>
        public List<MeFormatoDTO> GetByCriteriaMeFormatos(int areaUsuario)
        {
            return FactorySic.GetMeFormatoRepository().GetByCriteria(areaUsuario);
        }

        #endregion

        #region Métodos Tabla ME_FORMATOHOJA

        /// <summary>
        /// Inserta un registro de la tabla ME_FORMATOHOJA
        /// </summary>
        public void SaveMeFormatohoja(MeFormatohojaDTO entity)
        {
            try
            {
                FactorySic.GetMeFormatohojaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_FORMATOHOJA
        /// </summary>
        public void UpdateMeFormatohoja(MeFormatohojaDTO entity)
        {
            try
            {
                FactorySic.GetMeFormatohojaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_FORMATOHOJA
        /// </summary>
        public void DeleteMeFormatohoja(int hojanumero, int formatcodi)
        {
            try
            {
                FactorySic.GetMeFormatohojaRepository().Delete(hojanumero, formatcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_FORMATOHOJA
        /// </summary>
        public MeFormatohojaDTO GetByIdMeFormatohoja(int hojanumero, int formatcodi)
        {
            return FactorySic.GetMeFormatohojaRepository().GetById(hojanumero, formatcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_FORMATOHOJA
        /// </summary>
        public List<MeFormatohojaDTO> ListMeFormatohojas()
        {
            return FactorySic.GetMeFormatohojaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeFormatohoja
        /// </summary>
        public List<MeFormatohojaDTO> GetByCriteriaMeFormatohojas(int formatcodi)
        {
            return FactorySic.GetMeFormatohojaRepository().GetByCriteria(formatcodi);
        }

        #endregion

        #region Métodos Tabla ME_HOJAPTOMED

        /// <summary>
        /// Inserta un registro de la tabla ME_HOJAPTOMED
        /// </summary>
        public void SaveMeHojaptomed(MeHojaptomedDTO entity,int empresa)
        {
            try
            {
                FactorySic.GetMeHojaptomedRepository().Save(entity,empresa);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Graba un punto de medicion en el formato y devuelve el registro grabado
        /// </summary>
        /// <param name="entity"></param>
        public MeHojaptomedDTO GrabarHojaPtoMedicion(MeHojaptomedDTO entity,int empresa)
        {
            SaveMeHojaptomed(entity,empresa);
            return GetByIdMeHojaptomed(entity.Hojanumero, entity.Formatcodi, entity.Tipoinfocodi, entity.Ptomedicodi, entity.Hojaptosigno);
        }
        /// <summary>
        /// Actualiza un registro de la tabla ME_HOJAPTOMED
        /// </summary>
        public void UpdateMeHojaptomed(MeHojaptomedDTO entity)
        {
            try
            {
                FactorySic.GetMeHojaptomedRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_HOJAPTOMED
        /// </summary>
        public void DeleteMeHojaptomed(int hojanumero, int formatcodi, int ptomedicodi)
        {
            try
            {
                FactorySic.GetMeHojaptomedRepository().Delete(hojanumero, formatcodi,1, ptomedicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_HOJAPTOMED
        /// </summary>
        public MeHojaptomedDTO GetByIdMeHojaptomed(int hojanumero, int formatcodi, int tipoinfocodi ,int ptomedicodi, int hojaptosigno)
        {
            return FactorySic.GetMeHojaptomedRepository().GetById(hojanumero, formatcodi, tipoinfocodi,ptomedicodi, hojaptosigno);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_HOJAPTOMED
        /// </summary>
        public List<MeHojaptomedDTO> ListMeHojaptomeds()
        {
            return FactorySic.GetMeHojaptomedRepository().List();
        }

        /// <summary>
        /// Permite listar los puntos de medicion la tabla MeHojaptomed
        /// </summary>
        public List<MeHojaptomedDTO> GetByCriteriaMeHojaptomeds(int emprcodi,int formatcodi,int hojacodi)
        {
            return FactorySic.GetMeHojaptomedRepository().GetByCriteria(emprcodi,formatcodi,hojacodi);
        }

        /// <summary>
        /// Cambia el orden de dos puntos de medicion en una hoja de formato.
        /// </summary>
        /// <param name="formato"></param>
        /// <param name="hoja"></param>
        /// <param name="empresa"></param>
        /// <param name="fromPosition"></param>
        /// <param name="toPosition"></param>
        public int CambiarOrdenPto(int formato, int hoja, int empresa, int fromPosition, int toPosition)
        {
            int resultado = 1;
            try
            {
                var listahoja = GetByCriteriaMeHojaptomeds(empresa, formato, hoja);
                var entity = listahoja.Where(x => x.Hojaptoorden == fromPosition).FirstOrDefault();
                entity.Hojaptoorden = 0;
                UpdateMeHojaptomed(entity);
                entity = listahoja.Where(x => x.Hojaptoorden == toPosition).FirstOrDefault();
                entity.Hojaptoorden = fromPosition;
                UpdateMeHojaptomed(entity);
                entity = listahoja.Where(x => x.Hojaptoorden == 0).FirstOrDefault();
                entity.Hojaptoorden = toPosition;
                UpdateMeHojaptomed(entity);
            }
            catch 
            { 
            resultado = -1;
            }
            return resultado;
        }

        #endregion

        #region Métodos Tabla ME_HEADCOLUMN

        /// <summary>
        /// Inserta un registro de la tabla ME_HEADCOLUMN
        /// </summary>
        public void SaveMeHeadcolumn(MeHeadcolumnDTO entity)
        {
            try
            {
                FactorySic.GetMeHeadcolumnRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_HEADCOLUMN
        /// </summary>
        public void UpdateMeHeadcolumn(MeHeadcolumnDTO entity)
        {
            try
            {
                FactorySic.GetMeHeadcolumnRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_HEADCOLUMN
        /// </summary>
        public void DeleteMeHeadcolumn(int formato, int hoja, int empresa, int pos)
        {
            try
            {
                FactorySic.GetMeHeadcolumnRepository().Delete(formato,hoja,empresa,pos);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_HEADCOLUMN
        /// </summary>
        public MeHeadcolumnDTO GetByIdMeHeadcolumn(int formato, int hoja, int empresa, int pos)
        {
            return FactorySic.GetMeHeadcolumnRepository().GetById(formato,hoja,empresa,pos);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_HEADCOLUMN
        /// </summary>
        public List<MeHeadcolumnDTO> ListMeHeadcolumns()
        {
            return FactorySic.GetMeHeadcolumnRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeHeadcolumn
        /// </summary>
        public List<MeHeadcolumnDTO> GetByCriteriaMeHeadcolumns(int formato, int empresa)
        {
            return FactorySic.GetMeHeadcolumnRepository().GetByCriteria(formato,empresa);
        }

        #endregion

        #region Métodos Tabla FW_AREA

        /// <summary>
        /// Inserta un registro de la tabla FW_AREA
        /// </summary>
        public void SaveFwArea(FwAreaDTO entity)
        {
            try
            {
                FactorySic.GetFwAreaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla FW_AREA
        /// </summary>
        public void UpdateFwArea(FwAreaDTO entity)
        {
            try
            {
                FactorySic.GetFwAreaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla FW_AREA
        /// </summary>
        public void DeleteFwArea(int areacode)
        {
            try
            {
                FactorySic.GetFwAreaRepository().Delete(areacode);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla FW_AREA
        /// </summary>
        public FwAreaDTO GetByIdFwArea(int areacode)
        {
            return FactorySic.GetFwAreaRepository().GetById(areacode);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla FW_AREA
        /// </summary>
        public List<FwAreaDTO> ListFwAreas()
        {
            return FactorySic.GetFwAreaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla FwArea
        /// </summary>
        public List<FwAreaDTO> GetByCriteriaFwAreas()
        {
            return FactorySic.GetFwAreaRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla EXT_ARCHIVO

        /// <summary>
        /// Inserta un registro de la tabla EXT_ARCHIVO
        /// </summary>
        public int SaveExtArchivo(ExtArchivoDTO entity)
        {
            int idEnvio = 0;
            try
            {
                idEnvio = FactorySic.GetExtArchivoRepository().Save(entity);
                FactorySic.GetExtArchivoRepository().UpdateMaxId(idEnvio);
                return idEnvio;

            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        public int SaveUploadExtArchivo(ExtArchivoDTO entity, string nombreFile, string extension)
        {
            int idEnvio = 0;
            try
            {
                idEnvio = FactorySic.GetExtArchivoRepository().SaveUpload(entity, nombreFile, extension);
                FactorySic.GetExtArchivoRepository().UpdateMaxId(idEnvio);
                return idEnvio;

            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Actualiza un registro de la tabla EXT_ARCHIVO
        /// </summary>
        public void UpdateExtArchivo(ExtArchivoDTO entity)
        {
            try
            {
                FactorySic.GetExtArchivoRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EXT_ARCHIVO
        /// </summary>
        public void DeleteExtArchivo(int earcodi)
        {
            try
            {
                FactorySic.GetExtArchivoRepository().Delete(earcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EXT_ARCHIVO
        /// </summary>
        public ExtArchivoDTO GetByIdExtArchivo(int earcodi)
        {
            return FactorySic.GetExtArchivoRepository().GetById(earcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EXT_ARCHIVO
        /// </summary>
        public List<ExtArchivoDTO> ListExtArchivos()
        {
            return FactorySic.GetExtArchivoRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla ExtArchivo
        /// </summary>
        public List<ExtArchivoDTO> GetByCriteriaExtArchivos(int empresa, int estado, DateTime fechaInicial, DateTime fechaFinal)
        {
            return FactorySic.GetExtArchivoRepository().GetByCriteria(empresa, estado, fechaInicial, fechaFinal);
        }

        public List<ExtArchivoDTO> GetListaEnvioPagInterconexion(int empresa, int estado, DateTime fechaInicial, DateTime fechaFinal, int nroPagina, int nroFilas)
        {
            return FactorySic.GetExtArchivoRepository().ListaEnvioPagInterconexion(empresa, estado, fechaInicial, fechaFinal, nroPagina, nroFilas);
        }

        public int TotalEnvio(DateTime fechaini, DateTime fechafin, int empresa)
        {
            return FactorySic.GetExtArchivoRepository().TotalEnvioInterconexion(fechaini, fechafin, empresa);
        }

        #endregion

        #region Métodos Tabla EXT_LOGPRO

        /// <summary>
        /// Inserta un registro de la tabla EXT_LOGPRO
        /// </summary>
        public void SaveExtLogpro(ExtLogproDTO entity)
        {
            try
            {
                FactorySic.GetExtLogproRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EXT_LOGPRO
        /// </summary>
        public void UpdateExtLogpro(ExtLogproDTO entity)
        {
            try
            {
                FactorySic.GetExtLogproRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EXT_LOGPRO
        /// </summary>
        public void DeleteExtLogpro()
        {
            try
            {
                FactorySic.GetExtLogproRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EXT_LOGPRO
        /// </summary>
        public ExtLogproDTO GetByIdExtLogpro()
        {
            return FactorySic.GetExtLogproRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EXT_LOGPRO
        /// </summary>
        public List<ExtLogproDTO> ListExtLogpros()
        {
            return FactorySic.GetExtLogproRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla ExtLogpro
        /// </summary>
        public List<ExtLogproDTO> GetByCriteriaExtLogpros()
        {
            return FactorySic.GetExtLogproRepository().GetByCriteria();
        }

        #endregion


    }
}
