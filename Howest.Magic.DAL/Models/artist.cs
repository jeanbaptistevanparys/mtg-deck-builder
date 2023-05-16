using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Howest.MagicCards.DAL.Models
{
    public partial class artist
    {
        public artist()
        {
            cards = new HashSet<card>();
        }

        [Key]
        public long id { get; set; }
        [Required]
        [StringLength(255)]
        public string full_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updated_at { get; set; }

        [InverseProperty(nameof(card.artist))]
        public virtual ICollection<card> cards { get; set; }
    }
}
