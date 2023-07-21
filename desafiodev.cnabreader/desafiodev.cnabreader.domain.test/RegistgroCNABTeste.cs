using desafiodev.cnabreader.domain.Enums;
using desafiodev.cnabreader.domain.Exceptions;

namespace desafiodev.cnabreader.domain.test
{
    public class RegistgroCNABTeste
    {
        [Theory]
        [InlineData("3201903010000014200096206760174753****3153153453JOÃO MACEDO   BAR DO JOÃO       ")]
        [InlineData("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ")]
        [InlineData("3201903010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA")]
        public void Deve_Reconstruir_Linha_Original_Apos_Parsear_Corretamente_A_Mesma(string linhaCnab)
        {
            var cnab = RegistroCNAB.NewFromParse(linhaCnab);
            var rebuiltCnab = cnab.ToString();            
            Assert.True(rebuiltCnab == linhaCnab);
        }

        [Theory]
        [InlineData("3201903010000014200096206760174753****3153153453JOÃO MACEDO   BAR DO JOÃO       ", TipoTransacao.Financiamento, 142.00, "01/03/2019 15:34:53", "09620676017", "4753****3153", "JOÃO MACEDO", "BAR DO JOÃO")]
        [InlineData("5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ", TipoTransacao.RecebimentoEmprestimo, 132.00, "01/03/2019 14:56:07", "55641815063", "3123****7687", "MARIA JOSEFINA", "LOJA DO Ó - MATRIZ")]
        [InlineData("3201903010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA", TipoTransacao.Financiamento, 122.00, "01/03/2019 17:27:12", "84515254073", "6777****1313", "MARCOS PEREIRA", "MERCADO DA AVENIDA")]
        public void Deve_Parsear_Corretamente_A_Linha(string linhaCnab, TipoTransacao tipoEsperado, double valorEsperado, string dataHoraEsperada, string cpfEsperado, string cartaoEsperado, string donoEsperado, string lojaEsperada) 
        {
            var cnab = RegistroCNAB.NewFromParse(linhaCnab);
            Assert.True(cnab.TipoTransacao == tipoEsperado);
            Assert.True(cnab.Valor == valorEsperado);
            Assert.True(cnab.DataHora.ToString("dd/MM/yyyy HH:mm:ss") == dataHoraEsperada);
            Assert.True(cnab.CpfBeneficiario == cpfEsperado);
            Assert.True(cnab.CartaoUtilizado == cartaoEsperado);
            Assert.True(cnab.ProprietarioLoja == donoEsperado);
            Assert.True(cnab.NomeLoja == lojaEsperada);
        }

        [Theory]
        [InlineData("LINHA QUALQUER")]
        [InlineData("ESCREVI E SAI CORRENDO")]
        [InlineData("0201903010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA")]
        [InlineData("320yy03010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA")]
        [InlineData("32019030100000122,00845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA")]
        [InlineData("3201903010000012200845152540736777****1313172712MARCOS PEREIRA")]
        [InlineData("3201903010000012200845.152.540-736777****1313172712MARCOS PEREIRA")]
        public void Deve_Gerar_Excecao_Ao_Parsear_Linha_Invalida(string linhaCnab)
        {
            Assert.Throws<CnabParserException>(() => { var cnab = RegistroCNAB.NewFromParse(linhaCnab); });
        }
    }
}