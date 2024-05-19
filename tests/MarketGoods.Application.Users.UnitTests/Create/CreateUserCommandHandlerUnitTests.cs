namespace MarketGoods.Application.Users.UnitTests.Create
{
    using MarketGoods.Domain.Primitives;
    using MarketGoods.Domain.Users;
    using Moq;
    using ErrorOr;
    using MarketGoods.Domain.DomainErrors;
    using FluentAssertions;
    using MarketGoods.Application.Users.Commands.Create;

    public class CreateUserCommandHandlerUnitTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerUnitTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateUserCommandHandler(_mockUserRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreateUser_WhenPhoneNumberHasIncorrectFormat_ShouldReturnValidationError()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand("Seleznyov", "Dmitriy", "98343434343434", "email@mail.ru", "Administrator");

            //Act
            var result = await _handler.Handle(command, default);

            //Assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);

            result.FirstError.Code.Should().Be(Errors.User.PhoneNumberHasIncorrectFormat.Code);
            result.FirstError.Description.Should().Be(Errors.User.PhoneNumberHasIncorrectFormat.Description);
        }

        [Fact]
        public async Task HandleCreateUser_WhenEmailHasIncorrectFormat_ShouldReturnValidationError()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand("Seleznyov", "Dmitriy", "+79299131040", "email", "Administrator");

            //Act
            var result = await _handler.Handle(command, default);

            //Assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
        }

        [Fact]
        public async Task HandleCreateUser_WhenRolelHasIncorrectValue_ShouldReturnValidationError()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand("Seleznyov", "Dmitriy", "+79299131040", "email@mail.ru", "Admin");

            //Act
            var result = await _handler.Handle(command, default);

            //Assert

            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(Errors.User.RoleHasIncorrectValue.Code);
            result.FirstError.Description.Should().Be(Errors.User.RoleHasIncorrectValue.Description);
        }
    }
}
