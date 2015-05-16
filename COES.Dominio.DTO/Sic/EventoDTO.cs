using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    public class EventoDTO
    {
        public string EQUIABREV { get; set; }
        public int? EVENCODI { get; set; }
        public int? EMPRCODI { get; set; }
        public int? EQUICODI { get; set; }
        public int? TIPOEVENCODI { get; set; }
        public DateTime? EVENINI { get; set; }
        public DateTime? EVENFIN { get; set; }
        public int? EVENPADRE { get; set; }
        public int? FAMCODI { get; set; }
        public int? AREACODI { get; set; }
        public string SUBCAUSAABREV { get; set; }
        public int? SUBCAUSACODI { get; set; }
        public string TIPOEVENABREV { get; set; }
        public string AREANOMB { get; set; }
        public string EVENINTERRUP { get; set; }
        public string FAMABREV { get; set; }
        public string TAREAABREV { get; set; }
        public string EMPRNOMB { get; set; }
        public int? TAREACODI { get; set; }
        public string LASTUSER { get; set; }
        public DateTime? LASTDATE { get; set; }
        public string EVENASUNTO { get; set; }
        public string EVENPRELIMINAR { get; set; }
        public string CAUSAEVENABREV { get; set; }
        public int? EVENRELEVANTE { get; set; }
        public Nullable<short> EMPRCODIRESPON { get; set; }
        public Nullable<short> EVENCLASECODI { get; set; }
        public Nullable<decimal> EVENMWINDISP { get; set; }
        public Nullable<System.DateTime> EVENPREINI { get; set; }
        public Nullable<System.DateTime> EVENPOSTFIN { get; set; }
        public string EVENDESC { get; set; }
        public Nullable<decimal> EVENTENSION { get; set; }
        public string EVENAOPERA { get; set; }
        public string EVENCTAF { get; set; }
        public string EVENINFFALLA { get; set; }
        public string EVENINFFALLAN2 { get; set; }
        public string DELETED { get; set; }
        public string EVENTIPOFALLA { get; set; }
        public string EVENTIPOFALLAFASE { get; set; }
        public string SMSENVIADO { get; set; }
        public string SMSENVIAR { get; set; }
        public string EVENACTUACION { get; set; }
        public string EVENCOMENTARIOS { get; set; }
        public string EVENPERTURBACION { get; set; }
        public string TIPOEMPRDESC { get; set; }
        public Nullable<decimal> EQUITENSION { get; set; }
        public Nullable<decimal> ENERGIAINTERRUMPIDA { get; set; }
        public Nullable<decimal> INTERRUPCIONMW { get; set; }
        public Nullable<decimal> DISMINUCIONMW { get; set; }
        public double DURACION { get; set; }


    }
}
