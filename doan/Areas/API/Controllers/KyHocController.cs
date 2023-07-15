using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using doan.Models;
using doan.Utilities;

namespace doan.Areas.API.Controllers
{
    [Area("API")]
    public class KyHocController : Controller
    {
        private readonly DataContext _context;
        public KyHocController(DataContext context)
        {
            _context = context;
        }
        public JsonResult DSKyHoc()
        {
            var dsKyHoc = _context.KyHocs.OrderByDescending(x => x.ID).Select(i => 
            new {
                ID = i.ID,
                HocKy = i.KyHocStr()
            }).ToList();

            return Json(new
            {
                success = true,
                data = dsKyHoc
            });
        }

        public JsonResult ThongTinHocKy(int id)
        {
            var kyhoc = _context.KyHocs.Find(id);

            return Json(new
            {
                success = true,
                data = kyhoc
            });
        }
    }
}
