using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientRestNet.ResponseEntity;


namespace ClientRestNet
{
    public class PersonaRest : ClientRest
    {

        public override string GetController()
        {
            return "persona";
        }


        #region Metodos
        public RespuestaApi<List<PersonaResponse>> ListarPersona(RequestEntity.PersonaRequest Params)
        {
            WebApiClient WebApiClient = NewWebApiClient();
            return WebApiClient.PostAsJsonAsync<List<PersonaResponse>>("verpersonas", Params);
        }
        #endregion
        public RespuestaApi<PersonaResponse> Login(RequestEntity.PersonaRequest Params)
        {
            WebApiClient WebApiClient = NewWebApiClient();
            return WebApiClient.PostAsJsonAsync<PersonaResponse>("login", Params);
        }
    }
}
