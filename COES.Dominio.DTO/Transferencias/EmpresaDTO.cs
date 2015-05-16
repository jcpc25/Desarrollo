using System;
using System.Collections.Generic;
using COES.Base.Core;

namespace COES.Dominio.DTO.Transferencias
{
    /// <summary>
    /// Clase de mapeo de la tabla SI_EMPRESA
    /// </summary>
    public class EmpresaDTO
    {
        public System.Int32 EmprCodi { get; set; }
        public System.String EmprNombre { get; set; }
        public System.Int32 TipoEmprCodi { get; set; }
        
    }
}
