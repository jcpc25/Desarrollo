using System;
using System.Linq;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;
using COES.Servicios.Aplicacion.Factory;
using COES.Servicios.Aplicacion.Helper;
using COES.Servicios.Aplicacion.Mediciones;

namespace COES.Servicios.Aplicacion.Eventos
{
    public class EventoAppServicio : AppServicioBase
    {
        /// <summary>
        /// Permite listar los tipos de eventos
        /// </summary>
        /// <returns></returns>
        public List<TipoEventoDTO> ListarTipoEvento()
        {
            return FactorySic.ObtenerTipoEventoDao().ListarTipoEvento();
        }

        /// <summary>
        /// Permite listar las causas de ocurrencia de los eventos
        /// </summary>
        /// <param name="idTipoEvento"></param>
        /// <returns></returns>
        public List<SubCausaEventoDTO> ObtenerCausaEvento(int? idTipoEvento)
        {
            return FactorySic.ObtenerSubCausaEventoDao().ObtenerCausaEvento(idTipoEvento);
        }

        /// <summary>
        /// Permite buscar los eventos segun criterios especificados
        /// </summary>
        /// <param name="idTipoEvento"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="version"></param>
        /// <param name="turno"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idTipoEquipo"></param>
        /// <returns></returns>
        public List<EventoDTO> BuscarEventos(int? idTipoEvento, DateTime fechaInicio, DateTime fechaFin,
            string version, string turno, int? idTipoEmpresa, int? idEmpresa, int? idTipoEquipo, string informe, string indInterrupcion, int nroPage, int nroFilas)
        {
            string filtro = string.Empty;

            if (!string.IsNullOrEmpty(turno))
            {
                if (turno == ConstantesEvento.Turno1)
                {
                    filtro = String.Format(ConstantesEvento.FiltroFechaEvento, fechaInicio.ToString(ConstantesEvento.FormatoFechaExtendido),
                        fechaInicio.AddHours(7).ToString(ConstantesEvento.FormatoFechaExtendido));
                }
                if (turno == ConstantesEvento.Turno2)
                {
                    filtro = String.Format(ConstantesEvento.FiltroFechaEvento, fechaInicio.AddHours(7).ToString(ConstantesEvento.FormatoFechaExtendido),
                            fechaInicio.AddHours(15).ToString(ConstantesEvento.FormatoFechaExtendido));
                }
                if (turno == ConstantesEvento.Turno3)
                {
                    filtro = String.Format(ConstantesEvento.FiltroFechaEvento, fechaInicio.AddHours(15).ToString(ConstantesEvento.FormatoFechaExtendido),
                                fechaInicio.AddDays(1).ToString(ConstantesEvento.FormatoFechaExtendido));
                }
            }

            return FactorySic.ObtenerEventoDao().BuscarEventos(idTipoEvento, fechaInicio, fechaFin, version, filtro, idTipoEmpresa,
                idEmpresa, idTipoEquipo, informe, indInterrupcion, nroPage, nroFilas);
        }

        /// <summary>
        /// Permite obtener el número de filas de la consulta a ejecutar
        /// </summary>
        /// <param name="idTipoEvento"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="version"></param>
        /// <param name="turno"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idTipoEquipo"></param>
        /// <returns></returns>
        public int ObtenerNroFilasEvento(int? idTipoEvento, DateTime fechaInicio, DateTime fechaFin,
            string version, string turno, int? idTipoEmpresa, int? idEmpresa, int? idTipoEquipo, string informe, string indInterrupcion) 
        {
            string filtro = string.Empty;

            if (!string.IsNullOrEmpty(turno))
            {
                if (turno == ConstantesEvento.Turno1)
                {
                    filtro = String.Format(ConstantesEvento.FiltroFechaEvento, fechaInicio.ToString(ConstantesEvento.FormatoFechaExtendido),
                        fechaInicio.AddHours(7).ToString(ConstantesEvento.FormatoFechaExtendido));
                }
                if (turno == ConstantesEvento.Turno2)
                {
                    filtro = String.Format(ConstantesEvento.FiltroFechaEvento, fechaInicio.AddHours(7).ToString(ConstantesEvento.FormatoFechaExtendido),
                            fechaInicio.AddHours(15).ToString(ConstantesEvento.FormatoFechaExtendido));
                }
                if (turno == ConstantesEvento.Turno3)
                {
                    filtro = String.Format(ConstantesEvento.FiltroFechaEvento, fechaInicio.AddHours(15).ToString(ConstantesEvento.FormatoFechaExtendido),
                                fechaInicio.AddDays(1).ToString(ConstantesEvento.FormatoFechaExtendido));
                }
            }

            return FactorySic.ObtenerEventoDao().ObtenerNroRegistros(idTipoEvento, fechaInicio, 
                fechaFin, version, filtro, idTipoEmpresa, idEmpresa, idTipoEquipo, informe, indInterrupcion);
        }

