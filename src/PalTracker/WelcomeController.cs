using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalTracker
{
  [Route("/")]
  public class WelcomeController : ControllerBase
  {
    private readonly WelcomeMessage _message;

    [HttpGet]
    public string SayHello() => _message.Message;

    public WelcomeController(WelcomeMessage message)
    {
      _message = message;
    }
  }
}
