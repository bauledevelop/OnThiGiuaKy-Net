using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ontap.Data
{
    [Table("TranDau")]
    public class TranDau
    {
        [Key]
        public int MaTranDau { get; set; }
        public int MaDoiBong1 { get; set; }
        [ForeignKey("MaDoiBong1")]
        public DoiBong? DoiBong1 { get; set; }
        public int MaDoiBong2 { get; set; }
        [ForeignKey("MaDoiBong2")]
        public DoiBong? DoiBong2 { get; set; }
        public int MaSan { get; set; }
        [ForeignKey("MaSan")]
        public SanVanDong? SanVanDong { get; set; }
    }
}
