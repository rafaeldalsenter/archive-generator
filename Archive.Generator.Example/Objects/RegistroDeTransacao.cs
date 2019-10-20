using System;
using System.Collections.Generic;
using System.Text;
using Archive.Generator.PropertiesAttributes;

namespace Archive.Generator.Example.Objects
{
    public class RegistroDeTransacao : BaseArchiveGenerator
    {
        [Order(1)]
        [Size(1)]
        [Int(' ')]
        public int IdentificacaoDoRegistro { get; set; }

        [Order(2)]
        [Size(5)]
        [Int(' ')]
        public int? AgenciaDeDebito { get; set; }

        [Order(3)]
        [Size(1)]
        public string DigitoDaAgenciaDeDebito { get; set; }

        [Order(4)]
        [Size(5)]
        public string RazaoDaContaCorrente { get; set; }

        [Order(5)]
        [Size(5)]
        [Int(' ')]
        public int? ContaCorrente { get; set; }

        [Order(6)]
        [Size(1)]
        public string DigitoDaContaCorrente { get; set; }

        [Order(7)]
        [Size(17)]
        public string IdentificacaoDaEmpresaBeneficiariaNoBanco { get; set; }

        [Order(8)]
        [Size(25)]
        public string NumeroDeControleDoParticipante { get; set; }

        [Order(9)]
        [Size(3)]
        [Int(' ')]
        public int CodigoDoBancoASerDebitado { get; set; }

        [Order(10)]
        [Size(1)]
        [Int(' ')]
        public int CampoDeMulta { get; set; }

        [Order(11)]
        [Size(4)]
        [Int(' ')]
        public int PercentualDeMulta { get; set; }

        [Order(12)]
        [Size(11)]
        [Int(' ')]
        public long IdentificacaoDoTituloNoBanco { get; set; }
    }
}