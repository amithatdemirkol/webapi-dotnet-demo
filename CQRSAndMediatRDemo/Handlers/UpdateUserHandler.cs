using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetUserByIdAsync(command.Id);
            if (userDetails == null)
                return default;

            userDetails.UserName = command.UserName;
            userDetails.UserEmail = command.UserEmail;
            userDetails.UserAddress = command.UserAddress;
            userDetails.UserAge = command.UserAge;

            return await _userRepository.UpdateUserAsync(userDetails);
        }
    }
}
