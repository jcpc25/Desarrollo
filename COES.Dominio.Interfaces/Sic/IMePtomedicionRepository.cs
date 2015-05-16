using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_PTOMEDICION
    /// </summary>
    public interface IMePtomedicionRepository
    {
        void Save(MePtomedicionDTO entity);
        void Update(MePtomedicionDTO entity);
        void Delete(int ptomedicodi);
        MePtomedicionDTO GetById(int ptomedicodi);
        List<MePtomedicionDTO> List();
        List<MePtomedicionDTO> GetByCriteria(string empresas, string idsOriglectura, string idsTipoptomedicion);
        List<MePtomedicionDTO> ListarPtoMedicion(string listapto);
        List<MePtomedicionDTO> GetByIdEquipo(int equicodi);
        List<MePtomedicionDTO> ListarPtoDuplicado(int equipo, int origen, int tipopto);
        List<MePtomedicionDTO> ListarDetallePtoMedicionFiltro(string empresas, string idsOriglectura, string idsTipoptomedicion, int nroPaginas, int pageSize);
        int ObtenerTotalPtomedicion(string empresas, string idsOriglectura, string idsTipoptomedicion);
    }
}
