using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("DanhMucDiem")]
    public class DanhMucDiem
    {
        [Key]
        public int ID { get; set; }
        public string? TenDanhMuc { get; set; }
        public string? Shortname { get; set; }
        
    }

}