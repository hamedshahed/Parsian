using MediatR;

namespace Parsian.Command;

public record RegisterVehicleCommand(string Plaque) : IRequest;