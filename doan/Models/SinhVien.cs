using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public int ID { get; set; }
        public string? MSV { get; set; }
        public string? MatKhau { get; set; }
        public string? HoTen { get; set; }

    }

}