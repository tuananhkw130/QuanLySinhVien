using Microsoft.EntityFrameworkCore;
using doan.Areas.Admin.Models;
using doan.Models;

namespace doan.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<QuanTriVien> QuanTriViens { get; set; }
        public DbSet<KhoaVien> KhoaViens { get; set; }
        public DbSet<KyHoc> KyHocs { get; set; }
        public DbSet<DanhMucDiem> DanhMucDiems { get; set; }
        public DbSet<MaHocPhan> MaHocPhans { get; set; }
        public DbSet<DMDiemHocPhan> DMDiemHocPhans { get; set; }
        public DbSet<LopHocPhan> LopHocPhans { get; set; }
        public DbSet<SinhVien_LopHP> SinhVien_LopHPs { get; set; }

    }
}
