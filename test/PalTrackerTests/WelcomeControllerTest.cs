using Microsoft.Extensions.Configuration;
using Moq;
using PalTracker;
using Xunit;

namespace PalTrackerTests
{
  public class WelcomeControllerTest
  {
    [Fact]
    public void Get()
    {
      var message = new WelcomeMessage("hello from test");
      IConfiguration config = new Mock<IConfiguration>().Object;

      var controller = new WelcomeController(message, config);

      Assert.Equal("hello from test", controller.SayHello());
    }
  }
}