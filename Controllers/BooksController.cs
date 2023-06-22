using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ebook.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controllers;

public class BooksController : Controller
{
    private ModelsDbContext _dbcontext; 
    private readonly UserManager<IdentityUser> _userManager;

    public BooksController(ModelsDbContext _dbcontext, UserManager<IdentityUser> _userManager) {
        this._dbcontext = _dbcontext;
        this._userManager = _userManager;
    }

    public IActionResult Index()
    {
        List<Book> books = _dbcontext.Tbl_Book.ToList();
        ViewBag.books = books;
        return View();
    }

    public IActionResult Book(int id)
    {   
        Console.WriteLine(id);
        var book = _dbcontext.Tbl_Book.FirstOrDefault(b => b.Id == id);
        Console.WriteLine(book.Title);
        ViewBag.book = book;
        return View();
    }

    [Authorize]
    public IActionResult ReadBook(int id)
    {   
        Console.WriteLine(id);
        var book = _dbcontext.Tbl_Book.FirstOrDefault(b => b.Id == id);
        Console.WriteLine(book.Title);
        ViewBag.book = book;
        return View();
    }

    [Authorize]
    public async Task<IActionResult> AddBook(int id)
    {   

        var book = _dbcontext.Tbl_Book.FirstOrDefault(b => b.Id == id);
        
        BookUser newbu = new BookUser();
        newbu.book = book;
        // var logUser = _dbcontext.Tbl_AspNetUsers.FirstOrDefault(u => u.Id == User.GetUserId());
        // newbu.user = (IdentityUser)User.Identity;
        var usss = await _userManager.GetUserAsync(User);
        newbu.user = usss;

        _dbcontext.Tbl_BookUser.Add(newbu);
        _dbcontext.SaveChanges();

        // ViewBag.book = book;
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UserBooks()
    {   
        var usss = await _userManager.GetUserAsync(User);
        // var query = from bookuser in _dbcontext.Tbl_BookUser join book in _dbcontext.Tbl_Book on bookuser.book equals book.Id select new
        //             {
        //                 book.Title,
        //             };
        var query = from t1 in _dbcontext.Tbl_BookUser
                    where t1.user == usss
                    join t2 in _dbcontext.Tbl_Book on t1.book.Id equals t2.Id
                    
                    select new
                    {   
                        t2.Id,
                        t2.Title,
                        t2.Description
                    };

        // var s = query.ToList();
        // Console.WriteLine(query.ToList());
        

        // var bookk = query.ToList();

        // Console.WriteLine("\n\n\n\n\n");
        // foreach(var b in bookk) {
        //     Console.WriteLine(b.Title);
        // }

        ViewBag.Userb = query.ToList();
        return View();
    }


    public async Task<IActionResult> DeleteUserBook(int id)
    {   
        var usss = await _userManager.GetUserAsync(User);

        var del_book = _dbcontext.Tbl_BookUser.Where(bu => bu.user == usss).FirstOrDefault(bu => bu.book.Id == id);
        _dbcontext.Tbl_BookUser.Remove(del_book);
        _dbcontext.SaveChanges();


        return RedirectToAction("UserBooks");
    }
}
