using desafiodev.cnabreader.application.CnabImporter.Classes;
using desafiodev.cnabreader.application.CnabImporter.Requests;
using desafiodev.cnabreader.application.CnabImporter.Responses;
using desafiodev.cnabreader.application.Interfaces;
using desafiodev.cnabreader.domain;
using desafiodev.cnabreader.domain.Exceptions;
using desafiodev.infra.crosscutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiodev.cnabreader.application.CnabImporter
{
    public class CnabImporterService : ICnabImporterService
    {
        public async Task<CnabImporterResponse> Importar(CnabImporterRequest request)
        {
            var contents = request.Content.FromBase64();
            var lines = new List<string>(contents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            var response = new CnabImporterResponse(false);
            var registrosImportados = new List<RegistroCNAB>();
            var linhaNumero = 0;
            foreach (var line in lines)
            {
                try
                {
                    linhaNumero++;
                    var registroCnab = RegistroCNAB.NewFromParse(line);
                    registrosImportados.Add(registroCnab);
                    Totalize(response, registroCnab);                    
                }
                catch (CnabParserException e)
                {
                    response.Errors.Add($"Erro ao importar a linha {linhaNumero}: {e.Message}. Conteúdo da linha: {line}");
                }                    
            }
            if (registrosImportados.Any()) 
            {
                response.Success = true;
                response.ImportResult.ImportedRecordsCount = registrosImportados.Count;
            }

            return response;
        }

        private void Totalize(CnabImporterResponse response, RegistroCNAB registroCnab)
        {
            var totalizer = response.Totalizers.Where(x => x.NomeLoja == registroCnab.NomeLoja).FirstOrDefault();
            if (totalizer == null)
            {
                totalizer = new CnabImporterTotalizer(registroCnab.NomeLoja);
                response.Totalizers.Add(totalizer);
            }
            if (RegistroCNAB.IsTipoEntrada(registroCnab.TipoTransacao))
            {
                totalizer.Adicionar(registroCnab.Valor);
            }
            else
            {
                totalizer.Subtrair(registroCnab.Valor);
            }
        }
    }
}
