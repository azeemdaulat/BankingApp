using BankingApp.Application.Features.Users.Command;
using BankingApp.Application.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Users.Handler
{
    public class RevokeTokenHandler : IRequestHandler<RevokeTokenCommand, bool>
    {
        private readonly IUserService _userService;

        public RevokeTokenHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RevokeTokenAsync(request.Token);
        }
    }

}
