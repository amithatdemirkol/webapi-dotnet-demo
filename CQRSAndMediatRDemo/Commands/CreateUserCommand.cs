using CQRSAndMediatRDemo.Models;
using MediatR;
using System.Numerics;

namespace CQRSAndMediatRDemo.Commands
{
    public class CreateUserCommand : IRequest<UserDetails>
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public int UserAge { get; set; }

        public CreateUserCommand(string userName, string userEmail, string userAddress, int userAge)
        {
            UserName = userName;
            UserEmail = userEmail;
            UserAddress = userAddress;
            UserAge = userAge;
        }
    }
}
