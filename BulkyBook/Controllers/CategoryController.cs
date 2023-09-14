using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await  _db.Categories.ToListAsync();

            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid)
            {
               await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        // Update 

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            Category category = await  _db.Categories.FindAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {

                 _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        // Delete 

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            Category category = await _db.Categories.FindAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null || id <= 0) return BadRequest();

            Category category = await _db.Categories.FindAsync(id);

            if (category == null) return NotFound();

            _db.Categories.Remove(category);
           await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
