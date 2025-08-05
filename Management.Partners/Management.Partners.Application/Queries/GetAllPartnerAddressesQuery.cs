using System.Linq.Expressions;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Queries;

public record GetAllPartnerAddressesQuery : QueryBase, IRequest<IReadOnlyCollection<Address>>
{
    public string PartnerId { get; init; }

    public Expression<Func<Address, object>> OrderByExpr => x => x.Name;
}
