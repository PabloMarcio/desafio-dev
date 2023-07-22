using desafiodev.cnabreader.application.CnabImporter.Requests;
using desafiodev.cnabreader.application.CnabImporter.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.application.Interfaces
{
    public interface ICnabImporterService
    {
        Task<CnabImporterResponse> Importar(CnabImporterRequest request);
    }
}
