using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Sic
{
    public class TipoEventoDTO
    {
        public short TIPOEVENCODI { get; set; }
        public string TIPOEVENDESC { get; set; }
        public Nullable<short> SUBCAUSACODI { get; set; }
        public string TIPOEVENABREV { get; set; }
    }
}
