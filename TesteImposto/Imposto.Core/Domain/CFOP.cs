using System.Collections.Generic;
using System.Linq;

namespace Imposto.Core.Domain
{
    public class Cfop
    {
        private string EstadoOrigem { get; set; }
        private string EstadoDestino { get; set; }
        private string Valor { get; set; }

        private static IEnumerable<Cfop> Get()
        {
            var list = new List<Cfop>
            {
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "RJ", Valor = "6.000"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "PE", Valor = "6.001"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "MG", Valor = "6.002"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "PB", Valor = "6.003"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "PR", Valor = "6.004"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "PI", Valor = "6.005"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "RO", Valor = "6.006"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "SE", Valor = "6.007"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "TO", Valor = "6.008"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "SP", Valor = "6.009"},
                new Cfop() {EstadoOrigem = "SP", EstadoDestino = "PA", Valor = "6.010"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "RJ", Valor = "6.000"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "PE", Valor = "6.001"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "MG", Valor = "6.002"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "PB", Valor = "6.003"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "PR", Valor = "6.004"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "PI", Valor = "6.005"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "RO", Valor = "6.006"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "SE", Valor = "6.007"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "TO", Valor = "6.008"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "SP", Valor = "6.009"},
                new Cfop() {EstadoOrigem = "MG", EstadoDestino = "PA", Valor = "6.010"}
            };

            return list;
        }

        public string ObterValor(string estadoOrigem, string estadoDestino)
        {
            var resultado = Get()
                .FirstOrDefault(x => x.EstadoDestino.ToLower() == estadoDestino.ToLower() && x.EstadoOrigem.ToLower() == estadoOrigem.ToLower());
            return resultado != null ? resultado.Valor : "";
        }
    }
}
