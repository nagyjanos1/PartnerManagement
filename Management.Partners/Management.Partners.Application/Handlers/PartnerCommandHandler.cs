using Management.Partners.Application.Commands;
using Management.Partners.Application.Exceptions;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Handlers;

internal class PartnerCommandHandler :
    IRequestHandler<AddPartnerCommand, Partner>,
    IRequestHandler<UpdatePartnerCommand, Partner>,
    IRequestHandler<DeletePartnerCommand, Partner>
{
    private readonly IUnitOfWork _unitOfWork;

    public PartnerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Partner> Handle(AddPartnerCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partner = request.MapToModel();

        await repository.AddAsync(partner).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return partner;
    }
    
    public async Task<Partner> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partner = request.MapToModel();

        repository.Update(partner);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return partner;
    }

    public async Task<Partner> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Partner>();

        var partnerId = request.GetId();

        if (partnerId == Guid.Empty)
        {
            throw new PartnerBusinessException("Hibás Id");
        }

        var partner = await repository.GetAsync(partnerId).ConfigureAwait(false);

        repository.Remove(partner);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return partner;
    }
}
