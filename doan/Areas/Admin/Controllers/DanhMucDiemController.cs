using doan.Models;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucDiemController : Controller
    {
        private readonly DataContext _context;
        public DanhMucDiemController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP()
        {
            var sp =_context.DanhMucDiems.ToList();
            return View(sp);
        }
        public IActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Them(DanhMucDiem sp)
        {
            _context.DanhMucDiems.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Sua(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.DanhMucDiems.Find(id);
            return View(sp);
        }
        [HttpPost]
        public IActionResult Sua(DanhMucDiem sp)
        {
            _context.DanhMucDiems.Update(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Xoa(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.DanhMucDiems.Find(id);
            return View(sp);

        }
        [HttpPost]
        public IActionResult Xoa(DanhMucDiem sp)
        {
            _context.DanhMucDiems.Remove(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
    }
}
