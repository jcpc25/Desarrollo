using System;
using System.Collections.Generic;
using COES.Dominio.DTO.Sic;
using COES.Base.Core;

namespace COES.Dominio.Interfaces.Sic
{
    /// <summary>
    /// Interface de acceso a datos de la tabla ME_TIPOPUNTOMEDICION
    /// </summary>
    public interface IMeTipopuntomedicionRepository
    {
        int Save(MeTipopuntomedicionDTO entity);
        void Update(MeTipopuntomedicionDTO entity);
        void Delete(int tipoptomedicodi);
        MeTipopuntomedicionDTO GetById(int tipoptomedicodi);
        List<MeTipopuntomedicionDTO> List(string origlectcodi);
        List<MeTipopuntomedicionDTO> GetByCriteria();
    }
}
