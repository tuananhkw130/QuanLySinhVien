using doan.Models;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhoaVienController : Controller
    {
        private readonly DataContext _context;
        public KhoaVienController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP()
        {
            var sp =_context.KhoaViens.ToList();
            return View(sp);
        }
        public IActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Them(KhoaVien sp)
        {
            _context.KhoaViens.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Sua(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.KhoaViens.Find(id);
            return View(sp);
        }
        [HttpPost]
        public IActionResult Sua(KhoaVien sp)
        {
            _context.KhoaViens.Update(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Xoa(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.KhoaViens.Find(id);
            return View(sp);

        }
        [HttpPost]
        public IActionResult Xoa(KhoaVien sp)
        {
            _context.KhoaViens.Remove(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
    }
}
