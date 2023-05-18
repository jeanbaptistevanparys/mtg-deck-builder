#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Howest.MagicCards.DAL.Models.sql
{
    public partial class card
    {
        public card()
        {
            card_colors = new HashSet<card_color>();
            card_types = new HashSet<card_type>();
        }

        [Key]
        public long id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        public string mana_cost { get; set; }
        [Required]
        [StringLength(255)]
        public string converted_mana_cost { get; set; }
        [Required]
        [StringLength(255)]
        public string type { get; set; }
        [StringLength(255)]
        public string rarity_code { get; set; }
        [Required]
        [StringLength(255)]
        public string set_code { get; set; }
        public string text { get; set; }
        public string flavor { get; set; }
        public long? artist_id { get; set; }
        [Required]
        [StringLength(255)]
        public string number { get; set; }
        [StringLength(255)]
        public string power { get; set; }
        [StringLength(255)]
        public string toughness { get; set; }
        [Required]
        [StringLength(255)]
        public string layout { get; set; }
        public int? multiverse_id { get; set; }
        [StringLength(255)]
        public string original_image_url { get; set; }
        [Required]
        [StringLength(255)]
        public string image { get; set; }
        public string original_text { get; set; }
        [StringLength(255)]
        public string original_type { get; set; }
        [Required]
        [StringLength(255)]
        public string mtg_id { get; set; }
        public string variations { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updated_at { get; set; }

        [ForeignKey(nameof(artist_id))]
        [InverseProperty("cards")]
        public virtual artist artist { get; set; }
        public virtual rarity rarity_codeNavigation { get; set; }
        public virtual set set_codeNavigation { get; set; }
        [InverseProperty(nameof(card_color.card))]
        public virtual ICollection<card_color> card_colors { get; set; }
        [InverseProperty(nameof(card_type.card))]
        public virtual ICollection<card_type> card_types { get; set; }
    }
}
