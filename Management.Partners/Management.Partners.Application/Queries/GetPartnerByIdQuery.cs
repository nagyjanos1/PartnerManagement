using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Queries
{
    public record GetPartnerByIdQuery : IdQuery, IRequest<Partner>
    {
        public GetPartnerByIdQuery(string id)
        {
            Id = id;
        }
    }
}
