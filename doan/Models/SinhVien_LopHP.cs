using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("SinhVien_LopHP")]
    public class SinhVien_LopHP
    {
        [Key]
        public int ID { get; set; }
        public int IDSinhVien { get; set; }
        public int IDLopHP { get; set; }

    }

}