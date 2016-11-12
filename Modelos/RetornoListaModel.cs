using System.Collections.Generic;

namespace Modelos
{
    public class RetornoListaModel
    {
        public List<ItensListaModel> Itens { get; set; }
        public List<ErroModel> Erros { get; set; }
    }
}
