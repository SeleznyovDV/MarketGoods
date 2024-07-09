namespace MarketGoods.WebAPI.Controllers
{
    using MarketGoods.Application.Users.Commands.Create;
    using MarketGoods.Application.Users.Commands.Delete;
    using MarketGoods.Application.Users.Queries.Get;
    using MarketGoods.WebAPI.Caching;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
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
        [ResponseCache(CacheProfileName = DefaultCacheProfiles.Default5)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sender.Send(new GetAllUsersQuery());
            return Ok(response);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _sender.Send(new GetUserQuery(id));
            return Ok(response);
        }
        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _sender.Send(new DeleteUserCommand(id));
            return response.Match(id => Ok(id), errors => Problem(errors));
        }
    }
}
