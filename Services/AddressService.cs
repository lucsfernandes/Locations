using Grpc.Core;
using Locations.Data;
using Microsoft.EntityFrameworkCore;

namespace Locations.Services
{
    public class AddressService : Locations.AddressService.AddressServiceBase
    {
        private readonly ILogger<AddressService> _logger;
        private readonly MyDbContext _context;
        public AddressService(ILogger<AddressService> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<ListResponse> Get(ListParam request, ServerCallContext context)
        {
            var items = _context.Address
                .Where(x => x.professional_id == request.ProfessionalId)
                .Select(x => new ListResponse.Types.Address
                {
                    Id = x.id,
                    Cep = x.cep,
                    Address_ = x.address,
                    Number = x.number,
                    Complement = x.complement,
                    Neighborhood = x.neighborhood,
                    City = x.city,
                    ProfessionalId = x.professional_id
                }).ToList();

            var response = new ListResponse();
            response.Addresses.AddRange(items);
            Console.WriteLine(response);

            return Task.FromResult(response);
        }

        public override Task<CreateResponse> Create(CreateParams request, ServerCallContext context)
        {
            var result = _context.Address.Add(new Locations.Models.Address() 
            { 
                type = request.Type,
                cep = request.Cep, 
                address = request.Address,
                number = request.Number,
                complement = request.Complement,
                neighborhood = request.Neighborhood,
                city = request.City,
                uf = request.Uf,
                country = request.Country,
                latitude = request.Latitude,
                longitude = request.Longitude,
                professional_id = request.ProfessionalId,
                patient_id = request.PatientId,
                createdAt = DateTime.Now,
            });
            _context.SaveChanges();

            var id = result.Entity.id;

            return Task.FromResult(new CreateResponse()
            {
                Id = id,
            });

        }

        public override Task<UpdateResponse> Update(UpdateParams request, ServerCallContext context)
        {
            var result = _context.Address.Update(new Locations.Models.Address()
            {
                type = request.Type,
                cep = request.Cep,
                address = request.Address,
                number = request.Number,
                complement = request.Complement,
                neighborhood = request.Neighborhood,
                city = request.City,
                uf = request.Uf,
                country = request.Country,
                latitude = request.Latitude,
                longitude = request.Longitude,
                professional_id = request.ProfessionalId,
                patient_id = request.PatientId,
                updatedAt = DateTime.Now,
            });
            _context.SaveChanges();

            return Task.FromResult(new UpdateResponse()
            {
                AddressId = result.Entity.id
            });
        }
    }
}