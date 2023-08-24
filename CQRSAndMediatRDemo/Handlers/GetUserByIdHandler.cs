using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repositories;
using MediatR;
using System.Numerics;

namespace CQRSAndMediatRDemo.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDetails>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetails> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(query.Id);
        }
    }
}
