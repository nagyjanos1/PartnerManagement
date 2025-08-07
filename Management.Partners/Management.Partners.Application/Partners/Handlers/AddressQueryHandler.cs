using AutoMapper;
using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Application.Partners.Queries;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Management.Partners.Application.Partners.Handlers;

internal class AddressQueryHandler :
    IRequestHandler<GetAddressByIdQuery, AddressDto>,
    IRequestHandler<GetAllPartnerAddressesQuery, IReadOnlyCollection<AddressDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<AddressQueryHandler> _logger;

    public AddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddressQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var address = await repository.GetAsync(x => x.Id == request.Id).ConfigureAwait(false);

        return _mapper.Map<AddressDto>(address);
    }

    public async Task<IReadOnlyCollection<AddressDto>> Handle(GetAllPartnerAddressesQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var addresses = await repository.GetAllAsync(x => x.PartnerId == request.PartnerId, request.OrderByExpr, request.IsDescending,
            request.Skip, request.Take).ConfigureAwait(false);

        return [.. addresses.Select(_mapper.Map<AddressDto>)];
    }
}
