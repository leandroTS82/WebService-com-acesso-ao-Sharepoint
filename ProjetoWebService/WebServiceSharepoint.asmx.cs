using System.Web.Services;
using Modelos;
using DataSharePoint;

namespace ProjetoWebService
{
    /// <summary>
    /// Summary description for WebServiceSharepoint
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceSharepoint : System.Web.Services.WebService
    {
        [WebMethod]
        public RetornoListaModel ObtemLista()
        {
            RetornoListaModel retorno = BS.AcessaSharepointOnline();
            return retorno;
        }
    }
}
