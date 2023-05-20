#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Models.sql;

[Index(nameof(card_id), nameof(type_id), Name = "card_types_card_id_type_id_unique", IsUnique = true)]
public class card_type
{
    [Key] public long card_id { get; set; }

    [Key] public long type_id { get; set; }

    [Column(TypeName = "datetime")] public DateTime? created_at { get; set; }

    [Column(TypeName = "datetime")] public DateTime? updated_at { get; set; }

    [ForeignKey(nameof(card_id))]
    [InverseProperty("card_types")]
    public virtual card card { get; set; }

    [ForeignKey(nameof(type_id))]
    [InverseProperty("card_types")]
    public virtual type type { get; set; }
}