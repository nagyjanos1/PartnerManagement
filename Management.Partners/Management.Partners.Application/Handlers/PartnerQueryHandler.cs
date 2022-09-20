using Management.Partners.Application.Queries;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Management.Partners.Application.Handlers
{
    internal class PartnerQueryHandler :
        IRequestHandler<GetPartnerByIdQuery, Partner>,
        IRequestHandler<GetAllPartnersQuery, IReadOnlyCollection<Partner>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartnerQueryHandler(IUnitOfWork unitOfWork, ILogger<PartnerQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Partner> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Partner>();

            var partner = await repository.GetAsync(x => x.Id == request.Id).ConfigureAwait(false);

            return partner;
        }

        public async Task<IReadOnlyCollection<Partner>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Partner>();

            var partners = await repository.GetAllAsync(request.OrderByExpr, request.IsDescending, request.Skip, request.Take).ConfigureAwait(false);

            return partners.ToList();
        }
    }
}
