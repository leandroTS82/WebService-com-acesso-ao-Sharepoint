using System;
using Modelos;
namespace FuncoesAuxiliares
{
    public class TratamentoErros
    {
        public static ErroModel RegistraMensagemErro(string msg)
        {
            ErroModel erro = new ErroModel();
            erro.Mensagem = msg;
            return erro;
        }

        public static ErroModel RegistraException(Exception ex)
        {
            ErroModel erro = new ErroModel();
            erro.Mensagem = ex.Message;
            erro.AppOrObjeto = ex.Source;
            erro.Detalhes = ex.StackTrace;
            return erro;
        }      
    }
}
