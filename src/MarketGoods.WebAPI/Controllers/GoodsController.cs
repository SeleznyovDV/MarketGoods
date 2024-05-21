namespace MarketGoods.WebAPI.Controllers
{
    using FluentValidation;
    using MarketGoods.Application.Goods.Commands.Create;
    using MarketGoods.Application.Goods.Queries.Get;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("goods")]
    public class GoodsController : ApiController
    {
        private readonly ISender _sender;
        public GoodsController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateGoodCommand command)
        {
            var response = await _sender.Send(command);
            return response.Match(userId => Ok(userId), errors => Problem(errors));
        }
        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sender.Send(new GetAllGoodsQuery());
            return Ok(response);
        }
        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var response = await _sender.Send(new GetGoodQuery(id));
            return Ok(response);
        }
    }
}
