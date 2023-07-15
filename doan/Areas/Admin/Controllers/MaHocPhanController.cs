using doan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaHocPhanController : Controller
    {
        private readonly DataContext _context;
        public MaHocPhanController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP(int kyhoc = 0)
        {
            if (kyhoc == 0)
            {
                kyhoc = _context.KyHocs.OrderByDescending(x => x.ID).First().ID;
            }
            var sp =_context.MaHocPhans.Where(db => db.IDHocKy == kyhoc).ToList();

            ViewBag.kyhocstr = _context.KyHocs.Find(kyhoc).KyHocStr();
            ViewBag.kyhoc = kyhoc;

            return View(sp);
        }
        public IActionResult Them(int kyhoc)
        {
            var khoavien = (from m in _context.KhoaViens
                          select new SelectListItem()
                          {
                              Text = m.TenKhoaVien,
                              Value = m.ID.ToString()
                          }).ToList();
            khoavien.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.khoavien = khoavien;

            ViewBag.kyhoc = kyhoc;

            ViewBag.DSDMDiem = _context.DanhMucDiems.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Them(string MaHP, string TenHP, int PhienBan, int IDKhoaVien, int IDHocKy, int[] DSDMDiem)
        {
            MaHocPhan mahocphan = new MaHocPhan(_context);
            mahocphan.MaHP = MaHP;
            mahocphan.TenHP = TenHP;
            mahocphan.PhienBan = PhienBan;
            mahocphan.IDKhoaVien = IDKhoaVien;
            mahocphan.IDHocKy = IDHocKy;

            _context.MaHocPhans.Add(mahocphan);
            _context.SaveChanges();

            foreach (var item in DSDMDiem)
            {
                var dmdiemhp = new DMDiemHocPhan();
                dmdiemhp.IDMaHocPhan = mahocphan.ID;
                dmdiemhp.IDDanhMucDiem = item;
                _context.DMDiemHocPhans.Add(dmdiemhp);
                _context.SaveChanges();
            }

            return RedirectToAction("HienThiSP");
        }
    }
}
