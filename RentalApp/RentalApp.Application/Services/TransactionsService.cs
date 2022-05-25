using AutoMapper;
using RentalApp.Application.Dto.Transactions;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using System.Threading.Tasks;

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

        public async Task<TransactionDto> GetTransaction(int transactionId)
        {
            var transaction = await _transactionsRepository.GetTransaction(transactionId);

            if (transaction == null)
                throw new NotFoundException("Transaction does not exist.");

            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<TransactionDto> CreateTransaction(RequestTransactionDto newTransactionDto)
        {
            var transactionToAdd = _mapper.Map<Transaction>(newTransactionDto);

            await _transactionsRepository.AddTransaction(transactionToAdd);

            return _mapper.Map<TransactionDto>(transactionToAdd);
        }
    }
}
