using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Howest.MagicCards.DAL.Models
{
    public partial class type
    {
        public type()
        {
            card_types = new HashSet<card_type>();
        }

        [Key]
        public long id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        [Required]
        [Column("type")]
        [StringLength(255)]
        public string type1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? created_at { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updated_at { get; set; }

        [InverseProperty(nameof(card_type.type))]
        public virtual ICollection<card_type> card_types { get; set; }
    }
}
