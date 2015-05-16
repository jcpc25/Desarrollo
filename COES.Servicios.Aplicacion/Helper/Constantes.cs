using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Servicios.Aplicacion.Helper
{
    public class Constantes
    {
        public const string LogError = "ERROR.APLICACION";
        public const string SI = "S";
        public const string NO = "N";
        public const string Activo = "A";
        public const char CaracterComa = ',';
        public const string ParametroDefecto = "-1";
        public const string ParametroNoExiste = "-1000";
        public const string CaracterH = "H";
        public const string ParametroNulo = "-2";
    }

    /// <summary>
    /// Constantes utilizadas en el módulo de eventos
    /// </summary>
    public class ConstantesEvento
    {
        public const string Turno1 = "1";
        public const string Turno2 = "2";
        public const string Turno3 = "3";
        public const string FiltroFechaEvento = " and ( evenini >= TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS') and evenini < TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')) ";
        public const string FormatoFecha = "yyyy-MM-dd";
        public const string FormatoFechaExtendido = "yyyy-MM-dd HH:mm:ss";
        public const string SI = "S";
        public const string NO = "N";
    }

    /// <summary>
    /// Constantes utilizadas en el módulo de fórmulas scada
    /// </summary>
    public class ConstanteFormulaScada
    {
        public const char Scada = 'D';
        public const char Medicion = 'S';
        public const char SeparadorFormula = '+';
        public const string CaracterComa = ",";
        public const string SI = "S";
        public const string NO = "N";
        public const string OrigenSCADA = "S";
        public const string OrigenEjecutado = "M";
        public const string OrigenDemanda = "D";
        public const string FuenteEjecutado = "E";
        public const string FuenteDemanda = "D";   

        public const string TextoSCADA = "SCADA";
        public const string TextoEjecutado = "Ejecutado";
        public const string TextoDemanda = "Demanda barras";
    }

    /// <summary>
    /// Constantes para los puntos de medición
    /// </summary>
    public class ConstantesMedicion
    {
        public const int OrigenLecturaGeneracionRER = 15;
        public const int LecturaProgDiaraRER = 61;
        public const int LecturaProgSemanalRER = 62;
        public const int TipoInformacionRER = 1;
        public const string TextoNoEnvio = "No envió";
    }

}
