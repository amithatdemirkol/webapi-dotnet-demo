using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repositories;
using MediatR;
using System.Numerics;

namespace CQRSAndMediatRDemo.Handlers
{
    public class GetUserListHandler :  IRequestHandler<GetUserListQuery, List<UserDetails>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDetails>> Handle(GetUserListQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserListAsync();
        }
    }
}
