using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.domain.Exceptions
{
    public class CnabParserException : Exception
    {
        public CnabParserException(string message) : base(message) 
        {
                
        }
    }
}
