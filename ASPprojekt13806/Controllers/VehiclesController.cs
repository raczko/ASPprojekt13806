using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPprojekt13806.Areas.Identity.Data;
using ASPprojekt13806.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPprojekt13806.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public VehiclesController(ApplicationDBContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicles
                .Include(v => v.Brand)
                .Include(v => v.Category)
                .ToListAsync();
            return View(vehicles);
        }
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,Price,CategoryId,Model,Image,Year")] Vehicles vehicles)
        {
            if (vehicles.Year < DateTime.Now.Year)
            {
                _context.Add(vehicles);

                await _context.SaveChangesAsync();
                TempData["Success"] = "The product is create";
                return RedirectToAction("Index");
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", vehicles.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", vehicles.CategoryId);
            return View(vehicles);
        }
        public IActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles
       .Include(v => v.Brand)
       .Include(v => v.Category)
       .FirstOrDefault(v => v.Id == id);

            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,BrandId,Price,CategoryId,Model,Image,Year")] Vehicles vehicle)
        {
            if (vehicle.Year < DateTime.Now.Year)
            {

                _context.Update(vehicle);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View(vehicle);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles
                .Include(v => v.Brand)
                .Include(v => v.Category)
                .FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}