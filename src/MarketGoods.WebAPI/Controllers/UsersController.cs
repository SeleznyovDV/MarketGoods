namespace MarketGoods.WebAPI.Controllers
{
    using FluentValidation;
    using MarketGoods.Application.Users.Commands.Create;
    using MarketGoods.Application.Users.Queries.Get;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("users")]
    public class UsersController : ApiController
    {
        private readonly ISender _sender;
        private readonly IValidator<CreateUserCommand> _createUserValidator;
        public UsersController(ISender sender, IValidator<CreateUserCommand> createUserValidator)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _createUserValidator = createUserValidator ?? throw new ArgumentNullException(nameof(createUserValidator));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _createUserValidator.ValidateAsync(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var response = await _sender.Send(command);

            return response.Match(userId => Ok(userId), errors => Problem(errors));
        }
    }
}
