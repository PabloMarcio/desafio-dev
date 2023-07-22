using desafiodev.cnabreader.api.Controllers.Base;
using desafiodev.cnabreader.application.CnabImporter.Requests;
using desafiodev.cnabreader.application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafiodev.cnabreader.api.Controllers.Cnab
{
    [ApiController]
    [Route("[controller]")]
    public class CnabController : ApiController
    {
        private readonly ICnabImporterService _cnabImporterService;

        public CnabController(ICnabImporterService cnabImporterService)
        {
            _cnabImporterService = cnabImporterService;    
        }

        [HttpPost]
        [Route("importar")]
        public async Task<ActionResult> Importar(CnabImporterRequest request)
        {
            return CustomResponse(await _cnabImporterService.Importar(request));
        }
    }
}
