using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("KhoaVien")]
    public class KhoaVien
    {
        [Key]
        public int ID { get; set; }
        public string? MaKhoaVien { get; set; }
        public string? TenKhoaVien { get; set; }      
            
    }

}