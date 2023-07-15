using doan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LopHocPhanController : Controller
    {
        private readonly DataContext _context;
        public LopHocPhanController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP(int idhocphan)
        {
            var sp =_context.LopHocPhans.Where(db => db.IDMaHocPhan == idhocphan).ToList();
            ViewBag.idhocphan = idhocphan;

            ViewBag.kyhoc = _context.MaHocPhans.Find(idhocphan).IDHocKy;

            return View(sp);
        }

        public IActionResult HienThiSVDangKy(int id)
        {
            var sv = _context.SinhVien_LopHPs.Join(_context.SinhViens, x => x.IDSinhVien, y => y.ID, (x, y) => new
                        {
                            HoTen = y.HoTen,
                            MSV = y.MSV,
                            IDLopHP = x.IDLopHP
                        }).Where(x => x.IDLopHP == id).ToList();

            ViewBag.TenLopHP = _context.LopHocPhans.Find(id).TenLopHP;
            ViewBag.sv = sv;
            ViewBag.IDLopHP = _context.LopHocPhans.Find(id).IDMaHocPhan;

            return View();
        }
        public IActionResult Them(int idhocphan)
        {
            ViewBag.idhocphan = idhocphan;
            return View();
        }
        [HttpPost]
        public IActionResult Them(string TenLopHP, int SoSVDuKien, int IDMaHocPhan)
        {
            var checkUniqueTenLopHP = _context.LopHocPhans.Where(x => x.TenLopHP == TenLopHP).FirstOrDefault();
            if (checkUniqueTenLopHP != null)
            {
                TempData["msgtrunglop"] = "Trùng tên lớp";
                return View();
            }

            var lhp = new LopHocPhan(_context);
            lhp.TenLopHP = TenLopHP;
            lhp.SoSVDuKien = SoSVDuKien;
            lhp.IDMaHocPhan = IDMaHocPhan;
            _context.LopHocPhans.Add(lhp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP", new { idhocphan = lhp.IDMaHocPhan });
        }
    }
}
