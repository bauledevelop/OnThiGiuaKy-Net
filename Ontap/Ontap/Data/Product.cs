using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { set; get; }
        public string Name { set; get; }

        
        
    }
}
