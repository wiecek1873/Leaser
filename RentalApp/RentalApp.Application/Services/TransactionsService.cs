﻿using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Dto.Transactions;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;

namespace RentalApp.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IPostsRepository _postsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public TransactionsService(ITransactionsRepository transactionsRepository,IPostsRepository postsRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _postsRepository = postsRepository;
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

        public async Task<TransactionDto> CreateTransaction(string userId, RequestTransactionDto newTransactionDto)
        {
            var payer = await _usersRepository.GetUser(newTransactionDto.PayerId.ToString());

            if (payer == null)
                throw new NotFoundException("Payer with this id does not exist!");

            if (newTransactionDto.PayerId.ToString() == userId)
                throw new ConflictException("You can not create transaction with yourself!");

            var post = await _postsRepository.GetPost(newTransactionDto.PostId);

            if (post == null)
                throw new NotFoundException("Post with this id does not exist!");

            if (newTransactionDto.DateFrom > newTransactionDto.DateTo)
                throw new MethodNotAllowedException("Date from can not be later than date to deadline!");

            var transactionToAdd = _mapper.Map<Transaction>(newTransactionDto);

            await _transactionsRepository.AddTransaction(transactionToAdd);

            return _mapper.Map<TransactionDto>(transactionToAdd);
        }
    }
}
