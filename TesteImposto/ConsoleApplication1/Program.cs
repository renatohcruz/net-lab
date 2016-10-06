using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Data.Contracts;
using Imposto.Core.Data.Repository;
using Imposto.Core.Factory;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nota = Factory.CreateInstance<INotaFiscalRepository, NotaFiscalRepository>();
            var cfop = new Cfop();
            var resultado = cfop.ObterValor("SP", "RJ");

            var notaFiscal = Factory.CreateInstance<NotaFiscal, NotaFiscal>();

            Console.WriteLine(nota.PegarProximoNumeroNotaFiscal());
            Console.ReadKey();
        }
    }
}
