namespace MarketGoods.WebAPI.Controllers
{
    using MarketGoods.Application.Users.Commands;
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var createResult = await _sender.Send(command);

            return Ok(createResult);
        }
    }
}
