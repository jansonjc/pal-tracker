using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    private readonly IConfiguration _configuration;

    [HttpGet]
    public string SayHello() => _message.Message;

    [HttpGet("configProviders")]
    public string ConfigProviders()
    {
      string str = "";
      IConfigurationRoot configRoot = (IConfigurationRoot)_configuration;
      foreach (var provider in configRoot.Providers.ToList())
      {
        str += provider.ToString() + "\n";
      }

      return str;
    }

    [HttpGet("configs")]
    public string Configs()
    {
      string str = "";
      foreach (var configKey in _configuration.AsEnumerable())
      {
        str += configKey.Key + " => " + configKey.Value + "\n";
      }

      return str;
    }

    public WelcomeController(WelcomeMessage message, IConfiguration configuration)
    {
      _message = message;
      _configuration = configuration;
    }
  }
}
