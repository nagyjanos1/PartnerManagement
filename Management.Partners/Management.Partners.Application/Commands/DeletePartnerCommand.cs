using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Commands
{
    public record DeletePartnerCommand : IRequest<Partner>
    {
        public string Id { get; init; }

        internal Guid GetId()
        {
            return Guid.TryParse(Id, out var id) ? id : Guid.Empty;
        }
    }
}
