using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("CauThu")]
    public class CauThu
    {
        [Key]
        public int MaCauThu { get; set; }
        [Display(Name = "Tên Câu Thủ")]
        public string TenCauThu { get; set; }
        [Display(Name = "Số Áo")]
        public int Soao { get; set; }
        public int MaViTri { get; set; }
        [ForeignKey("MaViTri")]
        public ViTri? ViTri { get; set; }
        public int MaDoiBong { get; set; }
        [ForeignKey("MaDoiBong")]
        public DoiBong? DoiBong { get; set; }
    }
}
