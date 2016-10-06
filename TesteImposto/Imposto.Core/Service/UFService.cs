using System.Configuration;
using System.Linq;

namespace Imposto.Core.Service
{
    public class UfService
    {
        private readonly string[] _unidadesFederacaoSudeste;
        private readonly string[] _unidadesFederacao;

        public UfService()
        {
            _unidadesFederacaoSudeste = ConfigurationManager.AppSettings["UnidadesFederacaoSudeste"].Split('|');
            _unidadesFederacao = ConfigurationManager.AppSettings["UnidadesFederacao"].Split('|');
        }

        public UfService(string unidadesFederacaoSudeste, string unidadesFederacao)
        {
            _unidadesFederacaoSudeste = unidadesFederacaoSudeste.Split('|');
            _unidadesFederacao = unidadesFederacao.Split('|');
        }

        public bool EhUnidadeFederacaoSudeste(string estadoDestino)
        {
            return _unidadesFederacaoSudeste.Contains(estadoDestino.ToUpper());
        }

        public  bool EhUnidadeFederacao(string estado)
        {
            return _unidadesFederacao.Contains(estado.ToUpper());
        }
    }
}
