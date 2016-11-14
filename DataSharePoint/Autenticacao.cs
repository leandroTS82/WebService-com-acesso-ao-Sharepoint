using Microsoft.SharePoint.Client;
using Modelos;
using System;
using System.Security;

namespace DataSharePoint
{
    public static class Autenticacao
    {
        public static ClientContext AutenticaAcessoSPOnline(string url, string user, string password, out ErroModel registroErro)
        {
            ClientContext clientContex = new ClientContext(url);
            registroErro = null;
            try
            {
                var passWord = new SecureString();
                foreach (char c in password.ToCharArray()) passWord.AppendChar(c);
                clientContex.Credentials = new SharePointOnlineCredentials(user, passWord);
                clientContex.ExecuteQuery();
                return clientContex;
            }
            catch (Exception ex)
            {
                registroErro.Mensagem = $"O correu um erro durante a autenticação no sharepoint online no site {url}. {ex.Message}";
                registroErro.Detalhes = ex.StackTrace;
                registroErro.AppOrObjeto = ex.Source;
                return clientContex;
            }

        }
        
        private ClientContext AutenticaAcessoSP2010(string url, string user, string password, out ErroModel registroErro)
        {
            ClientContext clientContext = new ClientContext(url);
            registroErro = null;
            try
            {
                NetworkCredential credencial = new NetworkCredential(user, password, url);
                clientContext.Credentials = credencial;
                Web web = clientContext.Web;
                clientContext.Load(web);
                clientContext.Load(web, website => website.Title);
                clientContext.Load(web.Webs);

                CredentialCache cc = new CredentialCache();
                cc.Add(new Uri(url), "NTLM", CredentialCache.DefaultNetworkCredentials);
                clientContext.Credentials = cc;
                clientContext.AuthenticationMode = ClientAuthenticationMode.Default;

                clientContext.ExecuteQuery();
            }
            catch (Exception ex)
            {
                registroErro.Mensagem = $"Ocorreu um erro ao configurar as credenciais. {ex.Message}";
                registroErro.Detalhes = ex.StackTrace;
                registroErro.AppOrObjeto = ex.Source;
                return clientContex;
            }

            return clientContext;
        }
    }
}
