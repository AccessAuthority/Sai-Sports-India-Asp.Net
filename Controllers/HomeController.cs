using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SaiSports.Models;
using System.Reflection.Metadata;

namespace SaiSports.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;
        private readonly EmailSender _emailSender;

        public HomeController(AppDbContext context, IWebHostEnvironment environment, EmailSender emailSender)
        {
            _context = context;
            _environment = environment;
            _emailSender = emailSender;

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

        public IActionResult ProductDetails(int id)
        {
            var data = _context.tbl_products.Find(id);
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
                                       .Take(8) // Limit to 4 blogs
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
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult Career()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnquiryForm(tbl_enquiries e)
        {
            // Compose the email content
            string subject = $"New Contact Form Submission from {e.name}";
            string body = $"<h3>Contact Details:</h3>" +
                          $"<p><strong>Subject:</strong> {e.subject}</p>" +
                          $"<p><strong>Name:</strong> {e.name}</p>" +
                          $"<p><strong>Phone:</strong> {e.phone}</p>" +
                          $"<p><strong>Email:</strong> {e.email}</p>" +
                          $"<p><strong>Message:</strong><br/>{e.msg}</p>";

            // Use the EmailSender service to send the email
            _emailSender.SendEmailAsync("puri.saisports@gmail.com", subject, body);
            _context.tbl_enquiries.Add(e);
            _context.SaveChanges();
            return RedirectToAction("ContactUs");
        }
    }
}
