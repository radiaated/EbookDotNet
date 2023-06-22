using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ebook.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controllers;

public class AdminController : Controller
{
     private ModelsDbContext _dbcontext; 
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AdminController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager, ModelsDbContext _dbcontext)
    {
        this._dbcontext = _dbcontext;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

   public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    if (!_dbcontext.Roles.Any(r => r.Name == "Admin"))
                        {
                            var role = new IdentityRole { Name = "Admin" };
                            _dbcontext.Roles.Add(role);
                            _dbcontext.SaveChanges();
                        }
                    await _userManager.AddToRoleAsync(user, "Admin");

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }
    public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

    [Authorize]
    public IActionResult ViewBooks()
    {
        List<Book> books = _dbcontext.Tbl_Book.ToList();
        ViewBag.books = books;
        return View();
    }

    [Authorize]
    public IActionResult CreateBook()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult CreateBook(Book book, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                book.Cover= $"{fileName}";
                _dbcontext.Add(book);
                _dbcontext.SaveChanges();
                
                return RedirectToAction("ViewBooks");
            }
            return View(book);
        }

        [Authorize]
        public IActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _dbcontext.Tbl_Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Authorize]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult EditBook(int id, Book book, IFormFile file)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (file != null && file.Length > 0)
            {
                // Get the file name
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                 book.Cover= $"{fileName}";
                _dbcontext.Update(book);
                _dbcontext.SaveChanges();
            }
            
            
           

            
            return View(book);
        }


        [Authorize]
        public IActionResult DeleteBook(int id)
        {   
            // var usss = await _userManager.GetUserAsync(User);

            var del_book = _dbcontext.Tbl_Book.FirstOrDefault(bu => bu.Id == id);
            _dbcontext.Tbl_Book.Remove(del_book);
            _dbcontext.SaveChanges();


            return RedirectToAction("ViewBooks");
        }
}
