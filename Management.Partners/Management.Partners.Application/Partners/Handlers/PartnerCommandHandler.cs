using AutoMapper;
using Management.Partners.Application.Exceptions;
using Management.Partners.Application.Partners.Commands;
using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Partners.Handlers;

internal class PartnerCommandHandler :
    IRequestHandler<AddPartnerCommand, PartnerDto>,
    IRequestHandler<UpdatePartnerCommand, PartnerDto>,
    IRequestHandler<DeletePartnerCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PartnerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PartnerDto> Handle(AddPartnerCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partner = request.MapToDomain();

        await repository.AddAsync(partner).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<PartnerDto>(partner);
    }
    
    public async Task<PartnerDto> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partner = request.MapToDomain();

        repository.Update(partner);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<PartnerDto>(partner);
    }

    public async Task<Unit> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        if (request.Id == Guid.Empty)
        {
            throw new PartnerBusinessException("Hibás Id");
        }

        var partner = await repository.GetAsync(request.Id).ConfigureAwait(false);

        repository.Remove(partner);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return new Unit();
    }
}
