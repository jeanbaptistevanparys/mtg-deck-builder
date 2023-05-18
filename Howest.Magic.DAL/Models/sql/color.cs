#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Howest.MagicCards.DAL.Models.sql
{
    public partial class color
    {
        public color()
        {
            card_colors = new HashSet<card_color>();
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

        [InverseProperty(nameof(card_color.color))]
        public virtual ICollection<card_color> card_colors { get; set; }
    }
}
