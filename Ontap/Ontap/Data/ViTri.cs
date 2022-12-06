using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Ontap.Data
{
    [Table("ViTri")]
    public class ViTri
    {
        [Key]
        public int MaViTri { get; set; }
        [Display(Name = "Tên Vị Trí")]
        [Required]
        public string TenViTri { get; set; }
    }
}
