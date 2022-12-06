using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("Matche")]
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { set; get; }
        public long First { set; get; }
        public long Last { set; get; }
        public long IDStadium { set; get; }

        [ForeignKey("IDStadium")]
        public virtual Stadium Stadium { set; get; }
        
    }
}