        /// <summary>
        /// Permite obtener algunos datos principales del evento
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        public EventoDTO ObtenerResumenEvento(int idEvento)
        {
            return FactorySic.ObtenerEventoDao().ObtenerResumenEvento(idEvento);
        }

        /// <summary>
        /// Permite obtener los datos de un evento en particular
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        public EventoDTO ObtenerEvento(int idEvento)
        {
            return FactorySic.ObtenerEventoDao().ObtenerEvento(idEvento);
        }

        /// <summary>
        /// Permite actualizar un evento que tiene relacionado un reporte de perturbaciones
        /// </summary>
        /// <param name="idEvento"></param>
        public void ActualizarIndicadorReporteEvento(int idEvento)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite obtener los items del reporte de perturbacion de un evento
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        public List<InformePerturbacionDTO> ObtenerInformePorEvento(int idEvento)
        {
            return FactorySic.ObtenerInformePerturbacionDao().ObtenerInformePorEvento(idEvento);
        }

        /// <summary>
        /// Permite obtener un item del reporte de perturbaciones de un evento
        /// </summary>
        /// <param name="idInformePerturbacion"></param>
        /// <returns></returns>
        public InformePerturbacionDTO ObtenerItemReporteEvento(int idInformePerturbacion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite grabar o editar los items del reporte de perturbacion
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int GrabarInformePerturbacion(List<InformePerturbacionDTO> entitys, int idEvento, string usuario)
        {
            try
            {
                FactorySic.ObtenerInformePerturbacionDao().EliminarInforme(idEvento);

                foreach (InformePerturbacionDTO item in entitys)
                {
                    item.EVENCODI = idEvento;
                    item.LASTUSER = usuario;
                    item.LASTDATE = DateTime.Now;
                }

                FactorySic.ObtenerInformePerturbacionDao().GrabarInforme(entitys);
                FactorySic.ObtenerEventoDao().ActualizarInformePerturbacion(ConstantesEvento.SI, idEvento);

                return 1;
            }
            catch
            {
                return -1;
            }
        }        

        /// <summary>
        /// Permite quitar un item del reporte de perturbacion
        /// </summary>
        /// <param name="idInformePerturbacion"></param>
        public void EliminarInformePerturbacion(int idEvento)
        {
            try
            {
                FactorySic.ObtenerInformePerturbacionDao().EliminarInforme(idEvento);
                FactorySic.ObtenerEventoDao().ActualizarInformePerturbacion(ConstantesEvento.NO, idEvento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite listar las areas operativas por empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<AreaDTO> ObtenerAreaPorEmpresa(int? idEmpresa)
        {
            return FactorySic.ObtenerEventoDao().ObtenerAreaPorEmpresa(idEmpresa);
        }

        /// <summary>
        /// Permite buscar equipos segun los criterios especificados
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="idArea"></param>
        /// <param name="idFamilia"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<EquipoDTO> BuscarEquipoEvento(int? idEmpresa, int? idArea, int? idFamilia, string filtro, int nroPagina, int nroFilas)
        {
            return FactorySic.ObtenerEventoDao().BuscarEquipoEvento(idEmpresa, idArea, idFamilia, filtro, nroPagina, nroFilas);
        }

        /// <summary>
        /// Permite obtener el nro de items del resultado de la busqueda de equipos
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="idArea"></param>
        /// <param name="idFamilia"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public int ObtenerNroFilasBusquedaEquipo(int? idEmpresa, int? idArea, int? idFamilia, string filtro)
        {
            return FactorySic.ObtenerEventoDao().ObtenerNroFilasBusquedaEquipo(idEmpresa, idArea, idFamilia, filtro);
        }

        /// <summary>
        /// Permite listar las empresas
        /// </summary>
        /// <returns></returns>
        public List<EmpresaDTO> ListarEmpresas()
        {
            return FactorySic.ObtenerEventoDao().ListarEmpresas();
        }

        /// <summary>
        /// Permite listar las empresas por tipo
        /// </summary>
        /// <param name="idTipoEmpresa"></param>
        /// <returns></returns>
        public List<EmpresaDTO> ListarEmpresasPorTipo(int idTipoEmpresa)
        {
            return FactorySic.ObtenerEventoDao().ListarEmpresasPorTipo(idTipoEmpresa);
        }

        /// <summary>
        /// Permite listar las familias
        /// </summary>
        /// <returns></returns>
        public List<FamiliaDTO> ListarFamilias()
        {
            return FactorySic.ObtenerEventoDao().ListarFamilias();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla SI_TIPOEMPRESA
        /// </summary>
        public List<SiTipoempresaDTO> ListarTipoEmpresas()
        {
            return FactorySic.GetSiTipoempresaRepository().List();
        }

        /// <summary>
        /// Permite listar todos los registros de la tabla EVE_CAUSAEVENTO
        /// </summary>
        public List<EveCausaeventoDTO> ListarCausasEventos()
        {
            return FactorySic.GetEveCausaeventoRepository().List();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTipoEvento"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="version"></param>
        /// <param name="turno"></param>
        /// <param name="idTipoEmpresa"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idTipoEquipo"></param>
        /// <param name="informe"></param>
        /// <param name="indInterrupcion"></param>
        /// <param name="nroPage"></param>
        /// <param name="nroFilas"></param>
        /// <returns></returns>
        public List<EveManttoDTO> BuscarMantenimientos(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
            string tiposEmpresa, string empresas, string idsTipoEquipo, string indInterrupcion, string idstipoMantto,string idsEquipos, int nroPagina, int nroFilas)
        {
            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = (new ConsultaMedidoresAppServicio()).ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }
            if (string.IsNullOrEmpty(idsTipoMantenimiento)) idsTipoMantenimiento = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(tiposEmpresa)) tiposEmpresa = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsTipoEquipo)) idsTipoEquipo = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idstipoMantto))
            {
                idstipoMantto = Constantes.ParametroNulo;
                //idsEquipos = Constantes.ParametroNulo;
            }
            if (string.IsNullOrEmpty(idsEquipos)) idsEquipos = Constantes.ParametroNulo;

            return FactorySic.GetEveManttoRepository().BuscarMantenimientos(idsTipoMantenimiento, fechaInicio, fechaFin, tiposEmpresa,
                empresas, idsTipoEquipo, indInterrupcion, idstipoMantto, idsEquipos, nroPagina, nroFilas);
        }


