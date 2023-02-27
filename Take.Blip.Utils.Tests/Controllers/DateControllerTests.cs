using System.Net;
using Microsoft.AspNetCore.Mvc;
using Take.Blip.Utils.Api;
using Take.Blip.Utils.Facade.Date.Interfaces;

namespace Take.Blip.Utils.Tests.Controllers;

public sealed class DateControllerTests
{
  private readonly DateController _sut;
  private readonly Mock<IDateHandlerFacade> _dateHandlerFacade;

  public DateControllerTests()
  {
    _dateHandlerFacade = new Mock<IDateHandlerFacade>();

    _sut = new DateController(_dateHandlerFacade.Object);
  }

  [Theory]
  [InlineData(-3, HttpStatusCode.OK)]
  [InlineData(10, HttpStatusCode.OK)]
  public void GetCurrentDate_Should_Return_Correct_Status_Code(double date, HttpStatusCode expected)
  {
    var result = (ObjectResult) _sut.GetCurrentDate(date);
    result.StatusCode.ShouldBe((int) expected);
  }

  [Fact]
  public void GetIntervalBetweenDates_Should_Return_Success_Status_Code()
  {
    var expected = (int) HttpStatusCode.OK;

    var result = (OkObjectResult) _sut
      .GetIntervalBetweenCurrentAndPreviousDate(It.IsAny<string>());
      
    result.StatusCode.ShouldBe(expected);
  }

  [Fact]
  public void GetFormattedDate_Should_Return_Success_Status_Code()
  {
    var expected = (int) HttpStatusCode.OK;

    var result = (OkObjectResult) _sut
      .GetFormattedDate(It.IsAny<string>());
      
    result.StatusCode.ShouldBe(expected);
  }
}