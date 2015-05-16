using System;
using System.Collections.Generic;
using System.Linq;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using log4net;
using System.Text;
using System.Globalization;

namespace COES.Servicios.Aplicacion.Medidores
{
    /// <summary>
    /// Clases con métodos del módulo Medidores
    /// </summary>
    public class MedidoresAppServicio : AppServicioBase
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MedidoresAppServicio));

               

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

        public List<MeMedicion96DTO> ObtenerFlujoInterConexion(int idTipoFormacion,int idPtoMedicion,int idLectura, DateTime fechaIni,
            DateTime fechaFin)
        {
            return FactorySic.GetMeMedicion96Repository().GetByCriteria(idTipoFormacion, idPtoMedicion, idLectura, fechaIni, fechaFin);
        }

        /// <summary>
        /// Reporte de máxima demanda diaria
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <param name="tiposEmpresa"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="central"></param>
        /// <returns></returns>
        public List<DemandadiaDTO> ListarDemandaPorDia(DateTime fechaini, DateTime fechafin, string tiposEmpresa, string empresas,
            string tiposGeneracion, int central)
        {

            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = this.ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }


            List<DemandadiaDTO> listaResultado = new List<DemandadiaDTO>();
            int pos = 1;
            Decimal valorPiv = 0;
            var listaDia = FactorySic.GetMeMedicion96Repository().ListarTotalH(fechaini, fechafin, empresas, tiposGeneracion, central);
            foreach (var reg in listaDia)
            {
                for (int i = 1; i <= 96; i++)
                {
                    var valor = reg.GetType().GetProperty("H" + i.ToString()).GetValue(reg, null);
                    if (valorPiv < (decimal)valor)
                    {
                        valorPiv = (decimal)valor;
                        pos = i;
                    }
                }
                reg.Ptomedicodi = pos;
                reg.Meditotal = valorPiv;
                pos = 1;
                valorPiv = 0;
            }

            DemandadiaDTO entity;
            var lista = FactorySic.GetMeMedicion96Repository().ListarDetalle(fechaini, fechafin, empresas, tiposGeneracion, central);
            foreach (var reg in lista)
            {
                var regFecha = listaDia.Find(x => x.Medifecha == reg.Medifecha);
                if (regFecha != null)
                {
                    try
                    {                   
                    entity = new DemandadiaDTO();
                    entity.Medifecha = (DateTime)reg.Medifecha;
                    entity.Empresanomb = reg.Emprnomb;
                    entity.Centralnomb = reg.Central;
                    if (reg.Central == ConstantesBase.KeyTodos)
                        entity.Centralnomb = reg.Gruponomb;
                    entity.Gruponomb = reg.Gruponomb;
                    entity.Tipogeneracion = string.Empty;
                    if (reg.Tgenernomb != null)
                        entity.Tipogeneracion = reg.Tgenernomb;
                    entity.HMax = regFecha.Ptomedicodi;
                    entity.Valor = (decimal)reg.GetType().GetProperty("H" + regFecha.Ptomedicodi.ToString()).GetValue(reg, null);
                    if (entity.Valor == null)
                        entity.Valor = 0;
                    if (reg.Ptomedicodi == 5020) //Pto de medicion del flujo Zorritos
                    {
                        if (entity.Valor > 0) // Exportacion
                            entity.DestinoPotencia = ConstantesBase.ExportacionEcuador;
                        else
                            entity.DestinoPotencia = ConstantesBase.ImportacionEcuador;
                    }
                    else
                        entity.DestinoPotencia = ConstantesBase.GeneracionPeru;

                        listaResultado.Add(entity);
                    }
                    catch (Exception ex)
                    {
                        var text = ex.Message;
                    }
                }
            }

            return listaResultado;
        }

        /// <summary>
        /// Permite obtener las empresa por tipo
        /// </summary>
        /// <returns></returns>
        public List<SiEmpresaDTO> ObteneEmpresasPorTipo(string tiposEmpresa)
        {
            if (string.IsNullOrEmpty(tiposEmpresa)) tiposEmpresa = Constantes.ParametroDefecto;
            return FactorySic.GetSiEmpresaRepository().GetByCriteria(tiposEmpresa);
        }

        /// <summary>
        /// Muestra el reporte de máxima demanda HFP y HP
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <param name="tiposEmpresa"></param>
        /// <param name="empresas"></param>
        /// <param name="tiposGeneracion"></param>
        /// <param name="central"></param>
        /// <returns></returns>
        public List<DemandadiaDTO> ListarDemandaDiaHFPHP(DateTime fechaini, DateTime fechafin, string tiposEmpresa, string empresas,
            string tiposGeneracion, int central)
        {

            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = this.ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }

            decimal valorHFP = 0M;
            decimal valorHP = 0M;
            int horaHFP = 0;
            int horaHP = 0;
            var listaDia = FactorySic.GetMeMedicion96Repository().ListarTotalH(fechaini, fechafin, empresas, tiposGeneracion, central);
            DemandadiaDTO entity;
            List<DemandadiaDTO> entitys = new List<DemandadiaDTO>();
            foreach (var reg in listaDia)
            {
                //Calcular indice con el mayor valor y almacenar valor en meditotal
                for (int i = 1; i <= 96; i++)
                {
                    var valor = reg.GetType().GetProperty("H" + i.ToString()).GetValue(reg, null);
                    if (i > ConstantesBase.FueraPuntaFin && i < ConstantesBase.PuntaFin)
                    {//En Hora Punta
                        if (valorHP < (decimal)valor)
                        {
                            valorHP = (decimal)valor;
                            horaHP = i;
                        }
                    }
                    else
                    { //En Fuera de Punta
                        if (valorHFP < (decimal)valor)
                        {
                            valorHFP = (decimal)valor;
                            horaHFP = i;
                        }
                    }
                }

                entity = new DemandadiaDTO();
                entity.ValorHFP = valorHFP;
                entity.ValorHP = valorHP;
                entity.Medifecha = (DateTime)reg.Medifecha;
                entity.MedifechaHFP = ((DateTime)reg.Medifecha).AddMinutes(horaHFP * 15).ToString("HH:mm");
                entity.MedifechaHP = ((DateTime)reg.Medifecha).AddMinutes(horaHP * 15).ToString("HH:mm");
                entitys.Add(entity);
                valorHFP = 0M;
                valorHP = 0M;
                horaHFP = 0;
                horaHP = 0;
            }

            return entitys;
        }

        /// <summary>
        /// Guarda los Datos enviados por el agente, decide si es renvio
        /// fechaPeriodo no se usa, en proceso de eliminacion
        /// </summary>
        public int GuardarEnvioMedidores96(List<MeMedicion96DTO> listaMedicion96, short pEmpresa, DateTime fechaPeriodo, MdEnvioDTO pEnvio, out string mensaje)
        {
            mensaje = "";
            int retorno = 1;
            int codigoAntEnvio = 0;
            /// verificar si es reenvio
            codigoAntEnvio = UltimoEnvioMesXEmpresa(pEmpresa, fechaPeriodo);
            if (codigoAntEnvio < 0) return codigoAntEnvio;
            //Actualiza la Columna Total
            ActualizarListaEnvio96(listaMedicion96);
            if (codigoAntEnvio > 0) // Si existe un codigo de envio para la enmpresa es un reenvio
            {
                retorno = GuardarListaMedicionCambio96(listaMedicion96, pEmpresa, fechaPeriodo, pEnvio.Enviocodi, codigoAntEnvio, out mensaje);
                if (retorno < 0) return retorno;
            }
            else
            {
                retorno = 1;
                foreach(var reg in listaMedicion96)
                    SaveMeMedicion96(reg);

                if (retorno < 0) return retorno;
                if (retorno == 1)
                {
                    MdValidacionDTO validacion = new MdValidacionDTO();
                    validacion.Validaestado = "P";
                    validacion.Validames = fechaPeriodo;
                    validacion.Emprcodi = pEmpresa;
                    validacion.Lastuser = pEnvio.Usercodi;
                    validacion.Lastdate = pEnvio.Enviofecha;
                    validacion.Validafecha = pEnvio.Enviofecha;
                    SaveMdValidacion(validacion);
                }
                else
                {
                    retorno = -1;
                }
            }
            UpdateMdEnvio(pEnvio);

            return retorno;
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

        public int GuardarListaMedicionCambio96(List<MeMedicion96DTO> listaNuevaMedicion, short codigoEmpresa, DateTime fechaPeriodo, int codigoNewEnvio, int codigoAntEnvio, out string mensaje)
        {
            mensaje = "";
            int Hora;
            int retorno = 1;
            int hayCambios = 0;
            int Minuto;
            decimal valorOrigen;
            decimal valorModificado;
            bool noGrabarCambios = false;
            MdCambioenvioDTO cambioEnvio;

            IList<MdCambioenvioDTO> ListaCambioEnvio = new List<MdCambioenvioDTO>();
            List<MeMedicion96DTO> listaAntiguaMedicion = new List<MeMedicion96DTO>();
            listaAntiguaMedicion = FactorySic.GetMeMedicion96Repository().ObtenerEnvioPorEmpresa(codigoEmpresa, fechaPeriodo);

            //DateTime? fechaMes = null;
            //fechaMes = (DateTime)listaNuevaMedicion[0].MEDIFECHA;
            foreach (var medicionOrigen in listaAntiguaMedicion)
            {

                MeMedicion96DTO medicionModificada = listaNuevaMedicion.Find(x => x.Medifecha == medicionOrigen.Medifecha &&
                    x.Ptomedicodi == medicionOrigen.Ptomedicodi && x.Tipoinfocodi == medicionOrigen.Tipoinfocodi && 
                    x.Lectcodi == 1);
                if (medicionModificada != null)
                {
                    for (var i = 1; i <= 96; i++)
                    {
                        try
                        {
                            valorOrigen = (decimal)medicionOrigen.GetType().GetProperty("H" + i.ToString()).GetValue(medicionOrigen, null);
                            valorModificado = (decimal)medicionModificada.GetType().GetProperty("H" + i.ToString()).GetValue(medicionModificada, null);
                        }
                        catch (Exception ex)
                        {
                            retorno = -1;
                            mensaje += ex.Message;
                            throw;
                        }
                        if (Math.Abs(valorOrigen - valorModificado) > ConstantesBase.DELTACAMBIO)
                        {
                            //// SE CREA EL LOG DEL ENVIO
                            cambioEnvio = new MdCambioenvioDTO();
                            cambioEnvio.Cmbvalornew = valorModificado;
                            cambioEnvio.Cmbvalorold = valorOrigen;
                            cambioEnvio.Enviocodiold = codigoAntEnvio;
                            cambioEnvio.Enviocodinew = codigoNewEnvio;
                            Hora = i / 4;
                            Minuto = (i % 4) * 15;
                            cambioEnvio.Medifecha = medicionModificada.Medifecha.Value.AddHours(Hora).AddMinutes(Minuto);
                            cambioEnvio.Tipoinfocodi = medicionModificada.Tipoinfocodi;
                            cambioEnvio.Ptomedicodi = medicionModificada.Ptomedicodi;
                            hayCambios = 2;
                            ListaCambioEnvio.Add(cambioEnvio);
                        }

                    }
                }
                else
                {
                    ////// Archivo difiere en puntos de medicion con el anterior, no se compara cambios.
                    noGrabarCambios = true;
                    break;

                }
            }


            /// Borrar Lista Antigua
            /// 

            try
            {
               // medicion96Repository.Context.Database.ExecuteSqlCommand(execSQL);
                FactorySic.GetMeMedicion96Repository().DeleteEnvioPorEmpresa(codigoEmpresa, fechaPeriodo);
            }
            catch (Exception ex)
            {
                retorno = -2;
                mensaje += ex.Message;
                throw;
            }
            /// Agregar Lista Nueva
            //retorno = AgregarLista96(listaNuevaMedicion,out mensaje);
            //retorno = medicion96Repository.grabarMedicion96(listaNuevaMedicion);
            foreach(var reg in listaNuevaMedicion)
                FactorySic.GetMeMedicion96Repository().Save(reg);
            /// Agregar Cambios
            if (ListaCambioEnvio.Count() < 100 && !noGrabarCambios)
                foreach (var reg in ListaCambioEnvio)
                    SaveMdCambioenvio(reg);
            if (hayCambios > 0)
                retorno = hayCambios;
            return retorno;
        }

        /// <summary>
        /// Permite grabar los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        public void GrabarInterconexion(List<MeMedicion96DTO> entitys)
        {
            try
            {
                foreach (MeMedicion96DTO entity in entitys)
                {

                    entity.Lectcodi = 1;
                    FactorySic.GetMeMedicion96Repository().Save(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        /// <summary>
        /// Permite listar todos los registros de la tabla SI_EMPRESA
        /// </summary>
        public List<SiEmpresaDTO> ListSiEmpresas(int tipoemprcodi)
        {
            return FactorySic.GetSiEmpresaRepository().List(tipoemprcodi);
        }

        public List<ConsolidadoEnvioDTO> ConsolidadoEnvioXEmpresa(int emprcodi, DateTime fechaPeriodo)
        {
            return FactorySic.GetMeMedicion96Repository().ConsolidadoEnvioXEmpresa(emprcodi, fechaPeriodo);
        }

        /// <summary>
        /// Permite obtener la consulta de los datos de Interconexion cargados
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public string ObtenerConsultaInterconexion(int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";
            List<MeMedicion96DTO> list = FactorySic.GetMeMedicion96Repository().ObtenerEnvioInterconexion(idEmpresa, fechaInicio, fechaFin);

            StringBuilder strHtml = new StringBuilder();

            strHtml.Append("<table border='1' class='pretty tabla-adicional cell-border' cellspacing='0' width='100%' id='tabla'>");
            strHtml.Append("<thead>");
            strHtml.Append("<tr>");
            strHtml.Append("<th colspan='7'>LINEA DE TRANSMISIÓN L-2280 (ZORRITOS - MACHALA)</th>");
            strHtml.Append("</tr>");
            strHtml.Append("<tr>");
            strHtml.Append("<th>FECHA HORA</th>");
            strHtml.Append("<th>EXPORTACIÓN <br> L-2280 (ZORRITOS) <br> MWh</th>");
            strHtml.Append("<th>IMPORTACIÓN <br> L-2280 (ZORRITOS) <br> MWh</th>");
            strHtml.Append("<th>EXPORTACIÓN <br> L-2280 (ZORRITOS) <br> MVARh</th>");
            strHtml.Append("<th>IMPORTACIÓN <br> L-2280 (ZORRITOS) <br> MVARh</th>");
            strHtml.Append("<th>L-2280 (ZORRITOS) kV</th>");
            strHtml.Append("<th>L-2280 (ZORRITOS) Amp.</th>");
            strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            int minuto = 0;

            if (list.Count > 0)
            {
                for (int k = 1; k <= 96; k++)
                {
                    minuto = minuto + 15;
                    strHtml.Append("<tr>");
                    strHtml.Append(string.Format("<td>{0}</td>", fechaInicio.AddMinutes(minuto).ToString("dd/MM/yyyy HH:mm")));
                    MeMedicion96DTO entity = list.Where(x => x.Tipoinfocodi == 3).ToList().FirstOrDefault();
                    decimal valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    string mwExport = "";
                    string mwImport = "";
                    if (valor > 0)
                    {
                        mwExport = valor.ToString("N", nfi);
                        mwImport = 0.ToString("N", nfi);
                    }
                    else
                    {
                        valor = valor * (-1);
                        mwImport = valor.ToString("N", nfi);
                        mwExport = 0.ToString("N", nfi);                    
                    }
                    strHtml.Append(string.Format("<td>{0}</td>", mwExport));
                    strHtml.Append(string.Format("<td>{0}</td>", mwImport));

                    string mvarExport = "";
                    string mvarImport = "";
                    entity = list.Where(x => x.Tipoinfocodi == 4).ToList().FirstOrDefault();
                    valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    if (valor > 0)
                    {
                        mvarExport = valor.ToString("N", nfi);
                        mvarImport = 0.ToString("N", nfi);
                    }
                    else
                    {
                        valor = valor * (-1);
                        mvarImport = valor.ToString("N", nfi);
                        mvarExport = 0.ToString("N", nfi);
                    }
                    strHtml.Append(string.Format("<td>{0}</td>", mvarExport));
                    strHtml.Append(string.Format("<td>{0}</td>", mvarImport));
                    
                    entity = list.Where(x => x.Tipoinfocodi == 5).ToList().FirstOrDefault();
                    valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    string kVvalor = valor.ToString("N", nfi);
                    strHtml.Append(string.Format("<td>{0}</td>", kVvalor));
 
                    entity = list.Where(x => x.Tipoinfocodi == 9).ToList().FirstOrDefault();
                    valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    string AmpValor = valor.ToString("N", nfi);
                    strHtml.Append(string.Format("<td>{0}</td>", AmpValor));
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
        /// Obtiene Lista Historico Interconexion
        /// </summary>
        /// <param name="idPtomedicion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public List<MeMedicion96DTO> ObtenerHistoricoInterconexion(int idPtomedicion, DateTime fechaInicio, DateTime fechaFin)
        {
            return FactorySic.GetMeMedicion96Repository().ObtenerHistoricoInterconexion(idPtomedicion, fechaInicio, fechaFin);
        }

        /// <summary>
        /// Obtiene el Reporte Historico de Interconexion en formato html
        /// </summary>
        /// <param name="idPtomedicion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public string ObtenerConsultaHistoricaInterconexion(int idPtomedicion, DateTime fechaInicio, DateTime fechaFin)
        {
            List<MeMedicion96DTO> list = FactorySic.GetMeMedicion96Repository().ObtenerHistoricoInterconexion(idPtomedicion, fechaInicio, fechaFin);
            return ObtenerHtmlReporteInterconexion(list, fechaInicio, fechaFin);
        }
        /// <summary>
        /// Obtiene el reporte historico por pagina
        /// </summary>
        /// <param name="idPtomedicion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="pagina"></param>
        /// <returns></returns>
        public string ObtenerConsultaHistoricaPagInterconexion(int idPtomedicion, DateTime fechaInicio, DateTime fechaFin,int pagina)
        {
            List<MeMedicion96DTO> list = FactorySic.GetMeMedicion96Repository().ObtenerHistoricoPagInterconexion(idPtomedicion, fechaInicio, fechaFin,pagina);
            return ObtenerHtmlReporteInterconexion(list, fechaInicio, fechaFin);
        }

        public string ObtenerHtmlReporteInterconexion(List<MeMedicion96DTO> lista,DateTime fini,DateTime ffin)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalDigits = 3;
            nfi.NumberDecimalSeparator = ",";

            StringBuilder strHtml = new StringBuilder();

            strHtml.Append("<table border='1' class='pretty tabla-adicional' cellspacing='0' width='100%' id='tabla'>");
            strHtml.Append("<thead>");
            strHtml.Append("<tr>");
            strHtml.Append("<th colspan='7'>LINEA DE TRANSMISIÓN L-2280 (ZORRITOS - MACHALA)</th>");

            strHtml.Append("</tr>");
            strHtml.Append("<tr>");
            strHtml.Append("<th>FECHA HORA</th>");
            strHtml.Append("<th>EXPORTACIÓN <br> L-2280 (ZORRITOS) <br> MWh</th>");
            strHtml.Append("<th>IMPORTACIÓN <br> L-2280 (ZORRITOS) <br> MWh</th>");
            strHtml.Append("<th>EXPORTACIÓN <br> L-2280 (ZORRITOS) <br> MVARh</th>");
            strHtml.Append("<th>IMPORTACIÓN <br> L-2280 (ZORRITOS) <br> MVARh</th>");
            strHtml.Append("<th>L-2280 (ZORRITOS) kV</th>");
            strHtml.Append("<th>L-2280 (ZORRITOS) Amp.</th>");
            strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            int minuto = 0;
            
            for( DateTime f = fini; f <= ffin; f= f.AddDays(1))
            {
                var list = lista.Where(x => x.Medifecha == f);
                if(list.Count() != 0)
                for (int k = 1; k <= 96; k++)
                {

                    minuto = minuto + 15;
                    MeMedicion96DTO entity = list.Where(x => x.Tipoinfocodi == 3).ToList().FirstOrDefault();
                    strHtml.Append("<tr>");
                    strHtml.Append(string.Format("<td>{0}</td>", entity.Medifecha.Value.AddMinutes(minuto).ToString("dd/MM/yyyy HH:mm")));
                    decimal valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    string mwExport = "";
                    string mwImport = "";
                    if (valor > 0)
                    {
                        mwExport = valor.ToString("N", nfi);
                        mwImport = 0.ToString("N", nfi);
                    }
                    else
                    {
                        valor = valor * (-1);
                        mwImport = valor.ToString("N", nfi);
                        mwExport = 0.ToString("N", nfi);
                    }
                    strHtml.Append(string.Format("<td>{0}</td>", mwExport));
                    strHtml.Append(string.Format("<td>{0}</td>", mwImport));

                    string mvarExport = "";
                    string mvarImport = "";
                    entity = list.Where(x => x.Tipoinfocodi == 4).ToList().FirstOrDefault();
                    valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    if (valor > 0)
                    {
                        mvarExport = valor.ToString("N", nfi);
                        mvarImport = 0.ToString("N", nfi);
                    }
                    else
                    {
                        valor = valor * (-1);
                        mvarImport = valor.ToString("N", nfi);
                        mvarExport = 0.ToString("N", nfi);
                    }
                    strHtml.Append(string.Format("<td>{0}</td>", mvarExport));
                    strHtml.Append(string.Format("<td>{0}</td>", mvarImport));

                    entity = list.Where(x => x.Tipoinfocodi == 5).ToList().FirstOrDefault();
                    valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    string kVvalor = valor.ToString("N", nfi);
                    strHtml.Append(string.Format("<td>{0}</td>", kVvalor));
                    valor = (decimal)entity.GetType().GetProperty("H" + k).GetValue(entity, null);
                    string AmpValor = valor.ToString("N", nfi);
                    entity = list.Where(x => x.Tipoinfocodi == 9).ToList().FirstOrDefault();
                    strHtml.Append(string.Format("<td>{0}</td>", AmpValor));
                    strHtml.Append("</tr>");
                }

            }
            if(lista.Count == 0)
            {
                strHtml.Append("<tr><td  style='text-align:center'>No existen registros.</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>");
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");

            return strHtml.ToString();       
        }

        public int ObtenerTotalHistoricoInterconexion(int ptomedicodi, DateTime fechaini, DateTime fechafin)
        {
            return FactorySic.GetMeMedicion96Repository().ObtenerTotalHistoricoInterconexion(ptomedicodi, fechaini, fechafin);
        }
        /// <summary>
        /// Permite eliminar los valores previos cargados
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void EliminarValoresCargados(int idEmpresa, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                FactorySic.GetMeMedicion96Repository().DeleteEnvioInterconexion(fechaInicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #region Métodos Tabla SI_FUENTEENERGIA

        /// <summary>
        /// Inserta un registro de la tabla SI_FUENTEENERGIA
        /// </summary>
        public void SaveSiFuenteenergia(SiFuenteenergiaDTO entity)
        {
            try
            {
                FactorySic.GetSiFuenteenergiaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla SI_FUENTEENERGIA
        /// </summary>
        public void UpdateSiFuenteenergia(SiFuenteenergiaDTO entity)
        {
            try
            {
                FactorySic.GetSiFuenteenergiaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla SI_FUENTEENERGIA
        /// </summary>
        public void DeleteSiFuenteenergia(int fenergcodi)
        {
            try
            {
                FactorySic.GetSiFuenteenergiaRepository().Delete(fenergcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla SI_FUENTEENERGIA
        /// </summary>
        public SiFuenteenergiaDTO GetByIdSiFuenteenergia(int fenergcodi)
        {
            return FactorySic.GetSiFuenteenergiaRepository().GetById(fenergcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla SI_FUENTEENERGIA
        /// </summary>
        public List<SiFuenteenergiaDTO> ListSiFuenteenergias()
        {
            return FactorySic.GetSiFuenteenergiaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla SiFuenteenergia
        /// </summary>
        public List<SiFuenteenergiaDTO> GetByCriteriaSiFuenteenergias()
        {
            return FactorySic.GetSiFuenteenergiaRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla SI_TIPOGENERACION

        /// <summary>
        /// Inserta un registro de la tabla SI_TIPOGENERACION
        /// </summary>
        public void SaveSiTipogeneracion(SiTipogeneracionDTO entity)
        {
            try
            {
                FactorySic.GetSiTipogeneracionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla SI_TIPOGENERACION
        /// </summary>
        public void UpdateSiTipogeneracion(SiTipogeneracionDTO entity)
        {
            try
            {
                FactorySic.GetSiTipogeneracionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla SI_TIPOGENERACION
        /// </summary>
        public void DeleteSiTipogeneracion(int tgenercodi)
        {
            try
            {
                FactorySic.GetSiTipogeneracionRepository().Delete(tgenercodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla SI_TIPOGENERACION
        /// </summary>
        public SiTipogeneracionDTO GetByIdSiTipogeneracion(int tgenercodi)
        {
            return FactorySic.GetSiTipogeneracionRepository().GetById(tgenercodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla SI_TIPOGENERACION
        /// </summary>
        public List<SiTipogeneracionDTO> ListSiTipogeneracions()
        {
            return FactorySic.GetSiTipogeneracionRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla SiTipogeneracion
        /// </summary>
        public List<SiTipogeneracionDTO> GetByCriteriaSiTipogeneracions()
        {
            return FactorySic.GetSiTipogeneracionRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla ME_PTOMEDICION

        /// <summary>
        /// Se ingresa una cadena de puntos de medicion y se devuelve un List de todos los puntos
        /// de medicion con el detalle de dichos puntos(central,Grupo,Empresa)
        /// </summary>
        /// <param name="listaptos"></param>
        /// <returns></returns>
        public List<MePtomedicionDTO> ListarPtoMedicion(string listaptos)
        {
            return FactorySic.GetMePtomedicionRepository().ListarPtoMedicion(listaptos);
        }

        #endregion

        #region Métodos Tabla Si_Empresa

        public List<SiEmpresaDTO> ObtenerEmpresasPorUsuario(string userlogin)
        {
            return FactorySic.GetSiEmpresaRepository().GetByUser(userlogin);
        }

        public List<SiEmpresaDTO> ObtenerEmpresasSEIN()
        {
            return FactorySic.GetSiEmpresaRepository().ObtenerEmpresasSEIN();
        }
        #endregion

        #region Métodos Tabla MD_Publicacion

        public MdPublicacionDTO GetLastPubEmpresa(DateTime fecha, int emprcodi)
        {
            fecha = fecha.AddMonths(-1);
            return FactorySic.GetMdPublicacionRepository().GetLastPubEmpresa(fecha,emprcodi);
        }

        #endregion

        #region Métodos Tabla EXT_ARCHIVO

        /// <summary>
        /// Inserta un registro de la tabla EXT_ARCHIVO
        /// </summary>
        public int SaveExtArchivo(ExtArchivoDTO entity)
        {
            int idEnvio=0;
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
            return FactorySic.GetExtArchivoRepository().GetByCriteria(empresa,estado,fechaInicial,fechaFinal);
        }

        public List<ExtArchivoDTO> GetListaEnvioPagInterconexion(int empresa,int estado ,DateTime fechaInicial, DateTime fechaFinal, int nroPagina, int nroFilas)
        {
            return FactorySic.GetExtArchivoRepository().ListaEnvioPagInterconexion(empresa,estado,fechaInicial,fechaFinal,nroPagina,nroFilas);
        }

        public int TotalEnvio(DateTime fechaini, DateTime fechafin, int empresa)
        {
            return FactorySic.GetExtArchivoRepository().TotalEnvioInterconexion(fechaini, fechafin,empresa);
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

        #region Métodos Tabla MD_ENVIO

        /// <summary>
        /// Inserta un registro de la tabla MD_ENVIO
        /// </summary>
        public void SaveMdEnvio(MdEnvioDTO entity)
        {
            try
            {
                FactorySic.GetMdEnvioRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla MD_ENVIO
        /// </summary>
        public void UpdateMdEnvio(MdEnvioDTO entity)
        {
            try
            {
                FactorySic.GetMdEnvioRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }


        public void ActualizaEstadoEnvio(int enviocodi, int estado)
        {
            var envio = GetByIdMdEnvio(enviocodi);
            envio.Estenvcodi = estado;
            UpdateMdEnvio(envio);
        }
        /// <summary>
        /// Elimina un registro de la tabla MD_ENVIO
        /// </summary>
        public void DeleteMdEnvio(int enviocodi)
        {
            try
            {
                FactorySic.GetMdEnvioRepository().Delete(enviocodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla MD_ENVIO
        /// </summary>
        public MdEnvioDTO GetByIdMdEnvio(int enviocodi)
        {
            return FactorySic.GetMdEnvioRepository().GetById(enviocodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla MD_ENVIO
        /// </summary>
        public List<MdEnvioDTO> ListMdEnvios()
        {
            return FactorySic.GetMdEnvioRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MdEnvio
        /// </summary>
        public List<MdEnvioDTO> GetByCriteriaMdEnvios(int emprcodi,DateTime enviomes)
        {
            return FactorySic.GetMdEnvioRepository().GetByCriteria(emprcodi, enviomes);
        }

        public int UltimoEnvioMesXEmpresa(int emprcodi, DateTime enviomes)
        {
            int codigo = 0;

            var lista = GetByCriteriaMdEnvios(emprcodi, enviomes).Where(x => x.Estenvcodi == ConstantesBase.ENVIO_APROBADO || x.Estenvcodi == ConstantesBase.ENVIO_FUERAPLAZO);
            if (lista.Count() > 0)
                codigo = lista.Max(x => x.Enviocodi);
            return codigo;
        }
        #endregion

        #region Métodos Tabla MD_PUBLICACION

        /// <summary>
        /// Inserta un registro de la tabla MD_PUBLICACION
        /// </summary>
        public void SaveMdPublicacion(MdPublicacionDTO entity)
        {
            try
            {
                FactorySic.GetMdPublicacionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla MD_PUBLICACION
        /// </summary>
        public void UpdateMdPublicacion(MdPublicacionDTO entity)
        {
            try
            {
                FactorySic.GetMdPublicacionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla MD_PUBLICACION
        /// </summary>
        public void DeleteMdPublicacion(int emprcodi, DateTime publimes)
        {
            try
            {
                FactorySic.GetMdPublicacionRepository().Delete(emprcodi, publimes);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla MD_PUBLICACION
        /// </summary>
        public MdPublicacionDTO GetByIdMdPublicacion(int emprcodi, DateTime publimes)
        {
            return FactorySic.GetMdPublicacionRepository().GetById(emprcodi, publimes);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla MD_PUBLICACION
        /// </summary>
        public List<MdPublicacionDTO> ListMdPublicacions()
        {
            return FactorySic.GetMdPublicacionRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MdPublicacion
        /// </summary>
        public List<MdPublicacionDTO> GetByCriteriaMdPublicacions()
        {
            return FactorySic.GetMdPublicacionRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla MD_VALIDACION

        /// <summary>
        /// Inserta un registro de la tabla MD_VALIDACION
        /// </summary>
        public void SaveMdValidacion(MdValidacionDTO entity)
        {
            try
            {
                FactorySic.GetMdValidacionRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla MD_VALIDACION
        /// </summary>
        public void UpdateMdValidacion(MdValidacionDTO entity)
        {
            try
            {
                FactorySic.GetMdValidacionRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla MD_VALIDACION
        /// </summary>
        public void DeleteMdValidacion(DateTime validames, int emprcodi)
        {
            try
            {
                FactorySic.GetMdValidacionRepository().Delete(validames, emprcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla MD_VALIDACION
        /// </summary>
        public MdValidacionDTO GetByIdMdValidacion(DateTime validames, int emprcodi)
        {
            return FactorySic.GetMdValidacionRepository().GetById(validames, emprcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla MD_VALIDACION
        /// </summary>
        public List<MdValidacionDTO> ListMdValidacions()
        {
            return FactorySic.GetMdValidacionRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MdValidacion
        /// </summary>
        public List<MdValidacionDTO> GetByCriteriaMdValidacions()
        {
            return FactorySic.GetMdValidacionRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla MD_CAMBIOENVIO

        /// <summary>
        /// Inserta un registro de la tabla MD_CAMBIOENVIO
        /// </summary>
        public void SaveMdCambioenvio(MdCambioenvioDTO entity)
        {
            try
            {
                FactorySic.GetMdCambioenvioRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla MD_CAMBIOENVIO
        /// </summary>
        public void UpdateMdCambioenvio(MdCambioenvioDTO entity)
        {
            try
            {
                FactorySic.GetMdCambioenvioRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla MD_CAMBIOENVIO
        /// </summary>
        public void DeleteMdCambioenvio(int tipoinfocodi, int enviocodiold, DateTime medifecha, int ptomedicodi)
        {
            try
            {
                FactorySic.GetMdCambioenvioRepository().Delete(tipoinfocodi, enviocodiold, medifecha, ptomedicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla MD_CAMBIOENVIO
        /// </summary>
        public MdCambioenvioDTO GetByIdMdCambioenvio(int tipoinfocodi, int enviocodiold, DateTime medifecha, int ptomedicodi)
        {
            return FactorySic.GetMdCambioenvioRepository().GetById(tipoinfocodi, enviocodiold, medifecha, ptomedicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla MD_CAMBIOENVIO
        /// </summary>
        public List<MdCambioenvioDTO> ListMdCambioenvios()
        {
            return FactorySic.GetMdCambioenvioRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MdCambioenvio
        /// </summary>
        public List<MdCambioenvioDTO> GetByCriteriaMdCambioenvios()
        {
            return FactorySic.GetMdCambioenvioRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla ME_FORMATO

        /// <summary>
        /// Inserta un registro de la tabla ME_FORMATO
        /// </summary>
        public void SaveMeFormato(MeFormatoDTO entity)
        {
            try
            {
                FactorySic.GetMeFormatoRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
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
        public List<MeFormatohojaDTO> GetByCriteriaMeFormatohojas(int formato)
        {
            return FactorySic.GetMeFormatohojaRepository().GetByCriteria(formato);
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
        public MeHojaptomedDTO GetByIdMeHojaptomed(int hojanumero, int formatcodi,int tipoinfocodi, int ptomedicodi,int hojaptosigno)
        {
            return FactorySic.GetMeHojaptomedRepository().GetById(hojanumero, formatcodi, tipoinfocodi, ptomedicodi, hojaptosigno);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_HOJAPTOMED
        /// </summary>
        public List<MeHojaptomedDTO> ListMeHojaptomeds()
        {
            return FactorySic.GetMeHojaptomedRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeHojaptomed
        /// </summary>
        public List<MeHojaptomedDTO> GetByCriteriaMeHojaptomeds(int emprcodi, int formatcodi, int hojacodi)
        {
            return FactorySic.GetMeHojaptomedRepository().GetByCriteria(emprcodi,formatcodi,hojacodi);
        }

        #endregion

        #region Métodos Tabla ME_MEDIDOR

        /// <summary>
        /// Inserta un registro de la tabla ME_MEDIDOR
        /// </summary>
        public void SaveMeMedidor(MeMedidorDTO entity)
        {
            try
            {
                FactorySic.GetMeMedidorRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_MEDIDOR
        /// </summary>
        public void UpdateMeMedidor(MeMedidorDTO entity)
        {
            try
            {
                FactorySic.GetMeMedidorRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_MEDIDOR
        /// </summary>
        public void DeleteMeMedidor(int medicodi)
        {
            try
            {
                FactorySic.GetMeMedidorRepository().Delete(medicodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_MEDIDOR
        /// </summary>
        public MeMedidorDTO GetByIdMeMedidor(int medicodi)
        {
            return FactorySic.GetMeMedidorRepository().GetById(medicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_MEDIDOR
        /// </summary>
        public List<MeMedidorDTO> ListMeMedidors()
        {
            return FactorySic.GetMeMedidorRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeMedidor
        /// </summary>
        public List<MeMedidorDTO> GetByCriteriaMeMedidors()
        {
            return FactorySic.GetMeMedidorRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla ME_PERIODOMEDIDOR

        /// <summary>
        /// Inserta un registro de la tabla ME_PERIODOMEDIDOR
        /// </summary>
        public void SaveMePeriodomedidor(MePeriodomedidorDTO entity)
        {
            try
            {
                FactorySic.GetMePeriodomedidorRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Grabba una lista de periodos
        /// </summary>
        /// <param name="entitys"></param>
        public void SaveListaMePeriodomedidor(List<MePeriodomedidorDTO> entitys)
        {
            foreach (var reg in entitys)
            {
                SaveMePeriodomedidor(reg);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_PERIODOMEDIDOR
        /// </summary>
        public void UpdateMePeriodomedidor(MePeriodomedidorDTO entity)
        {
            try
            {
                FactorySic.GetMePeriodomedidorRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_PERIODOMEDIDOR
        /// </summary>
        public void DeleteMePeriodomedidor()
        {
            try
            {
                FactorySic.GetMePeriodomedidorRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_PERIODOMEDIDOR
        /// </summary>
        public MePeriodomedidorDTO GetByIdMePeriodomedidor()
        {
            return FactorySic.GetMePeriodomedidorRepository().GetById();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_PERIODOMEDIDOR
        /// </summary>
        public List<MePeriodomedidorDTO> ListMePeriodomedidors()
        {
            return FactorySic.GetMePeriodomedidorRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MePeriodomedidor
        /// </summary>
        public List<MePeriodomedidorDTO> GetByCriteriaMePeriodomedidors()
        {
            return FactorySic.GetMePeriodomedidorRepository().GetByCriteria();
        }

        #endregion

        #region Métodos Tabla ME_AMPLIACIONFECHA

        /// <summary>
        /// Inserta un registro de la tabla ME_AMPLIACIONFECHA
        /// </summary>
        public void SaveMeAmpliacionfecha(MeAmpliacionfechaDTO entity)
        {
            try
            {
                FactorySic.GetMeAmpliacionfechaRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla ME_AMPLIACIONFECHA
        /// </summary>
        public void UpdateMeAmpliacionfecha(MeAmpliacionfechaDTO entity)
        {
            try
            {
                FactorySic.GetMeAmpliacionfechaRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla ME_AMPLIACIONFECHA
        /// </summary>
        public void DeleteMeAmpliacionfecha()
        {
            try
            {
                FactorySic.GetMeAmpliacionfechaRepository().Delete();
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla ME_AMPLIACIONFECHA
        /// </summary>
        public MeAmpliacionfechaDTO GetByIdMeAmpliacionfecha(DateTime fecha, int empresa, int formato)
        {
            return FactorySic.GetMeAmpliacionfechaRepository().GetById(fecha,empresa,formato);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla ME_AMPLIACIONFECHA
        /// </summary>
        public List<MeAmpliacionfechaDTO> ListMeAmpliacionfechas()
        {
            return FactorySic.GetMeAmpliacionfechaRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla MeAmpliacionfecha
        /// </summary>
        public List<MeAmpliacionfechaDTO> GetByCriteriaMeAmpliacionfechas()
        {
            return FactorySic.GetMeAmpliacionfechaRepository().GetByCriteria();
        }

        public List<MeAmpliacionfechaDTO> ObtenerListaMeAmpliacionfechas(DateTime fechaIni, DateTime fechaFin, int empresa, int formato)
        {
            return FactorySic.GetMeAmpliacionfechaRepository().GetListaAmpliacion(fechaIni, fechaFin, empresa, formato);
        }

        #endregion



    }
}
