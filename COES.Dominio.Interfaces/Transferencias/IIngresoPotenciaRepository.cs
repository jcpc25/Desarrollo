using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COES.Dominio.DTO.Transferencias;

namespace COES.Dominio.Interfaces.Transferencias
{
    public interface IIngresoPotenciaRepository
    {
        int Save(IngresoPotenciaDTO entity);
        void Delete(System.Int32 PeriCodi, System.Int32 IngrPoteVersion);
        List<IngresoPotenciaDTO> GetByCodigo(int? pericodi);
        List<IngresoPotenciaDTO> GetByCriteria(int pericodi, int version);
    }
}
