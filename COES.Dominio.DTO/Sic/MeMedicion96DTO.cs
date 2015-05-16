using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.DTO.Sic
{
    public class MeMedicion96DTO
    {
        public int Lectcodi { get; set; }
        public int Origlectcodi { get; set; }
        public DateTime? Medifecha { get; set; }
        public int Tipoinfocodi { get; set; }
        public string Ptomedielenomb { get; set; }
        public string Gruponomb { get; set; }

        public int Ptomedicodi { get; set; }
        public decimal? Meditotal { get; set; }
        public string Mediestado { get; set; }

        public int Equipadre { get; set; }
        public string Central { get; set; }
        public int Equicodi { get; set; }
        public string Equinomb { get; set; }
        public int Emprcodi { get; set; }
        public string Emprnomb { get; set; }
        public int Fenergcodi { get; set; }
        public string Fenergnomb { get; set; }
        public string Fenergabrev { get; set; }
        public int Tipogrupocodi { get; set; }
        public int Tgenercodi { get; set; }
        public string Tgenernomb { get; set; }            
        public string Tipoinfoabrev { get; set; }
        public int Tipoptomedicodi { get; set; }
        public string Tipoptomedinomb { get; set; }

        public decimal? H1 { get; set; }
        public decimal? H2 { get; set; }
        public decimal? H3 { get; set; }
        public decimal? H4 { get; set; }
        public decimal? H5 { get; set; }
        public decimal? H6 { get; set; }
        public decimal? H7 { get; set; }
        public decimal? H8 { get; set; }
        public decimal? H9 { get; set; }
        public decimal? H10 { get; set; }
        public decimal? H11 { get; set; }
        public decimal? H12 { get; set; }
        public decimal? H13 { get; set; }
        public decimal? H14 { get; set; }
        public decimal? H15 { get; set; }
        public decimal? H16 { get; set; }
        public decimal? H17 { get; set; }
        public decimal? H18 { get; set; }
        public decimal? H19 { get; set; }
        public decimal? H20 { get; set; }
        public decimal? H21 { get; set; }
        public decimal? H22 { get; set; }
        public decimal? H23 { get; set; }
        public decimal? H24 { get; set; }
        public decimal? H25 { get; set; }
        public decimal? H26 { get; set; }
        public decimal? H27 { get; set; }
        public decimal? H28 { get; set; }
        public decimal? H29 { get; set; }
        public decimal? H30 { get; set; }
        public decimal? H31 { get; set; }
        public decimal? H32 { get; set; }
        public decimal? H33 { get; set; }
        public decimal? H34 { get; set; }
        public decimal? H35 { get; set; }
        public decimal? H36 { get; set; }
        public decimal? H37 { get; set; }
        public decimal? H38 { get; set; }
        public decimal? H39 { get; set; }
        public decimal? H40 { get; set; }
        public decimal? H41 { get; set; }
        public decimal? H42 { get; set; }
        public decimal? H43 { get; set; }
        public decimal? H44 { get; set; }
        public decimal? H45 { get; set; }
        public decimal? H46 { get; set; }
        public decimal? H47 { get; set; }
        public decimal? H48 { get; set; }
        public decimal? H49 { get; set; }
        public decimal? H50 { get; set; }
        public decimal? H51 { get; set; }
        public decimal? H52 { get; set; }
        public decimal? H53 { get; set; }
        public decimal? H54 { get; set; }
        public decimal? H55 { get; set; }
        public decimal? H56 { get; set; }
        public decimal? H57 { get; set; }
        public decimal? H58 { get; set; }
        public decimal? H59 { get; set; }
        public decimal? H60 { get; set; }
        public decimal? H61 { get; set; }
        public decimal? H62 { get; set; }
        public decimal? H63 { get; set; }
        public decimal? H64 { get; set; }
        public decimal? H65 { get; set; }
        public decimal? H66 { get; set; }
        public decimal? H67 { get; set; }
        public decimal? H68 { get; set; }
        public decimal? H69 { get; set; }
        public decimal? H70 { get; set; }
        public decimal? H71 { get; set; }
        public decimal? H72 { get; set; }
        public decimal? H73 { get; set; }
        public decimal? H74 { get; set; }
        public decimal? H75 { get; set; }
        public decimal? H76 { get; set; }
        public decimal? H77 { get; set; }
        public decimal? H78 { get; set; }
        public decimal? H79 { get; set; }
        public decimal? H80 { get; set; }
        public decimal? H81 { get; set; }
        public decimal? H82 { get; set; }
        public decimal? H83 { get; set; }
        public decimal? H84 { get; set; }
        public decimal? H85 { get; set; }
        public decimal? H86 { get; set; }
        public decimal? H87 { get; set; }
        public decimal? H88 { get; set; }
        public decimal? H89 { get; set; }
        public decimal? H90 { get; set; }
        public decimal? H91 { get; set; }
        public decimal? H92 { get; set; }
        public decimal? H93 { get; set; }
        public decimal? H94 { get; set; }
        public decimal? H95 { get; set; }
        public decimal? H96 { get; set; }
    }


    public class MedicionReporteDTO
    {
        public int NroItem { get; set; }
        public string Emprnomb { get; set; }
        public string Central { get; set; }
        public string Unidad { get; set; }
        public int Tgenercodi { get; set; }
        public string Tgenernomb { get; set; }
        public int Fenergcodi { get; set; }
        public string Fenergnomb { get; set; }
        public decimal Total { get; set; }
        public decimal MaximaDemanda { get; set; }
        public decimal MinimaDemanda { get; set; }
        public bool IndicadorTotal { get; set; }
        public bool IndicadorTotalGeneral { get; set; }
        public decimal Hidraulico { get; set; }
        public decimal Solar { get; set; }
        public decimal Termico { get; set; }
        public decimal Eolico { get; set; }

        public DateTime FechaMaximaDemanda { get; set; }
        public DateTime FechaMinimaDemanda { get; set; }
        public int HoraMaximaDemanda { get; set; }
        public int HoraMinimaDemanda { get; set; }

        public DateTime MaximaDemandaHora { get; set; }
        public DateTime MinimaDemandaHora { get; set; }

        public decimal BloqueMaximaDemanda { get; set; }
        public decimal BloqueMediaDemanda { get; set; }
        public decimal BloqueMinimaDemanda { get; set; }

        public int BloqueMaximaHora { get; set; }
        public int BloqueMediaHora { get; set; }
        public int BloqueMinimaHora { get; set; }

        public DateTime HoraBloqueMaxima { get; set; }
        public DateTime HoraBloqueMedia { get; set; }
        public DateTime HoraBloqueMinima { get; set; }

        public decimal EnergiaFuenteEnergia { get; set; }
        public decimal MDFuenteEnergia { get; set; }

        public int Anio { get; set; }
        public int Mes { get; set; }
        public string DiaHoraMD { get; set; }
        public decimal ValorMD { get; set; }
        public int EmprCodi { get; set; }
        public int CentralCodi { get; set; }
        public int EquiCodi { get; set; }
        public int Indice { get; set; }
    }
}
