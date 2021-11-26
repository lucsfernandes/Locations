using Grpc.Core;
using Locations.Data;
using SearchAddressApi;

namespace Locations.Services
{
    public class SearchAddressService : SearchAddressApi.SearchAddressService.SearchAddressServiceBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<SearchAddressService> _logger;

        public SearchAddressService(MyDbContext context, ILogger<SearchAddressService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public override Task<ListUfResponse> ListUf(GetParams request, ServerCallContext context)
        {
            var result = _context.SearchAddress
                .GroupBy(x => new
                {
                    UF = x.UF,
                })
                .Select(g => new ListUfResponse.Types.Uf() 
                {
                    UF = g.Key.UF
                }).ToList();

            var response = new ListUfResponse();
            response.Ufs.AddRange(result);


            return Task.FromResult(response);

        }

        public override Task<SearchAddressApi.ListResponse> ListAddress(ListCep request, ServerCallContext context)
        {
            var items = _context.SearchAddress
                .Where(x => x.CEP == request.CEP)
                .Select(x => new
                {
                    CEP = x.CEP,
                    UF = x.UF,
                    Endereco = $"{x.Tipo_Acento} {x.Nome_Acento}",
                    Bairro1_Acento = x.Bairro1_Acento,
                    Cidade_Acento = x.Cidade_Acento,
                    latitude = x.latitude,
                    longitude = x.longitude,
                }).ToList();

            var first = items.First();

            return Task.FromResult(new SearchAddressApi.ListResponse
            {
                CEP = first.CEP,
                UF = first.UF,
                Endereco = first.Endereco,
                Bairro1Acento = first.Bairro1_Acento,
                CidadeAcento = first.Cidade_Acento,
                Latitude = first.latitude,
                Longitude = first.longitude,
            });

        }

    }
}
