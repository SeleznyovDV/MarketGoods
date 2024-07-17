namespace MarketGoods.WebAPI.Controllers
{
    using MarketGoods.Application.Goods.Commands.Create;
    using MarketGoods.Application.Goods.Commands.Delete;
    using MarketGoods.Application.Goods.Commands.Update;
    using MarketGoods.Application.Goods.Queries.Get;
    using MarketGoods.WebAPI.Caching;
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
            return response.Match(response => Ok(response), errors => Problem(errors));
        }
        [HttpGet, Route("getall")]
        [ResponseCache(CacheProfileName = DefaultCacheProfiles.Default5)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sender.Send(new GetAllGoodsQuery());
            return Ok(response);
        }
        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _sender.Send(new GetGoodQuery(id));
            return Ok(response);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGoodCommand command)
        {
            var response = await _sender.Send(command);
            return response.Match(response => Ok(response), errors => Problem(errors));
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _sender.Send(new DeleteGoodCommand(id));
            return response.Match(response => Ok(response), errors => Problem(errors));
        }
    }
}
