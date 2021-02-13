using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoggerProber.Models;

namespace LoggerProber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("LoggerProber");
        }

        public IActionResult Index()
        {
            _logger.LogTrace("This is a trace log");
            _logger.LogDebug("This is a debug log");
            _logger.LogInformation("This is an informational log @{Time}", DateTime.Now);
            _logger.LogWarning("This is a warning log");
            _logger.LogError("This is a error log");
            _logger.LogCritical("This is a critical log");

            try
            {
                throw new Exception("Forgot to catch me !");
            }
            catch( Exception ex)
            {
                _logger.LogCritical(ex, "Critical Excxeption caught @ {Time} !!!!!", DateTime.Now);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
