using System.Web.Services;

namespace UsandoWebServiceParaConectarAoSharepoint
{
    /// <summary>
    /// Consulta site sharepoint e retorna itens
    /// </summary>
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string ConsultaSiteSharePoint()
        {
            return "";
        }
    }
}
