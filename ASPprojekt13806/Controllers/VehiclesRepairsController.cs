using ASPprojekt13806.Areas.Identity.Data;
using ASPprojekt13806.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ASPprojekt13806.Controllers
{
    [Authorize]
    public class VehicleRepairsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public VehicleRepairsController(ApplicationDBContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: VehicleRepairs
        public async Task<IActionResult> Index()
        {
            var vehicleRepairs = await _context.VehicleRepairs.Include(v => v.Vehicle).ToListAsync();
            return View(vehicleRepairs);
        }
        [AllowAnonymous]
        // GET: VehicleRepairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRepairs = await _context.VehicleRepairs
                .Include(v => v.Vehicle)
                .Where(v => v.VehicleId == id)
                .ToListAsync();

            if (vehicleRepairs == null)
            {
                return NotFound();
            }

            return View(vehicleRepairs);
        }

        // GET: VehicleRepairs/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Model");
            return View();
        }

        // POST: VehicleRepairs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,RepairDate,VehicleId")] VehicleRepairs vehicleRepair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleRepair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Model", vehicleRepair.VehicleId);
            return View(vehicleRepair);
        }

        // GET: VehicleRepairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRepair = await _context.VehicleRepairs.FindAsync(id);

            if (vehicleRepair == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Model", vehicleRepair.VehicleId);
            return View(vehicleRepair);
        }

        // POST: VehicleRepairs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,RepairDate,VehicleId")] VehicleRepairs vehicleRepair)
        {
            if (id != vehicleRepair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(vehicleRepair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Model", vehicleRepair.VehicleId);
            return View(vehicleRepair);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRepair = await _context.VehicleRepairs
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (vehicleRepair == null)
            {
                return NotFound();
            }

            return View(vehicleRepair);
        }

        // POST: VehicleRepairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleRepair = await _context.VehicleRepairs.FindAsync(id);
            _context.VehicleRepairs.Remove(vehicleRepair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

