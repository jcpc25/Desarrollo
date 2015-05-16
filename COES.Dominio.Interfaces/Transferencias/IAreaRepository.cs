using COES.Dominio.DTO.Transferencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IAreaRepository
    {
        AreaDTO GetById(System.Int32 id);
        List<AreaDTO> List();
        List<AreaDTO> GetByCriteria(string nombre);
    }
}
