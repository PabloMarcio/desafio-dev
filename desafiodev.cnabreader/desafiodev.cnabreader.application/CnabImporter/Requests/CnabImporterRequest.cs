using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.application.CnabImporter.Requests
{
    public class CnabImporterRequest
    {
        public string Content { get; set; }
        public CnabImporterRequest()
        {
            Content = string.Empty;
        }
    }
}
