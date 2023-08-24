using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Repositories;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetUserByIdAsync(command.Id);
            if (userDetails == null)
                return default;

            return await _userRepository.DeleteUserAsync(userDetails.Id);
        }
    }
}