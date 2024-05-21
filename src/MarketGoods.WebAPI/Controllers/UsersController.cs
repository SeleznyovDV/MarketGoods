namespace MarketGoods.WebAPI.Controllers
{
    using MarketGoods.Application.Users.Commands.Create;
    using MarketGoods.Application.Users.Queries.Get;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("users")]
    public class UsersController : ApiController
    {
        private readonly ISender _sender;
        public UsersController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }
        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var response = await _sender.Send(command);
            return response.Match(userId => Ok(userId), errors => Problem(errors));
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sender.Send(new GetAllUsersQuery());
            return Ok(response);
        }
    }
}
