using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using doan.Models;
using doan.Utilities;

namespace doan.Areas.API.Controllers
{
    [Area("API")]
    public class HocPhanController : Controller
    {
        private readonly DataContext _context;
        public HocPhanController(DataContext context)
        {
            _context = context;
        }
        public JsonResult DSMaHocPhan(int IDKyHoc)
        {
            var kyhoc = _context.KyHocs.Find(IDKyHoc);
            if (kyhoc == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Học kỳ không tồn tại",
                });
            }
            var dsMaHP = _context.MaHocPhans
                            .Where(x => x.IDHocKy == kyhoc.ID)
                            .Join(_context.KhoaViens, x => x.IDKhoaVien, y => y.ID, (x, y) => new
                            {
                                ID = x.ID,
                                MaHP = x.MaHP,
                                TenHP = x.TenHP,
                                PhienBan = x.PhienBan,
                                TenKhoaVien = y.TenKhoaVien,
                                MaKhoaVien = y.MaKhoaVien
                            }).ToList();

            return Json(new
            {
                success = true,
                data = dsMaHP
            });
        }

        public JsonResult DSLopHP(int IDMaHP)
        {
            var dsLopHP = _context.LopHocPhans.Where(x => x.IDMaHocPhan == IDMaHP)
                            .Select(x => new
                            {
                                ID = x.ID,
                                TenHP = x.TenLopHP,
                                DSSinhVien = _context.SinhVien_LopHPs.Where(db => db.IDLopHP == x.ID)
                                            .Join(_context.SinhViens, a => a.IDSinhVien, b => b.ID, (a, b) => new
                                            {
                                                b.MSV
                                            }).Select(x => x.MSV).ToArray()
                            });

            return Json(new
            {
                success = true,
                data = dsLopHP
            });
        }

        public JsonResult DSDiem(int IDMaHP)
        {
            var dsDiem = _context.DMDiemHocPhans.Where(x => x.IDMaHocPhan == IDMaHP)
                         .Join(_context.DanhMucDiems, a => a.IDDanhMucDiem, b => b.ID, (a, b) => new
                         {
                             TenDanhMuc = b.TenDanhMuc,
                             Code = b.Shortname
                         }).ToList();

            return Json(new
            {
                success = true,
                data = dsDiem
            });
        }
    }
}
