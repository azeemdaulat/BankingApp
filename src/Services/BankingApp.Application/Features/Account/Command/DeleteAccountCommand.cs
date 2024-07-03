using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Account.Command
{
    public class DeleteAccountCommand : IRequest
    {
        public int Id { get; set; }
    }
}
