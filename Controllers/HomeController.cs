using Microsoft.AspNetCore.Mvc;
using SaiSports.Models;
using System.Reflection.Metadata;

namespace SaiSports.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;

        public HomeController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public IActionResult Index()
        {
            var data = _context.tbl_blog.Take(4).ToList();
            return View(data);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Products()
        {
            var data = _context.tbl_products.ToList();
            return View(data);
        }

        public IActionResult Blog()
        {
            var data = _context.tbl_blog.ToList();
            return View(data);
        }

        public IActionResult BlogDetail(int id)
        {
            var data = _context.tbl_blog.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            // Fetch 4 other blog posts (excluding the current blog post)
            var relatedBlogs = _context.tbl_blog
                                       .Where(b => b.id != id) // Exclude the current blog post
                                       .OrderBy(r => Guid.NewGuid()) // Randomize the results
                                       .Take(4) // Limit to 4 blogs
                                       .ToList();

            // Create the ViewModel and pass it to the view
            var viewModel = new CombineViewModel
            {
                CurrentBlog = data,
                RelatedBlogs = relatedBlogs
            };

            return View(viewModel);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnquiryForm(tbl_enquiries e)
        {
            _context.tbl_enquiries.Add(e);
            _context.SaveChanges();
            TempData["msg"] = "Form Submitted";
            return RedirectToAction("ContactUs");
        }
    }
}
