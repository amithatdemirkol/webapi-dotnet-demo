using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries
{
    public class GetUserByIdQuery : IRequest<UserDetails>
    {
        public int Id { get; set; }
    }
}
