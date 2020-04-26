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
    [HttpGet]
    public string SayHello() => "hello";
  }
}
