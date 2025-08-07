using AutoMapper;
using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Application.Partners.Queries;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Management.Partners.Application.Partners.Handlers;

internal class PartnerQueryHandler :
    IRequestHandler<GetPartnerByIdQuery, PartnerDto>,
    IRequestHandler<GetAllPartnersQuery, IReadOnlyCollection<PartnerListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<PartnerQueryHandler> _logger;

    public PartnerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PartnerQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PartnerDto> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partner = await repository.GetAsync(x => x.Id == request.Id).ConfigureAwait(false);

        return _mapper.Map<PartnerDto>(partner);
    }

    public async Task<IReadOnlyCollection<PartnerListDto>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partners = await repository.GetAllAsync(request.OrderByExpr, request.IsDescending, request.Skip, request.Take).ConfigureAwait(false);

        return partners.Select(_mapper.Map<PartnerListDto>).ToList();
    }
}
