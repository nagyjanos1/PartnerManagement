using System.Linq.Expressions;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Queries
{
    public record GetAllPartnersQuery : QueryBase, IRequest<IReadOnlyCollection<Partner>>
    {
        public Expression<Func<Partner, string>> OrderByExpr => x => x.Name;
    }
}
