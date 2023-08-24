using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries
{
    public class GetUserListQuery :  IRequest<List<UserDetails>>
    {
    }
}
