using System.Linq.Expressions;
using Management.Partners.Application.Common;
using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Partners.Queries;

public record GetAllPartnersQuery : QueryBase, IRequest<IReadOnlyCollection<PartnerListDto>>
{
    public Expression<Func<Partner, string>> OrderByExpr => x => x.Name;
}
