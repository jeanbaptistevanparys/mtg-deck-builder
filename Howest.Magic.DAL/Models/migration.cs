using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Howest.MagicCards.DAL.Models
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
