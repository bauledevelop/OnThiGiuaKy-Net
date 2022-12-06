using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("SanVanDong")]
    public class SanVanDong
    {
        [Key]
        public int MaSan { get; set; }
        [Display(Name = "Tên Sân Vận Động")]
        public string TenSan { get; set; }
    }
}
