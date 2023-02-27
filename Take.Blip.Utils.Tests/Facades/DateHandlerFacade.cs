using Take.Blip.Utils.Facade.Date;
using Take.Blip.Utils.Facade.Date.Interfaces;

namespace Take.Blip.Utils.Tests.Facade;

public sealed class DateHandlerFacadeTests
{
  private readonly IDateHandlerFacade _sut;

  public DateHandlerFacadeTests()
  {
    _sut = new DateHandlerFacade();
  }

  [Theory]
  [InlineData(0, 0)]
  [InlineData(1, -1)]
  [InlineData(2, -2)]
  public void GetCurrentDate_Should_Return_Right_DatetimeOffset(double offSetDateTime, int expected)
  {
    var now = DateTimeOffset.UtcNow;

    var result = _sut.GetCurrentDate(offSetDateTime);

    var diff = (now - result).Hours;

    diff.ShouldBe(expected);
  }
}