using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
   public interface IRatioCumplimientoRepository
    {
       
       List<RatioCumplimientoDTO> GetByCodigo(int? tipoemprcodi, int? pericodi);
       List<RatioCumplimientoDTO> GetByCriteria(string nombre);
    }
}
