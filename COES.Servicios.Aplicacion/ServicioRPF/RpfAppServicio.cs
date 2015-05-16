using COES.Base.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Sic;

namespace COES.Servicios.Aplicacion.ServicioRPF
{
    public class RpfAppServicio : AppServicioBase
    {
        /// <summary>
        /// Permite obtener el listado de unidades que deben cargar
        /// </summary>
        /// <returns></returns>
        public List<ServicioRpfDTO> ObtenerUnidadesCarga()
        {
            return Factory.FactorySic.ObtenerServicioRpfDao().GetByCriteria();
        }

        /// <summary>
        /// Permite obtener la reserva primaria en un instante de tiempo
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public decimal? ObtenerReservaPrimaria(DateTime fecha)
        {
            return Factory.FactorySic.ObtenerServicioRpfDao().ObtenerReservaPrimaria(fecha);            
        }

        /// <summary>
        /// Permite obtener la frecuencia de los últimos 10 segundos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<decimal> ObtenerFrecuenciasSanJuan(DateTime fecha)
        {
            return Factory.FactorySic.ObtenerServicioRpfDao().ObtenerFrecuenciasSanJuan(fecha);
        }

        /// <summary>
        /// Permite obtener las frecuencias de las 600 segundos de SE San Juan
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<decimal> ObtenerFrecuenciaSanJuanTotal(DateTime fecha)
        {
            return Factory.FactorySic.ObtenerServicioRpfDao().ObtenerFrecuenciaSanJuanTotal(fecha);
        }

        /// <summary>
        /// Permite obtener las frecuencias para la evaluación de consistencia
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<decimal> ObtenerFrecuenciasComparacion(DateTime fecha)
        {
            return Factory.FactorySic.ObtenerServicioRpfDao().ObtenerFrecuenciasComparacion(fecha);
        }

        /// <summary>
        /// Permite determinar el estado operativo de una unidad
        /// </summary>
        /// <param name="equicodi"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public int ObtenerEstadoOperativo(int equicodi, DateTime fecha)
        {
            return Factory.FactorySic.ObtenerServicioRpfDao().ValidarExistenciaHoraOperacion(equicodi, fecha);            
        }

        /// <summary>
        /// Permite listar las gps del coes
        /// </summary>
        /// <returns></returns>
        public List<ServicioGps> ObtenerGPS(DateTime fecha)
        {            
            return Factory.FactorySic.ObtenerServicioRpfDao().ObtenerGPS(fecha);
        }

        /// <summary>
        /// Permite listar las frecuencias de un gps
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="gpsCodi"></param>
        /// <returns></returns>
        public List<ServicioGps> ObtenerConsultaFrecuencia(DateTime fecha, int gpsCodi)
        {            
            return Factory.FactorySic.ObtenerServicioRpfDao().ObtenerConsultaFrecuencia(fecha, gpsCodi);
        }

        /// <summary>
        /// Permite reemplazar los valoes de las frecuencias entre dos gps
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="gpsOrigen"></param>
        /// <param name="gpsDestino"></param>
        public void ReemplazarFrecuencias(DateTime fecha, int gpsOrigen, int gpsDestino) 
        {
            try
            {
                Factory.FactorySic.ObtenerServicioRpfDao().ReemplazarFrecuencias(fecha, gpsOrigen, gpsDestino);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }   

    }
}
