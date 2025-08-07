using System.Linq.Expressions;
using Management.Partners.Application.Common;
using Management.Partners.Application.Contracts.Dtos;
using Management.Partners.Domain.Contracts;
using MediatR;

namespace Management.Partners.Application.Contracts.Queries;

public record GetAllContractsQuery : QueryBase, IRequest<IReadOnlyCollection<ContractListDto>>
{
    public Expression<Func<Contract, string>> OrderByExpr => x => x.Subject;
}