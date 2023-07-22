using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.application.CnabImporter.Classes
{
    public class CnabImporterTotalizer
    {
        public string NomeLoja { get; internal set; }
        public double SaldoOperacoes { get; internal set; }
        public CnabImporterTotalizer(string nomeLoja)
        {
            NomeLoja = nomeLoja;
            SaldoOperacoes = 0;
        }

        public void Adicionar(double valor)
        {
            SaldoOperacoes += valor;
        }

        public void Subtrair(double valor) 
        {  
            SaldoOperacoes -= valor;
        }
    }
}
