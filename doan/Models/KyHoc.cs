using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("HocKy")]
    public class KyHoc
    {
        [Key]
        public int ID { get; set; }
        public int NamHoc { get; set; }
        public int HocKy { get; set; }      
        public bool MoDangKyHoc { get; set; }

        public string NamHocStr()
        {
            return "Năm " + this.NamHoc.ToString() + "-" + (this.NamHoc + 1).ToString();
        }

        public string HocKyStr()
        {
            switch (this.HocKy)
            {
                case 1: return "Học kỳ 1";
                case 2: return "Học kỳ 2";
                case 3: return "Học kỳ hè";
                default: return "Học kỳ không tồn tại";
            }
        }

        public string KyHocStr()
        {
            return this.HocKyStr() + " - " + this.NamHocStr();
        }
            
    }

}