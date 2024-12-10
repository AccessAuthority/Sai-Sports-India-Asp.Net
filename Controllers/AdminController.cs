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
            var data = _context.tbl_enquiries.ToList();
            return View(data);
        }

        public IActionResult Products()
        {
            var data = _context.tbl_products.ToList();
            return View(data);
        }

        public IActionResult ProductForm()
        {
            return View();
        }
        //Insertion of products Property Data 
        [HttpPost]
        public async Task<IActionResult> ProductForm(tbl_products products, IFormFile img1, IFormFile img2, IFormFile img3, IFormFile img4, IFormFile img5)
        {
            if (!ModelState.IsValid)
            {

                return View(products);
            }

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
            return RedirectToAction("Products");
        }

        private async Task<string> Saveimgc(IFormFile img)
        {
            var folderPath = Path.Combine(_environment.WebRootPath, "upload"); // Ensure this folder exists
            var fileName = Path.GetFileName(img.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }

            return fileName;
        }

        // GET: Edit Updation of products Property Data
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
          
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
            existingproducts.ptags = products.ptags;
            existingproducts.price = products.price;
            existingproducts.quantity = products.quantity;
            existingproducts.black = products.black;
            existingproducts.red = products.red;
            existingproducts.blue = products.blue;
            existingproducts.green = products.green; // Example field
            existingproducts.white = products.white; // Example field
            existingproducts.author = products.author; // Example field
            existingproducts.date = products.date; // Example field
            existingproducts.pcontent = products.pcontent; // Example field

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
            var data = _context.tbl_blog.ToList();
            return View(data);
        }
        public IActionResult BlogForm()
        {
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

    }
}
