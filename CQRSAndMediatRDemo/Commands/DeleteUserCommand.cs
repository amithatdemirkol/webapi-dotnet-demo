using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

