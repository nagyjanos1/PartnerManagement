using Management.Partners.Application.Common;
using Management.Partners.Application.Partners.Dtos;
using MediatR;

namespace Management.Partners.Application.Partners.Queries;

public record GetAddressByIdQuery : IdQuery, IRequest<AddressDto>
{
    public GetAddressByIdQuery(Guid id)
    {
        Id = id;
    }
}
