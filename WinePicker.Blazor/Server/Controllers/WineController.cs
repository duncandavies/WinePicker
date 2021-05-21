using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WinePicker.Shared.Interfaces;
using WinePicker.Shared.Models;

namespace WinePicker.Blazor.Server.Controllers
{
    [ApiController]
    [Route("wines")]
    public class WineController : ControllerBase
    {
        private readonly IWineBL _businessLogic;
        private readonly ILogger<WineController> _logger;

        public WineController(ILogger<WineController> logger, IWineBL businessLogic)
        {
            _logger = logger;
            _businessLogic = businessLogic;
        }

        [HttpGet]
        public IEnumerable<WineModel> GetAll()
        {
            return _businessLogic.GetWines().Result;
        }
    }
}