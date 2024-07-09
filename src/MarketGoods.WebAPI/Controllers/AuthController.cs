namespace MarketGoods.WebAPI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MarketGoods.Application.Recipients.Queries.Login;
    using MarketGoods.Application.Recipients.Commands.Register;
    public class AuthController : ApiController
    {
        private readonly ISender _sender;
        public AuthController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRecipientQuery query)
        {
            var result = await _sender.Send(query);
            return result.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRecipientCommand query)
        {
            var result = await _sender.Send(query);
            return result.Match(user => Ok(user), errors => Problem(errors));
        }
    }
}
