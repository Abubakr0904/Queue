using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Data;
using Microsoft.EntityFrameworkCore;
using app.Mappers;
using app.ViewModels;
using app.Entities;
using Microsoft.AspNetCore.Authorization;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _ctx;

    public HomeController(ILogger<HomeController> logger, AppDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }
    public async Task<IActionResult> Index()
    {
        var queues = _ctx.Queues.ToList().OrderBy(i => i.CreatedAt).ToList();
        return View(queues.ToModel());
    }

    public IActionResult ShowQueue()
    {
        return View();
    }

    public IActionResult TakeQueue()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> TakeQueue(QueueViewModel model)
    {
        var queue = new app.Entities.Queue();
        queue.Id = Guid.NewGuid();
        queue.CustomerName = model.CustomerName;
        queue.CreatedAt = DateTimeOffset.UtcNow.ToLocalTime();
        queue.Phone = model.Phone;
        queue.IsActive = true;
        queue.ModifiedAt = default(DateTimeOffset);
        queue.QueueTime = queue.CreatedAt;

        if(_ctx.Queues.Any())
        {
            var lastentity = _ctx.Queues.OrderBy(i => i.CreatedAt).LastOrDefault();
            queue.QueueTime = lastentity.QueueTime.AddMinutes(10);
        }
        try
        {
            await _ctx.Queues.AddAsync(queue);
            await _ctx.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogCritical($"Error in adding queue: {e.Message}");
        }

        return RedirectToAction("Index", queue.ToModel());
    }

    [HttpPost]
    public async Task<IActionResult> RemoveQueue(Guid id)
    {
        var queue = _ctx.Queues.Any(i => i.Id == id);
        if(queue != default)
        {
            _ctx.Remove(queue);
            await _ctx.SaveChangesAsync();
        }
        return LocalRedirect("/");
    }

    [Authorize]
    public IActionResult Admin() => View(_ctx.Queues.ToList().ToModel());

    [HttpGet]
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
