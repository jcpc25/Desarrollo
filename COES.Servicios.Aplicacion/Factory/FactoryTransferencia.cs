using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.Interfaces.Transferencias;
using COES.Infraestructura.Datos.Respositorio.Transferencias;

namespace COES.Servicios.Aplicacion.Factory
{
    public class FactoryTransferencia
    {
        public static string StrConexion = "ContextoSIC";

        public static IAreaRepository GetAreaRepository()
        {
            return new AreaRespository(StrConexion);
        }

        public static IBarraRepository GetBarraRepository()
        {
            return new BarraRespository(StrConexion);
        }

        public static ICentralGeneracionRepository GetCentralGeneracionRepository()
        {
            return new CentralGeneracionRepository(StrConexion);
        }

        public static ICodigoEntregaRepository GetCodigoEntregaRepository()
        {
            return new CodigoEntregaRepository(StrConexion);
        }

        public static ICodigoRetiroRepository GetCodigoRetiroRepository()
        {
            return new CodigoRetiroRepository(StrConexion);
        }

        public static ICodigoRetiroSinContratoRepository GetCodigoRetiroSinContratoRepository()
        {
            return new CodigoRetiroSinContratoRespository(StrConexion);
        }

        public static ICompensacionRepository GetCompensacionRepository()
        {
            return new CompensacionRepository(StrConexion);

        }

        public static ICostoMarginalRepository GetCostoMarginalRepository()
        {
            return new CostoMarginalRepository(StrConexion);
        }

        public static IEmpresaPagoRepository GetEmpresaPagoRepository()
        {
            return new EmpresaPagoRepository(StrConexion);
        }

        public static IEmpresaRepository GetEmpresaRepository()
        {
            return new EmpresaRepository(StrConexion);
        }

        public static IEnvioInformacionRepository GetIEnvioInformacionRepository()
        {
            return new ExportExcelRepository(StrConexion);
        }

        public static IExportExcelRepository GetExportExcelRepository()
        {
            return new ExportExcelGRepository(StrConexion);
        }

        public static IFactorPerdidaRepository GetFactorPerdidaRepository()
        {
            return new FactorPerdidaRepository(StrConexion);
        }

        public static IInfoDesbalanceRepository GetInfoDesbalanceRepository()
        {
            return new InfoDesbalanceRepository(StrConexion);
        }

        public static IInfoDesviacionRepository GetInfoDesviacionRepository()
        {
            return new InfoDesviacionRepository(StrConexion);
        }

        public static IInfoFaltanteRepository GetInfoFaltanteRepository()
        {
            return new InfoFaltanteRepository(StrConexion);
        }

        public static IInformePreliminarRepository GetInformePreliminarRepository()
        {
            return new InformePreliminarRepository(StrConexion);
        }

        public static IIngresoCompensacionRepository GetIngresoCompensacionRepository()
        {
            return new IngresoCompensacionRepository(StrConexion);
        }

        public static IIngresoPotenciaRepository GetIngresoPotenciaRepository()
        {
            return new IngresoPotenciaRepository(StrConexion);
        }

        public static IIngresoRetiroSCRepository GetIngresoRetiroSCRepository()
        {
            return new IngresoRetiroSCRepository(StrConexion);
        }

        public static IPeriodoRepository GetPeriodoRepository()
        {
            return new PeriodoRepository(StrConexion);
        }

        public static IRatioCumplimientoRepository GetRatioCumplimientoRepository()
        {
            return new RatioCumplimientoRepository(StrConexion);
        }

        public static IRecalculoRepository GetRecalculoRepository()
        {
            return new RecalculoRepository(StrConexion);

        }

        public static ISaldoEmpresaRepository GetSaldoEmpresaRepository()
        {
            return new SaldoEmpresaRepository(StrConexion);
        }

        public static ITipoContratoRepository GetTipoContratoRepository()
        {
            return new TipoContratoRespository(StrConexion);
        }

        public static ITipoEmpresaRepository GetTipoEmpresaRepository()
        {
            return new TipoEmpresaRepository(StrConexion);
        }

        public static ITipoTramiteRepository GetTipoTramiteRepository()
        {
            return new TipoTramiteRepository(StrConexion);
        }
        
        public static ITipoUsuarioRepository GetTipoUsuarioRepository()
        {
            return new TipoUsuarioRespository(StrConexion);
        }

        public static ITramiteRepository GetTramiteRepository()
        {
            return new TramiteRepository(StrConexion);
        }

        public static ITransferenciaEntregaRepository GetTransferenciaEntregaRepository()
        {
            return new TransferenciaEntregaRepository(StrConexion);
        }

        public static ITransferenciaEntregaDetalleRepository GetTransferenciaEntregaDetalleRepository()
        {
            return new TransferenciaEntregaDetalleRepository(StrConexion);
        }

        public static ITransferenciaRetiroRepository GetTransferenciaRetiroRepository()
        {
            return new TransferenciaRetiroRepository(StrConexion);
        }

        public static ITransferenciaRetiroDetalleRepository GetTransferenciaRetiroDetalleRepository()
        {
            return new TransferenciaRetiroDetalleRepository(StrConexion);
        }

        public static IValorTransferenciaRepository GetValorTransferenciaRepository()
        {
            return new ValorTransferenciaRepository(StrConexion);
        }
        public static IValorTransferenciaEmpresaRepository GetValorTransferenciaEmpresaRepository()
        {
            return new ValorTransferenciaEmpresaRepository(StrConexion);
        }

        public static IValorTotalEmpresaRepository GetValorTotalEmpresaRepository()
        {
            return new ValorTotalEmpresaRepository(StrConexion);
        }

         public static ISaldoCodigoRetiroSCRepository GetSaldoCodigoRetiroSCRepository()
        {
            return new SaldoCodigoRetiroSCRepository(StrConexion);
        }


 

    }
}
