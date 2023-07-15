using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("MaHocPhan")]
    public class MaHocPhan
    {
        private readonly DataContext _context;
        public MaHocPhan(DataContext context)
        {
            _context = context;
        }

        [Key]
        public int ID { get; set; }
        public string? MaHP { get; set; }
        public string? TenHP { get; set; }
        public int? PhienBan { get; set; }
        public int? IDKhoaVien { get; set; }
        public int? IDHocKy { get; set; }
        public string KhoaVienStr()
        {
            return _context.KhoaViens.Find(this.IDKhoaVien).TenKhoaVien ?? "";
        }

        public string KyHocStr()
        {
            return _context.KyHocs.Find(this.IDHocKy).KyHocStr();
        }

        public string DSDMDiem()
        {
            string result = "";
            var dmDiem = _context.DMDiemHocPhans.Where(db => db.IDMaHocPhan == this.ID).ToList();
            foreach (var item in dmDiem)
            {
                result += _context.DanhMucDiems.Find(item.IDDanhMucDiem).TenDanhMuc + ", ";
            }

            return result.TrimEnd(' ').TrimEnd(',');
        }

        public int SoLop()
        {
            return _context.LopHocPhans.Where(db => db.IDMaHocPhan == this.ID).Count();
        }

        public IList<LopHocPhan> DSLopHP()
        {
            return _context.LopHocPhans.Where(lhp => lhp.IDMaHocPhan == this.ID).ToList();
        }
    }

}