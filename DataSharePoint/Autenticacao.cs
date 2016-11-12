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
    }
}
