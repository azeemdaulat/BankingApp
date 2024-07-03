using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Users.Queries;
using BankingApp.Application.Service;
using MediatR;

namespace BankingApp.Application.Features.Users.Handler
{
    public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        private readonly IUserService _userService;

        public GetUserDetailsHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserDetailsAsync(request.UserId);
        }
    }

}
