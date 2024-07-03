using BankingApp.Application.Features.Users.Command;
using BankingApp.Application.Response;
using BankingApp.Application.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Users.Handler
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, AuthenticateResponse>
    {
        private readonly IUserService _userService;

        public RefreshTokenHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthenticateResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RefreshTokenAsync(request.Token);
        }
    }

}
