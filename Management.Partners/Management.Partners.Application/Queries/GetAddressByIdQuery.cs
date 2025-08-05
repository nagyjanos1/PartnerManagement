using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Queries;

public record GetAddressByIdQuery : IdQuery, IRequest<Address>
{
    public GetAddressByIdQuery(Guid id)
    {
        Id = id;
    }
}
