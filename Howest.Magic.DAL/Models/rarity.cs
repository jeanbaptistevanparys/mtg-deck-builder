using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Howest.MagicCards.DAL.Models
{
    [Index(nameof(code), Name = "rarities_code_unique", IsUnique = true)]
    public partial class rarity
    {
        public rarity()
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
