using Management.Partners.Application.Common;
using Management.Partners.Application.Contracts.Dtos;
using MediatR;

namespace Management.Partners.Application.Contracts.Queries;

public record GetContractByIdQuery : IdQuery, IRequest<ContractDto>
{
    public GetContractByIdQuery(Guid id)
    {
        Id = id;
    }
}