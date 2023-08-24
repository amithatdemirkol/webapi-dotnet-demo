using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CQRSAndMediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<UserDetails>> GetUserListAsync()
        {
            var userDetails = await mediator.Send(new GetUserListQuery());

            return userDetails;
        }

        [HttpGet("userId")]
        public async Task<UserDetails> GetUserByIdAsync(int userId)
        {
            var userDetails = await mediator.Send(new GetUserByIdQuery() { Id = userId });

            return userDetails;
        }

        [HttpPost]
        public async Task<UserDetails> AddUserAsync(UserDetails userDetails)
        {
            var userDetail = await mediator.Send(new CreateUserCommand(
                userDetails.UserName,
                userDetails.UserEmail,
                userDetails.UserAddress,
                userDetails.UserAge));
            return userDetail;
        }

        [HttpPut]
        public async Task<int> UpdateUserAsync(UserDetails userDetails)
        {
            var isUserDetailUpdated = await mediator.Send(new UpdateUserCommand(
               userDetails.Id,
               userDetails.UserName,
               userDetails.UserEmail,
               userDetails.UserAddress,
               userDetails.UserAge));
            return isUserDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteUserAsync(int Id)
        {
            return await mediator.Send(new DeleteUserCommand() { Id = Id });
        }
    }
}