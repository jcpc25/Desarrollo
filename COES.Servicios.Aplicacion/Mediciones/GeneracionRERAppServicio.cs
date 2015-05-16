using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using System.Linq;
using log4net;
using System.Text;

namespace COES.Servicios.Aplicacion.Mediciones
{
    public class GeneracionRERAppServicio
    {
        /// <summary>
        /// Instancia para el manejo de logs
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(GeneracionRERAppServicio));

        #region Métodos Tabla WB_GENERACIONRER

        /// <summary>
        /// Inserta un registro de la tabla WB_GENERACIONRER
        /// </summary>
        public int SaveWbGeneracionrer(int indicador, int ptoCentral, int? ptoUnidad, string userName)
        {
            try
            {
                int resultado = 0;
                int ptoMedicion = 0;
                string indCentral = string.Empty;

                if (indicador == 1)
                {
                    int countUnidad = FactorySic.GetWbGeneracionrerRepository().ValidarExistencia((int)ptoUnidad);
                    if (countUnidad == 0)
                    {
                        int countCentral = FactorySic.GetWbGeneracionrerRepository().ValidarExistencia(ptoCentral);
                        if (countCentral == 0)
                        {
                            ptoMedicion = (int)ptoUnidad;
                            resultado = 1;      
                            indCentral = Constantes.NO;
                        }
                        else 
                        {
                            resultado = 2; //existe central
                        }
                    }
                    else 
                    {
                        resultado = 3; //ya existe unidad
                    }
                }
                else 
                {
                    int countCentral = FactorySic.GetWbGeneracionrerRepository().ValidarExistencia(ptoCentral);
                    if (countCentral == 0)
                    {
                        int countUnidad = FactorySic.GetWbGeneracionrerRepository().ValidarExistenciaUnidad(ptoCentral);
                        if (countUnidad == 0)
                        {
                            ptoMedicion = ptoCentral;
                            resultado = 1;    
                            indCentral = Constantes.SI;
                        }
                        else 
                        {
                            resultado = 4; //existen unidades agregadas
                        }
                    }
                    else 
                    {
                        resultado = 5; //existe central
                    }
                }
                
                if (resultado == 1)
                {

                    int validacionGeneral = FactorySic.GetWbGeneracionrerRepository().ValidarExistenciaGeneral(ptoMedicion);
                                        
                    WbGeneracionrerDTO entity = new WbGeneracionrerDTO();
                    entity.Ptomedicodi = ptoMedicion;
                    entity.IndPorCentral = indCentral;
                    entity.Feccreate = DateTime.Now;
                    entity.Fecupdate = DateTime.Now;
                    entity.Usercreate = userName;
                    entity.Userupdate = userName;
                    entity.Estado = Constantes.Activo;

                    if (validacionGeneral == 0)
                    {
                        FactorySic.GetWbGeneracionrerRepository().Save(entity);
                    }
                    else 
                    {
                        FactorySic.GetWbGeneracionrerRepository().Update(entity);
                    }
                }
                
                return resultado;
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                return -1;
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla WB_GENERACIONRER
        /// </summary>
        public void UpdateWbGeneracionrer(WbGeneracionrerDTO entity)
        {
            try
            {
                FactorySic.GetWbGeneracionrerRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla WB_GENERACIONRER
        /// </summary>
        public void DeleteWbGeneracionrer(int ptomedicodi, string lastUser)
        {
            try
            {
                FactorySic.GetWbGeneracionrerRepository().Delete(ptomedicodi, lastUser, DateTime.Now);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla WB_GENERACIONRER
        /// </summary>
        public WbGeneracionrerDTO GetByIdWbGeneracionrer(int ptomedicodi)
        {
            return FactorySic.GetWbGeneracionrerRepository().GetById(ptomedicodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla WB_GENERACIONRER
        /// </summary>
        public List<WbGeneracionrerDTO> ListWbGeneracionrers()
        {
            return FactorySic.GetWbGeneracionrerRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla WbGeneracionrer
        /// </summary>
        public List<WbGeneracionrerDTO> GetByCriteriaWbGeneracionrers()
        {
            return FactorySic.GetWbGeneracionrerRepository().GetByCriteria();
        }


        /// <summary>
        /// Permite obtener las empresas que reportarán
        /// </summary>
        /// <returns></returns>
        public List<WbGeneracionrerDTO> ObtenerPuntosEmpresas()
        {
            return FactorySic.GetWbGeneracionrerRepository().ObtenerPuntosEmpresas();
        }

        /// <summary>
        /// Permite obtener las centrales por empresa seleccianda
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<WbGeneracionrerDTO> ObtenerPuntosCentrales(int idEmpresa)
        {
            return FactorySic.GetWbGeneracionrerRepository().ObtenerPuntosCentrales(idEmpresa);
        }

        /// <summary>
        /// Permite obtener las unidades por cada central seleccionada
        /// </summary>
        /// <param name="idCentral"></param>
        /// <returns></returns>
        public List<WbGeneracionrerDTO> ObtenerPuntosUnidades(int ptoCentral)
        {
            return FactorySic.GetWbGeneracionrerRepository().ObtenerPuntosUnidades(ptoCentral);
        }

        /// <summary>
        /// Permite obtner la lista de puntos para elaborar formato
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<WbGeneracionrerDTO> ObtenerListaFormato(int idEmpresa)
        {
            return FactorySic.GetWbGeneracionrerRepository().ObtenerPuntoFormato(idEmpresa);
        }

        #endregion


        #region Metodos Tabla ME_MEDICION48
        
        /// <summary>
        /// Permite grabar los datos cargados
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="userName"></param>
        /// <param name="horizonte"></param>
        public void GrabarGeneracionRER(List<MeMedicion48DTO> entitys, string userName, int horizonte)
        {
            try
            {
                foreach (MeMedicion48DTO entity in entitys)
                {
                    entity.Lastuser = userName;
                    entity.Lastdate = DateTime.Now;
                    entity.Lectcodi = (horizonte == 0) ? ConstantesMedicion.LecturaProgDiaraRER : ConstantesMedicion.LecturaProgSemanalRER;
                    entity.Tipoinfocodi = ConstantesMedicion.TipoInformacionRER;

                    FactorySic.GetMeMedicion48Repository().Save(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite eliminar los valores previos cargados
        /// </summary>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        public void EliminarValoresCargados(int idEmpresa, int horizonte, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                int lectCodi = (horizonte == 0) ? ConstantesMedicion.LecturaProgDiaraRER : ConstantesMedicion.LecturaProgSemanalRER;
                FactorySic.GetMeMedicion48Repository().EliminarValoresCargados(idEmpresa, lectCodi, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite validar la existencia de datos
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public bool ValidarValoresCargados(int idEmpresa, int horizonte, DateTime fechaInicio, DateTime fechaFin)
        {
            int lectCodi = (horizonte == 0) ? ConstantesMedicion.LecturaProgDiaraRER : ConstantesMedicion.LecturaProgSemanalRER;
            return FactorySic.GetMeMedicion48Repository().ValidarExistenciaDatos(idEmpresa, lectCodi, fechaInicio, fechaFin);
        }

        /// <summary>
        /// Permite obtener la consulta de carga de generacion rer
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="horizonte"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public List<MeMedicion48DTO> ObtenerConsulta(int idEmpresa, int horizonte, DateTime fechaInicio, DateTime fechaFin)
        {
            int lectCodi = (horizonte == 0) ? ConstantesMedicion.LecturaProgDiaraRER : ConstantesMedicion.LecturaProgSemanalRER;
            List<MeMedicion48DTO> list = FactorySic.GetMeMedicion48Repository().ObtenerGeneracionRER(idEmpresa, lectCodi, fechaInicio, fechaFin);

            return list;
        }

        /// <summary>
        /// Permite obtener la consulta de los datos de generación RER cargados
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="horizonte"></param>
        /// <param name="fecha"></param>
        /// <param name="nroSemana"></param>
        /// <returns></returns>
        public string ObtenerConsultaRER(int idEmpresa, int horizonte, DateTime fechaInicio, DateTime fechaFin, int indicador)
        {
            int lectCodi = (horizonte == 0) ? ConstantesMedicion.LecturaProgDiaraRER : ConstantesMedicion.LecturaProgSemanalRER;
            List<MeMedicion48DTO> list = FactorySic.GetMeMedicion48Repository().ObtenerGeneracionRER(idEmpresa, lectCodi, fechaInicio, fechaFin);

            List<WbGeneracionrerDTO> puntos = this.ObtenerListaFormato(idEmpresa);
            List<WbGeneracionrerDTO> listCentrales = puntos.Where(x => x.IndPorCentral == Constantes.SI).ToList();
            List<WbGeneracionrerDTO> listUnidades = puntos.Where(x => x.IndPorCentral == Constantes.NO).ToList();
            List<int> ids = listUnidades.Select(x => x.CentralCodi).Distinct().ToList();
            int countDia = (horizonte == 0) ? 1 : 7;

            StringBuilder strHtml = new StringBuilder();

            if (indicador == 1)
            {
                strHtml.Append("<table border='0' class='pretty tabla-adicional' cellspacing='0' width='100%' id='tabla'>");
            }
            else 
            {
                strHtml.Append("<table border='0' class='tabla-formulario' cellspacing='0' width='100%' id='tabla'>");
            }


            strHtml.Append("<thead>");
            strHtml.Append("<tr>");
            strHtml.Append("<th rowspan='3'>HORA</th>");

            foreach (WbGeneracionrerDTO item in listCentrales)
            {
                strHtml.Append(string.Format("<th>{0}</th>", item.EmprNomb));
            }
            foreach (int id in ids)
            {
                List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();
                foreach (WbGeneracionrerDTO item in listUnidad)
                {
                    strHtml.Append(string.Format("<th>{0}</th>", item.EmprNomb));
                }
            }
            strHtml.Append("</tr>");

            foreach (WbGeneracionrerDTO item in listCentrales)
            {
                strHtml.Append(string.Format("<th>{0}</th>", item.Central));
            }
            foreach (int id in ids)
            {
                List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();
                foreach (WbGeneracionrerDTO item in listUnidad)
                {
                    strHtml.Append(string.Format("<th>{0}</th>", item.Central));
                }
            }
            strHtml.Append("</tr>");
            strHtml.Append("<tr>");
            foreach (WbGeneracionrerDTO item in listCentrales)
            {
                strHtml.Append("<th>CENTRAL</th>");
            }
            foreach (int id in ids)
            {
                List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();
                foreach (WbGeneracionrerDTO item in listUnidad)
                {
                    strHtml.Append(string.Format("<th>{0}</th>", item.EquiNomb));
                }
            }
            strHtml.Append("</tr>");
            strHtml.Append("</thead>");
            strHtml.Append("<tbody>");

            int minuto = 0;

            if (list.Count > 0)
            {
                for (int i = 0; i < countDia; i++)
                {
                    for (int k = 1; k <= 48; k++)
                    {
                        strHtml.Append("<tr>");
                        strHtml.Append(string.Format("<td>{0}</td>", fechaInicio.AddMinutes(minuto).ToString("dd/MM/yyyy HH:mm")));
                        minuto = minuto + 30;

                        foreach (WbGeneracionrerDTO item in listCentrales)
                        {
                            if (list.Where(x => x.Ptomedicodi == item.Ptomedicodi).Count() > i)
                            {
                                MeMedicion48DTO entity = list.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList()[i];
                                strHtml.Append(string.Format("<td>{0}</td>", entity.GetType().GetProperty("H" + k).GetValue(entity, null)));
                            }
                            else {
                                strHtml.Append("<td></td>");
                            }
                        }

                        foreach (int id in ids)
                        {
                            List<WbGeneracionrerDTO> listUnidad = listUnidades.Where(x => x.CentralCodi == id).ToList();

                            foreach (WbGeneracionrerDTO item in listUnidad)
                            {
                                if (list.Where(x => x.Ptomedicodi == item.Ptomedicodi).Count() > i)
                                {                                    
                                    MeMedicion48DTO entity = list.Where(x => x.Ptomedicodi == item.Ptomedicodi).ToList()[i];

                                    strHtml.Append(string.Format("<td>{0}</td>", entity.GetType().GetProperty("H" + k).GetValue(entity, null)));
                                }
                                else
                                {
                                    strHtml.Append("<td></td>");
                                }
                            }
                        }

                        strHtml.Append("</tr>");
                    }
                }
            }
            else
            {
                if (indicador == 1)
                {
                    strHtml.Append(String.Format("<td colspan='{0}' style='text-align:center'>No existen registros.</td>", puntos.Count + 1));
                }                
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");

            return strHtml.ToString();
        }

        #endregion


        #region Métodos Tabla EXT_LOGENVIO

        /// <summary>
        /// Inserta un registro de la tabla EXT_LOGENVIO
        /// </summary>
        public void SaveExtLogenvio(ExtLogenvioDTO entity)
        {
            try
            {
                FactorySic.GetExtLogenvioRepository().Save(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla EXT_LOGENVIO
        /// </summary>
        public void UpdateExtLogenvio(ExtLogenvioDTO entity)
        {
            try
            {
                FactorySic.GetExtLogenvioRepository().Update(entity);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla EXT_LOGENVIO
        /// </summary>
        public void DeleteExtLogenvio(int logcodi)
        {
            try
            {
                FactorySic.GetExtLogenvioRepository().Delete(logcodi);
            }
            catch (Exception ex)
            {
                Logger.Error(Constantes.LogError, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite obtener un registro de la tabla EXT_LOGENVIO
        /// </summary>
        public ExtLogenvioDTO GetByIdExtLogenvio(int logcodi)
        {
            return FactorySic.GetExtLogenvioRepository().GetById(logcodi);
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EXT_LOGENVIO
        /// </summary>
        public List<ExtLogenvioDTO> ListExtLogenvios()
        {
            return FactorySic.GetExtLogenvioRepository().List();
        }

        /// <summary>
        /// Permite realizar búsquedas en la tabla ExtLogenvio
        /// </summary>
        public List<ExtLogenvioDTO> GetByCriteriaExtLogenvios(int horizonte, DateTime fecha, int? nroSemana)
        {
            int lectCodi = (horizonte == 0) ? ConstantesMedicion.LecturaProgDiaraRER : ConstantesMedicion.LecturaProgSemanalRER;

            List<ExtLogenvioDTO> list = FactorySic.GetExtLogenvioRepository().GetByCriteria(lectCodi, fecha, nroSemana);
            List<WbGeneracionrerDTO> listEmpresas = this.ObtenerPuntosEmpresas();

            List<ExtLogenvioDTO> listNew = new List<ExtLogenvioDTO>();

            foreach (WbGeneracionrerDTO item in listEmpresas)
            {
                if (list.Where(x => x.Emprcodi == item.EmprCodi).Count() == 0)
                {
                    listNew.Add(new ExtLogenvioDTO
                    {
                        EmprNomb = item.EmprNomb,
                        EstEnvNomb = ConstantesMedicion.TextoNoEnvio                        
                    });
                }
            }

            list.AddRange(listNew);

            return list;
        }

        #endregion

    }
}
