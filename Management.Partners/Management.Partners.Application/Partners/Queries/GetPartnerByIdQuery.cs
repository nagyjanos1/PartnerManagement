using Management.Partners.Application.Common;
using Management.Partners.Application.Partners.Dtos;
using MediatR;

namespace Management.Partners.Application.Partners.Queries;

public record GetPartnerByIdQuery : IdQuery, IRequest<PartnerDto>
{
    public GetPartnerByIdQuery(Guid id)
    {
        Id = id;
    }
}
