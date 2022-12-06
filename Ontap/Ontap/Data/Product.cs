using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }

        
        
    }
}
