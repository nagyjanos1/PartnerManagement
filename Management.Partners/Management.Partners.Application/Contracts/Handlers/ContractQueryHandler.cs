using AutoMapper;
using Management.Partners.Application.Contracts.Dtos;
using Management.Partners.Application.Contracts.Queries;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Management.Partners.Application.Contracts.Handlers;

internal class ContractQueryHandler :
    IRequestHandler<GetContractByIdQuery, ContractDto>,
    IRequestHandler<GetAllContractsQuery, IReadOnlyCollection<ContractListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ContractQueryHandler> _logger;

    public ContractQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ContractQueryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ContractDto> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Contract>();

        var contract = await repository.GetAsync(x => x.Id == request.Id).ConfigureAwait(false);

        return _mapper.Map<ContractDto>(contract);
    }

    public async Task<IReadOnlyCollection<ContractListDto>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Contract>();

        var contracts = await repository.GetAllAsync(request.OrderByExpr, request.IsDescending, request.Skip, request.Take).ConfigureAwait(false);

        return [.. contracts.Select(_mapper.Map<ContractListDto>)];
    }
}