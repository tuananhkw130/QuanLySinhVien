using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using doan.Utilities;

namespace doan.Models
{

    [Table("LopHocPhan")]
    public class LopHocPhan
    {
        private readonly DataContext _context;
        public LopHocPhan(DataContext context)
        {
            _context = context;
        }
        [Key]
        public int ID { get; set; }
        public string? TenLopHP { get; set; }
        public int? SoSVDuKien { get; set; }
        public int? IDMaHocPhan { get; set; }
        public bool DaDangKyHoc()
        {
            var dangkyhoc = _context.SinhVien_LopHPs.Where(x => x.IDSinhVien == Functions._UserID && x.IDLopHP == this.ID).FirstOrDefault();
            if (dangkyhoc == null)
            {
                return false;
            }

            return true;
        }

        public int SoSVChinhThuc()
        {
            return _context.SinhVien_LopHPs.Where(x => x.IDLopHP == this.ID).Count();
        }
       
    }

}