using MarketGoods.Application.Goods.Commands.Update;
using MarketGoods.Domain.Goods;
using MarketGoods.Domain.DomainErrors;
using MarketGoods.Domain.Primitives;

namespace MarketGoods.Application.Goods.UnitTests.Update
{
    public class UpdateGoodCommandHandlerUnitTests
    {
        private readonly Mock<IGoodRepository> _mockGoodRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UpdateGoodCommandHandler _handler;
        public UpdateGoodCommandHandlerUnitTests()
        {
            _mockGoodRepository = new Mock<IGoodRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _handler = new UpdateGoodCommandHandler(_mockGoodRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task HandleUpdateUser_WhenCurrencyHasIncorrectFormat_ShouldReturnValidationError()
        {
            //Arrange
            UpdateGoodCommand command = new UpdateGoodCommand(Guid.NewGuid(), "Beef", "Food", 123, "12131");

            //Act
            var result = await _handler.Handle(command, default);

            //Assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);

            result.FirstError.Code.Should().Be(Errors.Goods.CurrencyHasIncorrectValue.Code);
            result.FirstError.Description.Should().Be(Errors.Goods.CurrencyHasIncorrectValue.Description);
        }

        [Fact]
        public async Task HandleUpdateGood_WhenPriceHasIncorrectFormat_ShouldReturnValidationError()
        {
            //Arrange
            UpdateGoodCommand command = new UpdateGoodCommand(Guid.NewGuid(), "Beef", "Food", -123, "Euro");

            //Act
            var result = await _handler.Handle(command, default);

            //Assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);

            result.FirstError.Code.Should().Be(Errors.Goods.PriceHasIncorrectValue.Code);
            result.FirstError.Description.Should().Be(Errors.Goods.PriceHasIncorrectValue.Description);
        }
    }
}
