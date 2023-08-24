using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public int UserAge { get; set; }

        public UpdateUserCommand(int id, string userName, string userEmail, string userAddress, int userAge)
        {
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
            UserAddress = userAddress;
            UserAge = userAge;
        }
    }
}
