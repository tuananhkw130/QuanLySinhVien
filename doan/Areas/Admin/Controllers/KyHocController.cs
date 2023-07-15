using doan.Models;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KyHocController : Controller
    {
        private readonly DataContext _context;
        public KyHocController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP()
        {
            var sp =_context.KyHocs.ToList();
            return View(sp);
        }
        public IActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Them(KyHoc sp)
        {
            sp.MoDangKyHoc = false;
            _context.KyHocs.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Sua(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.KyHocs.Find(id);
            return View(sp);
        }
        [HttpPost]
        public IActionResult Sua(KyHoc sp)
        {
            sp.MoDangKyHoc = false;
            _context.KyHocs.Update(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
        public IActionResult Xoa(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sp = _context.KyHocs.Find(id);
            return View(sp);

        }
        [HttpPost]
        public IActionResult Xoa(KyHoc sp)
        {
            _context.KyHocs.Remove(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }

        public IActionResult ThayDoiDangKyHoc(int id)
        {
            bool trangthai = _context.KyHocs.Find(id).MoDangKyHoc;

            _context.KyHocs.ToList().ForEach(x => x.MoDangKyHoc = false);
            _context.SaveChanges();

            _context.KyHocs.Find(id).MoDangKyHoc = !trangthai;
            _context.SaveChanges();

            return RedirectToAction("HienThiSP");
        }
    }
}
