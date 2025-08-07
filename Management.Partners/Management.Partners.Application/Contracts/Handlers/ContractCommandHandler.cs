using AutoMapper;
using Management.Partners.Application.Exceptions;
using Management.Partners.Application.Contracts.Commands;
using Management.Partners.Application.Contracts.Dtos;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Contracts;
using MediatR;

namespace Management.Partners.Application.Contracts.Handlers;

internal class ContractCommandHandler :
    IRequestHandler<AddContractCommand, ContractDto>,
    IRequestHandler<UpdateContractCommand, ContractDto>,
    IRequestHandler<DeleteContractCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContractCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ContractDto> Handle(AddContractCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Contract>();

        var contract = request.MapToDomain();

        await repository.AddAsync(contract).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<ContractDto>(contract);
    }
    
    public async Task<ContractDto> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Contract>();

        var contract = request.MapToDomain();

        repository.Update(contract);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<ContractDto>(contract);
    }

    public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Contract>();

        if (request.Id == Guid.Empty)
        {
            throw new PartnerBusinessException("Hibás Id");
        }

        var contract = await repository.GetAsync(request.Id).ConfigureAwait(false);

        repository.Remove(contract);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return new Unit();
    }
}