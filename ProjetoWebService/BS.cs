using DataSharePoint;
using FuncoesAuxiliares;
using Microsoft.SharePoint.Client;
using Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ProjetoWebService
{
    public class BS
    {
        public static RetornoListaModel AcessaSharepointOnline()
        {
            RetornoListaModel resultado = new RetornoListaModel();
            List<ErroModel> listaErros = new List<ErroModel>();
            List<ItensListaModel> listaItens = new List<ItensListaModel>();
            ErroModel registroErro = new ErroModel();
            string lista = "", user = "", password = "", url = "";
            try
            {
                if (url == "") url = ConfigurationManager.AppSettings["siteUrl"].ToString();
                user = ConfigurationManager.AppSettings["User"].ToString();
                password = ConfigurationManager.AppSettings["Password"].ToString();

                ClientContext contextClient = Autenticacao.AutenticaAcessoSPOnline(url, user, password, out registroErro);
                if (registroErro != null)
                {
                    listaErros.Add(registroErro);
                    resultado.Erros = listaErros;
                    return resultado;
                }
                else
                {
                    lista = ConfigurationManager.AppSettings["Lista"].ToString();
                    listaItens = ObtemLista.obtemLista(contextClient, out registroErro, lista);
                    if (registroErro != null)
                    {
                        listaErros.Add(registroErro);
                        resultado.Erros = listaErros;
                    }
                }
            }
            catch (Exception ex)
            {
                listaErros.Add(TratamentoErros.RegistraMensagemErro($"Ocorreu um erro durante a consulta da lista {lista}"));
                listaErros.Add(TratamentoErros.RegistraException(ex));
            }
            resultado.Erros = listaErros;
            resultado.Itens = listaItens;
            return resultado;
        }
    }
}