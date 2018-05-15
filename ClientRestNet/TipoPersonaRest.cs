using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientRestNet.ResponseEntity;


namespace ClientRestNet
{
    public class TipoPersonaRest : ClientRest
    {
        public override string GetController()
        {
            return "tipo_persona";
        }

        #region Metodos
        //public RespuestaApi<List<TipoPersonaResponse>>listarTipoPersona(RequestEntity.TipoPersonaRequest Params)
        //{
        //    WebApiClient WebApiClient = NewWebApiClient();
        //    return WebApiClient.PostAsJsonAsync<List<TipoPersonaResponse>>("vertipopersonas", Params);
        //}
        #endregion
    }
}
