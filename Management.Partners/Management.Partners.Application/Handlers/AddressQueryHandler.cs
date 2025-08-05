using Management.Partners.Application.Queries;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Management.Partners.Application.Handlers;

internal class AddressQueryHandler :
    IRequestHandler<GetAddressByIdQuery, Address>,
    IRequestHandler<GetAllPartnerAddressesQuery, IReadOnlyCollection<Address>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AddressQueryHandler> _logger;

    public AddressQueryHandler(IUnitOfWork unitOfWork, ILogger<AddressQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Address> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var address = await repository.GetAsync(x => x.Id == request.Id).ConfigureAwait(false);

        return address;
    }

    public async Task<IReadOnlyCollection<Address>> Handle(GetAllPartnerAddressesQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var addresses = await repository.GetAllAsync(x => x.PartnerId == request.PartnerId, request.OrderByExpr, request.IsDescending,
            request.Skip, request.Take).ConfigureAwait(false);

        return addresses.ToList();
    }
}
