using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.domain.Enums
{
    public enum TipoTransacao
    {
        Debito = 1, //Entrada
        Boleto = 2, //Saída
        Financiamento = 3, //Saída
        Credito = 4, //Entrada 	
        RecebimentoEmprestimo = 5, //Entrada
        Vendas = 6, //Entrada
        RecebimentoTed = 7, //Entrada
        RecebimentoDoc = 8, //Entrada
        Aluguel = 9 //Saída 
    }
}
