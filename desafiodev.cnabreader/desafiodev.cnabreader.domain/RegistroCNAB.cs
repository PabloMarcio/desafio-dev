using desafiodev.cnabreader.domain.Enums;
using desafiodev.cnabreader.domain.Exceptions;
using System.Drawing;

namespace desafiodev.cnabreader.domain
{
    public class RegistroCNAB
    {
        public TipoTransacao TipoTransacao { get; internal set; }
        public DateTime DataHora { get; internal set; }
        public double Valor { get; internal set; }
        public string CpfBeneficiario { get; internal set; }
        public string CartaoUtilizado { get; internal set; }
        public string ProprietarioLoja { get; internal set; }
        public string NomeLoja { get; internal set; }

        internal RegistroCNAB(TipoTransacao tipo, DateTime dataHora, double valor, string cpf, string cartao, string donoLoja, string nomeLoja)
        {
            TipoTransacao = tipo;
            DataHora = dataHora;
            Valor = valor;
            CpfBeneficiario = cpf; 
            CartaoUtilizado = cartao;
            ProprietarioLoja = donoLoja;
            NomeLoja = nomeLoja;
        }

        public static RegistroCNAB NewFromParse(string cnabLinha)
        {
            try
            {
                var tipo = cnabLinha.Substring(0, 1);
                var data = cnabLinha.Substring(1, 8);
                var valor = cnabLinha.Substring(9, 10);
                var cpf = cnabLinha.Substring(19, 11);
                var cartao = cnabLinha.Substring(30, 12);
                var hora = cnabLinha.Substring(42, 6);
                var dono = cnabLinha.Substring(48, 14).Trim();
                var loja = cnabLinha.Substring(62, 18).Trim(); // o arquivo enviado no github contém apenas 18 de tamanho para este campo, embora a documentação especifique 19

                return new RegistroCNAB(ObterTipo(tipo), ObterDataHora(data, hora), ObterValor(valor), cpf, cartao, dono, loja);

            }
            catch (CnabParserException cnabEx)
            {
                throw cnabEx;
            }
            catch (Exception ex)
            {
                throw new CnabParserException($"A linha fornecida não atende ao layout especificado. Erro de parse: {ex.Message}");
            }
        }

        private static double ObterValor(string valor)
        {
            try
            {
                return Convert.ToInt32(valor) / 100;
            }
            catch (Exception)
            {
                throw new CnabParserException($"Não foi possível normalizar o campo Valor. Conteúdo: {valor}");
            }
        }

        private static DateTime ObterDataHora(string data, string hora)
        {
            try
            {
                var ano = Convert.ToInt32(data.Substring(0, 4));
                var mes = Convert.ToInt32(data.Substring(4, 2));
                var dia = Convert.ToInt32(data.Substring(6, 2));
                var hh = Convert.ToInt32(hora.Substring(0, 2));
                var mm = Convert.ToInt32(hora.Substring(2, 2));
                var ss = Convert.ToInt32(hora.Substring(4, 2));
                return new DateTime(ano, mes, dia, hh, mm, ss);
            }
            catch (Exception) 
            {
                throw new CnabParserException($"Não foi possível normalizar os campos Data/Hora. Conteúdo de Data: {data}. Conteúdo de Hora: {hora}");
            }
            
        }

        private static TipoTransacao ObterTipo(string tipo)
        {
            try
            {
                if (("123456789".Contains(tipo) && tipo.Length == 1) == false)
                    throw new CnabParserException($"Não foi possível obter o tipo da transação. Conteúdo de Tipo: {tipo}");
                return (TipoTransacao)Convert.ToInt32(tipo);
            }
            catch (Exception)
            {
                throw new CnabParserException($"Não foi possível obter o tipo da transação. Conteúdo de Tipo: {tipo}");
            }                
        }

        public override string ToString()
        {
            var tipo = Convert.ToInt32(TipoTransacao).ToString();
            var data = DataHora.ToString("yyyyMMdd");
            var valor = (Valor * 100).ToString().PadLeft(10, '0');
            var cpf = CpfBeneficiario.PadLeft(11, '0');
            var cartao = CartaoUtilizado.PadLeft(12, '0');
            var hora = DataHora.ToString("HHmmss");
            var dono = ProprietarioLoja.PadRight(14, ' ');
            var loja = NomeLoja.PadRight(18, ' '); // o arquivo enviado no github contém apenas 18 de tamanho para este campo, embora a documentação especifique 19
            return $"{tipo}{data}{valor}{cpf}{cartao}{hora}{dono}{loja}";
        }
    }
}