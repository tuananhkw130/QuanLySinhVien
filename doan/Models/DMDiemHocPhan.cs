using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("DMDiemHocPhan")]
    public class DMDiemHocPhan
    {
        [Key]
        public int ID { get; set; }
        public int? IDDanhMucDiem { get; set; }
        public int? IDMaHocPhan { get; set; }

    }

}