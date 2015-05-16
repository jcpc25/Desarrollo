using System;
using COES.Dominio.Interfaces.Scada;
using COES.Dominio.Interfaces.Sic;
using COES.Infraestructura.Datos.Respositorio.Sic;
using COES.Infraestructura.Datos.Respositorio;

namespace COES.Servicios.Aplicacion.Factory
{
    /// <summary>
    /// Clase que permite crear objetos repositorio
    /// </summary>
    public class FactorySic
    {
        public static string StrConexion = "ContextoSIC";
        public static string StrConexionSCADA = "ContextoSCADA";

        public static IEmpresaRepository GetEmpresaRepository()
        {
            return new EmpresaRepository(StrConexion);
        }

        public static EveEventoRepository ObtenerEventoDao()
        {
            return new EveEventoRepository(StrConexion);
        }

        public static ISiEmpresaRepository GetSiEmpresaRepository()
        {
            return new SiEmpresaRepository(StrConexion);
        }


        public static EveTipoEventoRepository ObtenerTipoEventoDao()
        {
            return new EveTipoEventoRepository(StrConexion);
        }

        public static EveSubCausaEventoRepository ObtenerSubCausaEventoDao()
        {
            return new EveSubCausaEventoRepository(StrConexion);
        }

        public static IRpfEnergiaPotenciaRepository GetRPFhidraulicoRepository()
        {
            return new RpfEnergiaPotenciaRepository(StrConexion);
        }

        public static EveInformePerturbacionRepository ObtenerInformePerturbacionDao()
        {
            return new EveInformePerturbacionRepository(StrConexion);
        }

        public static EjecutadoRuleRepository ObtenerEjecutadoRuleDao()
        {
            return new EjecutadoRuleRepository(StrConexion);
        }

        public static ScadaRepository ObtenerScadaSICDao()
        {
            return new ScadaRepository(StrConexion);
        }

        public static ScadaRepository ObtenerScadaTRDao()   
        {
            return new ScadaRepository(StrConexionSCADA);
        }

        public static ServicioRpfRepository ObtenerServicioRpfDao()
        {
            return new ServicioRpfRepository(StrConexion);
        }

        public static IeodCuadroRepository ObtenerIeodCuadroDao()
        {
            return new IeodCuadroRepository(StrConexion);
        }

        public static ParametroRpfRepository ObtenerParametroRpfDao()
        {
            return new ParametroRpfRepository(StrConexion);
        }

        public static IEqFamiliaRepository GetEqFamiliaRepository()
        {
            return new EqFamiliaRepository(StrConexion);
        }

        public static IMeMedicion48Repository GetMeMedicion48Repository()
        {
            return new MeMedicion48Repository(StrConexion);
        }

        public static IMeMedicion96Repository GetMeMedicion96Repository()
        {
            return new MeMedicion96Repository(StrConexion);
        }

        public static IDesviacionRepository GetDesviacionRepositoryOracle()
        {
            return new DesviacionRepository(StrConexion);
        }

        public static IPrCombustibleRepository GetPrCombustibleRepository()
        {
            return new PrCombustibleRepository(StrConexion);
        }

        public static IPrGrupoRepository GetPrGrupoRepository()
        {
            return new PrGrupoRepository(StrConexion);
        }

        public static IEqEquipoRepository GetEqEquipoRepository()
        {
            return new EqEquipoRepository(StrConexion);
        }

        public static ISiFuenteenergiaRepository GetSiFuenteenergiaRepository()
        {
            return new SiFuenteenergiaRepository(StrConexion);
        }

        public static IMePerfilRuleRepository GetMePerfilRuleRepository()
        {
            return new MePerfilRuleRepository(StrConexion);
        }

        public static IMePerfilRuleRepository GetMePerfilRuleScadaRepository()
        {
            return new MePerfilRuleRepository(StrConexionSCADA);
        }

        public static IMePerfilRuleAreaRepository GetMePerfilRuleAreaRepository()
        {
            return new MePerfilRuleAreaRepository(StrConexion);
        }

