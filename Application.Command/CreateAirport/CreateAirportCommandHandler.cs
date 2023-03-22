using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace Application.Commands
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Airport>
    {
        private readonly IAirportRepository _airportRepository;

        public CreateAirportCommandHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<Airport> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            // Create a new Airport object using the request data.
            var airport = _airportRepository.Add(new Airport(request.Code, request.Name));
            // Save the changes to the repository.
            await _airportRepository.UnitOfWork.SaveEntitiesAsync();
            // Return the newly created Airport object.
            return airport;
        }
    }
}