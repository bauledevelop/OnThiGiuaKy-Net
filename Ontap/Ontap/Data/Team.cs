using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public long ID { set; get; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(1024)]
        public string Name { set; get; }
        public ICollection<Player> Players { get; set; }
    }
}
