namespace MarketGoods.WebAPI.Controllers
{
    using FluentValidation;
    using MarketGoods.Application.Goods.Commands.Create;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    [Route("goods")]
    public class GoodsController : ApiController
    {
        private readonly ISender _sender;
        private readonly IValidator<CreateGoodCommand> _createGoodValidator;
        public GoodsController(ISender sender, IValidator<CreateGoodCommand> createGoodValidator)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _createGoodValidator = createGoodValidator ?? throw new ArgumentNullException(nameof(createGoodValidator));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGoodCommand command) 
        {
            var result = await _createGoodValidator.ValidateAsync(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var response = await _sender.Send(command);
            return response.Match(userId => Ok(userId), errors => Problem(errors));
        }
    }
}
