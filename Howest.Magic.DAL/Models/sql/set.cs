#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Models.sql
{
    [Index(nameof(code), Name = "sets_code_unique", IsUnique = true)]
    public partial class set
    {
        public set()
        {
            cards = new HashSet<card>();
        }

        [Key]
        public long id { get; set; }
        [Required]
        [StringLength(255)]
        public string code { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updated_at { get; set; }

        public virtual ICollection<card> cards { get; set; }
    }
}
