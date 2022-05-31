using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Dto.Transactions;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using System.Collections.Generic;
using System;

namespace RentalApp.Application.Services
{
	public class TransactionsService : ITransactionsService
	{
		private readonly ITransactionsRepository _transactionsRepository;
		private readonly IPostsRepository _postsRepository;
		private readonly IUsersRepository _usersRepository;
		private readonly IMapper _mapper;

		public TransactionsService(ITransactionsRepository transactionsRepository, IPostsRepository postsRepository, IUsersRepository usersRepository, IMapper mapper)
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

		public async Task<List<TransactionDto>> GetTransactionsByPostId(int postId)
		{
			var post = await _postsRepository.GetPost(postId);

			if (post == null)
				throw new NotFoundException("Post with this id does not exist!");

			var transactions = await _transactionsRepository.GetTransactionsByPostId(postId);

			return _mapper.Map<List<TransactionDto>>(transactions);
		}

		public async Task<List<TransactionDto>> GetTransactionsByPayerId(Guid payerId)
		{
			var payer = await _usersRepository.GetUser(payerId.ToString());

			if (payer == null)
				throw new NotFoundException("Payer with this id does not exist!");

			var transactions = await _transactionsRepository.GetTransactionsByPayerId(payerId);

			return _mapper.Map<List<TransactionDto>>(transactions);
		}

		public async Task<TransactionDto> CreateTransaction(string userId, RequestTransactionDto newTransactionDto)
		{
			var payer = await _usersRepository.GetUser(newTransactionDto.PayerId.ToString());

			if (payer == null)
				throw new NotFoundException("Payer with this id does not exist!");

			if (payer.Points < newTransactionDto.Price)
				throw new MethodNotAllowedException("You do not have enough points!");

			if (post == null)
				throw new NotFoundException("Post with this id does not exist!");

            if (newTransactionDto.PayerId == post.UserId)
                throw new ConflictException("You can not create transaction with yourself!");

            if (newTransactionDto.DateFrom > newTransactionDto.DateTo)
                throw new MethodNotAllowedException("Date from can not be later than date to deadline!");

            if (post.AvailableFrom >= newTransactionDto.DateFrom)
                throw new MethodNotAllowedException("Date from transaction can not be earlier than available post date from!");

            if (post.AvailableTo.HasValue)
                if (post.AvailableTo <= newTransactionDto.DateTo)
                    throw new MethodNotAllowedException("Date to transaction can not be later than available post date to!");

            var postTransactions = await _transactionsRepository.GetTransactionsByPostId(newTransactionDto.PostId);
			if (newTransactionDto.DateFrom > newTransactionDto.DateTo)
				throw new MethodNotAllowedException("Date from can not be later than date to deadline!");

			var postTransactions = await _transactionsRepository.GetTransactionsByPostId(newTransactionDto.PostId);

			foreach (var transaction in postTransactions)
			{
				if (transaction.DateFrom > newTransactionDto.DateFrom && transaction.DateFrom < newTransactionDto.DateTo && transaction.DateTo > newTransactionDto.DateTo)
					throw new MethodNotAllowedException("You can not add transaction in this time span!");

				if (transaction.DateFrom < newTransactionDto.DateFrom && transaction.DateTo > newTransactionDto.DateTo)
					throw new MethodNotAllowedException("You can not add transaction in this time span!");

				if (transaction.DateFrom < newTransactionDto.DateFrom && newTransactionDto.DateFrom < transaction.DateTo && transaction.DateTo < newTransactionDto.DateTo)
					throw new MethodNotAllowedException("You can not add transaction in this time span!");
			}

			var transactionToAdd = _mapper.Map<Transaction>(newTransactionDto);

			await _usersRepository.PayForTransaction(payer.Id.ToString(), newTransactionDto.Price);

			await _transactionsRepository.AddTransaction(transactionToAdd);

			return _mapper.Map<TransactionDto>(transactionToAdd);
		}

		public async Task<TransactionDto> ReturnItem(int transactionId, string payerId)
		{
			var transaction = await _transactionsRepository.GetTransaction(transactionId);

			if (transaction == null)
				throw new NotFoundException("Transaction with this id does not exist!");

			if (transaction.Status != TransactionStatus.Borrowed)
				throw new MethodNotAllowedException("You can not return not borrowed item!");

			if (transaction.PayerId.ToString() != payerId)
				throw new MethodNotAllowedException("You can not return an item from not your transaction!");

			transaction = await _transactionsRepository.ReturnItem(transactionId);

			return _mapper.Map<TransactionDto>(transaction);
		}
	}
}
