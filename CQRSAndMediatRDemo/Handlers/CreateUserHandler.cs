using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repositories;
using MediatR;
using System.Numerics;

namespace CQRSAndMediatRDemo.Handlers
{
    public class CreateUserHandler: IRequestHandler<CreateUserCommand, UserDetails>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDetails> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userDetails = new UserDetails()
            {
                UserName = command.UserName,
                UserEmail = command.UserEmail,
                UserAddress = command.UserAddress,
                UserAge = command.UserAge
            };

            return await _userRepository.AddUserAsync(userDetails);
        }
    }
}
