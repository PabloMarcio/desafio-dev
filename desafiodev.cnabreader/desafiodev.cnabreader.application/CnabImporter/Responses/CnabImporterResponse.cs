using desafiodev.cnabreader.application.CnabImporter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.application.CnabImporter.Responses
{
    public class CnabImporterResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public CnabImportResult ImportResult { get; set; }
        public List<CnabImporterTotalizer> Totalizers { get; set; }

        public CnabImporterResponse(bool success)
        {
            Success = success;
            Errors = new();
            ImportResult = new();
            Totalizers = new();
        }        
    }
}
