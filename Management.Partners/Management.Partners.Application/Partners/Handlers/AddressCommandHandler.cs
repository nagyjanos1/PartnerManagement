using AutoMapper;
using Management.Partners.Application.Exceptions;
using Management.Partners.Application.Partners.Commands;
using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Domain.Partners;
using MediatR;

namespace Management.Partners.Application.Partners.Handlers;

internal class AddressCommandHandler :
    IRequestHandler<AddAddressCommand, AddressDto>, 
    IRequestHandler<UpdateAddressCommand, AddressDto>,
    IRequestHandler<DeleteAddressCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AddressDto> Handle(AddAddressCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var address = request.MapToDomain();

        await repository.AddAsync(address).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<AddressDto>(address);
    }

    public async Task<AddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        var address = request.MapToDomain();

        repository.Update(address);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<AddressDto>(address);
    }

    public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Address>();

        if (request.Id == Guid.Empty)
        {
            throw new PartnerBusinessException("Hibás Id");
        }

        var address = await repository.GetAsync(request.Id).ConfigureAwait(false);

        repository.Remove(address);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return new Unit();
    }
}
