using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.application.CnabImporter.Classes
{
    public class CnabImportResult
    {
        public int ImportedRecordsCount { get; set; }
        public CnabImportResult() 
        { 
            ImportedRecordsCount = 0;
        }
    }
}