        public static ISiTipoempresaRepository GetSiTipoempresaRepository()
        {
            return new SiTipoempresaRepository(StrConexion);
        }

        public static IEveCausaeventoRepository GetEveCausaeventoRepository()
        {
            return new EveCausaeventoRepository(StrConexion);
        }

        public static IPrTipogrupoRepository GetPrTipogrupoRepository()
        {
            return new PrTipogrupoRepository(StrConexion);
        }

        public static IWbGeneracionrerRepository GetWbGeneracionrerRepository()
        {
            return new WbGeneracionrerRepository(StrConexion);
        }

        public static IManRegistroRepository GetManRegistroRepository()
        {
            return new ManRegistroRepository(StrConexion);        
        }

        public static IEqAreaRepository GetEqAreaRepository()
        {
            return new EqAreaRepository(StrConexion);
        }

        public static IEqEquirelRepository GetEqEquirelRepository()
        {
            return new EqEquirelRepository(StrConexion);
        }

        public static IEqFamrelRepository GetEqFamrelRepository()
        {
            return new EqFamrelRepository(StrConexion);
        }

        public static IEqPropequiRepository GetEqPropequiRepository()
        {
            return new EqPropequiRepository(StrConexion);
        }

        public static IEqPropiedadRepository GetEqPropiedadRepository()
        {
            return new EqPropiedadRepository(StrConexion);
        }

        public static IEqRelacionRepository GetEqRelacionRepository()
        {
            return new EqRelacionRepository(StrConexion);
        }

        public static IEqTipoareaRepository GetEqTipoareaRepository()
        {
            return new EqTipoareaRepository(StrConexion);
        }

        public static IEqTiporelRepository GetEqTiporelRepository()
        {
            return new EqTiporelRepository(StrConexion);
        }

        public static IManManttoRepository GetManManttoRepository()
        {
            return new ManManttoRepository(StrConexion);
        }

        public static IExtLogenvioRepository GetExtLogenvioRepository()
        {
            return new ExtLogenvioRepository(StrConexion);
        }
        
        public static ISiTipogeneracionRepository GetSiTipogeneracionRepository()
        {
            return new SiTipogeneracionRepository(StrConexion);
        }

        public static IPrConceptoRepository GetPrConceptoRepository()
        {
            return new PrConceptoRepository(StrConexion);
        }

        public static IPrGrupodatRepository GetPrGrupodatRepository()
        {
            return new PrGrupodatRepository(StrConexion);
        }

        public static IPrEquipodatRepository GetPrEquipodatRepository()
        {
            return new PrEquipodatRepository(StrConexion);
        }

        public static IEveEvenclaseRepository GetEveEvenclaseRepository()
        {
            return new EveEvenclaseRepository(StrConexion);
        }

        public static IEveManttoRepository GetEveManttoRepository()
        {
            return new EveManttoRepository(StrConexion);
        }

        public static IMePtomedicionRepository GetMePtomedicionRepository()
        {
            return new MePtomedicionRepository(StrConexion);
        }

        public static IMdPublicacionRepository GetMdPublicacionRepository()
        {
            return new MdPublicacionRepository(StrConexion);
        }

        public static IExtArchivoRepository GetExtArchivoRepository()
        {
            return new ExtArchivoRepository(StrConexion);
        }

        public static IExtLogproRepository GetExtLogproRepository()
        {
            return new ExtLogproRepository(StrConexion);
        }

        public static IMdCambioenvioRepository GetMdCambioenvioRepository()
        {
            return new MdCambioenvioRepository(StrConexion);
        }

        public static IMdEnvioRepository GetMdEnvioRepository()
        {
            return new MdEnvioRepository(StrConexion);
        }

        public static IMdValidacionRepository GetMdValidacionRepository()
        {
            return new MdValidacionRepository(StrConexion);
        }

        public static IMeOrigenlecturaRepository GetMeOrigenlecturaRepository()
        {
            return new MeOrigenlecturaRepository(StrConexion);
        }

        public static IMeLecturaRepository GetMeLecturaRepository()
        {
            return new MeLecturaRepository(StrConexion);
        }

