using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using doan.Models;
using doan.Utilities;

namespace doan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (Functions._UserID == 0)
            {
                return RedirectToAction("DangNhap");
            }

            var hockymodangky = _context.KyHocs.Where(db => db.MoDangKyHoc).FirstOrDefault();
            if (hockymodangky == null)
            {
                return RedirectToAction("Error");
            }
            int idhocky = hockymodangky.ID;
            ViewBag.TenHocKyDangKy = _context.KyHocs.Find(idhocky).KyHocStr();

            var dsmahp = _context.MaHocPhans.Where(mhp => mhp.IDHocKy == idhocky).ToList();

            return View(dsmahp);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(SinhVien sv)
        {
            var checksv = _context.SinhViens.Where(x => x.MSV == sv.MSV && x.MatKhau == sv.MatKhau).FirstOrDefault();
            if (checksv == null)
            {
                TempData["msg"] = "Thông tin tài khoản hoặc mật khẩu không đúng";
                return View();
            }

            Functions._UserID = checksv.ID;
            Functions._UserName = checksv.HoTen;

            return RedirectToAction("Index");
        }

        public IActionResult DangXuat()
        {
            Functions._UserID = 0;
            Functions._UserName = String.Empty;

            return RedirectToAction("DangNhap");
        }

        public IActionResult CapNhatDangKyHoc(int[] CheckboxLopHP)
        {
            if (Functions._UserID == 0)
            {
                return RedirectToAction("DangNhap");
            }

            var hockymodangky = _context.KyHocs.Where(db => db.MoDangKyHoc).FirstOrDefault();
            if (hockymodangky == null)
            {
                return RedirectToAction("Error");
            }
            int idhocky = hockymodangky.ID;

            var dsmahp = _context.MaHocPhans.Where(mhp => mhp.IDHocKy == idhocky)
                        .Join(_context.LopHocPhans, a => a.ID, b => b.IDMaHocPhan, (a, b) => new
                        {
                            ID = b.ID
                        })
                        .ToList();

            foreach (var item in dsmahp)
            {
                var dslopdadangky = _context.SinhVien_LopHPs.Where(x => x.IDSinhVien == Functions._UserID && x.IDLopHP == item.ID).FirstOrDefault();
                if (dslopdadangky == null)
                {
                    continue;
                }

                _context.SinhVien_LopHPs.Remove(dslopdadangky);
                _context.SaveChanges();
            }

            foreach (var x in CheckboxLopHP)
            {
                var sv_lophp = new SinhVien_LopHP();
                sv_lophp.IDSinhVien = Functions._UserID;
                sv_lophp.IDLopHP = x;
                _context.SinhVien_LopHPs.Add(sv_lophp);
                _context.SaveChanges();
            }

            TempData["msg"] = "Cập nhật thành công";
            return RedirectToAction("Index");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}