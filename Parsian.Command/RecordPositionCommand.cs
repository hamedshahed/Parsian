using MediatR;

namespace Parsian.Command;

public record RecordPositionCommand(string Plaque, double Latitude, double Longitude, DateTime DateTime) : IRequest;