        public static ISiTipoinformacionRepository GetSiTipoinformacionRepository()
        {
            return new SiTipoinformacionRepository(StrConexion);
        }

        public static IMeTipopuntomedicionRepository GetMeTipopuntomedicionRepository()
        {
            return new MeTipopuntomedicionRepository(StrConexion);
        }

        public static IFwCounterRepository GetFwCounterRepository()
        {
            return new FwCounterRepository(StrConexion);
        }

        public static IMeFormatoRepository GetMeFormatoRepository()
        {
            return new MeFormatoRepository(StrConexion);
        }

        public static IMeFormatohojaRepository GetMeFormatohojaRepository()
        {
            return new MeFormatohojaRepository(StrConexion);
        }

        public static IMeHojaptomedRepository GetMeHojaptomedRepository()
        {
            return new MeHojaptomedRepository(StrConexion);
        }

        public static IFwAreaRepository GetFwAreaRepository()
        {
            return new FwAreaRepository(StrConexion);
        }
        
        public static IMeMedidorRepository GetMeMedidorRepository()
        {
            return new MeMedidorRepository(StrConexion);
        }

        public static IMePeriodomedidorRepository GetMePeriodomedidorRepository()
        {
            return new MePeriodomedidorRepository(StrConexion);
        }

        public static IMeAmpliacionfechaRepository GetMeAmpliacionfechaRepository()
        {
            return new MeAmpliacionfechaRepository(StrConexion);
        }
        public static IMeHeadcolumnRepository GetMeHeadcolumnRepository()
        {
            return new MeHeadcolumnRepository(StrConexion);
        }

        public static IMeMedicion24Repository GetMeMedicion24Repository()
        {
            return new MeMedicion24Repository(StrConexion);
        }

        public static IMeMedicion1Repository GetMeMedicion1Repository()
        {
            return new MeMedicion1Repository(StrConexion);
        }

        ///////// Combustibles /////////

        public static IExtEstadoEnvioRepository GetExtEstadoEnvioRepository()
        {
            return new ExtEstadoEnvioRepository(StrConexion);
        }

        public static ICbCombustibledatosRepository GetCbCombustibledatosRepository()
        {
            return new CbCombustibledatosRepository(StrConexion);
        }

        public static ICbConceptocombRepository GetCbConceptocombRepository()
        {
            return new CbConceptocombRepository(StrConexion);
        }
        public static ICbEnvioRepository GetCbEnvioRepository()
        {
            return new CbEnvioRepository(StrConexion);
        }

        public static ICbArchivoEnvioRepository GetCbArchivoEnvioRepository()
        {
            return new CbArchivoEnvioRepository(StrConexion);
        }


        ///////////////////////////////

        public static IWbMedidoresValidacionRepository GetWbMedidoresValidacionRepository()
        {
            return new WbMedidoresValidacionRepository(StrConexion);
        }

        public static IEnEnsayoRepository GetEnEnsayoRepository()
        {
            return new EnEnsayoRepository(StrConexion);
        }

        public static IEnEnsayoformatoRepository GetEnEnsayoformatoRepository()
        {
            return new EnEnsayoformatoRepository(StrConexion);
        }

        public static IEnEnsayounidadRepository GetEnEnsayounidadRepository()
        {
            return new EnEnsayounidadRepository(StrConexion);
        }

        public static IEnFormatoRepository GetEnFormatoRepository()
        {
            return new EnFormatoRepository(StrConexion);
        }

        public static IEnEstensayoRepository GetEnEstensayoRepository()
        {
            return new EnEstensayoRepository(StrConexion);
        }

        public static IEnEstadosRepository GetEnEstadosRepository()
        {
            return new EnEstadoRepository(StrConexion);
        }
        public static IEnEstformatoRepository GetEnEstformatoRepository()
        {
            return new EnEstformatoRepository(StrConexion);
        }
        public static IEnEstformatoRepository GetEnEstformatoRepositori()
        {
            return new EnEstformatoRepository(StrConexion);
        }

    }
}