        public int ObtenerNroFilasMantenimiento(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
             string tiposEmpresa, string empresas, string idsTipoEquipo,string idsEquipos, string indInterrupcion, string idstipoMantto)
        {
            if (tiposEmpresa != Constantes.ParametroDefecto && empresas == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = (new ConsultaMedidoresAppServicio()).ObteneEmpresasPorTipo(tiposEmpresa).Select(x => x.Emprcodi).ToList();
                empresas = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }
            if (string.IsNullOrEmpty(idsTipoMantenimiento)) idsTipoMantenimiento = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(tiposEmpresa)) tiposEmpresa = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(empresas)) empresas = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsTipoEquipo)) idsTipoEquipo = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsEquipos)) idsEquipos = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idstipoMantto)) idstipoMantto = Constantes.ParametroNulo;

            return FactorySic.GetEveManttoRepository().ObtenerNroRegistros(idsTipoMantenimiento, fechaInicio,
                fechaFin, tiposEmpresa, empresas, idsTipoEquipo, idsEquipos, indInterrupcion, idstipoMantto);
        }


        public List<EveManttoDTO> GenerarReportesGrafico(string idsTipoMantenimiento, DateTime fechaInicio, DateTime fechaFin,
          string idsTipoEmpresa, string idsEmpresa, string idsTipoEquipo, string indInterrupcion, string idsTipoMantto,string idsEquipo)
        {
            List<EveManttoDTO> entitys = new List<EveManttoDTO>();
            if (idsTipoEmpresa != Constantes.ParametroDefecto && idsEmpresa == Constantes.ParametroDefecto)
            {
                List<int> idsEmpresas = (new ConsultaMedidoresAppServicio()).ObteneEmpresasPorTipo(idsTipoEmpresa).Select(x => x.Emprcodi).ToList();
                idsEmpresa = string.Join<int>(Constantes.CaracterComa.ToString(), idsEmpresas);
            }
            if (string.IsNullOrEmpty(idsTipoMantenimiento)) idsTipoMantenimiento = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsTipoEmpresa)) idsTipoEmpresa = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsEmpresa)) idsEmpresa = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsTipoEquipo)) idsTipoEquipo = Constantes.ParametroNulo;
            if (string.IsNullOrEmpty(idsEquipo)) idsEquipo = Constantes.ParametroNulo;
            entitys = FactorySic.GetEveManttoRepository().ObtenerReporteMantenimientos(idsTipoMantenimiento, fechaInicio, fechaFin,
             idsTipoEmpresa, idsEmpresa, idsTipoEquipo, indInterrupcion, idsTipoMantto,idsEquipo);
            return entitys;
        }

        public List<EveEvenclaseDTO> ListarClaseEventos()
        {
            return FactorySic.GetEveEvenclaseRepository().List();
        }

        /// <summary>
        /// Lista de Equipos por Familia
        /// </summary>
        /// <param name="sCodEquipos"></param>
        /// <returns></returns>
        public List<EqEquipoDTO> ListarEquipos(string sCodEquipos,string sCodEmpresas)
        {
            if (string.IsNullOrEmpty(sCodEquipos)) sCodEquipos = Constantes.ParametroDefecto;
            if (string.IsNullOrEmpty(sCodEmpresas)) sCodEmpresas = Constantes.ParametroDefecto;
            return FactorySic.GetEqEquipoRepository().ListarEquipoxFamilias2(sCodEquipos, sCodEmpresas);
        }

        /// <summary>
        /// Sobreescritura el metodo dispose
        /// </summary>
        public void Dispose()
        {
            
        }      
    }
}
