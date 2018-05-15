using ClientRestNet.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestNet.RequestEntity
{
    public class EmpresaRequest : ClientRest
    {
        public override string GetController()
        {
            return "empresa";
        }


        #region Metodos
        public RespuestaApi<List<EmpresaResponse>> ListarEmpresa(RequestEntity.EmpresaRequest Params)
        {
            WebApiClient WebApiClient = NewWebApiClient();
            return WebApiClient.PostAsJsonAsync<List<EmpresaResponse>>("verempresas", Params);
        }
        #endregion
    }
}