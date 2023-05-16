using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Howest.MagicCards.DAL.Models
{
    [Index(nameof(card_id), nameof(color_id), Name = "card_colors_card_id_color_id_unique", IsUnique = true)]
    public partial class card_color
    {
        [Key]
        public long card_id { get; set; }
        [Key]
        public long color_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updated_at { get; set; }

        [ForeignKey(nameof(card_id))]
        [InverseProperty("card_colors")]
        public virtual card card { get; set; }
        [ForeignKey(nameof(color_id))]
        [InverseProperty("card_colors")]
        public virtual color color { get; set; }
    }
}
