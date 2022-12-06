using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public long ID { set; get; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(1024)]
        public string Name { set; get; }
        public int Type { set; get; }
        public int Number { set; get; }
        public long IDTeam { set; get; }
      
        [ForeignKey("IDTeam")]
        public long TeamID { get; set; }
        public Team Team { get; set; }
    }
}
