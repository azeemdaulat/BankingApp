using AutoMapper;
using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Account.Command;
using BankingApp.Domain.Entities;

namespace BankingApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
        CreateMap<Account,AccountDto>().ReverseMap();
        CreateMap<Transaction, TransactionDto>().ReverseMap();
        CreateMap<Account,CreateAccountCommand>().ReverseMap();
        CreateMap<Account,UpdateAccountCommand>().ReverseMap();
        }
    }
}
