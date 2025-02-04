using Microsoft.AspNetCore.Mvc;
using SaiSports.Models;

namespace SaiSports.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }
        public IActionResult Dashboard()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            // Count total enquiries
            int totalEnquiries = _context.tbl_enquiries.Count();

            // Count total blogs
            int totalBlogs = _context.tbl_blog.Count();

            // Count total listed products
            int totalProducts = _context.tbl_products.Count();

            // Pass the counts to the ViewBag or ViewData to send data to the view
            ViewBag.TotalEnquiries = totalEnquiries;
            ViewBag.TotalBlogs = totalBlogs;
            ViewBag.TotalProducts = totalProducts;

            // Pass all enquiries to the view if required
            var data = _context.tbl_enquiries.ToList();

            return View(data);
        }


        public IActionResult Products()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            var data = _context.tbl_products.ToList();
            return View(data);
        }

        public IActionResult ProductForm()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            return View();
        }
        // Insertion of products Property Data 
        [HttpPost]
        public async Task<IActionResult> ProductForm(tbl_products products, IFormFile img1, IFormFile img2, IFormFile img3, IFormFile img4, IFormFile img5)
        {
            // Save images with unique names
            if (img1 != null && img1.Length > 0)
            {
                products.img1 = await Saveimgc(img1);
            }

            if (img2 != null && img2.Length > 0)
            {
                products.img2 = await Saveimgc(img2);
            }

            if (img3 != null && img3.Length > 0)
            {
                products.img3 = await Saveimgc(img3);
            }

            if (img4 != null && img4.Length > 0)
            {
                products.img4 = await Saveimgc(img4);
            }

            if (img5 != null && img5.Length > 0)
            {
                products.img5 = await Saveimgc(img5);
            }

            // Add to the database
            _context.tbl_products.Add(products);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductForm");
        }

        // Helper method to save image with a unique name
        private async Task<string> Saveimgc(IFormFile img)
        {
            // Generate a unique file name using GUID and file extension
            var fileExtension = Path.GetExtension(img.FileName);
            var fileName = Guid.NewGuid().ToString() + fileExtension;

            // Define the folder path for saving the image
            var folderPath = Path.Combine(_environment.WebRootPath, "upload");

            // Ensure the directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Define the file path for saving the image
            var filePath = Path.Combine(folderPath, fileName);

            // Save the image to the folder
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }

            // Return the unique file name to store in the database
            return fileName;
        }

        // GET: Edit Updation of products Property Data
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }

            var products = await _context.tbl_products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(tbl_products products, IFormFile img1, IFormFile img2, IFormFile img3, IFormFile img4, IFormFile img5)
        {
            var existingproducts = await _context.tbl_products.FindAsync(products.id);
            if (existingproducts == null)
            {
                return NotFound(); // Handle not found case
            }

            // Update property fields
            existingproducts.pname = products.pname;
            existingproducts.pcategory = products.pcategory;
            existingproducts.author = products.author;
            existingproducts.date = products.date;
            existingproducts.pcontent = products.pcontent;
            existingproducts.pdesc = products.pdesc;
            existingproducts.stretchability = products.stretchability;
            existingproducts.wash_care = products.wash_care;
            existingproducts.closure_type = products.closure_type;
            existingproducts.special_features = products.special_features;
            existingproducts.season_suitability = products.season_suitability;
            existingproducts.fabric = products.fabric;
            existingproducts.fabric_weight = products.fabric_weight;
            existingproducts.weave_type = products.weave_type;
            existingproducts.color_pattern = products.color_pattern;
            existingproducts.size = products.size;
            existingproducts.fit_type = products.fit_type;
            existingproducts.thread_count = products.thread_count;
            existingproducts.style = products.style;

            // Process new images if provided
            if (img1 != null && img1.Length > 0)
            {
                existingproducts.img1 = await Saveimgc(img1);
            }

            if (img2 != null && img2.Length > 0)
            {
                existingproducts.img2 = await Saveimgc(img2);
            }

            if (img3 != null && img3.Length > 0)
            {
                existingproducts.img3 = await Saveimgc(img3);
            }

            if (img4 != null && img4.Length > 0)
            {
                existingproducts.img4 = await Saveimgc(img4);
            }

            if (img5 != null && img5.Length > 0)
            {
                existingproducts.img5 = await Saveimgc(img5);
            }

            // Update the property in the context
            _context.Update(existingproducts);
            await _context.SaveChangesAsync();

            return RedirectToAction("Products", "Admin"); // Redirect to the list or confirmation page
        }


        //Deletion Of products Property Data
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Find the residential item by ID
            var products = await _context.tbl_products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            // Optionally delete images if needed
            DeleteImages(products);

            // Remove the residential item from the database
            _context.tbl_products.Remove(products);
            await _context.SaveChangesAsync();

            // Redirect to the appropriate view after deletion
            return RedirectToAction("Products");
        }

        private void DeleteImages(tbl_products products)
        {
            var folderPath = Path.Combine(_environment.WebRootPath, "upload");

            // List of image properties
            var imageProperties = new List<string>
            {
        products.img1,
        products.img2,
        products.img3,
        products.img4,
        products.img5
             };

            foreach (var imageName in imageProperties)
            {
                if (!string.IsNullOrEmpty(imageName))
                {
                    var filePath = Path.Combine(folderPath, imageName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
        }
       

        public IActionResult Blog()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            var data = _context.tbl_blog.ToList();
            return View(data);
        }
        public IActionResult BlogForm()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlogFunction(tbl_blog blogPost, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                // Handle image upload if there's one
                if (img != null && img.Length > 0)
                {
                    var folderPath = Path.Combine(_environment.WebRootPath, "upload"); // Ensure this folder exists
                    var fileName = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }

                    // Set the image URL in the blog post
                    blogPost.img = Url.Content("~/upload/" + fileName); // Assuming you have an ImageUrl property
                }

                // Add the blog post to the context and save
                _context.tbl_blog.Add(blogPost);
                await _context.SaveChangesAsync();

                return RedirectToAction("Blog", "Admin"); // Redirect to the blog list or wherever you want
            }

            return View(blogPost); // Return to the view with validation errors
        }

        //Delete Blog post
        public IActionResult DeleteBlog(int id)
        {
            var blogPost = _context.tbl_blog.Find(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            // Assuming `ImageUrl` holds the path to the image
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", blogPost.img);

            // Remove the blog post from the database
            _context.tbl_blog.Remove(blogPost);
            _context.SaveChanges();

            // Check if the image file exists and delete it
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            return RedirectToAction("Blog", "Admin");
        }
        // GET: Edit Blog Post
        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            var blogPost = await _context.tbl_blog.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost); // Return the view with the blog post data
        }

        // POST: Edit Blog Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(tbl_blog blogPost, IFormFile img)
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }

            var existingBlogPost = await _context.tbl_blog.FindAsync(blogPost.id); // Assuming Id is the primary key

            if (existingBlogPost == null)
            {
                return NotFound();
            }

            if (img != null && img.Length > 0)
            {
                // Handle new image upload
                var folderPath = Path.Combine(_environment.WebRootPath, "upload"); // Ensure this folder exists
                var fileName = Guid.NewGuid() + Path.GetExtension(img.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                }

                // Set the new image URL in the blog post
                existingBlogPost.img = Url.Content("~/upload/" + fileName);
            }

            // Update the other properties of the blog post
            existingBlogPost.title = blogPost.title;
            existingBlogPost.author = blogPost.author;
            existingBlogPost.category = blogPost.category;
            existingBlogPost.date = blogPost.date;
            existingBlogPost.blog_content = blogPost.blog_content;
            existingBlogPost.description = blogPost.description;
            existingBlogPost.tags = blogPost.tags;

            // Save changes to the database
            _context.Update(existingBlogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction("Blog", "Admin"); // Redirect to the blog list
        }

        public IActionResult Enquiries()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            var data = _context.tbl_enquiries.ToList();
            return View(data);
        }

        //Delete Enquiry
        public IActionResult DeleteEnquiry(int id)
        {
            var data = _context.tbl_enquiries.Find(id);
            _context.tbl_enquiries.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Enquiries", "Admin");
        }


        public IActionResult CareerEnquiries()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("SSAdmin", "Home");
            }
            var data = _context.tbl_career.ToList();
            return View(data);
        }

        // POST: Delete Career
        [HttpPost]
        public async Task<IActionResult> DeleteCareer(int id)
        {
            // Find the career entry by id
            var career = await _context.tbl_career.FindAsync(id);

            // Check if resume and cover letter files exist, and delete them
            if (!string.IsNullOrEmpty(career.resume))
            {
                var resumePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", career.resume.TrimStart('/'));
                if (System.IO.File.Exists(resumePath))
                {
                    System.IO.File.Delete(resumePath); // Delete the file
                }
            }

            if (!string.IsNullOrEmpty(career.coverLetter))
            {
                var coverLetterPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", career.coverLetter.TrimStart('/'));
                if (System.IO.File.Exists(coverLetterPath))
                {
                    System.IO.File.Delete(coverLetterPath); // Delete the file
                }
            }

            // Remove the career entry from the database
            _context.tbl_career.Remove(career);
            await _context.SaveChangesAsync();

            // Redirect to the career list or confirmation page after deletion
            return RedirectToAction("CareerEnquiries"); // Adjust to your desired action after deletion
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears the session
            return RedirectToAction("Index", "Home"); // Redirect to login page
        }
    }
}
