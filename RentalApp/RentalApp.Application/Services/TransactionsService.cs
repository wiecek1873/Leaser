using AutoMapper;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;

namespace RentalApp.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public TransactionsService(ITransactionsRepository transactionsRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
    }
}
