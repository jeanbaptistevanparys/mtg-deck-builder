#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Howest.MagicCards.DAL.Models.sql
{
    public partial class migration
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column("migration")]
        [StringLength(255)]
        public string migration1 { get; set; }
        public int batch { get; set; }
    }
}
