using Archive.Generator.Example.Objects;
using System;

namespace Archive.Generator.Example
{
    public class GeneratorExample
    {
        public Header GerarHeader(string nomeDaEmpresa)
            => new Header
            {
                IdentificacaoDoRegistro = 0,
                IdentificacaoDoArquivoRemessa = 1,
                LiteralRemessa = "REMESSA",
                CodigoDeServico = 1,
                LiteralServico = "COBRANCA",
                CodigoDaEmpresa = 10, // Número ficticio
                NomeDaEmpresa = nomeDaEmpresa,
                NumeroDoBradescoNaCamaraDeCompensacao = 237,
                NomeDoBancoPorExtenso = "Bradesco",
                DataDeGravacaoDoArquivo = DateTime.Now,
                IdentificacaoDoSistema = "MX",
                NumeroSequencialDaRemessa = 1,
                NumeroSequenciaDoRegistroDeUmEmUm = 1
            };
    }
}