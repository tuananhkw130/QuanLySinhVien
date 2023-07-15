using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("QuanTriVien")]
    public class QuanTriVien
    {
        [Key]
        public int ID { get; set; }
        public string? HoTen { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
    }

}