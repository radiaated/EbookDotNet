using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ebook.Models;

namespace Ebook.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ModelsDbContext _dbcontext; 

    public HomeController(ILogger<HomeController> logger, ModelsDbContext _dbcontext)
    {
        _logger = logger;
        this._dbcontext = _dbcontext;
    }

    public IActionResult Index()
    {
        List<Book> books = _dbcontext.Tbl_Book.ToList();
        ViewBag.books = books;
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
