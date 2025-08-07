using System.Linq.Expressions;
using Management.Partners.Application.Common;
using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Partners.Queries;

public record GetAllPartnerAddressesQuery : QueryBase, IRequest<IReadOnlyCollection<AddressDto>>
{
    public string PartnerId { get; init; }

    public Expression<Func<Address, object>> OrderByExpr => x => x.Name;
}
