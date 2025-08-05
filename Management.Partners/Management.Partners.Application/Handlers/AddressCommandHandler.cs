using Management.Partners.Application.Commands;
using Management.Partners.Application.Exceptions;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Handlers;

internal class AddressCommandHandler : 
    IRequestHandler<AddAddressCommand, Address>, 
    IRequestHandler<UpdateAddressCommand, Address>,
    IRequestHandler<DeleteAddressCommand, Address>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Address> Handle(AddAddressCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var address = request.MapToModel();

        await repository.AddAsync(address).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return address;
    }

    public async Task<Address> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var address = request.MapToModel();

        repository.Update(address);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return address;
    }

    public async Task<Address> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var addressId = request.GetId();

        if (addressId == Guid.Empty)
        {
            throw new PartnerBusinessException("Hibás Id");
        }

        var address = await repository.GetAsync(addressId).ConfigureAwait(false);

        repository.Remove(address);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return address;
    }
}
