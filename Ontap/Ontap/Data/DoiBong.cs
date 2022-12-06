using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("DoiBong")]
    public class DoiBong
    {
        [Key]
        public int MaDoiBong { get; set; }
        [Display(Name = "Tên Đội Bóng")]
        public string TenDoiBong { get; set; }
        public ICollection<CauThu>? CauThu { get; set; }
    }
}
