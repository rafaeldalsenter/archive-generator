using System;
using Archive.Generator.PropertiesAttributes;

namespace Archive.Generator.Example.Objects
{
    public class Header : BaseArchiveGenerator
    {
        [Order(1)]
        [Size(1)]
        [Int(' ')]
        public int IdentificacaoDoRegistro { get; set; }

        [Order(2)]
        [Size(1)]
        [Int(' ')]
        public int IdentificacaoDoArquivoRemessa { get; set; }

        [Order(3)]
        [Size(7)]
        public string LiteralRemessa { get; set; }

        [Order(4)]
        [Size(2)]
        [Int(' ')]
        public int CodigoDeServico { get; set; }

        [Order(5)]
        [Size(15)]
        public string LiteralServico { get; set; }

        [Order(6)]
        [Size(20)]
        [Int(' ')]
        public int CodigoDaEmpresa { get; set; }

        [Order(7)]
        [Size(30)]
        public string NomeDaEmpresa { get; set; }

        [Order(8)]
        [Size(3)]
        [Int(' ')]
        public int NumeroDoBradescoNaCamaraDeCompensacao { get; set; }

        [Order(9)]
        [Size(15)]
        public string NomeDoBancoPorExtenso { get; set; }

        [Order(10)]
        [DateTimeFormatter("yyMMdd")]
        public DateTime DataDeGravacaoDoArquivo { get; set; }

        [Order(11)]
        [Size(8)]
        public string Branco1 { get; set; }

        [Order(12)]
        [Size(2)]
        public string IdentificacaoDoSistema { get; set; }

        [Order(13)]
        [Size(7)]
        [Int(' ')]
        public int NumeroSequencialDaRemessa { get; set; }

        [Order(14)]
        [Size(277)]
        public string Branco2 { get; set; }

        [Order(15)]
        [Size(6)]
        [Int(' ')]
        public int NumeroSequenciaDoRegistroDeUmEmUm { get; set; }
    }
}