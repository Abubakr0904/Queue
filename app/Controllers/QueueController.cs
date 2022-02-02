using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    public class QueueController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly ILogger<QueueController> _logger;

        public QueueController(ILogger<QueueController> logger, AppDbContext ctx)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}