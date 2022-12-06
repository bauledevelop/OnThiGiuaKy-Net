using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("Stadium")]
    public class Stadium
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(1024)]
        public string Name { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

    }
}
